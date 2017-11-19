// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|normal-1855-RGB,emission-8627-OUT,custl-7595-OUT,alpha-9632-OUT,refract-1725-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:178,x:32176,y:32673,varname:node_178,prsc:2;n:type:ShaderForge.SFN_Dot,id:6851,x:31235,y:32897,varname:node_6851,prsc:2,dt:1|A-4797-OUT,B-5714-OUT;n:type:ShaderForge.SFN_NormalVector,id:5714,x:31026,y:32991,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:4797,x:31026,y:32870,varname:node_4797,prsc:2;n:type:ShaderForge.SFN_Dot,id:6863,x:31235,y:33070,varname:node_6863,prsc:2,dt:1|A-5714-OUT,B-9240-OUT;n:type:ShaderForge.SFN_Add,id:1768,x:32176,y:32935,varname:node_1768,prsc:2|A-5124-OUT,B-8338-RGB,C-412-OUT;n:type:ShaderForge.SFN_Power,id:9256,x:31437,y:33170,cmnt:Specular Light,varname:node_9256,prsc:2|VAL-6863-OUT,EXP-2681-OUT;n:type:ShaderForge.SFN_HalfVector,id:9240,x:31026,y:33130,varname:node_9240,prsc:2;n:type:ShaderForge.SFN_LightColor,id:6516,x:32176,y:32802,varname:node_6516,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7595,x:32360,y:32802,varname:node_7595,prsc:2|A-178-OUT,B-6516-RGB,C-1768-OUT;n:type:ShaderForge.SFN_Color,id:9940,x:31672,y:32825,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6544118,c2:0.8426978,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5384,x:31672,y:32649,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8993b617f08498f43adcbd90697f1c5d,ntxv:0,isnm:False|UVIN-9506-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1855,x:32360,y:32613,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c6dfb00dbee6bc044a8a3bb22e56e064,ntxv:3,isnm:True|UVIN-9506-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5124,x:31877,y:32807,cmnt:Diffuse Light,varname:node_5124,prsc:2|A-5384-RGB,B-9940-RGB,C-1331-OUT;n:type:ShaderForge.SFN_AmbientLight,id:8338,x:31877,y:32927,varname:node_8338,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:6501,x:31437,y:33070,ptovrint:False,ptlb:Bands,ptin:_Bands,varname:_Bands,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Slider,id:5464,x:30288,y:33238,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4511278,max:1;n:type:ShaderForge.SFN_Add,id:3678,x:31026,y:33287,varname:node_3678,prsc:2|A-6782-OUT,B-515-OUT;n:type:ShaderForge.SFN_Vector1,id:515,x:30858,y:33375,varname:node_515,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:6782,x:30858,y:33225,varname:node_6782,prsc:2|A-5464-OUT,B-5653-OUT;n:type:ShaderForge.SFN_Vector1,id:5653,x:30445,y:33308,varname:node_5653,prsc:2,v1:10;n:type:ShaderForge.SFN_Exp,id:2681,x:31197,y:33287,varname:node_2681,prsc:2,et:1|IN-3678-OUT;n:type:ShaderForge.SFN_Posterize,id:1331,x:31672,y:32991,varname:node_1331,prsc:2|IN-6851-OUT,STPS-6501-OUT;n:type:ShaderForge.SFN_Posterize,id:412,x:31672,y:33122,varname:node_412,prsc:2|IN-9256-OUT,STPS-6501-OUT;n:type:ShaderForge.SFN_TexCoord,id:9506,x:31425,y:32698,varname:node_9506,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:9632,x:32312,y:33112,ptovrint:False,ptlb:OPACITY,ptin:_OPACITY,varname:node_2690,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2820513,max:1;n:type:ShaderForge.SFN_ComponentMask,id:6299,x:31721,y:33648,varname:node_6299,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9554-RGB;n:type:ShaderForge.SFN_Multiply,id:6130,x:31945,y:33648,varname:node_6130,prsc:2|A-6299-OUT,B-6175-OUT;n:type:ShaderForge.SFN_Vector1,id:6175,x:31721,y:33855,varname:node_6175,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Fresnel,id:4073,x:32039,y:33981,varname:node_4073,prsc:2|EXP-9304-OUT;n:type:ShaderForge.SFN_Vector1,id:5373,x:31758,y:33463,varname:node_5373,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:1725,x:32134,y:33617,varname:node_1725,prsc:2|A-6130-OUT,B-5373-OUT,T-4073-OUT;n:type:ShaderForge.SFN_Slider,id:9304,x:31690,y:33997,ptovrint:False,ptlb:Fresnel Slide_copy,ptin:_FresnelSlide_copy,varname:_FresnelSlide_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.289488,max:5;n:type:ShaderForge.SFN_Tex2d,id:9554,x:31403,y:33720,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:_node_8449_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6191,x:31999,y:33145,ptovrint:False,ptlb:emission,ptin:_emission,varname:node_2120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8c4254dd5d9a8f74d8ca24f37aff8c3a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8627,x:32173,y:33179,varname:node_8627,prsc:2|A-6191-RGB,B-2276-OUT;n:type:ShaderForge.SFN_Fresnel,id:2276,x:31999,y:33345,varname:node_2276,prsc:2;proporder:1855-9940-5384-6501-5464-9632-9304-9554-6191;pass:END;sub:END;*/

Shader "Shader Forge/toonGlass" {
    Properties {
        _Normals ("Normals", 2D) = "bump" {}
        _Color ("Color", Color) = (0.6544118,0.8426978,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Bands ("Bands", Float ) = 8
        _Gloss ("Gloss", Range(0, 1)) = 0.4511278
        _OPACITY ("OPACITY", Range(0, 1)) = 0.2820513
        _FresnelSlide_copy ("Fresnel Slide_copy", Range(0, 5)) = 1.289488
        _Refraction ("Refraction", 2D) = "white" {}
        _emission ("emission", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform float _Bands;
            uniform float _Gloss;
            uniform float _OPACITY;
            uniform float _FresnelSlide_copy;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform sampler2D _emission; uniform float4 _emission_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Refraction_var = tex2D(_Refraction,TRANSFORM_TEX(i.uv0, _Refraction));
                float node_5373 = 0.0;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + lerp((_Refraction_var.rgb.rg*0.03),float2(node_5373,node_5373),pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSlide_copy));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float4 _emission_var = tex2D(_emission,TRANSFORM_TEX(i.uv0, _emission));
                float3 emissive = (_emission_var.rgb*(1.0-max(0,dot(normalDirection, viewDirection))));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 finalColor = emissive + (attenuation*_LightColor0.rgb*((_Diffuse_var.rgb*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss*10.0)+1.0))) * _Bands) / (_Bands - 1)));
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,_OPACITY),1);
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
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform float _Bands;
            uniform float _Gloss;
            uniform float _OPACITY;
            uniform float _FresnelSlide_copy;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform sampler2D _emission; uniform float4 _emission_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float3 normalLocal = _Normals_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Refraction_var = tex2D(_Refraction,TRANSFORM_TEX(i.uv0, _Refraction));
                float node_5373 = 0.0;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + lerp((_Refraction_var.rgb.rg*0.03),float2(node_5373,node_5373),pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSlide_copy));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 finalColor = (attenuation*_LightColor0.rgb*((_Diffuse_var.rgb*_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss*10.0)+1.0))) * _Bands) / (_Bands - 1)));
                fixed4 finalRGBA = fixed4(finalColor * _OPACITY,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
