Shader"Custom/UIRoundEdgeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _EdgeRadius ("Edge Radius", Range(0, 50)) = 10
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
Lighting Off

ZWrite Off

Blend SrcAlphaOneMinusSrcAlpha

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
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
};

float _EdgeRadius;

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}

sampler2D _MainTex;

fixed4 frag(v2f i) : SV_Target
{
    float2 uv = i.uv;
    float2 center = float2(0.5, 0.5);
    float dist = length(uv - center);
    float alpha = smoothstep(0.5 - _EdgeRadius, 0.5 + _EdgeRadius, dist);
    return tex2D(_MainTex, uv) * alpha;
}
            ENDCG
        }
    }
}
