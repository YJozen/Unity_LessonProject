Shader "Slime/Step4"//球を滑らかに繋げる
{
    Properties {}
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent" // 透過できるようにする
        }

        Pass
        {
            ZWrite On // 深度を書き込む
            Blend SrcAlpha OneMinusSrcAlpha // 透過できるようにする

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // 入力データ用の構造体
            struct input
            {
                float4 vertex : POSITION; // 頂点座標
            };

            // vertで計算してfragに渡す用の構造体
            struct v2f
            {
                float4 pos : POSITION1; // ピクセルワールド座標
                float4 vertex : SV_POSITION; // 頂点座標
            };

            // 出力データ用の構造体
            struct output
            {
                float4 col: SV_Target; // ピクセル色
                float depth : SV_Depth; // 深度
            };






            // 入力 -> v2f
            v2f vert(const input v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.pos = mul(unity_ObjectToWorld, v.vertex); // ローカル座標をワールド座標に変換
                return o;
            }

            // 球の距離関数
            float4 sphereDistanceFunction(float4 sphere, float3 pos)
            {
                return length(sphere.xyz - pos) - sphere.w;
            }

            // 深度計算
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

            #define MAX_SPHERE_COUNT 256 // 最大の球の個数
            float4 _Spheres[MAX_SPHERE_COUNT]; // 球の座標・半径を格納した配列
            int _SphereCount; // 処理する球の個数

            // smooth min関数
            float smoothMin(float x1, float x2, float k)
            {
                return -log(exp(-k * x1) + exp(-k * x2)) / k;//
            }

            // 全ての球との最短距離を返す
            float getDistance(float3 pos)
            {
                float dist = 100000;
                for (int i = 0; i < _SphereCount; i++)
                {
                    dist = smoothMin(dist, sphereDistanceFunction(_Spheres[i], pos), 3);//滑らかに描画するため
                }
                return dist;
            }

            // v2f -> 出力
            output frag(const v2f i)
            {
                output o;

                float3 pos = i.pos.xyz; // レイの座標（ピクセルのワールド座標で初期化）
                const float3 rayDir = normalize(pos.xyz - _WorldSpaceCameraPos); // レイの進行方向


                //球の端が一部透明になってしまうかもしれません。これは描画の対象となる形状の面がレイと平行に近いときに発生します。滑らかに繋げたことによってそのような面が増えてしまったようです。
                //解消するには、レイマーチングのステップ数を上げるか（副作用として動作が重くなります）、塗りつぶしの閾値を上げます（副作用として深度や法線の品質が下がります）。
                //ステップ数を30から40に、閾値を0.001から0.01に上げると、以下のようになりました。
                for (int i = 0; i < 40; i++)
                {
                    // posと球との最短距離
                    float dist = getDistance(pos);

                    // 距離が0.01以下になったら、色と深度を書き込んで処理終了
                    if (dist < 0.01)
                    {
                        o.col = fixed4(0, 1, 0, 0.5); // 塗りつぶし
                        o.depth = getDepth(pos); // 深度書き込み
                        return o;
                    }

                    // レイの方向に行進
                    pos += dist * rayDir;
                }

                // 衝突判定がなかったら透明にする
                o.col = 0;
                o.depth = 0;
                return o;
            }
            ENDCG
        }
    }
}