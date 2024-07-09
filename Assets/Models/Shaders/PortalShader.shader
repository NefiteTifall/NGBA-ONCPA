Shader "Custom/PortalShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Speed ("Animation Speed", Float) = 1.0
        _FrameCount ("Frame Count", Float) = 20.0
        _TextureTotalHeight ("Total Texture Height", Float) = 256.0
        _TextureHeight ("Texture Height", Float) = 16.0
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
            float _TextureTotalHeight;
            float _TextureHeight;

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
                float time = _Time.y * _Speed;
                int frameInt = (int)floor(time) % (int)_FrameCount;

                // Calculate the offset in units of _TextureHeight pixels
                float yOffset = frameInt * (_TextureHeight / _TextureTotalHeight);
                uv.y = uv.y + yOffset - floor(uv.y + yOffset);

                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
