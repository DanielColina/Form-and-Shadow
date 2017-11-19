// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33561,y:32202,varname:node_4013,prsc:2|diff-1674-OUT,spec-5311-OUT,emission-7917-OUT,transm-1154-R,lwrap-1154-R,voffset-8740-OUT;n:type:ShaderForge.SFN_Subtract,id:1206,x:32178,y:32404,varname:node_1206,prsc:2|A-7182-OUT,B-6519-OUT;n:type:ShaderForge.SFN_Vector1,id:6519,x:31999,y:32486,varname:node_6519,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:1256,x:32350,y:32404,varname:node_1256,prsc:2|IN-1206-OUT;n:type:ShaderForge.SFN_Frac,id:7182,x:31999,y:32352,varname:node_7182,prsc:2|IN-1034-OUT;n:type:ShaderForge.SFN_Panner,id:6490,x:31661,y:32352,varname:node_6490,prsc:2,spu:0,spv:0.25|UVIN-1653-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1034,x:31828,y:32352,varname:node_1034,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-6490-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9634,x:32525,y:32454,cmnt:Triangle Wave,varname:node_9634,prsc:2|A-1256-OUT,B-1171-OUT;n:type:ShaderForge.SFN_Vector1,id:1171,x:32350,y:32540,varname:node_1171,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:1963,x:32729,y:32517,cmnt:Panning gradient,varname:node_1963,prsc:2|VAL-9634-OUT,EXP-4226-OUT;n:type:ShaderForge.SFN_NormalVector,id:1856,x:32956,y:33021,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:8740,x:33183,y:32851,varname:node_8740,prsc:2|A-2726-OUT,B-9567-OUT,C-1856-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9567,x:32956,y:32853,ptovrint:False,ptlb:Bulge Scale,ptin:_BulgeScale,varname:_BulgeScale,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Lerp,id:3276,x:33183,y:32179,varname:node_3276,prsc:2|A-6716-RGB,B-1865-OUT,T-1963-OUT;n:type:ShaderForge.SFN_Tex2d,id:6716,x:32956,y:32013,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cde4ef07ad497c3458ffc810f453020f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7917,x:33183,y:32683,cmnt:Glow,varname:node_7917,prsc:2|A-1154-RGB,B-1600-OUT,C-2726-OUT;n:type:ShaderForge.SFN_Color,id:1154,x:32956,y:32517,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2391481,c3:0.1102941,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:4226,x:32525,y:32601,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_ValueProperty,id:1600,x:32956,y:32685,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_TexCoord,id:1653,x:31498,y:32352,varname:node_1653,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:2726,x:32956,y:32761,varname:node_2726,prsc:2|IN-1963-OUT;n:type:ShaderForge.SFN_Tex2d,id:6737,x:33069,y:32296,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_6737,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7080112e8348ac645ba3efc486d53e6b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:615,x:33129,y:32497,ptovrint:False,ptlb:SpecAdjust,ptin:_SpecAdjust,varname:node_615,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:5311,x:33376,y:32262,varname:node_5311,prsc:2|A-6737-RGB,B-615-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1865,x:32733,y:32100,ptovrint:False,ptlb:DiffAdjust,ptin:_DiffAdjust,varname:node_1865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:1674,x:33376,y:32090,varname:node_1674,prsc:2|A-5832-OUT,B-3276-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5832,x:33208,y:31880,ptovrint:False,ptlb:ColorAdjust,ptin:_ColorAdjust,varname:node_5832,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:6716-4226-1154-1600-9567-6737-615-1865-5832;pass:END;sub:END;*/

Shader "Shader Forge/glowingBulgeShader" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _BulgeShape ("Bulge Shape", Float ) = 5
        _GlowColor ("Glow Color", Color) = (1,0.2391481,0.1102941,1)
        _GlowIntensity ("Glow Intensity", Float ) = 1.2
        _BulgeScale ("Bulge Scale", Float ) = 0.2
        _Specular ("Specular", 2D) = "white" {}
        _SpecAdjust ("SpecAdjust", Range(0, 1)) = 1
        _DiffAdjust ("DiffAdjust", Float ) = 0.1
        _ColorAdjust ("ColorAdjust", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _BulgeScale;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform float _SpecAdjust;
            uniform float _DiffAdjust;
            uniform float _ColorAdjust;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7935 = _Time;
                float node_1963 = pow((abs((frac((o.uv0+node_7935.g*float2(0,0.25)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_2726 = node_1963;
                v.vertex.xyz += (node_2726*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float3 specularColor = (_Specular_var.rgb*_SpecAdjust);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_GlowColor.r,_GlowColor.r,_GlowColor.r)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_GlowColor.r,_GlowColor.r,_GlowColor.r);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 node_7935 = _Time;
                float node_1963 = pow((abs((frac((i.uv0+node_7935.g*float2(0,0.25)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 diffuseColor = (_ColorAdjust*lerp(_Diffuse_var.rgb,float3(_DiffAdjust,_DiffAdjust,_DiffAdjust),node_1963));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_2726 = node_1963;
                float3 emissive = (_GlowColor.rgb*_GlowIntensity*node_2726);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _BulgeScale;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform float _SpecAdjust;
            uniform float _DiffAdjust;
            uniform float _ColorAdjust;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2901 = _Time;
                float node_1963 = pow((abs((frac((o.uv0+node_2901.g*float2(0,0.25)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_2726 = node_1963;
                v.vertex.xyz += (node_2726*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float3 specularColor = (_Specular_var.rgb*_SpecAdjust);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = float3(_GlowColor.r,_GlowColor.r,_GlowColor.r)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(_GlowColor.r,_GlowColor.r,_GlowColor.r);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 node_2901 = _Time;
                float node_1963 = pow((abs((frac((i.uv0+node_2901.g*float2(0,0.25)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 diffuseColor = (_ColorAdjust*lerp(_Diffuse_var.rgb,float3(_DiffAdjust,_DiffAdjust,_DiffAdjust),node_1963));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _BulgeScale;
            uniform float _BulgeShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7462 = _Time;
                float node_1963 = pow((abs((frac((o.uv0+node_7462.g*float2(0,0.25)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float node_2726 = node_1963;
                v.vertex.xyz += (node_2726*_BulgeScale*v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
