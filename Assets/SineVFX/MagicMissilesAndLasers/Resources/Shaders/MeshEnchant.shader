// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33586,y:32644,varname:node_4795,prsc:2|emission-8058-OUT,voffset-1200-OUT;n:type:ShaderForge.SFN_Color,id:797,x:32988,y:32268,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:1200,x:32624,y:33762,varname:node_1200,prsc:2|A-5219-OUT,B-625-OUT;n:type:ShaderForge.SFN_NormalVector,id:625,x:32419,y:33810,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:4521,x:31507,y:33803,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_4521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.1;n:type:ShaderForge.SFN_Fresnel,id:1970,x:31571,y:31910,varname:node_1970,prsc:2|EXP-8917-OUT;n:type:ShaderForge.SFN_Slider,id:8917,x:31236,y:31921,ptovrint:False,ptlb:Fresnel Exp,ptin:_FresnelExp,varname:node_8917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Slider,id:9983,x:32831,y:32442,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_9983,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:10;n:type:ShaderForge.SFN_Vector4Property,id:489,x:29705,y:31804,ptovrint:False,ptlb:_EnchantPoint,ptin:_EnchantPoint,varname:node_489,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_Distance,id:6242,x:29954,y:31853,varname:node_6242,prsc:2|A-489-XYZ,B-6158-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:6158,x:29705,y:31964,varname:node_6158,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:6647,x:30151,y:31767,varname:node_6647,prsc:2|IN-6242-OUT;n:type:ShaderForge.SFN_Add,id:7244,x:30717,y:32949,varname:node_7244,prsc:2|A-9690-OUT,B-2019-OUT;n:type:ShaderForge.SFN_Clamp01,id:4551,x:31323,y:33062,varname:node_4551,prsc:2|IN-2191-OUT;n:type:ShaderForge.SFN_Smoothstep,id:2191,x:31164,y:33062,varname:node_2191,prsc:2|A-9457-OUT,B-2007-OUT,V-6702-OUT;n:type:ShaderForge.SFN_Vector1,id:9457,x:30927,y:32938,varname:node_9457,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:2007,x:30717,y:33143,varname:node_2007,prsc:2|A-2019-OUT,B-9530-OUT;n:type:ShaderForge.SFN_Vector1,id:9530,x:30496,y:33175,varname:node_9530,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp,id:6702,x:30927,y:33004,varname:node_6702,prsc:2|IN-7244-OUT,MIN-6136-OUT,MAX-2007-OUT;n:type:ShaderForge.SFN_Vector1,id:6136,x:30717,y:33074,varname:node_6136,prsc:2,v1:0;n:type:ShaderForge.SFN_Sin,id:4417,x:30136,y:32569,varname:node_4417,prsc:2|IN-5597-OUT;n:type:ShaderForge.SFN_Add,id:4097,x:31901,y:32928,varname:node_4097,prsc:2|A-4088-OUT,B-4551-OUT;n:type:ShaderForge.SFN_Add,id:8802,x:29775,y:32562,varname:node_8802,prsc:2|A-7545-TTR,B-8413-OUT;n:type:ShaderForge.SFN_Time,id:7545,x:29572,y:32454,varname:node_7545,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3838,x:30299,y:32569,varname:node_3838,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4417-OUT;n:type:ShaderForge.SFN_Set,id:3808,x:30307,y:31767,varname:DistanceMask,prsc:2|IN-6647-OUT;n:type:ShaderForge.SFN_Get,id:9690,x:30475,y:33023,varname:node_9690,prsc:2|IN-3808-OUT;n:type:ShaderForge.SFN_Get,id:8413,x:29551,y:32623,varname:node_8413,prsc:2|IN-3808-OUT;n:type:ShaderForge.SFN_Multiply,id:4088,x:31604,y:32800,varname:node_4088,prsc:2|A-405-OUT,B-4551-OUT;n:type:ShaderForge.SFN_Multiply,id:5597,x:29958,y:32600,varname:node_5597,prsc:2|A-8802-OUT,B-7356-OUT;n:type:ShaderForge.SFN_Add,id:5219,x:32419,y:33666,varname:node_5219,prsc:2|A-8291-OUT,B-4521-OUT,C-8485-OUT;n:type:ShaderForge.SFN_Set,id:3441,x:30458,y:32569,varname:Waves,prsc:2|IN-3838-OUT;n:type:ShaderForge.SFN_Get,id:752,x:31817,y:33944,varname:node_752,prsc:2|IN-3441-OUT;n:type:ShaderForge.SFN_Multiply,id:8485,x:32039,y:33878,varname:node_8485,prsc:2|A-4521-OUT,B-752-OUT;n:type:ShaderForge.SFN_Get,id:405,x:31329,y:32674,varname:node_405,prsc:2|IN-3441-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9798,x:30188,y:32222,varname:node_9798,prsc:2;n:type:ShaderForge.SFN_Append,id:8170,x:30789,y:32047,varname:node_8170,prsc:2|A-8828-OUT,B-4146-R;n:type:ShaderForge.SFN_Tex2d,id:7018,x:30972,y:32047,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_7018,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8170-OUT;n:type:ShaderForge.SFN_Multiply,id:8291,x:32038,y:33583,varname:node_8291,prsc:2|A-7998-OUT,B-4521-OUT,C-6849-OUT;n:type:ShaderForge.SFN_Subtract,id:8828,x:30405,y:31978,varname:node_8828,prsc:2|A-6242-OUT,B-7545-T;n:type:ShaderForge.SFN_Multiply,id:9993,x:32300,y:32667,varname:node_9993,prsc:2|A-6191-OUT,B-7233-OUT,C-4551-OUT;n:type:ShaderForge.SFN_Multiply,id:8058,x:33307,y:32627,varname:node_8058,prsc:2|A-797-RGB,B-9983-OUT,C-7309-OUT,D-6005-RGB;n:type:ShaderForge.SFN_Slider,id:5344,x:31236,y:31778,ptovrint:False,ptlb:Fresnel Exp 2,ptin:_FresnelExp2,varname:_FresnelExp_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Fresnel,id:6191,x:31571,y:31766,varname:node_6191,prsc:2|EXP-5344-OUT;n:type:ShaderForge.SFN_Multiply,id:7330,x:32300,y:32823,varname:node_7330,prsc:2|A-1970-OUT,B-4097-OUT;n:type:ShaderForge.SFN_Add,id:7309,x:32553,y:32754,varname:node_7309,prsc:2|A-9993-OUT,B-7330-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7356,x:29775,y:32714,ptovrint:False,ptlb:Wave Lenght,ptin:_WaveLenght,varname:node_7356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Set,id:1091,x:31139,y:32069,varname:NoiseMask,prsc:2|IN-7018-R;n:type:ShaderForge.SFN_Get,id:7233,x:32054,y:32677,varname:node_7233,prsc:2|IN-1091-OUT;n:type:ShaderForge.SFN_Get,id:7998,x:31681,y:33525,varname:node_7998,prsc:2|IN-1091-OUT;n:type:ShaderForge.SFN_Transform,id:1313,x:30362,y:32222,varname:node_1313,prsc:2,tffrom:0,tfto:1|IN-9798-XYZ;n:type:ShaderForge.SFN_ComponentMask,id:4146,x:30528,y:32222,varname:node_4146,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-1313-XYZ;n:type:ShaderForge.SFN_Vector1,id:6849,x:31702,y:33580,varname:node_6849,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:6005,x:32871,y:32932,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_6005,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-3682-OUT;n:type:ShaderForge.SFN_Append,id:3682,x:32592,y:33027,varname:node_3682,prsc:2|A-3573-OUT,B-1030-OUT;n:type:ShaderForge.SFN_Vector1,id:1030,x:32388,y:33099,varname:node_1030,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:6239,x:32191,y:33390,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_5692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-8496-UVOUT;n:type:ShaderForge.SFN_Append,id:7713,x:32376,y:33407,varname:node_7713,prsc:2|A-6239-R,B-6239-G;n:type:ShaderForge.SFN_Panner,id:8496,x:32021,y:33390,varname:node_8496,prsc:2,spu:0,spv:-0.5|UVIN-9942-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9942,x:31848,y:33390,varname:node_9942,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ObjectPosition,id:7053,x:29705,y:32154,varname:node_7053,prsc:2;n:type:ShaderForge.SFN_Subtract,id:3267,x:30001,y:32105,varname:node_3267,prsc:2|A-7053-XYZ,B-489-XYZ;n:type:ShaderForge.SFN_Cross,id:9133,x:30213,y:32028,varname:node_9133,prsc:2|A-489-XYZ,B-3267-OUT;n:type:ShaderForge.SFN_Add,id:3573,x:32243,y:33008,varname:node_3573,prsc:2|A-7309-OUT,B-4551-OUT;n:type:ShaderForge.SFN_TexCoord,id:5980,x:32168,y:33710,varname:node_5980,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:2019,x:30496,y:33101,ptovrint:False,ptlb:_DistanceOffsetScale,ptin:_DistanceOffsetScale,varname:node_2019,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:797-9983-8917-5344-4521-7018-7356-6005;pass:END;sub:END;*/

Shader "Sine VFX/MeshEnchant" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 4
        _FresnelExp ("Fresnel Exp", Range(0, 4)) = 1
        _FresnelExp2 ("Fresnel Exp 2", Range(0, 4)) = 1
        _OffsetPower ("Offset Power", Range(0, 0.1)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _WaveLenght ("Wave Lenght", Float ) = 0
        _Ramp ("Ramp", 2D) = "white" {}
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
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _TintColor;
            uniform float _OffsetPower;
            uniform float _FresnelExp;
            uniform float _FinalPower;
            uniform float4 _EnchantPoint;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _FresnelExp2;
            uniform float _WaveLenght;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _DistanceOffsetScale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_6242 = distance(_EnchantPoint.rgb,mul(unity_ObjectToWorld, v.vertex).rgb);
                float4 node_7545 = _Time;
                float2 node_8170 = float2((node_6242-node_7545.g),mul( unity_WorldToObject, float4(mul(unity_ObjectToWorld, v.vertex).rgb,0) ).xyz.rgb.rgb.r);
                float4 _Noise_var = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_8170, _Noise),0.0,0));
                float NoiseMask = _Noise_var.r;
                float DistanceMask = (1.0 - node_6242);
                float Waves = (sin(((node_7545.a+DistanceMask)*_WaveLenght))*0.5+0.5);
                v.vertex.xyz += (((NoiseMask*_OffsetPower*2.0)+_OffsetPower+(_OffsetPower*Waves))*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_6242 = distance(_EnchantPoint.rgb,i.posWorld.rgb);
                float4 node_7545 = _Time;
                float2 node_8170 = float2((node_6242-node_7545.g),mul( unity_WorldToObject, float4(i.posWorld.rgb,0) ).xyz.rgb.rgb.r);
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_8170, _Noise));
                float NoiseMask = _Noise_var.r;
                float node_2007 = (_DistanceOffsetScale+1.0);
                float DistanceMask = (1.0 - node_6242);
                float node_4551 = saturate(smoothstep( 0.0, node_2007, clamp((DistanceMask+_DistanceOffsetScale),0.0,node_2007) ));
                float Waves = (sin(((node_7545.a+DistanceMask)*_WaveLenght))*0.5+0.5);
                float node_7309 = ((pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExp2)*NoiseMask*node_4551)+(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExp)*((Waves*node_4551)+node_4551)));
                float2 node_3682 = float2((node_7309+node_4551),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3682, _Ramp));
                float3 emissive = (_TintColor.rgb*_FinalPower*node_7309*_Ramp_var.rgb);
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
