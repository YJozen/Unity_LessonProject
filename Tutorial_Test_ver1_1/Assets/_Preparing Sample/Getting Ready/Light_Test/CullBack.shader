Shader "Custom/CullBack"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            ZWrite Off
            Cull Back
            Blend Zero One
        }
    }
}