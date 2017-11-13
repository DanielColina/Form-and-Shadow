// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32810,y:32959,varname:node_4013,prsc:2|diff-7585-RGB;n:type:ShaderForge.SFN_Tex2d,id:7585,x:32482,y:32930,ptovrint:False,ptlb:node_7585,ptin:_node_7585,varname:node_7585,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:17c799f634aa72a46aa523925085d44c,ntxv:0,isnm:False|UVIN-9211-UVOUT;n:type:ShaderForge.SFN_Rotator,id:9211,x:32210,y:32950,varname:node_9211,prsc:2|UVIN-7119-UVOUT,PIV-1472-OUT,ANG-3353-OUT,SPD-562-OUT;n:type:ShaderForge.SFN_TexCoord,id:7119,x:31941,y:32782,varname:node_7119,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:3353,x:32510,y:33266,varname:node_3353,prsc:2,frmn:0,frmx:1,tomn:0,tomx:6.28|IN-3981-OUT;n:type:ShaderForge.SFN_Slider,id:8266,x:31736,y:33120,ptovrint:False,ptlb:angle,ptin:_angle,varname:node_8266,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.180904,max:5;n:type:ShaderForge.SFN_Multiply,id:3981,x:32302,y:33304,varname:node_3981,prsc:2|A-718-OUT,B-6596-OUT;n:type:ShaderForge.SFN_Vector1,id:679,x:31842,y:33356,varname:node_679,prsc:2,v1:-1;n:type:ShaderForge.SFN_SwitchProperty,id:6596,x:32072,y:33390,ptovrint:False,ptlb:rotdirection,ptin:_rotdirection,varname:node_6596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-679-OUT,B-8394-OUT;n:type:ShaderForge.SFN_Vector1,id:8394,x:31861,y:33495,varname:node_8394,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector2,id:1472,x:32031,y:32650,varname:node_1472,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_ValueProperty,id:562,x:32313,y:32568,ptovrint:False,ptlb:node_562,ptin:_node_562,varname:node_562,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:619,x:31861,y:33251,varname:node_619,prsc:2;n:type:ShaderForge.SFN_Multiply,id:718,x:32072,y:33197,varname:node_718,prsc:2|A-8266-OUT,B-619-T;proporder:7585-8266-6596-562;pass:END;sub:END;*/

Shader "Shader Forge/RotateTexture" {
    Properties {
        _node_7585 ("node_7585", 2D) = "white" {}
        _angle ("angle", Range(0, 5)) = 0.180904
        [MaterialToggle] _rotdirection ("rotdirection", Float ) = -1
        _node_562 ("node_562", Float ) = 1
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
            uniform sampler2D _node_7585; uniform float4 _node_7585_ST;
            uniform float _angle;
            uniform fixed _rotdirection;
            uniform float _node_562;
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
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_619 = _Time;
                float node_9211_ang = (((_angle*node_619.g)*lerp( (-1.0), 1.0, _rotdirection ))*6.28+0.0);
                float node_9211_spd = _node_562;
                float node_9211_cos = cos(node_9211_spd*node_9211_ang);
                float node_9211_sin = sin(node_9211_spd*node_9211_ang);
                float2 node_9211_piv = float2(0.5,0.5);
                float2 node_9211 = (mul(i.uv0-node_9211_piv,float2x2( node_9211_cos, -node_9211_sin, node_9211_sin, node_9211_cos))+node_9211_piv);
                float4 _node_7585_var = tex2D(_node_7585,TRANSFORM_TEX(node_9211, _node_7585));
                float3 diffuseColor = _node_7585_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            uniform sampler2D _node_7585; uniform float4 _node_7585_ST;
            uniform float _angle;
            uniform fixed _rotdirection;
            uniform float _node_562;
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
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_619 = _Time;
                float node_9211_ang = (((_angle*node_619.g)*lerp( (-1.0), 1.0, _rotdirection ))*6.28+0.0);
                float node_9211_spd = _node_562;
                float node_9211_cos = cos(node_9211_spd*node_9211_ang);
                float node_9211_sin = sin(node_9211_spd*node_9211_ang);
                float2 node_9211_piv = float2(0.5,0.5);
                float2 node_9211 = (mul(i.uv0-node_9211_piv,float2x2( node_9211_cos, -node_9211_sin, node_9211_sin, node_9211_cos))+node_9211_piv);
                float4 _node_7585_var = tex2D(_node_7585,TRANSFORM_TEX(node_9211, _node_7585));
                float3 diffuseColor = _node_7585_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
