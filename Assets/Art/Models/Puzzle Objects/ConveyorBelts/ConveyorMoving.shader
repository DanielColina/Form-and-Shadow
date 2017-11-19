// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-1490-RGB,normal-678-RGB,alpha-1490-A;n:type:ShaderForge.SFN_Tex2d,id:1490,x:32389,y:32719,ptovrint:False,ptlb:Diff,ptin:_Diff,varname:node_1490,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2696-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:678,x:32400,y:32912,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_678,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9254-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7338,x:31840,y:32620,varname:node_7338,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2696,x:32088,y:32682,varname:node_2696,prsc:2,spu:0,spv:0.25|UVIN-7338-UVOUT,DIST-9424-OUT;n:type:ShaderForge.SFN_Time,id:9495,x:31575,y:32685,varname:node_9495,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:7860,x:31778,y:32846,varname:node_7860,prsc:2,frmn:0,frmx:1,tomn:0,tomx:10|IN-458-OUT;n:type:ShaderForge.SFN_Divide,id:9424,x:31938,y:32815,varname:node_9424,prsc:2|A-9495-T,B-7860-OUT;n:type:ShaderForge.SFN_Slider,id:458,x:31418,y:32905,ptovrint:False,ptlb:SprialDirNSpeed,ptin:_SprialDirNSpeed,varname:_node_9524_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.09,cur:0,max:0.09;n:type:ShaderForge.SFN_TexCoord,id:7362,x:31886,y:33012,varname:node_7362,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9254,x:32134,y:33074,varname:node_9254,prsc:2,spu:0,spv:0.25|UVIN-7362-UVOUT,DIST-7189-OUT;n:type:ShaderForge.SFN_Time,id:7636,x:31621,y:33077,varname:node_7636,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:4140,x:31824,y:33238,varname:node_4140,prsc:2,frmn:0,frmx:1,tomn:0,tomx:10|IN-458-OUT;n:type:ShaderForge.SFN_Divide,id:7189,x:31984,y:33207,varname:node_7189,prsc:2|A-7636-T,B-4140-OUT;proporder:1490-678-458;pass:END;sub:END;*/

Shader "Shader Forge/ConveyorMoving" {
    Properties {
        _Diff ("Diff", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _SprialDirNSpeed ("SprialDirNSpeed", Range(-0.09, 0.09)) = 0
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
            uniform sampler2D _Diff; uniform float4 _Diff_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _SprialDirNSpeed;
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
                float4 node_7636 = _Time;
                float2 node_9254 = (i.uv0+(node_7636.g/(_SprialDirNSpeed*10.0+0.0))*float2(0,0.25));
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(node_9254, _Normal));
                float3 normalLocal = _Normal_var.rgb;
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
                float4 node_9495 = _Time;
                float2 node_2696 = (i.uv0+(node_9495.g/(_SprialDirNSpeed*10.0+0.0))*float2(0,0.25));
                float4 _Diff_var = tex2D(_Diff,TRANSFORM_TEX(node_2696, _Diff));
                float3 diffuseColor = _Diff_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,_Diff_var.a);
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
            uniform sampler2D _Diff; uniform float4 _Diff_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _SprialDirNSpeed;
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
                float4 node_7636 = _Time;
                float2 node_9254 = (i.uv0+(node_7636.g/(_SprialDirNSpeed*10.0+0.0))*float2(0,0.25));
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(node_9254, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_9495 = _Time;
                float2 node_2696 = (i.uv0+(node_9495.g/(_SprialDirNSpeed*10.0+0.0))*float2(0,0.25));
                float4 _Diff_var = tex2D(_Diff,TRANSFORM_TEX(node_2696, _Diff));
                float3 diffuseColor = _Diff_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * _Diff_var.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
