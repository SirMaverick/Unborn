// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.34 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.34;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-9533-OUT,spec-358-OUT,gloss-1813-OUT,emission-9533-OUT,alpha-4632-OUT,clip-6452-OUT,olwid-7613-OUT,voffset-4869-OUT;n:type:ShaderForge.SFN_Slider,id:358,x:32353,y:32859,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32343,y:32954,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Color,id:5848,x:31518,y:32897,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.6689653,c3:1,c4:0.5;n:type:ShaderForge.SFN_Subtract,id:7946,x:31862,y:32946,varname:node_7946,prsc:2|A-5848-RGB,B-2137-RGB;n:type:ShaderForge.SFN_Slider,id:7995,x:31223,y:33516,ptovrint:False,ptlb:Transparancy,ptin:_Transparancy,cmnt:Transparency,varname:node_7464,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.49,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:4632,x:32046,y:33056,ptovrint:False,ptlb:Opacity,ptin:_Opacity,cmnt:Transparency,varname:_Offset_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:8554,x:32164,y:33746,ptovrint:False,ptlb:Offset,ptin:_Offset,cmnt:Transparency,varname:_Transparancy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.5;n:type:ShaderForge.SFN_Multiply,id:1199,x:32563,y:34131,varname:node_1199,prsc:2|A-8554-OUT,B-2137-R;n:type:ShaderForge.SFN_Blend,id:7977,x:32863,y:33964,varname:node_7977,prsc:2,blmd:10,clmp:True|SRC-1199-OUT,DST-8554-OUT;n:type:ShaderForge.SFN_Multiply,id:4869,x:33039,y:33801,varname:node_4869,prsc:2|A-9059-OUT,B-7977-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7613,x:32872,y:33224,ptovrint:False,ptlb:node_9478,ptin:_node_9478,varname:node_9478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.01;n:type:ShaderForge.SFN_Multiply,id:6452,x:32284,y:33292,varname:node_6452,prsc:2|A-9059-OUT,B-7888-OUT;n:type:ShaderForge.SFN_Blend,id:7888,x:32108,y:33455,varname:node_7888,prsc:2,blmd:10,clmp:True|SRC-2226-OUT,DST-7995-OUT;n:type:ShaderForge.SFN_RemapRange,id:9059,x:31790,y:33179,varname:node_9059,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-2137-R;n:type:ShaderForge.SFN_Tex2d,id:2137,x:31470,y:33146,ptovrint:False,ptlb:BlackbarsTexture,ptin:_BlackbarsTexture,varname:node_2331,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0acc6afed861dd544ad84cd32d8bb060,ntxv:0,isnm:False|UVIN-6035-UVOUT;n:type:ShaderForge.SFN_Panner,id:6035,x:31153,y:32937,varname:node_6035,prsc:2,spu:0,spv:-0.02|UVIN-6541-OUT;n:type:ShaderForge.SFN_TexCoord,id:5924,x:31076,y:33218,varname:node_5924,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:4894,x:31178,y:33821,ptovrint:False,ptlb:GradiantTexture,ptin:_GradiantTexture,varname:node_4026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ee973782e820e0843ae6eb6bce534c37,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2226,x:31808,y:33622,varname:node_2226,prsc:2|A-7995-OUT,B-4894-R;n:type:ShaderForge.SFN_Color,id:5425,x:31003,y:32608,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.6689653,c3:1,c4:0.5;n:type:ShaderForge.SFN_ComponentMask,id:6582,x:31281,y:33169,varname:node_6582,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5924-U;n:type:ShaderForge.SFN_Append,id:6541,x:31470,y:33346,varname:node_6541,prsc:2|A-6582-OUT,B-7529-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9743,x:30630,y:33487,varname:node_9743,prsc:2;n:type:ShaderForge.SFN_Slider,id:5109,x:30473,y:33288,ptovrint:False,ptlb:node_5109,ptin:_node_5109,varname:node_5109,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3846154,max:1;n:type:ShaderForge.SFN_Multiply,id:5383,x:30818,y:33348,varname:node_5383,prsc:2|A-5109-OUT,B-9743-Y;n:type:ShaderForge.SFN_NormalVector,id:8466,x:30544,y:32947,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:6521,x:30760,y:33040,varname:node_6521,prsc:2,dt:0|A-8466-OUT,B-485-OUT;n:type:ShaderForge.SFN_Vector3,id:485,x:30544,y:33120,varname:node_485,prsc:2,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Abs,id:9276,x:30842,y:32850,varname:node_9276,prsc:2|IN-6521-OUT;n:type:ShaderForge.SFN_Lerp,id:9533,x:32089,y:32718,varname:node_9533,prsc:2|A-7946-OUT,B-5425-RGB,T-9276-OUT;n:type:ShaderForge.SFN_Multiply,id:7529,x:30974,y:33493,varname:node_7529,prsc:2|A-5383-OUT,B-9743-X;proporder:358-1813-5848-2137-7613-4632-7995-4894-8554-5425-5109;pass:END;sub:END;*/

Shader "Shader Forge/Hologram_PBR_V2" {
    Properties {
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Color ("Color", Color) = (0,0.6689653,1,0.5)
        _BlackbarsTexture ("BlackbarsTexture", 2D) = "white" {}
        _node_9478 ("node_9478", Float ) = 0.01
        _Opacity ("Opacity", Range(0, 1)) = 0
        _Transparancy ("Transparancy", Range(0.49, 1)) = 1
        _GradiantTexture ("GradiantTexture", 2D) = "black" {}
        _Offset ("Offset", Range(0, 0.5)) = 0
        _Emission ("Emission", Color) = (0,0.6689653,1,0.5)
        _node_5109 ("node_5109", Range(0, 1)) = 0.3846154
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Transparancy;
            uniform float _Offset;
            uniform float _node_9478;
            uniform sampler2D _BlackbarsTexture; uniform float4 _BlackbarsTexture_ST;
            uniform sampler2D _GradiantTexture; uniform float4 _GradiantTexture_ST;
            uniform float _node_5109;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                float4 node_9575 = _Time + _TimeEditor;
                float2 node_6035 = (float2(o.uv0.r.r,((_node_5109*mul(unity_ObjectToWorld, v.vertex).g)*mul(unity_ObjectToWorld, v.vertex).r))+node_9575.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2Dlod(_BlackbarsTexture,float4(TRANSFORM_TEX(node_6035, _BlackbarsTexture),0.0,0));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float node_4869 = (node_9059*saturate(( _Offset > 0.5 ? (1.0-(1.0-2.0*(_Offset-0.5))*(1.0-(_Offset*_BlackbarsTexture_var.r))) : (2.0*_Offset*(_Offset*_BlackbarsTexture_var.r)) )));
                v.vertex.xyz += float3(node_4869,node_4869,node_4869);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(float4(v.vertex.xyz + v.normal*_node_9478,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9575 = _Time + _TimeEditor;
                float2 node_6035 = (float2(i.uv0.r.r,((_node_5109*i.posWorld.g)*i.posWorld.r))+node_9575.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2D(_BlackbarsTexture,TRANSFORM_TEX(node_6035, _BlackbarsTexture));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float4 _GradiantTexture_var = tex2D(_GradiantTexture,TRANSFORM_TEX(i.uv0, _GradiantTexture));
                clip((node_9059*saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_GradiantTexture_var.r))) : (2.0*_Transparancy*(_Transparancy*_GradiantTexture_var.r)) ))) - 0.5);
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color;
            uniform float _Transparancy;
            uniform float _Opacity;
            uniform float _Offset;
            uniform sampler2D _BlackbarsTexture; uniform float4 _BlackbarsTexture_ST;
            uniform sampler2D _GradiantTexture; uniform float4 _GradiantTexture_ST;
            uniform float4 _Emission;
            uniform float _node_5109;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                UNITY_FOG_COORDS(7)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_6231 = _Time + _TimeEditor;
                float2 node_6035 = (float2(o.uv0.r.r,((_node_5109*mul(unity_ObjectToWorld, v.vertex).g)*mul(unity_ObjectToWorld, v.vertex).r))+node_6231.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2Dlod(_BlackbarsTexture,float4(TRANSFORM_TEX(node_6035, _BlackbarsTexture),0.0,0));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float node_4869 = (node_9059*saturate(( _Offset > 0.5 ? (1.0-(1.0-2.0*(_Offset-0.5))*(1.0-(_Offset*_BlackbarsTexture_var.r))) : (2.0*_Offset*(_Offset*_BlackbarsTexture_var.r)) )));
                v.vertex.xyz += float3(node_4869,node_4869,node_4869);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 node_6231 = _Time + _TimeEditor;
                float2 node_6035 = (float2(i.uv0.r.r,((_node_5109*i.posWorld.g)*i.posWorld.r))+node_6231.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2D(_BlackbarsTexture,TRANSFORM_TEX(node_6035, _BlackbarsTexture));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float4 _GradiantTexture_var = tex2D(_GradiantTexture,TRANSFORM_TEX(i.uv0, _GradiantTexture));
                clip((node_9059*saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_GradiantTexture_var.r))) : (2.0*_Transparancy*(_Transparancy*_GradiantTexture_var.r)) ))) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 node_9533 = lerp((_Color.rgb-_BlackbarsTexture_var.rgb),_Emission.rgb,abs(dot(i.normalDir,float3(0,1,0))));
                float3 diffuseColor = node_9533; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz)*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_9533;
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color;
            uniform float _Transparancy;
            uniform float _Opacity;
            uniform float _Offset;
            uniform sampler2D _BlackbarsTexture; uniform float4 _BlackbarsTexture_ST;
            uniform sampler2D _GradiantTexture; uniform float4 _GradiantTexture_ST;
            uniform float4 _Emission;
            uniform float _node_5109;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_132 = _Time + _TimeEditor;
                float2 node_6035 = (float2(o.uv0.r.r,((_node_5109*mul(unity_ObjectToWorld, v.vertex).g)*mul(unity_ObjectToWorld, v.vertex).r))+node_132.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2Dlod(_BlackbarsTexture,float4(TRANSFORM_TEX(node_6035, _BlackbarsTexture),0.0,0));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float node_4869 = (node_9059*saturate(( _Offset > 0.5 ? (1.0-(1.0-2.0*(_Offset-0.5))*(1.0-(_Offset*_BlackbarsTexture_var.r))) : (2.0*_Offset*(_Offset*_BlackbarsTexture_var.r)) )));
                v.vertex.xyz += float3(node_4869,node_4869,node_4869);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 node_132 = _Time + _TimeEditor;
                float2 node_6035 = (float2(i.uv0.r.r,((_node_5109*i.posWorld.g)*i.posWorld.r))+node_132.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2D(_BlackbarsTexture,TRANSFORM_TEX(node_6035, _BlackbarsTexture));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float4 _GradiantTexture_var = tex2D(_GradiantTexture,TRANSFORM_TEX(i.uv0, _GradiantTexture));
                clip((node_9059*saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_GradiantTexture_var.r))) : (2.0*_Transparancy*(_Transparancy*_GradiantTexture_var.r)) ))) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float3 node_9533 = lerp((_Color.rgb-_BlackbarsTexture_var.rgb),_Emission.rgb,abs(dot(i.normalDir,float3(0,1,0))));
                float3 diffuseColor = node_9533; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Transparancy;
            uniform float _Offset;
            uniform sampler2D _BlackbarsTexture; uniform float4 _BlackbarsTexture_ST;
            uniform sampler2D _GradiantTexture; uniform float4 _GradiantTexture_ST;
            uniform float _node_5109;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                float4 node_7297 = _Time + _TimeEditor;
                float2 node_6035 = (float2(o.uv0.r.r,((_node_5109*mul(unity_ObjectToWorld, v.vertex).g)*mul(unity_ObjectToWorld, v.vertex).r))+node_7297.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2Dlod(_BlackbarsTexture,float4(TRANSFORM_TEX(node_6035, _BlackbarsTexture),0.0,0));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float node_4869 = (node_9059*saturate(( _Offset > 0.5 ? (1.0-(1.0-2.0*(_Offset-0.5))*(1.0-(_Offset*_BlackbarsTexture_var.r))) : (2.0*_Offset*(_Offset*_BlackbarsTexture_var.r)) )));
                v.vertex.xyz += float3(node_4869,node_4869,node_4869);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7297 = _Time + _TimeEditor;
                float2 node_6035 = (float2(i.uv0.r.r,((_node_5109*i.posWorld.g)*i.posWorld.r))+node_7297.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2D(_BlackbarsTexture,TRANSFORM_TEX(node_6035, _BlackbarsTexture));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float4 _GradiantTexture_var = tex2D(_GradiantTexture,TRANSFORM_TEX(i.uv0, _GradiantTexture));
                clip((node_9059*saturate(( _Transparancy > 0.5 ? (1.0-(1.0-2.0*(_Transparancy-0.5))*(1.0-(_Transparancy*_GradiantTexture_var.r))) : (2.0*_Transparancy*(_Transparancy*_GradiantTexture_var.r)) ))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color;
            uniform float _Offset;
            uniform sampler2D _BlackbarsTexture; uniform float4 _BlackbarsTexture_ST;
            uniform float4 _Emission;
            uniform float _node_5109;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2486 = _Time + _TimeEditor;
                float2 node_6035 = (float2(o.uv0.r.r,((_node_5109*mul(unity_ObjectToWorld, v.vertex).g)*mul(unity_ObjectToWorld, v.vertex).r))+node_2486.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2Dlod(_BlackbarsTexture,float4(TRANSFORM_TEX(node_6035, _BlackbarsTexture),0.0,0));
                float node_9059 = (_BlackbarsTexture_var.r*-1.0+1.0);
                float node_4869 = (node_9059*saturate(( _Offset > 0.5 ? (1.0-(1.0-2.0*(_Offset-0.5))*(1.0-(_Offset*_BlackbarsTexture_var.r))) : (2.0*_Offset*(_Offset*_BlackbarsTexture_var.r)) )));
                v.vertex.xyz += float3(node_4869,node_4869,node_4869);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_2486 = _Time + _TimeEditor;
                float2 node_6035 = (float2(i.uv0.r.r,((_node_5109*i.posWorld.g)*i.posWorld.r))+node_2486.g*float2(0,-0.02));
                float4 _BlackbarsTexture_var = tex2D(_BlackbarsTexture,TRANSFORM_TEX(node_6035, _BlackbarsTexture));
                float3 node_9533 = lerp((_Color.rgb-_BlackbarsTexture_var.rgb),_Emission.rgb,abs(dot(i.normalDir,float3(0,1,0))));
                o.Emission = node_9533;
                
                float3 diffColor = node_9533;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
