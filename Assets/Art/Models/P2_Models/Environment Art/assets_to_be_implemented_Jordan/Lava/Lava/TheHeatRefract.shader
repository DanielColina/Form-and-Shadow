// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1469-OUT,alpha-8099-OUT,voffset-9006-OUT;n:type:ShaderForge.SFN_Tex2d,id:6758,x:31875,y:33472,ptovrint:False,ptlb:WaveTex,ptin:_WaveTex,varname:node_6758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4066-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7889,x:31423,y:33356,varname:node_7889,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4066,x:31707,y:33472,varname:node_4066,prsc:2,spu:0.25,spv:0.25|UVIN-7889-UVOUT,DIST-6387-OUT;n:type:ShaderForge.SFN_Time,id:6889,x:31158,y:33421,varname:node_6889,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:7618,x:31361,y:33582,varname:node_7618,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-2475-OUT;n:type:ShaderForge.SFN_Divide,id:6387,x:31521,y:33551,varname:node_6387,prsc:2|A-6889-T,B-7618-OUT;n:type:ShaderForge.SFN_Slider,id:2475,x:31003,y:33637,ptovrint:False,ptlb:Panning Speed,ptin:_PanningSpeed,varname:_node_9524_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2021776,max:1;n:type:ShaderForge.SFN_ComponentMask,id:4518,x:32125,y:33479,varname:node_4518,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-6758-RGB;n:type:ShaderForge.SFN_Multiply,id:9006,x:32349,y:33479,varname:node_9006,prsc:2|A-4518-G,B-8310-OUT;n:type:ShaderForge.SFN_Slider,id:8310,x:31948,y:33719,ptovrint:False,ptlb:WaveAmount,ptin:_WaveAmount,varname:node_8310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.005,cur:0,max:0.005;n:type:ShaderForge.SFN_Slider,id:8099,x:32309,y:32980,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Lerp,id:9263,x:31465,y:31781,varname:node_9263,prsc:2|A-2526-RGB,B-7770-RGB,T-2164-OUT;n:type:ShaderForge.SFN_Tex2d,id:2526,x:31131,y:31518,ptovrint:False,ptlb:diff1,ptin:_diff1,varname:node_9749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c348d5ced6beb7140a5cbac68ef1fad7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7770,x:30822,y:32251,ptovrint:False,ptlb:diff2,ptin:_diff2,varname:_node_9749_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4a5c43f40b60a7a4282fefc4d751a87f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_DepthBlend,id:3331,x:31062,y:32053,varname:node_3331,prsc:2|DIST-3297-OUT;n:type:ShaderForge.SFN_Tex2d,id:9569,x:30855,y:31919,ptovrint:False,ptlb:spiralwht,ptin:_spiralwht,varname:node_3099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6583d60cd64664f41ad62a0e4ea1f759,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2164,x:31114,y:31888,varname:node_2164,prsc:2|A-9569-RGB,B-3331-OUT;n:type:ShaderForge.SFN_Vector1,id:3297,x:30822,y:32107,varname:node_3297,prsc:2,v1:0.25;n:type:ShaderForge.SFN_DepthBlend,id:6955,x:31762,y:31889,varname:node_6955,prsc:2|DIST-1519-OUT;n:type:ShaderForge.SFN_Vector1,id:1519,x:31545,y:31955,varname:node_1519,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:1469,x:32016,y:31658,varname:node_1469,prsc:2|A-7566-OUT,B-9263-OUT,T-6955-OUT;n:type:ShaderForge.SFN_Vector3,id:7566,x:31595,y:31571,varname:node_7566,prsc:2,v1:0.9019608,v2:0.4665315,v3:0;proporder:6758-2475-8310-8099-2526-7770-9569;pass:END;sub:END;*/

Shader "Shader Forge/HeatRefraction" {
    Properties {
        _WaveTex ("WaveTex", 2D) = "white" {}
        _PanningSpeed ("Panning Speed", Range(0, 1)) = 0.2021776
        _WaveAmount ("WaveAmount", Range(-0.005, 0.005)) = 0
        _Opacity ("Opacity", Range(0, 10)) = 0
        _diff1 ("diff1", 2D) = "white" {}
        _diff2 ("diff2", 2D) = "white" {}
        _spiralwht ("spiralwht", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float _PanningSpeed;
            uniform float _WaveAmount;
            uniform float _Opacity;
            uniform sampler2D _diff1; uniform float4 _diff1_ST;
            uniform sampler2D _diff2; uniform float4 _diff2_ST;
            uniform sampler2D _spiralwht; uniform float4 _spiralwht_ST;
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
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_6889 = _Time;
                float2 node_4066 = (o.uv0+(node_6889.g/(_PanningSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_4066, _WaveTex),0.0,0));
                float node_9006 = (_WaveTex_var.rgb.rb.g*_WaveAmount);
                v.vertex.xyz += float3(node_9006,node_9006,node_9006);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _diff1_var = tex2D(_diff1,TRANSFORM_TEX(i.uv0, _diff1));
                float4 _diff2_var = tex2D(_diff2,TRANSFORM_TEX(i.uv0, _diff2));
                float4 _spiralwht_var = tex2D(_spiralwht,TRANSFORM_TEX(i.uv0, _spiralwht));
                float3 diffuseColor = lerp(float3(0.9019608,0.4665315,0),lerp(_diff1_var.rgb,_diff2_var.rgb,(_spiralwht_var.rgb*saturate((sceneZ-partZ)/0.25))),saturate((sceneZ-partZ)/0.5));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float _PanningSpeed;
            uniform float _WaveAmount;
            uniform float _Opacity;
            uniform sampler2D _diff1; uniform float4 _diff1_ST;
            uniform sampler2D _diff2; uniform float4 _diff2_ST;
            uniform sampler2D _spiralwht; uniform float4 _spiralwht_ST;
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
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_6889 = _Time;
                float2 node_4066 = (o.uv0+(node_6889.g/(_PanningSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_4066, _WaveTex),0.0,0));
                float node_9006 = (_WaveTex_var.rgb.rb.g*_WaveAmount);
                v.vertex.xyz += float3(node_9006,node_9006,node_9006);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _diff1_var = tex2D(_diff1,TRANSFORM_TEX(i.uv0, _diff1));
                float4 _diff2_var = tex2D(_diff2,TRANSFORM_TEX(i.uv0, _diff2));
                float4 _spiralwht_var = tex2D(_spiralwht,TRANSFORM_TEX(i.uv0, _spiralwht));
                float3 diffuseColor = lerp(float3(0.9019608,0.4665315,0),lerp(_diff1_var.rgb,_diff2_var.rgb,(_spiralwht_var.rgb*saturate((sceneZ-partZ)/0.25))),saturate((sceneZ-partZ)/0.5));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _Opacity,0);
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
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float _PanningSpeed;
            uniform float _WaveAmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_6889 = _Time;
                float2 node_4066 = (o.uv0+(node_6889.g/(_PanningSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_4066, _WaveTex),0.0,0));
                float node_9006 = (_WaveTex_var.rgb.rb.g*_WaveAmount);
                v.vertex.xyz += float3(node_9006,node_9006,node_9006);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
