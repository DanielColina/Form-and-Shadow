// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-4653-OUT,normal-8078-OUT,alpha-6609-OUT,refract-7347-OUT,voffset-7374-OUT;n:type:ShaderForge.SFN_Tex2d,id:1814,x:32170,y:32323,ptovrint:False,ptlb:node_1814,ptin:_node_1814,varname:node_1814,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7a85f4342f0c0e8449dde65efad40f47,ntxv:3,isnm:False;n:type:ShaderForge.SFN_DepthBlend,id:4129,x:31793,y:33005,varname:node_4129,prsc:2|DIST-283-OUT;n:type:ShaderForge.SFN_Vector1,id:283,x:31547,y:33049,varname:node_283,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Lerp,id:2251,x:32159,y:32601,varname:node_2251,prsc:2|A-9049-RGB,B-5525-OUT,T-4129-OUT;n:type:ShaderForge.SFN_Tex2d,id:6522,x:31657,y:32727,ptovrint:False,ptlb:node_6522,ptin:_node_6522,varname:node_6522,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:84b85ec41044ee344807ed641b608c7c,ntxv:0,isnm:False|UVIN-415-UVOUT;n:type:ShaderForge.SFN_Lerp,id:4653,x:32386,y:32584,varname:node_4653,prsc:2|A-2251-OUT,B-1814-RGB,T-1972-OUT;n:type:ShaderForge.SFN_Color,id:9049,x:31614,y:32379,ptovrint:False,ptlb:node_9049,ptin:_node_9049,varname:node_9049,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_DepthBlend,id:1972,x:32179,y:33012,varname:node_1972,prsc:2|DIST-6676-OUT;n:type:ShaderForge.SFN_Vector1,id:6676,x:31980,y:33046,varname:node_6676,prsc:2,v1:0.9;n:type:ShaderForge.SFN_OneMinus,id:5525,x:31865,y:32709,varname:node_5525,prsc:2|IN-6522-RGB;n:type:ShaderForge.SFN_TexCoord,id:1656,x:31250,y:32820,varname:node_1656,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:415,x:31426,y:32789,varname:node_415,prsc:2,spu:-0.01,spv:-0.01|UVIN-1656-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8511,x:31469,y:33355,varname:node_8511,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6054,x:31662,y:33360,varname:node_6054,prsc:2,spu:0.02,spv:-0.02|UVIN-8511-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1918,x:31872,y:33353,ptovrint:False,ptlb:node_1112,ptin:_node_1112,varname:node_1112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:da84e1e8d1432e54e85bd32766dd8094,ntxv:3,isnm:False|UVIN-6054-UVOUT;n:type:ShaderForge.SFN_Lerp,id:8078,x:32325,y:33347,varname:node_8078,prsc:2|A-3448-OUT,B-1918-RGB,T-3933-OUT;n:type:ShaderForge.SFN_Vector3,id:3448,x:32071,y:33174,varname:node_3448,prsc:2,v1:0.5,v2:0.5,v3:1;n:type:ShaderForge.SFN_Tex2d,id:7618,x:31936,y:33683,ptovrint:False,ptlb:WaveTex,ptin:_WaveTex,varname:node_6758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:014d92ee21059504c9a7f27498ac079a,ntxv:0,isnm:False|UVIN-3785-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:8026,x:31484,y:33567,varname:node_8026,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3785,x:31768,y:33683,varname:node_3785,prsc:2,spu:0.25,spv:0.25|UVIN-8026-UVOUT,DIST-6390-OUT;n:type:ShaderForge.SFN_Time,id:4877,x:31219,y:33632,varname:node_4877,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:2915,x:31422,y:33793,varname:node_2915,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-1211-OUT;n:type:ShaderForge.SFN_Divide,id:6390,x:31582,y:33762,varname:node_6390,prsc:2|A-4877-T,B-2915-OUT;n:type:ShaderForge.SFN_Slider,id:1211,x:31062,y:33852,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:_node_9524_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1219681,max:10;n:type:ShaderForge.SFN_ComponentMask,id:6675,x:32186,y:33690,varname:node_6675,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7618-RGB;n:type:ShaderForge.SFN_Multiply,id:7374,x:32410,y:33690,varname:node_7374,prsc:2|A-6675-OUT,B-1537-OUT;n:type:ShaderForge.SFN_Slider,id:1537,x:32029,y:33928,ptovrint:False,ptlb:WaveHeight,ptin:_WaveHeight,varname:node_8310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.005;n:type:ShaderForge.SFN_Slider,id:6609,x:32336,y:32999,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6609,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:3933,x:32029,y:33506,ptovrint:False,ptlb:NormalStrength,ptin:_NormalStrength,varname:node_3933,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8025758,max:10;n:type:ShaderForge.SFN_TexCoord,id:4503,x:29863,y:32520,varname:node_4503,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7481,x:30150,y:32674,varname:node_7481,prsc:2,spu:0.25,spv:0.25|UVIN-4503-UVOUT,DIST-8041-OUT;n:type:ShaderForge.SFN_Time,id:8761,x:29630,y:32643,varname:node_8761,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3302,x:29811,y:32866,varname:node_3302,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-9099-OUT;n:type:ShaderForge.SFN_Divide,id:8041,x:29967,y:32737,varname:node_8041,prsc:2|A-8761-T,B-3302-OUT;n:type:ShaderForge.SFN_Slider,id:9099,x:29473,y:32843,ptovrint:False,ptlb:TimeSlider,ptin:_TimeSlider,varname:_node_9524_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_ComponentMask,id:8431,x:30769,y:33178,varname:node_8431,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2947-RGB;n:type:ShaderForge.SFN_Multiply,id:990,x:30993,y:33178,varname:node_990,prsc:2|A-8431-OUT,B-9084-OUT;n:type:ShaderForge.SFN_Vector1,id:9084,x:30769,y:33385,varname:node_9084,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Fresnel,id:8965,x:31087,y:33511,varname:node_8965,prsc:2|EXP-2670-OUT;n:type:ShaderForge.SFN_Vector1,id:2908,x:30806,y:32993,varname:node_2908,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:7347,x:31182,y:33147,varname:node_7347,prsc:2|A-990-OUT,B-2908-OUT,T-8965-OUT;n:type:ShaderForge.SFN_Slider,id:2670,x:30738,y:33527,ptovrint:False,ptlb:Fresnel Slide,ptin:_FresnelSlide,varname:node_900,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.289488,max:5;n:type:ShaderForge.SFN_Tex2d,id:2947,x:30440,y:32850,ptovrint:False,ptlb:refractionMask,ptin:_refractionMask,varname:node_8449,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7481-UVOUT;proporder:1814-6522-9049-1918-7618-1537-6609-3933-2670-2947-9099-1211;pass:END;sub:END;*/

Shader "Shader Forge/WaterShader" {
    Properties {
        _node_1814 ("node_1814", 2D) = "bump" {}
        _node_6522 ("node_6522", 2D) = "white" {}
        _node_9049 ("node_9049", Color) = (1,1,1,1)
        _node_1112 ("node_1112", 2D) = "bump" {}
        _WaveTex ("WaveTex", 2D) = "white" {}
        _WaveHeight ("WaveHeight", Range(0, 0.005)) = 0
        _Opacity ("Opacity", Range(0, 1)) = 0
        _NormalStrength ("NormalStrength", Range(0, 10)) = 0.8025758
        _FresnelSlide ("Fresnel Slide", Range(0, 5)) = 1.289488
        _refractionMask ("refractionMask", 2D) = "white" {}
        _TimeSlider ("TimeSlider", Range(0, 1)) = 0.4
        _WaveSpeed ("WaveSpeed", Range(0, 10)) = 0.1219681
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
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _node_1814; uniform float4 _node_1814_ST;
            uniform sampler2D _node_6522; uniform float4 _node_6522_ST;
            uniform float4 _node_9049;
            uniform sampler2D _node_1112; uniform float4 _node_1112_ST;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float _WaveSpeed;
            uniform float _WaveHeight;
            uniform float _Opacity;
            uniform float _NormalStrength;
            uniform float _TimeSlider;
            uniform float _FresnelSlide;
            uniform sampler2D _refractionMask; uniform float4 _refractionMask_ST;
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
                float4 node_4877 = _Time;
                float2 node_3785 = (o.uv0+(node_4877.g/(_WaveSpeed*2.0+-1.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_3785, _WaveTex),0.0,0));
                v.vertex.xyz += float3((_WaveTex_var.rgb.rg*_WaveHeight),0.0);
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
                float4 node_3253 = _Time;
                float2 node_6054 = (i.uv0+node_3253.g*float2(0.02,-0.02));
                float4 _node_1112_var = tex2D(_node_1112,TRANSFORM_TEX(node_6054, _node_1112));
                float3 normalLocal = lerp(float3(0.5,0.5,1),_node_1112_var.rgb,_NormalStrength);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_8761 = _Time;
                float2 node_7481 = (i.uv0+(node_8761.g/(_TimeSlider*20.0+-10.0))*float2(0.25,0.25));
                float4 _refractionMask_var = tex2D(_refractionMask,TRANSFORM_TEX(node_7481, _refractionMask));
                float node_2908 = 0.0;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + lerp((_refractionMask_var.rgb.rg*0.03),float2(node_2908,node_2908),pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSlide));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
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
                float2 node_415 = (i.uv0+node_3253.g*float2(-0.01,-0.01));
                float4 _node_6522_var = tex2D(_node_6522,TRANSFORM_TEX(node_415, _node_6522));
                float4 _node_1814_var = tex2D(_node_1814,TRANSFORM_TEX(i.uv0, _node_1814));
                float3 diffuseColor = lerp(lerp(_node_9049.rgb,(1.0 - _node_6522_var.rgb),saturate((sceneZ-partZ)/0.8)),_node_1814_var.rgb,saturate((sceneZ-partZ)/0.9));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,_Opacity),1);
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
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _node_1814; uniform float4 _node_1814_ST;
            uniform sampler2D _node_6522; uniform float4 _node_6522_ST;
            uniform float4 _node_9049;
            uniform sampler2D _node_1112; uniform float4 _node_1112_ST;
            uniform sampler2D _WaveTex; uniform float4 _WaveTex_ST;
            uniform float _WaveSpeed;
            uniform float _WaveHeight;
            uniform float _Opacity;
            uniform float _NormalStrength;
            uniform float _TimeSlider;
            uniform float _FresnelSlide;
            uniform sampler2D _refractionMask; uniform float4 _refractionMask_ST;
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
                float4 node_4877 = _Time;
                float2 node_3785 = (o.uv0+(node_4877.g/(_WaveSpeed*2.0+-1.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_3785, _WaveTex),0.0,0));
                v.vertex.xyz += float3((_WaveTex_var.rgb.rg*_WaveHeight),0.0);
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
                float4 node_7552 = _Time;
                float2 node_6054 = (i.uv0+node_7552.g*float2(0.02,-0.02));
                float4 _node_1112_var = tex2D(_node_1112,TRANSFORM_TEX(node_6054, _node_1112));
                float3 normalLocal = lerp(float3(0.5,0.5,1),_node_1112_var.rgb,_NormalStrength);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 node_8761 = _Time;
                float2 node_7481 = (i.uv0+(node_8761.g/(_TimeSlider*20.0+-10.0))*float2(0.25,0.25));
                float4 _refractionMask_var = tex2D(_refractionMask,TRANSFORM_TEX(node_7481, _refractionMask));
                float node_2908 = 0.0;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + lerp((_refractionMask_var.rgb.rg*0.03),float2(node_2908,node_2908),pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSlide));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_415 = (i.uv0+node_7552.g*float2(-0.01,-0.01));
                float4 _node_6522_var = tex2D(_node_6522,TRANSFORM_TEX(node_415, _node_6522));
                float4 _node_1814_var = tex2D(_node_1814,TRANSFORM_TEX(i.uv0, _node_1814));
                float3 diffuseColor = lerp(lerp(_node_9049.rgb,(1.0 - _node_6522_var.rgb),saturate((sceneZ-partZ)/0.8)),_node_1814_var.rgb,saturate((sceneZ-partZ)/0.9));
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
            uniform float _WaveSpeed;
            uniform float _WaveHeight;
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
                float4 node_4877 = _Time;
                float2 node_3785 = (o.uv0+(node_4877.g/(_WaveSpeed*2.0+-1.0))*float2(0.25,0.25));
                float4 _WaveTex_var = tex2Dlod(_WaveTex,float4(TRANSFORM_TEX(node_3785, _WaveTex),0.0,0));
                v.vertex.xyz += float3((_WaveTex_var.rgb.rg*_WaveHeight),0.0);
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
