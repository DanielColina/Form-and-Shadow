// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32761,y:32691,varname:node_4013,prsc:2|diff-4577-RGB,alpha-996-OUT;n:type:ShaderForge.SFN_Tex2d,id:6947,x:32231,y:32664,ptovrint:False,ptlb:Nvm1,ptin:_Nvm1,varname:node_6947,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5676-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3933,x:32747,y:33256,varname:node_3933,prsc:2|A-1232-OUT,B-8546-OUT;n:type:ShaderForge.SFN_Slider,id:8546,x:32812,y:33418,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8546,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:5020,x:31366,y:32510,varname:node_5020,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8440,x:31884,y:32664,varname:node_8440,prsc:2|A-5020-UVOUT,B-8775-OUT;n:type:ShaderForge.SFN_Slider,id:8775,x:31353,y:32734,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:_node_8546_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Panner,id:5676,x:32036,y:32664,varname:node_5676,prsc:2,spu:0.1,spv:0.1|UVIN-8440-OUT;n:type:ShaderForge.SFN_Tex2d,id:2520,x:32191,y:32468,ptovrint:False,ptlb:node_2520,ptin:_node_2520,varname:node_2520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1f9c856dbc67c7f44a8cf4e8048115c0,ntxv:0,isnm:False|UVIN-7899-UVOUT;n:type:ShaderForge.SFN_Panner,id:7899,x:32086,y:32312,varname:node_7899,prsc:2,spu:0.2,spv:-0.2|UVIN-1359-OUT;n:type:ShaderForge.SFN_Slider,id:3250,x:31563,y:32356,ptovrint:False,ptlb:NRMTile,ptin:_NRMTile,varname:_Tiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:5;n:type:ShaderForge.SFN_Multiply,id:1359,x:31924,y:32312,varname:node_1359,prsc:2|A-5020-UVOUT,B-3250-OUT;n:type:ShaderForge.SFN_Tex2d,id:9260,x:32039,y:33074,ptovrint:False,ptlb:Nm2,ptin:_Nm2,varname:_node_6947_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4833-UVOUT;n:type:ShaderForge.SFN_Panner,id:4833,x:31860,y:33074,varname:node_4833,prsc:2,spu:-0.05,spv:-0.1|UVIN-2548-OUT;n:type:ShaderForge.SFN_Multiply,id:2628,x:32405,y:33059,varname:node_2628,prsc:2|A-6947-A,B-9260-A;n:type:ShaderForge.SFN_Color,id:4577,x:32611,y:32383,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4577,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:6529,x:31242,y:33129,ptovrint:False,ptlb:Tiling2,ptin:_Tiling2,varname:_Tiling_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:2548,x:31786,y:32832,varname:node_2548,prsc:2|A-5020-UVOUT,B-6529-OUT;n:type:ShaderForge.SFN_Multiply,id:4494,x:31604,y:33276,varname:node_4494,prsc:2|A-5020-UVOUT,B-4967-OUT;n:type:ShaderForge.SFN_Slider,id:4967,x:31136,y:33526,ptovrint:False,ptlb:Tiling3,ptin:_Tiling3,varname:_Tiling3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Panner,id:8293,x:31754,y:33471,varname:node_8293,prsc:2,spu:0.1,spv:0.01|UVIN-4494-OUT;n:type:ShaderForge.SFN_Tex2d,id:2113,x:31933,y:33471,ptovrint:False,ptlb:Nm3,ptin:_Nm3,varname:_Nm3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8293-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1232,x:32362,y:33300,varname:node_1232,prsc:2|A-2628-OUT,B-2113-A;n:type:ShaderForge.SFN_Tex2d,id:6419,x:32553,y:32734,ptovrint:False,ptlb:Test1,ptin:_Test1,varname:_Nvm2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-625-OUT;n:type:ShaderForge.SFN_TexCoord,id:8180,x:32014,y:32047,varname:node_8180,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:625,x:32434,y:32468,varname:node_625,prsc:2|A-9565-OUT,B-6947-A;n:type:ShaderForge.SFN_Multiply,id:9565,x:32469,y:32206,varname:node_9565,prsc:2|A-371-OUT,B-8180-UVOUT;n:type:ShaderForge.SFN_Slider,id:371,x:32312,y:32061,ptovrint:False,ptlb:UVTest,ptin:_UVTest,varname:_NRMTile_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:2,max:5;n:type:ShaderForge.SFN_Multiply,id:996,x:33014,y:33195,varname:node_996,prsc:2|A-3933-OUT,B-6051-A;n:type:ShaderForge.SFN_Tex2d,id:6051,x:32585,y:33450,ptovrint:False,ptlb:node_6051,ptin:_node_6051,varname:node_6051,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fa6f55e5b4508014898ad5f9cea73db7,ntxv:0,isnm:False;proporder:6947-8546-8775-2520-3250-9260-4577-6529-2113-4967-6419-371-6051;pass:END;sub:END;*/

Shader "Shader Forge/WaterReflCaust" {
    Properties {
        _Nvm1 ("Nvm1", 2D) = "white" {}
        _Opacity ("Opacity", Range(0, 1)) = 1
        _Tiling ("Tiling", Range(0, 5)) = 1
        _node_2520 ("node_2520", 2D) = "white" {}
        _NRMTile ("NRMTile", Range(0, 5)) = 2
        _Nm2 ("Nm2", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Tiling2 ("Tiling2", Range(0, 5)) = 1
        _Nm3 ("Nm3", 2D) = "white" {}
        _Tiling3 ("Tiling3", Range(0, 5)) = 1
        _Test1 ("Test1", 2D) = "white" {}
        _UVTest ("UVTest", Range(-5, 5)) = 2
        _node_6051 ("node_6051", 2D) = "white" {}
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
            uniform sampler2D _Nvm1; uniform float4 _Nvm1_ST;
            uniform float _Opacity;
            uniform float _Tiling;
            uniform sampler2D _Nm2; uniform float4 _Nm2_ST;
            uniform float4 _Color;
            uniform float _Tiling2;
            uniform float _Tiling3;
            uniform sampler2D _Nm3; uniform float4 _Nm3_ST;
            uniform sampler2D _node_6051; uniform float4 _node_6051_ST;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
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
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 node_2925 = _Time;
                float2 node_5676 = ((i.uv0*_Tiling)+node_2925.g*float2(0.1,0.1));
                float4 _Nvm1_var = tex2D(_Nvm1,TRANSFORM_TEX(node_5676, _Nvm1));
                float2 node_4833 = ((i.uv0*_Tiling2)+node_2925.g*float2(-0.05,-0.1));
                float4 _Nm2_var = tex2D(_Nm2,TRANSFORM_TEX(node_4833, _Nm2));
                float2 node_8293 = ((i.uv0*_Tiling3)+node_2925.g*float2(0.1,0.01));
                float4 _Nm3_var = tex2D(_Nm3,TRANSFORM_TEX(node_8293, _Nm3));
                float4 _node_6051_var = tex2D(_node_6051,TRANSFORM_TEX(i.uv0, _node_6051));
                fixed4 finalRGBA = fixed4(finalColor,((((_Nvm1_var.a*_Nm2_var.a)*_Nm3_var.a)*_Opacity)*_node_6051_var.a));
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
            uniform sampler2D _Nvm1; uniform float4 _Nvm1_ST;
            uniform float _Opacity;
            uniform float _Tiling;
            uniform sampler2D _Nm2; uniform float4 _Nm2_ST;
            uniform float4 _Color;
            uniform float _Tiling2;
            uniform float _Tiling3;
            uniform sampler2D _Nm3; uniform float4 _Nm3_ST;
            uniform sampler2D _node_6051; uniform float4 _node_6051_ST;
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
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 node_7375 = _Time;
                float2 node_5676 = ((i.uv0*_Tiling)+node_7375.g*float2(0.1,0.1));
                float4 _Nvm1_var = tex2D(_Nvm1,TRANSFORM_TEX(node_5676, _Nvm1));
                float2 node_4833 = ((i.uv0*_Tiling2)+node_7375.g*float2(-0.05,-0.1));
                float4 _Nm2_var = tex2D(_Nm2,TRANSFORM_TEX(node_4833, _Nm2));
                float2 node_8293 = ((i.uv0*_Tiling3)+node_7375.g*float2(0.1,0.01));
                float4 _Nm3_var = tex2D(_Nm3,TRANSFORM_TEX(node_8293, _Nm3));
                float4 _node_6051_var = tex2D(_node_6051,TRANSFORM_TEX(i.uv0, _node_6051));
                fixed4 finalRGBA = fixed4(finalColor * ((((_Nvm1_var.a*_Nm2_var.a)*_Nm3_var.a)*_Opacity)*_node_6051_var.a),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
