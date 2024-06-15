Shader "Hidden/Vignette"
{
    Properties
    {
        _MainTex ("texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv: TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return 0;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D (_MainTex, i.uv);
                float intensity = abs(_SinTime.w * distance (i.uv.xy, float2 (0.5,0.5)));
                col = float4(col.x + intensity, col.y - intensity, col.z - intensity, col.w);
                return col;
            }
            ENDCG
        }
     }   
}
