Shader "Slime/Step0"//�V�F�[�_�[�@�X�^�[�g
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
                float4 pos : POSITION1; // �s�N�Z�����[���h���W 3D��ԓ��̃I�u�W�F�N�g�̈ʒu
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
                o.vertex = UnityObjectToClipPos(v.vertex); //���_���W�@�@���f�����W�@�@�@�@�@�@�@�@�@�@�@�@���@���[���h���W�ɕϊ����A���Ɂ@�N���b�v���W�i��Ԃ�؂����ă����_�����O������ԁE�\���͈́j�@�ɕϊ������
                o.pos = mul(unity_ObjectToWorld, v.vertex);//���_���W�@�@���f�����W�@���[�J�����W�@�@�@�@�@���@�i�s�N�Z���j���[���h���W�ɕϊ�

                return o;
            }

            // v2f -> �o��
            output frag(const v2f i)
            {
                output o;
                o.col = fixed4(i.pos.xyz, 0.5);// 3D��Ԃł̍��W�@����i�R���́j�@�F��ݒ�
                o.depth = 1;//�[�x�͂P ��Ԏ�O
                return o;
            }
            ENDCG
        }
    }
}
