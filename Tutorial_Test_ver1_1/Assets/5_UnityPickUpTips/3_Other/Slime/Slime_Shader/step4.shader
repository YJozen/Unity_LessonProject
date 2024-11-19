Shader "Slime/Step4"//�������炩�Ɍq����
{
    Properties {}
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent" // ���߂ł���悤�ɂ���
        }

        Pass
        {
            ZWrite On // �[�x����������
            Blend SrcAlpha OneMinusSrcAlpha // ���߂ł���悤�ɂ���

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // ���̓f�[�^�p�̍\����
            struct input
            {
                float4 vertex : POSITION; // ���_���W
            };

            // vert�Ōv�Z����frag�ɓn���p�̍\����
            struct v2f
            {
                float4 pos : POSITION1; // �s�N�Z�����[���h���W
                float4 vertex : SV_POSITION; // ���_���W
            };

            // �o�̓f�[�^�p�̍\����
            struct output
            {
                float4 col: SV_Target; // �s�N�Z���F
                float depth : SV_Depth; // �[�x
            };






            // ���� -> v2f
            v2f vert(const input v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.pos = mul(unity_ObjectToWorld, v.vertex); // ���[�J�����W�����[���h���W�ɕϊ�
                return o;
            }

            // ���̋����֐�
            float4 sphereDistanceFunction(float4 sphere, float3 pos)
            {
                return length(sphere.xyz - pos) - sphere.w;
            }

            // �[�x�v�Z
            inline float getDepth(float3 pos)
            {
                const float4 vpPos = mul(UNITY_MATRIX_VP, float4(pos, 1.0));

                float z = vpPos.z / vpPos.w;
                #if defined(SHADER_API_GLCORE) || \
                    defined(SHADER_API_OPENGL) || \
                    defined(SHADER_API_GLES) || \
                    defined(SHADER_API_GLES3)
                return z * 0.5 + 0.5;
                #else
                return z;
                #endif
            }

            #define MAX_SPHERE_COUNT 256 // �ő�̋��̌�
            float4 _Spheres[MAX_SPHERE_COUNT]; // ���̍��W�E���a���i�[�����z��
            int _SphereCount; // �������鋅�̌�

            // smooth min�֐�
            float smoothMin(float x1, float x2, float k)
            {
                return -log(exp(-k * x1) + exp(-k * x2)) / k;//
            }

            // �S�Ă̋��Ƃ̍ŒZ������Ԃ�
            float getDistance(float3 pos)
            {
                float dist = 100000;
                for (int i = 0; i < _SphereCount; i++)
                {
                    dist = smoothMin(dist, sphereDistanceFunction(_Spheres[i], pos), 3);//���炩�ɕ`�悷�邽��
                }
                return dist;
            }

            // v2f -> �o��
            output frag(const v2f i)
            {
                output o;

                float3 pos = i.pos.xyz; // ���C�̍��W�i�s�N�Z���̃��[���h���W�ŏ������j
                const float3 rayDir = normalize(pos.xyz - _WorldSpaceCameraPos); // ���C�̐i�s����


                //���̒[���ꕔ�����ɂȂ��Ă��܂���������܂���B����͕`��̑ΏۂƂȂ�`��̖ʂ����C�ƕ��s�ɋ߂��Ƃ��ɔ������܂��B���炩�Ɍq�������Ƃɂ���Ă��̂悤�Ȗʂ������Ă��܂����悤�ł��B
                //��������ɂ́A���C�}�[�`���O�̃X�e�b�v�����グ�邩�i����p�Ƃ��ē��삪�d���Ȃ�܂��j�A�h��Ԃ���臒l���グ�܂��i����p�Ƃ��Đ[�x��@���̕i����������܂��j�B
                //�X�e�b�v����30����40�ɁA臒l��0.001����0.01�ɏグ��ƁA�ȉ��̂悤�ɂȂ�܂����B
                for (int i = 0; i < 40; i++)
                {
                    // pos�Ƌ��Ƃ̍ŒZ����
                    float dist = getDistance(pos);

                    // ������0.01�ȉ��ɂȂ�����A�F�Ɛ[�x����������ŏ����I��
                    if (dist < 0.01)
                    {
                        o.col = fixed4(0, 1, 0, 0.5); // �h��Ԃ�
                        o.depth = getDepth(pos); // �[�x��������
                        return o;
                    }

                    // ���C�̕����ɍs�i
                    pos += dist * rayDir;
                }

                // �Փ˔��肪�Ȃ������瓧���ɂ���
                o.col = 0;
                o.depth = 0;
                return o;
            }
            ENDCG
        }
    }
}