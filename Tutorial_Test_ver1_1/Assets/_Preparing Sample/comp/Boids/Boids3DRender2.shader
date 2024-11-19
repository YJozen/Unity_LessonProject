Shader "Custom/Boids3DRender2"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BoidScale ("Boid Scale", Vector) = (1,1,1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        Cull Off

        CGPROGRAM
        #pragma surface surf Standard vertex:vert addshadow
        #pragma instancing_options procedural:setup
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _Color;
        float3 _BoidScale;

        struct BoidData
        {
            float3 velocity;
            float3 position;
        };

        #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
        StructuredBuffer<BoidData> _BoidDataBuffer;
        #endif

        float4x4 radianToRotationMatrix(float3 angles)
        {
            float cy = cos(angles.y); float sy = sin(angles.y);
            float cx = cos(angles.x); float sx = sin(angles.x);
            float cz = cos(angles.z); float sz = sin(angles.z);
            return float4x4(
                cy * cz + sy * sx * sz, -cy * sz + sy * sx * cz, sy * cx, 0,
                cx * sz, cx * cz, -sx, 0,
                -sy * cz + cy * sx * sz, sy * sz + cy * sx * cz, cy * cx, 0,
                0, 0, 0, 1
            );
        }

        void setup()
        {
        }

        void vert(inout appdata_full v)
        {
            #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
            BoidData boidData = _BoidDataBuffer[unity_InstanceID];
            float3 boidPosition = boidData.position.xyz;
            float3 boidScale = _BoidScale;

            float4x4 object2world = float4x4(
                boidScale.x, 0, 0, 0,
                0, boidScale.y, 0, 0,
                0, 0, boidScale.z, 0,
                boidPosition.x, boidPosition.y, boidPosition.z, 1
            );

            float rotX = -asin(boidData.velocity.y / (length(boidData.velocity.xyz) + 1e-8));
            float rotY = atan2(boidData.velocity.x, boidData.velocity.z);
            float4x4 rotMatrix = radianToRotationMatrix(float3(rotX, rotY, 0));
            object2world = mul(rotMatrix, object2world);

            v.vertex = mul(unity_ObjectToWorld, mul(object2world, v.vertex));
            v.normal = normalize(mul(unity_ObjectToWorld, mul(object2world, v.normal)));
            #endif
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            clip(c.a - 0.1);
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
