// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Legacy Shaders/ColouredShadow" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 200

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;

struct Input {
    float2 uv_MainTex;
};

half4 LightingCSLambert(SurfaceOutput s, half3 lightDir, half atten)
{
	fixed diff = max(0, dot(s.Normal, lightDir));

	fixed4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten * 2);

	//shadow colorization
	c.rgb += _ShadowColor.xyz * max(0.0, (1.0 - (diff * atten * 2))) * _DiffuseVal;
	c.a = s.Alpha;
	return c;
}

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    o.Albedo = c.rgb;
    o.Alpha = c.a;
}
ENDCG
}

Fallback "Legacy Shaders/VertexLit"
}
