// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33496,y:32463,varname:node_4013,prsc:2|diff-1791-RGB,normal-1112-RGB,emission-7789-OUT,alpha-3722-OUT,voffset-7352-OUT;n:type:ShaderForge.SFN_TexCoord,id:9348,x:31948,y:33042,varname:node_9348,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8900,x:32222,y:33104,varname:node_8900,prsc:2,spu:0,spv:0.35|UVIN-9348-UVOUT,DIST-739-OUT;n:type:ShaderForge.SFN_Time,id:9175,x:31683,y:33107,varname:node_9175,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3257,x:31886,y:33268,varname:node_3257,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-9524-OUT;n:type:ShaderForge.SFN_Divide,id:739,x:32046,y:33237,varname:node_739,prsc:2|A-9175-T,B-3257-OUT;n:type:ShaderForge.SFN_Slider,id:9524,x:31512,y:33329,ptovrint:False,ptlb:NormalPann,ptin:_NormalPann,varname:node_9524,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:1,max:1;n:type:ShaderForge.SFN_ValueProperty,id:3722,x:32383,y:32863,ptovrint:False,ptlb:node_3722,ptin:_node_3722,varname:node_3722,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.05;n:type:ShaderForge.SFN_Tex2d,id:1112,x:32383,y:33046,ptovrint:False,ptlb:node_1112,ptin:_node_1112,varname:node_1112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:da84e1e8d1432e54e85bd32766dd8094,ntxv:3,isnm:True|UVIN-8900-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6403,x:31844,y:32682,ptovrint:False,ptlb:WhtSpiral,ptin:_WhtSpiral,varname:node_6403,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6583d60cd64664f41ad62a0e4ea1f759,ntxv:0,isnm:False|UVIN-9590-UVOUT;n:type:ShaderForge.SFN_Multiply,id:738,x:32092,y:32682,varname:node_738,prsc:2|A-6403-B,B-164-RGB;n:type:ShaderForge.SFN_Color,id:164,x:31844,y:32862,ptovrint:False,ptlb:ColorOrange2,ptin:_ColorOrange2,varname:_node_4928_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9338235,c2:0.3670892,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:1594,x:31343,y:32694,varname:node_1594,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9590,x:31591,y:32756,varname:node_9590,prsc:2,spu:0.25,spv:0.25|UVIN-1594-UVOUT,DIST-2331-OUT;n:type:ShaderForge.SFN_Time,id:3018,x:31078,y:32759,varname:node_3018,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:8407,x:31281,y:32920,varname:node_8407,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-6664-OUT;n:type:ShaderForge.SFN_Divide,id:2331,x:31441,y:32889,varname:node_2331,prsc:2|A-3018-T,B-8407-OUT;n:type:ShaderForge.SFN_Slider,id:6664,x:30921,y:32979,ptovrint:False,ptlb:SprialDirNSpeed,ptin:_SprialDirNSpeed,varname:_node_9524_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:2;n:type:ShaderForge.SFN_Tex2d,id:675,x:31825,y:32308,ptovrint:False,ptlb:BlckSpiral,ptin:_BlckSpiral,varname:_node_6403_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4a5c43f40b60a7a4282fefc4d751a87f,ntxv:0,isnm:False|UVIN-186-UVOUT;n:type:ShaderForge.SFN_Multiply,id:981,x:32073,y:32308,varname:node_981,prsc:2|A-675-B,B-2635-RGB;n:type:ShaderForge.SFN_Color,id:2635,x:31825,y:32488,ptovrint:False,ptlb:ColorOrange1,ptin:_ColorOrange1,varname:_node_4928_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9338235,c2:0.3670892,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:8278,x:31410,y:32246,varname:node_8278,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:186,x:31684,y:32308,varname:node_186,prsc:2,spu:-0.25,spv:-0.25|UVIN-8278-UVOUT,DIST-3002-OUT;n:type:ShaderForge.SFN_Lerp,id:7789,x:32374,y:32513,varname:node_7789,prsc:2|A-981-OUT,B-738-OUT,T-28-OUT;n:type:ShaderForge.SFN_ValueProperty,id:28,x:32058,y:32567,ptovrint:False,ptlb:node_3722_copy,ptin:_node_3722_copy,varname:_node_3722_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:1791,x:32614,y:32364,ptovrint:False,ptlb:node_4928_copy_copy_copy,ptin:_node_4928_copy_copy_copy,varname:_node_4928_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9338235,c2:0.3670892,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4322,x:32133,y:33554,ptovrint:False,ptlb:node_6758,ptin:_node_6758,varname:node_6758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5530-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9066,x:31681,y:33438,varname:node_9066,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:5530,x:31965,y:33554,varname:node_5530,prsc:2,spu:0.25,spv:0.25|UVIN-9066-UVOUT,DIST-2881-OUT;n:type:ShaderForge.SFN_Time,id:7395,x:31416,y:33503,varname:node_7395,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3633,x:31619,y:33664,varname:node_3633,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-3743-OUT;n:type:ShaderForge.SFN_Divide,id:2881,x:31779,y:33633,varname:node_2881,prsc:2|A-7395-T,B-3633-OUT;n:type:ShaderForge.SFN_Slider,id:3743,x:31259,y:33723,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:_node_9524_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1219681,max:10;n:type:ShaderForge.SFN_ComponentMask,id:6808,x:32383,y:33561,varname:node_6808,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4322-RGB;n:type:ShaderForge.SFN_Multiply,id:7352,x:32607,y:33561,varname:node_7352,prsc:2|A-6808-OUT,B-7218-OUT;n:type:ShaderForge.SFN_Slider,id:7218,x:32226,y:33799,ptovrint:False,ptlb:WaveHeight,ptin:_WaveHeight,varname:node_8310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.005;n:type:ShaderForge.SFN_Time,id:668,x:31103,y:32311,varname:node_668,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:6103,x:31306,y:32472,varname:node_6103,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-14-OUT;n:type:ShaderForge.SFN_Divide,id:3002,x:31466,y:32441,varname:node_3002,prsc:2|A-668-T,B-6103-OUT;n:type:ShaderForge.SFN_Slider,id:14,x:30946,y:32531,ptovrint:False,ptlb:Lerptitude,ptin:_Lerptitude,varname:_Emissive_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:2.10154,max:10;proporder:9524-3722-1112-6403-164-6664-675-2635-28-1791-4322-7218-3743-14;pass:END;sub:END;*/

Shader "Shader Forge/underLava" {
    Properties {
        _NormalPann ("NormalPann", Range(-0.5, 1)) = 1
        _node_3722 ("node_3722", Float ) = 0.05
        _node_1112 ("node_1112", 2D) = "bump" {}
        _WhtSpiral ("WhtSpiral", 2D) = "white" {}
        _ColorOrange2 ("ColorOrange2", Color) = (0.9338235,0.3670892,0,1)
        _SprialDirNSpeed ("SprialDirNSpeed", Range(-1, 2)) = 0
        _BlckSpiral ("BlckSpiral", 2D) = "white" {}
        _ColorOrange1 ("ColorOrange1", Color) = (0.9338235,0.3670892,0,1)
        _node_3722_copy ("node_3722_copy", Float ) = 1
        _node_4928_copy_copy_copy ("node_4928_copy_copy_copy", Color) = (0.9338235,0.3670892,0,1)
        _node_6758 ("node_6758", 2D) = "white" {}
        _WaveHeight ("WaveHeight", Range(0, 0.005)) = 0
        _WaveSpeed ("WaveSpeed", Range(0, 10)) = 0.1219681
        _Lerptitude ("Lerptitude", Range(-10, 10)) = 2.10154
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
            uniform float _NormalPann;
            uniform float _node_3722;
            uniform sampler2D _node_1112; uniform float4 _node_1112_ST;
            uniform sampler2D _WhtSpiral; uniform float4 _WhtSpiral_ST;
            uniform float4 _ColorOrange2;
            uniform float _SprialDirNSpeed;
            uniform sampler2D _BlckSpiral; uniform float4 _BlckSpiral_ST;
            uniform float4 _ColorOrange1;
            uniform float _node_3722_copy;
            uniform float4 _node_4928_copy_copy_copy;
            uniform sampler2D _node_6758; uniform float4 _node_6758_ST;
            uniform float _WaveSpeed;
            uniform float _WaveHeight;
            uniform float _Lerptitude;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7395 = _Time;
                float2 node_5530 = (o.uv0+(node_7395.g/(_WaveSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _node_6758_var = tex2Dlod(_node_6758,float4(TRANSFORM_TEX(node_5530, _node_6758),0.0,0));
                v.vertex.xyz += float3((_node_6758_var.rgb.rg*_WaveHeight),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9175 = _Time;
                float2 node_8900 = (i.uv0+(node_9175.g/(_NormalPann*20.0+-10.0))*float2(0,0.35));
                float3 _node_1112_var = UnpackNormal(tex2D(_node_1112,TRANSFORM_TEX(node_8900, _node_1112)));
                float3 normalLocal = _node_1112_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float3 diffuseColor = _node_4928_copy_copy_copy.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_668 = _Time;
                float2 node_186 = (i.uv0+(node_668.g/(_Lerptitude*20.0+-10.0))*float2(-0.25,-0.25));
                float4 _BlckSpiral_var = tex2D(_BlckSpiral,TRANSFORM_TEX(node_186, _BlckSpiral));
                float4 node_3018 = _Time;
                float2 node_9590 = (i.uv0+(node_3018.g/(_SprialDirNSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _WhtSpiral_var = tex2D(_WhtSpiral,TRANSFORM_TEX(node_9590, _WhtSpiral));
                float3 emissive = lerp((_BlckSpiral_var.b*_ColorOrange1.rgb),(_WhtSpiral_var.b*_ColorOrange2.rgb),_node_3722_copy);
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,_node_3722);
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
            uniform float _NormalPann;
            uniform float _node_3722;
            uniform sampler2D _node_1112; uniform float4 _node_1112_ST;
            uniform sampler2D _WhtSpiral; uniform float4 _WhtSpiral_ST;
            uniform float4 _ColorOrange2;
            uniform float _SprialDirNSpeed;
            uniform sampler2D _BlckSpiral; uniform float4 _BlckSpiral_ST;
            uniform float4 _ColorOrange1;
            uniform float _node_3722_copy;
            uniform float4 _node_4928_copy_copy_copy;
            uniform sampler2D _node_6758; uniform float4 _node_6758_ST;
            uniform float _WaveSpeed;
            uniform float _WaveHeight;
            uniform float _Lerptitude;
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
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7395 = _Time;
                float2 node_5530 = (o.uv0+(node_7395.g/(_WaveSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _node_6758_var = tex2Dlod(_node_6758,float4(TRANSFORM_TEX(node_5530, _node_6758),0.0,0));
                v.vertex.xyz += float3((_node_6758_var.rgb.rg*_WaveHeight),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9175 = _Time;
                float2 node_8900 = (i.uv0+(node_9175.g/(_NormalPann*20.0+-10.0))*float2(0,0.35));
                float3 _node_1112_var = UnpackNormal(tex2D(_node_1112,TRANSFORM_TEX(node_8900, _node_1112)));
                float3 normalLocal = _node_1112_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _node_4928_copy_copy_copy.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _node_3722,0);
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
            uniform sampler2D _node_6758; uniform float4 _node_6758_ST;
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
                float4 node_7395 = _Time;
                float2 node_5530 = (o.uv0+(node_7395.g/(_WaveSpeed*20.0+-10.0))*float2(0.25,0.25));
                float4 _node_6758_var = tex2Dlod(_node_6758,float4(TRANSFORM_TEX(node_5530, _node_6758),0.0,0));
                v.vertex.xyz += float3((_node_6758_var.rgb.rg*_WaveHeight),0.0);
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
