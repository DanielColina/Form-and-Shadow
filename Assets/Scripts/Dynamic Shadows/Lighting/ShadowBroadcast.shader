// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'PositionFog()' with transforming position into clip space.
// Upgrade NOTE: replaced 'V2F_POS_FOG' with 'float4 pos : SV_POSITION'

// Shader " Vertex Colored" {
//  Properties {
//     _Color ("Main Color", Color) = (1,1,1,1)
//     _MainTex ("Base (RGB)", 2D) = "white" {}
// }
// SubShader {
//     Tags { "RenderType"="Opaque" }
//     LOD 200
// 
// CGPROGRAM
// #pragma surface surf Lambert
// 
// sampler2D _MainTex;
// fixed4 _Color;
// 
// struct Input {
//     float2 uv_MainTex;
//     float4 color : COLOR;
// };
// 
// void surf (Input IN, inout SurfaceOutput o) {
//     fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
//     o.Albedo = c.rgb;
//     o.Albedo *= IN.color.rgb;
//     o.Alpha = c.a;
// }
// ENDCG
// }
// Fallback "VertexLit"
// }

Shader "Custom/TransparentShadowCollector"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _ShadowIntensity ("Shadow Intensity", Range (0, 1)) = 0.6
    }
    SubShader
    {
        Tags {"RenderType"="AlphaTest" }
        Pass
        {
            Tags {"LightMode" = "ForwardBase" }

            Blend SrcAlpha OneMinusSrcAlpha
            //Lighting On
            Cull Back
            ZWrite On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            uniform fixed4  _Color;
            uniform float _ShadowIntensity;
            struct v2f
            {
                float4 pos : SV_POSITION;
                LIGHTING_COORDS(0,1)
            };
            v2f vert(appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos (v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o);
             
                return o;
            }
            fixed4 frag(v2f i) : COLOR
            {
                float attenuation = LIGHT_ATTENUATION(i);
                return fixed4(0,0,0,(1-attenuation)*_ShadowIntensity) * _Color;
            }
            ENDCG
        }
    }
    Fallback "Standard"
}