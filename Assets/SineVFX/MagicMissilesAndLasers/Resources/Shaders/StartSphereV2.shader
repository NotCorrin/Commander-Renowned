// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33544,y:33028,varname:node_4795,prsc:2|emission-2800-OUT,voffset-3604-OUT;n:type:ShaderForge.SFN_Fresnel,id:4585,x:31711,y:32569,varname:node_4585,prsc:2|EXP-3347-OUT;n:type:ShaderForge.SFN_Slider,id:7831,x:32558,y:32937,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_7831,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Tex2d,id:1357,x:32715,y:32738,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_1357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-4927-OUT;n:type:ShaderForge.SFN_Append,id:4927,x:32544,y:32738,varname:node_4927,prsc:2|A-9342-OUT,B-2639-OUT;n:type:ShaderForge.SFN_Vector1,id:2639,x:32347,y:32820,varname:node_2639,prsc:2,v1:0;n:type:ShaderForge.SFN_NormalVector,id:253,x:32385,y:33609,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:1892,x:32385,y:33789,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_1892,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3333333,max:4;n:type:ShaderForge.SFN_Multiply,id:3604,x:32804,y:33531,varname:node_3604,prsc:2|A-253-OUT,B-1892-OUT;n:type:ShaderForge.SFN_Multiply,id:2800,x:32982,y:32872,varname:node_2800,prsc:2|A-1357-RGB,B-7831-OUT,C-6234-RGB;n:type:ShaderForge.SFN_Tex2d,id:7475,x:30916,y:32371,ptovrint:False,ptlb:NoiseTest,ptin:_NoiseTest,varname:node_7475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9150-OUT;n:type:ShaderForge.SFN_ScreenPos,id:9953,x:30260,y:32362,varname:node_9953,prsc:2,sctp:1;n:type:ShaderForge.SFN_Panner,id:7463,x:30427,y:32362,varname:node_7463,prsc:2,spu:0,spv:-0.5|UVIN-9953-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2317,x:31905,y:32380,varname:node_2317,prsc:2|A-201-OUT,B-9274-OUT;n:type:ShaderForge.SFN_Fresnel,id:9274,x:31326,y:32301,varname:node_9274,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2013,x:29680,y:32557,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:7093,x:30021,y:32557,varname:node_7093,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1809-XYZ;n:type:ShaderForge.SFN_Multiply,id:159,x:30395,y:32609,varname:node_159,prsc:2|A-5339-OUT,B-4141-OUT,C-9080-OUT;n:type:ShaderForge.SFN_Fresnel,id:4141,x:30021,y:32710,varname:node_4141,prsc:2|EXP-847-OUT;n:type:ShaderForge.SFN_Add,id:9150,x:30608,y:32362,varname:node_9150,prsc:2|A-7463-UVOUT,B-159-OUT;n:type:ShaderForge.SFN_Slider,id:9080,x:29864,y:32873,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_9080,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Transform,id:1809,x:29847,y:32557,varname:node_1809,prsc:2,tffrom:0,tfto:3|IN-2013-OUT;n:type:ShaderForge.SFN_Slider,id:847,x:29670,y:32767,ptovrint:False,ptlb:Distortion Fresnel Exp,ptin:_DistortionFresnelExp,varname:node_847,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Color,id:6234,x:32715,y:33039,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6234,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Normalize,id:5339,x:30216,y:32557,varname:node_5339,prsc:2|IN-7093-OUT;n:type:ShaderForge.SFN_Tex2d,id:2272,x:30916,y:32559,ptovrint:False,ptlb:Space Tex,ptin:_SpaceTex,varname:node_2272,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6197-UVOUT;n:type:ShaderForge.SFN_Add,id:5300,x:31171,y:32458,varname:node_5300,prsc:2|A-7475-R,B-2272-R;n:type:ShaderForge.SFN_Clamp01,id:201,x:31326,y:32458,varname:node_201,prsc:2|IN-5300-OUT;n:type:ShaderForge.SFN_ScreenPos,id:6197,x:30735,y:32559,varname:node_6197,prsc:2,sctp:2;n:type:ShaderForge.SFN_Slider,id:3347,x:31368,y:32677,ptovrint:False,ptlb:Fresnel Exp,ptin:_FresnelExp,varname:node_3347,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Clamp01,id:9342,x:32273,y:32478,varname:node_9342,prsc:2|IN-5110-OUT;n:type:ShaderForge.SFN_Add,id:5110,x:32074,y:32478,varname:node_5110,prsc:2|A-2317-OUT,B-4585-OUT;proporder:7831-1357-1892-7475-9080-847-6234-2272-3347;pass:END;sub:END;*/

Shader "Sine VFX/StartSphereV2" {
    Properties {
        _FinalPower ("Final Power", Range(0, 4)) = 1
        _Ramp ("Ramp", 2D) = "white" {}
        _OffsetPower ("Offset Power", Range(0, 4)) = 0.3333333
        _NoiseTest ("NoiseTest", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 4)) = 1
        _DistortionFresnelExp ("Distortion Fresnel Exp", Range(0, 4)) = 0
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _SpaceTex ("Space Tex", 2D) = "white" {}
        _FresnelExp ("Fresnel Exp", Range(0, 4)) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float _FinalPower;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _OffsetPower;
            uniform sampler2D _NoiseTest; uniform float4 _NoiseTest_ST;
            uniform float _DistortionPower;
            uniform float _DistortionFresnelExp;
            uniform float4 _Color;
            uniform sampler2D _SpaceTex; uniform float4 _SpaceTex_ST;
            uniform float _FresnelExp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += (v.normal*_OffsetPower);
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
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
////// Emissive:
                float4 node_7531 = _Time;
                float2 node_9150 = ((float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg+node_7531.g*float2(0,-0.5))+(normalize(mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg)*pow(1.0-max(0,dot(normalDirection, viewDirection)),_DistortionFresnelExp)*_DistortionPower));
                float4 _NoiseTest_var = tex2D(_NoiseTest,TRANSFORM_TEX(node_9150, _NoiseTest));
                float4 _SpaceTex_var = tex2D(_SpaceTex,TRANSFORM_TEX(sceneUVs.rg, _SpaceTex));
                float2 node_4927 = float2(saturate(((saturate((_NoiseTest_var.r+_SpaceTex_var.r))*(1.0-max(0,dot(normalDirection, viewDirection))))+pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExp))),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4927, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_Color.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
