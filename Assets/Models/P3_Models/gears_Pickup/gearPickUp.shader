// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32688,y:32729,varname:node_4013,prsc:2|diff-9242-OUT,spec-1209-OUT,emission-3213-OUT,transm-8273-OUT,lwrap-8273-OUT;n:type:ShaderForge.SFN_Subtract,id:193,x:31203,y:32803,varname:node_193,prsc:2|A-9211-OUT,B-3971-OUT;n:type:ShaderForge.SFN_Vector1,id:3971,x:31024,y:32885,varname:node_3971,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:5013,x:31375,y:32803,varname:node_5013,prsc:2|IN-193-OUT;n:type:ShaderForge.SFN_Frac,id:9211,x:31024,y:32751,varname:node_9211,prsc:2|IN-1985-OUT;n:type:ShaderForge.SFN_Panner,id:2027,x:30686,y:32751,varname:node_2027,prsc:2,spu:0.25,spv:0|UVIN-6128-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1985,x:30853,y:32751,varname:node_1985,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2027-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3340,x:31550,y:32853,cmnt:Triangle Wave,varname:node_3340,prsc:2|A-5013-OUT,B-2868-OUT;n:type:ShaderForge.SFN_Vector1,id:2868,x:31375,y:32939,varname:node_2868,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:8273,x:31754,y:32916,cmnt:Panning gradient,varname:node_8273,prsc:2|VAL-3340-OUT,EXP-6399-OUT;n:type:ShaderForge.SFN_Lerp,id:9242,x:32208,y:32578,varname:node_9242,prsc:2|A-9071-RGB,B-6010-OUT,T-8273-OUT;n:type:ShaderForge.SFN_Tex2d,id:9071,x:31981,y:32412,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3213,x:32208,y:33082,cmnt:Glow,varname:node_3213,prsc:2|A-8429-RGB,B-8272-OUT,C-5879-OUT;n:type:ShaderForge.SFN_Color,id:8429,x:31981,y:32916,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2391481,c3:0.1102941,c4:1;n:type:ShaderForge.SFN_Vector1,id:1209,x:32208,y:32746,varname:node_1209,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:6399,x:31550,y:33000,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Vector1,id:6010,x:31981,y:32580,varname:node_6010,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:8272,x:31981,y:33084,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_TexCoord,id:6128,x:30523,y:32751,varname:node_6128,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:5879,x:31981,y:33160,varname:node_5879,prsc:2|IN-8273-OUT;proporder:9071-6399-8429-8272;pass:END;sub:END;*/

Shader "Shader Forge/gearPickUp" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _BulgeShape ("Bulge Shape", Float ) = 5
        _GlowColor ("Glow Color", Color) = (1,0.2391481,0.1102941,1)
        _GlowIntensity ("Glow Intensity", Float ) = 1.2
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
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
                float node_1209 = 1.0;
                float3 specularColor = float3(node_1209,node_1209,node_1209);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float4 node_5130 = _Time;
                float node_8273 = pow((abs((frac((i.uv0+node_5130.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 w = float3(node_8273,node_8273,node_8273)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_8273,node_8273,node_8273);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float node_6010 = 0.1;
                float3 diffuseColor = lerp(_Diffuse_var.rgb,float3(node_6010,node_6010,node_6010),node_8273);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_5879 = node_8273;
                float3 emissive = (_GlowColor.rgb*_GlowIntensity*node_5879);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
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
                float node_1209 = 1.0;
                float3 specularColor = float3(node_1209,node_1209,node_1209);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float4 node_1474 = _Time;
                float node_8273 = pow((abs((frac((i.uv0+node_1474.g*float2(0.25,0)).r)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 w = float3(node_8273,node_8273,node_8273)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                float3 backLight = max(float3(0.0,0.0,0.0), -NdotLWrap + w ) * float3(node_8273,node_8273,node_8273);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float node_6010 = 0.1;
                float3 diffuseColor = lerp(_Diffuse_var.rgb,float3(node_6010,node_6010,node_6010),node_8273);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
