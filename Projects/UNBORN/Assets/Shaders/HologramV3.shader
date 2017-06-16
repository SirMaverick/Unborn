// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33093,y:32701,varname:node_3138,prsc:2|emission-3616-RGB,alpha-9578-OUT,clip-2675-OUT;n:type:ShaderForge.SFN_Tex2d,id:4026,x:31114,y:33755,ptovrint:False,ptlb:node_4026,ptin:_node_4026,varname:node_4026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Slider,id:7464,x:31088,y:33432,ptovrint:False,ptlb:Transparancy,ptin:_Transparancy,cmnt:Transparency,varname:node_7464,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.499,cur:0.75,max:0.75;n:type:ShaderForge.SFN_Multiply,id:9745,x:31743,y:33556,varname:node_9745,prsc:2|A-7464-OUT,B-4026-R;n:type:ShaderForge.SFN_Blend,id:2675,x:32043,y:33389,varname:node_2675,prsc:2,blmd:10,clmp:True|SRC-9745-OUT,DST-7464-OUT;n:type:ShaderForge.SFN_Slider,id:9578,x:32425,y:32986,ptovrint:False,ptlb:node_9578,ptin:_node_9578,varname:node_9578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5382414,max:1;n:type:ShaderForge.SFN_Tex2d,id:3616,x:32053,y:32526,ptovrint:False,ptlb:node_3616,ptin:_node_3616,varname:node_3616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c2eadb0c71390c447ba72f4107c92a3f,ntxv:0,isnm:False;proporder:4026-7464-9578-3616;pass:END;sub:END;*/

Shader "Shader Forge/HologramV1" {
    Properties {
        _node_4026 ("node_4026", 2D) = "black" {}
        _Transparancy ("Transparancy", Range(0.499, 0.75)) = 0.75
        _node_9578 ("node_9578", Range(0, 1)) = 0.5382414
        _node_3616 ("node_3616", 2D) = "white" {}
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4026; uniform float4 _node_4026_ST;
            uniform float _Transparancy;
            uniform float _node_9578;
            uniform sampler2D _node_3616; uniform float4 _node_3616_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_4026_var = tex2D(_node_4026,TRANSFORM_TEX(i.uv0, _node_4026));
                clip(saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_node_4026_var.r))) : (2.0*_Transparancy*(_Transparancy*_node_4026_var.r)) )) - 0.5);
////// Lighting:
////// Emissive:
                float4 _node_3616_var = tex2D(_node_3616,TRANSFORM_TEX(i.uv0, _node_3616));
                float3 emissive = _node_3616_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,_node_9578);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_4026; uniform float4 _node_4026_ST;
            uniform float _Transparancy;
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
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_4026_var = tex2D(_node_4026,TRANSFORM_TEX(i.uv0, _node_4026));
                clip(saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_node_4026_var.r))) : (2.0*_Transparancy*(_Transparancy*_node_4026_var.r)) )) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
