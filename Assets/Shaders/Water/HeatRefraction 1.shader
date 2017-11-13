// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|alpha-4944-OUT,refract-702-OUT;n:type:ShaderForge.SFN_TexCoord,id:7889,x:31375,y:32951,varname:node_7889,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4066,x:31662,y:33105,varname:node_4066,prsc:2,spu:0.25,spv:0.25|UVIN-7889-UVOUT,DIST-6387-OUT;n:type:ShaderForge.SFN_Time,id:6889,x:31142,y:33074,varname:node_6889,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:7618,x:31323,y:33297,varname:node_7618,prsc:2,frmn:0,frmx:1,tomn:-10,tomx:10|IN-2475-OUT;n:type:ShaderForge.SFN_Divide,id:6387,x:31479,y:33168,varname:node_6387,prsc:2|A-6889-T,B-7618-OUT;n:type:ShaderForge.SFN_Slider,id:2475,x:30985,y:33274,ptovrint:False,ptlb:TimeSlider,ptin:_TimeSlider,varname:_node_9524_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_Vector1,id:4944,x:32419,y:32973,varname:node_4944,prsc:2,v1:0;n:type:ShaderForge.SFN_ComponentMask,id:4518,x:32281,y:33609,varname:node_4518,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8449-RGB;n:type:ShaderForge.SFN_Multiply,id:9006,x:32505,y:33609,varname:node_9006,prsc:2|A-4518-OUT,B-3743-OUT;n:type:ShaderForge.SFN_Vector1,id:3743,x:32281,y:33816,varname:node_3743,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Fresnel,id:6596,x:32599,y:33942,varname:node_6596,prsc:2|EXP-900-OUT;n:type:ShaderForge.SFN_Vector1,id:7840,x:32318,y:33424,varname:node_7840,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:702,x:32694,y:33578,varname:node_702,prsc:2|A-9006-OUT,B-7840-OUT,T-6596-OUT;n:type:ShaderForge.SFN_Slider,id:900,x:32250,y:33958,ptovrint:False,ptlb:Fresnel Slide,ptin:_FresnelSlide,varname:node_900,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.289488,max:5;n:type:ShaderForge.SFN_Tex2d,id:8449,x:31952,y:33281,ptovrint:False,ptlb:node_8449,ptin:_node_8449,varname:node_8449,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4066-UVOUT;proporder:2475-900-8449;pass:END;sub:END;*/

Shader "Shader Forge/HeatRefraction" {
    Properties {
        _TimeSlider ("TimeSlider", Range(0, 1)) = 0.4
        _FresnelSlide ("Fresnel Slide", Range(0, 5)) = 1.289488
        _node_8449 ("node_8449", 2D) = "white" {}
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
            uniform sampler2D _GrabTexture;
            uniform float _TimeSlider;
            uniform float _FresnelSlide;
            uniform sampler2D _node_8449; uniform float4 _node_8449_ST;
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
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_6889 = _Time;
                float2 node_4066 = (i.uv0+(node_6889.g/(_TimeSlider*20.0+-10.0))*float2(0.25,0.25));
                float4 _node_8449_var = tex2D(_node_8449,TRANSFORM_TEX(node_4066, _node_8449));
                float node_7840 = 0.0;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + lerp((_node_8449_var.rgb.rg*0.03),float2(node_7840,node_7840),pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSlide));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,0.0),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
