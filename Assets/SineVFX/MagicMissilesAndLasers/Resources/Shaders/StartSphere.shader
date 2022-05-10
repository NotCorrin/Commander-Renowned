// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33192,y:32988,varname:node_4795,prsc:2|emission-2800-OUT,voffset-3604-OUT;n:type:ShaderForge.SFN_Fresnel,id:4585,x:31647,y:32465,varname:node_4585,prsc:2;n:type:ShaderForge.SFN_Slider,id:7831,x:32206,y:32897,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_7831,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Tex2d,id:1357,x:32363,y:32698,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_1357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-4927-OUT;n:type:ShaderForge.SFN_Append,id:4927,x:32192,y:32698,varname:node_4927,prsc:2|A-501-OUT,B-2639-OUT;n:type:ShaderForge.SFN_Vector1,id:2639,x:31995,y:32780,varname:node_2639,prsc:2,v1:0;n:type:ShaderForge.SFN_NormalVector,id:253,x:32033,y:33569,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:1892,x:32033,y:33749,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_1892,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3333333,max:4;n:type:ShaderForge.SFN_FragmentPosition,id:6451,x:30361,y:33461,varname:node_6451,prsc:2;n:type:ShaderForge.SFN_Append,id:9549,x:31099,y:33411,varname:node_9549,prsc:2|A-5896-G,B-5896-B;n:type:ShaderForge.SFN_Append,id:2336,x:31099,y:33558,varname:node_2336,prsc:2|A-5896-B,B-5896-R;n:type:ShaderForge.SFN_Append,id:911,x:31099,y:33709,varname:node_911,prsc:2|A-5896-R,B-5896-G;n:type:ShaderForge.SFN_Tex2dAsset,id:6395,x:31370,y:33899,ptovrint:False,ptlb:Offset Noise,ptin:_OffsetNoise,varname:node_6395,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6397,x:31734,y:33413,varname:node_6397,prsc:2,ntxv:0,isnm:False|UVIN-2257-UVOUT,TEX-6395-TEX;n:type:ShaderForge.SFN_Tex2d,id:2119,x:31734,y:33560,varname:node_2119,prsc:2,ntxv:0,isnm:False|UVIN-4593-UVOUT,TEX-6395-TEX;n:type:ShaderForge.SFN_Tex2d,id:7954,x:31734,y:33711,varname:node_7954,prsc:2,ntxv:0,isnm:False|UVIN-4511-UVOUT,TEX-6395-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:7856,x:32033,y:33424,varname:node_7856,prsc:2,chbt:0|M-9309-OUT,R-6397-R,G-2119-R,B-7954-R;n:type:ShaderForge.SFN_NormalVector,id:266,x:31422,y:33197,prsc:2,pt:False;n:type:ShaderForge.SFN_Abs,id:3143,x:31591,y:33197,varname:node_3143,prsc:2|IN-266-OUT;n:type:ShaderForge.SFN_Multiply,id:9309,x:31770,y:33197,varname:node_9309,prsc:2|A-3143-OUT,B-3143-OUT;n:type:ShaderForge.SFN_Multiply,id:3604,x:32452,y:33491,varname:node_3604,prsc:2|A-7856-OUT,B-253-OUT,C-1892-OUT;n:type:ShaderForge.SFN_Panner,id:2257,x:31370,y:33411,varname:node_2257,prsc:2,spu:-0.5,spv:0|UVIN-9549-OUT;n:type:ShaderForge.SFN_Panner,id:4593,x:31370,y:33560,varname:node_4593,prsc:2,spu:-0.5,spv:0|UVIN-2336-OUT;n:type:ShaderForge.SFN_Panner,id:4511,x:31370,y:33709,varname:node_4511,prsc:2,spu:0.25,spv:0.25|UVIN-911-OUT;n:type:ShaderForge.SFN_Multiply,id:2800,x:32630,y:32832,varname:node_2800,prsc:2|A-1357-RGB,B-7831-OUT;n:type:ShaderForge.SFN_Tex2d,id:7475,x:31395,y:32393,ptovrint:False,ptlb:NoiseTest,ptin:_NoiseTest,varname:node_7475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9150-OUT;n:type:ShaderForge.SFN_ScreenPos,id:9953,x:30739,y:32384,varname:node_9953,prsc:2,sctp:1;n:type:ShaderForge.SFN_Add,id:501,x:31871,y:32388,varname:node_501,prsc:2|A-2317-OUT,B-4585-OUT;n:type:ShaderForge.SFN_Panner,id:7463,x:30906,y:32384,varname:node_7463,prsc:2,spu:0,spv:-0.5|UVIN-9953-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2317,x:31647,y:32326,varname:node_2317,prsc:2|A-462-OUT,B-7475-R;n:type:ShaderForge.SFN_Fresnel,id:9274,x:31008,y:32159,varname:node_9274,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:3983,x:31175,y:32159,varname:node_3983,prsc:2|IN-9274-OUT;n:type:ShaderForge.SFN_Multiply,id:462,x:31354,y:32159,varname:node_462,prsc:2|A-3983-OUT,B-3983-OUT;n:type:ShaderForge.SFN_NormalVector,id:2013,x:30149,y:32579,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:7093,x:30500,y:32579,varname:node_7093,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1809-XYZ;n:type:ShaderForge.SFN_Multiply,id:159,x:30874,y:32631,varname:node_159,prsc:2|A-7093-OUT,B-4141-OUT,C-9080-OUT;n:type:ShaderForge.SFN_Fresnel,id:4141,x:30500,y:32732,varname:node_4141,prsc:2|EXP-847-OUT;n:type:ShaderForge.SFN_Add,id:9150,x:31087,y:32384,varname:node_9150,prsc:2|A-7463-UVOUT,B-159-OUT;n:type:ShaderForge.SFN_Slider,id:9080,x:30343,y:32895,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_9080,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Transform,id:1809,x:30326,y:32579,varname:node_1809,prsc:2,tffrom:0,tfto:3|IN-2013-OUT;n:type:ShaderForge.SFN_Slider,id:847,x:30149,y:32789,ptovrint:False,ptlb:Distortion Fresnel Exp,ptin:_DistortionFresnelExp,varname:node_847,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_ObjectPosition,id:755,x:30361,y:33608,varname:node_755,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:5896,x:30757,y:33537,varname:node_5896,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-1611-OUT;n:type:ShaderForge.SFN_Subtract,id:1611,x:30587,y:33537,varname:node_1611,prsc:2|A-6451-XYZ,B-755-XYZ;proporder:7831-1357-1892-6395-7475-9080-847;pass:END;sub:END;*/

Shader "Sine VFX/StartSphere" {
    Properties {
        _FinalPower ("Final Power", Range(0, 4)) = 1
        _Ramp ("Ramp", 2D) = "white" {}
        _OffsetPower ("Offset Power", Range(0, 4)) = 0.3333333
        _OffsetNoise ("Offset Noise", 2D) = "white" {}
        _NoiseTest ("NoiseTest", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 4)) = 1
        _DistortionFresnelExp ("Distortion Fresnel Exp", Range(0, 4)) = 0
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
            uniform sampler2D _OffsetNoise; uniform float4 _OffsetNoise_ST;
            uniform sampler2D _NoiseTest; uniform float4 _NoiseTest_ST;
            uniform float _DistortionPower;
            uniform float _DistortionFresnelExp;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 node_3143 = abs(v.normal);
                float3 node_9309 = (node_3143*node_3143);
                float4 node_8483 = _Time;
                float3 node_5896 = (mul(unity_ObjectToWorld, v.vertex).rgb-objPos.rgb).rgb;
                float2 node_2257 = (float2(node_5896.g,node_5896.b)+node_8483.g*float2(-0.5,0));
                float4 node_6397 = tex2Dlod(_OffsetNoise,float4(TRANSFORM_TEX(node_2257, _OffsetNoise),0.0,0));
                float2 node_4593 = (float2(node_5896.b,node_5896.r)+node_8483.g*float2(-0.5,0));
                float4 node_2119 = tex2Dlod(_OffsetNoise,float4(TRANSFORM_TEX(node_4593, _OffsetNoise),0.0,0));
                float2 node_4511 = (float2(node_5896.r,node_5896.g)+node_8483.g*float2(0.25,0.25));
                float4 node_7954 = tex2Dlod(_OffsetNoise,float4(TRANSFORM_TEX(node_4511, _OffsetNoise),0.0,0));
                v.vertex.xyz += ((node_9309.r*node_6397.r + node_9309.g*node_2119.r + node_9309.b*node_7954.r)*v.normal*_OffsetPower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
////// Emissive:
                float node_3983 = (1.0 - (1.0-max(0,dot(normalDirection, viewDirection))));
                float4 node_8483 = _Time;
                float2 node_9150 = ((float2((sceneUVs.x * 2 - 1)*(_ScreenParams.r/_ScreenParams.g), sceneUVs.y * 2 - 1).rg+node_8483.g*float2(0,-0.5))+(mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg*pow(1.0-max(0,dot(normalDirection, viewDirection)),_DistortionFresnelExp)*_DistortionPower));
                float4 _NoiseTest_var = tex2D(_NoiseTest,TRANSFORM_TEX(node_9150, _NoiseTest));
                float2 node_4927 = float2((((node_3983*node_3983)*_NoiseTest_var.r)+(1.0-max(0,dot(normalDirection, viewDirection)))),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4927, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower);
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
