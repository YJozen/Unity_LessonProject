Shader "Custom/CullFront"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            ZWrite Off
            Cull Front
            Blend Zero One
        }
    }
}