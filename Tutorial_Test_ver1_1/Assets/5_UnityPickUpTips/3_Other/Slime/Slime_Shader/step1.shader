Shader "Slime/Step1"//レイマーチングで球を表示する
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
                float4 pos : POSITION1;      // ピクセルワールド座標 3D空間の座標
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
                o.vertex = UnityObjectToClipPos(v.vertex);  //モデル座標　頂点座標　を　クリップ座標に変換
                o.pos = mul(unity_ObjectToWorld, v.vertex); //モデル座標　頂点座標 ローカル座標をワールド座標に変換
                return o;
            }



            // 球の距離関数
            float4 sphereDistanceFunction(float4 sphere, float3 pos)
            {
                return length(sphere.xyz - pos) - sphere.w;//球の位置　- 3D空間での座標     -　 半径
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


            //とりあえず、球情報は　　座標(0, 0, 0)に半径0.5の球
            //レイ判定の距離によって表示を変える
            // v2f -> 出力
            output frag(const v2f i)
            {
                output o;

                float3 pos = i.pos.xyz; // レイの座標（ピクセルのワールド座標で初期化）　　3D空間での座標を保持
                const float3 rayDir = normalize(pos.xyz - _WorldSpaceCameraPos); // レイの進行方向　カメラ位置　から　3D空間での座標　までのベクトル　

                float4 sphere = float4(0, 0, 0, 0.5); // 球の座標と半径　float4型で球情報保持


                //ループ回数の30はステップ数です。レイマーチングでは、文字通りレイを行進させて物体との衝突を確認していくわけですが、最大何回レイを行進させるかというのがこの数字になります。
                for (int i = 0; i < 30; i++)
                {
                    // posと球との最短距離
                    float dist = sphereDistanceFunction(sphere, pos);//（球の位置　と　3D空間での座標　の　差）　- 半径　 

                    //条件式内の0.001という数字は閾値で、レイの位置と球の表面との距離がこの値未満になったときにピクセルを塗りつぶします。
                    // 距離が0.001以下になったら、色と深度を書き込んで処理終了
                    if (dist < 0.001)
                    {
                        o.col = fixed4(0, 1, 0, 0.5); // 　この色で　塗りつぶし　
                        o.depth = getDepth(pos); // 3D空間での座標における　　深度書き込み
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