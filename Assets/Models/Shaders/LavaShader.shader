Shader "Custom/LavaShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Speed ("Animation Speed", Float) = 1.0
        _FrameCount ("Frame Count", Float) = 20.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Speed;
            float _FrameCount;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Calculate the frame number based on time and speed
                float totalFrames = _FrameCount * 2 - 2; // Forward and backward frame count
                float time = frac(_Time.y * _Speed / totalFrames) * totalFrames;

                // Convert continuous time to discrete frame number
                int frameInt = floor(time + 0.5); // Round to nearest frame

                // Ping-pong logic to reverse the direction
                float frame;
                if (frameInt > _FrameCount - 1)
                {
                    frame = totalFrames - frameInt;
                }
                else
                {
                    frame = frameInt;
                }

                float yOffset = frame / _FrameCount;
                uv.y = uv.y + yOffset - floor(uv.y + yOffset);
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
