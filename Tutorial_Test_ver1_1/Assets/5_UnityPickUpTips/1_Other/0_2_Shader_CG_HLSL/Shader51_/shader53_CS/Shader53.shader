Shader "Custom/shader53"
{
    SubShader 
    {
        Pass
        {
            Tags { "RenderType"="Opaque" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f 
            {
                float4 pos : SV_POSITION;
                half4 color : COLOR0;
            };

            v2f vert(appdata_full v) 
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : COLOR 
            {
                //メッシュから受け取った頂点の色情報をそのまま利用する
                return i.color;
            }
            ENDCG
        }
    }
}
