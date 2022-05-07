// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33478,y:32715,varname:node_4795,prsc:2|emission-5837-OUT,alpha-283-OUT,clip-873-OUT;n:type:ShaderForge.SFN_Tex2d,id:6816,x:30192,y:32927,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_6816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3921-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3578,x:32377,y:33212,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_3578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9305,x:32373,y:32754,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_9305,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3662-OUT;n:type:ShaderForge.SFN_Append,id:3662,x:32201,y:32754,varname:node_3662,prsc:2|A-3560-OUT,B-7633-OUT;n:type:ShaderForge.SFN_Vector1,id:7633,x:32004,y:32852,varname:node_7633,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:5837,x:32616,y:32848,varname:node_5837,prsc:2|A-9305-RGB,B-5344-RGB,C-4712-OUT,D-3578-R;n:type:ShaderForge.SFN_Color,id:5344,x:32373,y:32931,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:4712,x:32220,y:33107,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_4712,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_TexCoord,id:1327,x:29259,y:32799,varname:node_1327,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1959,x:32657,y:33420,varname:node_1959,prsc:2|A-3560-OUT,B-9542-OUT,C-3578-R;n:type:ShaderForge.SFN_Slider,id:9542,x:32220,y:33400,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Tex2d,id:7447,x:30192,y:32736,ptovrint:False,ptlb:Noise 02,ptin:_Noise02,varname:node_7447,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9458-UVOUT;n:type:ShaderForge.SFN_Clamp01,id:1684,x:31970,y:34075,varname:node_1684,prsc:2|IN-7206-OUT;n:type:ShaderForge.SFN_Clamp01,id:283,x:32826,y:33420,varname:node_283,prsc:2|IN-1959-OUT;n:type:ShaderForge.SFN_Slider,id:7206,x:31644,y:34075,ptovrint:False,ptlb:Progress,ptin:_Progress,varname:node_7206,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:6065,x:32153,y:34271,ptovrint:False,ptlb:Opacity Cutoff,ptin:_OpacityCutoff,varname:node_6065,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Subtract,id:4324,x:32770,y:34275,varname:node_4324,prsc:2|A-9647-OUT,B-8697-OUT;n:type:ShaderForge.SFN_OneMinus,id:8697,x:32153,y:34075,varname:node_8697,prsc:2|IN-1684-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9647,x:32421,y:34338,varname:node_9647,prsc:2|IN-6065-R,IMIN-2147-OUT,IMAX-3508-OUT,OMIN-714-OUT,OMAX-5909-OUT;n:type:ShaderForge.SFN_Vector1,id:2147,x:32153,y:34436,varname:node_2147,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3508,x:32153,y:34502,varname:node_3508,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:714,x:32153,y:34582,ptovrint:False,ptlb:Opacity Remap 1,ptin:_OpacityRemap1,varname:node_714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:5909,x:32153,y:34658,ptovrint:False,ptlb:Opacity Remap 2,ptin:_OpacityRemap2,varname:_OpacityRemap2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:6617,x:31213,y:32875,varname:node_6617,prsc:2|A-7454-OUT,B-6816-R,C-9560-OUT;n:type:ShaderForge.SFN_Panner,id:9458,x:29586,y:32719,varname:node_9458,prsc:2,spu:-1,spv:0|UVIN-1327-UVOUT,DIST-6858-OUT;n:type:ShaderForge.SFN_Panner,id:3921,x:29586,y:32886,varname:node_3921,prsc:2,spu:-1,spv:0|UVIN-1327-UVOUT,DIST-7688-OUT;n:type:ShaderForge.SFN_Time,id:1480,x:28902,y:32777,varname:node_1480,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6858,x:29259,y:32570,varname:node_6858,prsc:2|A-1480-T,B-8212-OUT;n:type:ShaderForge.SFN_Multiply,id:7688,x:29259,y:33011,varname:node_7688,prsc:2|A-2840-OUT,B-1480-T;n:type:ShaderForge.SFN_ValueProperty,id:2840,x:28902,y:32926,ptovrint:False,ptlb:Noise 1 Scroll Speed,ptin:_Noise1ScrollSpeed,varname:node_2840,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8212,x:28902,y:32714,ptovrint:False,ptlb:Noise 2 Scroll Speed,ptin:_Noise2ScrollSpeed,varname:_Noise1ScrollSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:9579,x:31472,y:32932,varname:node_9579,prsc:2|A-6617-OUT,B-7732-OUT;n:type:ShaderForge.SFN_Tex2d,id:7760,x:30192,y:33117,ptovrint:False,ptlb:Core,ptin:_Core,varname:node_7760,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Clamp01,id:3560,x:31712,y:32932,varname:node_3560,prsc:2|IN-9579-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6516,x:30192,y:32642,ptovrint:False,ptlb:Noise Boost,ptin:_NoiseBoost,varname:node_6516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:7732,x:31225,y:33087,varname:node_7732,prsc:2|A-7760-R,B-7454-OUT;n:type:ShaderForge.SFN_Tex2d,id:8385,x:30192,y:33309,ptovrint:False,ptlb:Noise 03 Core,ptin:_Noise03Core,varname:node_8385,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2221-UVOUT;n:type:ShaderForge.SFN_Panner,id:2221,x:29595,y:33263,varname:node_2221,prsc:2,spu:-1,spv:0|UVIN-1327-UVOUT,DIST-4858-OUT;n:type:ShaderForge.SFN_Multiply,id:4858,x:29270,y:33280,varname:node_4858,prsc:2|A-1480-T,B-4140-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4140,x:28913,y:33281,ptovrint:False,ptlb:Noise 3 Core Scroll Speed,ptin:_Noise3CoreScrollSpeed,varname:node_4140,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:6910,x:30398,y:33372,varname:node_6910,prsc:2|A-8385-R,B-308-OUT;n:type:ShaderForge.SFN_ValueProperty,id:308,x:30192,y:33494,ptovrint:False,ptlb:Noise Core Add,ptin:_NoiseCoreAdd,varname:node_308,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:7454,x:30556,y:33372,varname:node_7454,prsc:2|IN-6910-OUT;n:type:ShaderForge.SFN_Multiply,id:2304,x:30498,y:32706,varname:node_2304,prsc:2|A-6516-OUT,B-7447-R;n:type:ShaderForge.SFN_Clamp01,id:9560,x:30675,y:32706,varname:node_9560,prsc:2|IN-2304-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6531,x:31959,y:33600,ptovrint:False,ptlb:_Distance,ptin:_Distance,varname:node_6531,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_If,id:5700,x:32230,y:33526,varname:node_5700,prsc:2|A-8521-OUT,B-6531-OUT,GT-8419-OUT,EQ-8419-OUT,LT-679-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:789,x:31691,y:33379,varname:node_789,prsc:2;n:type:ShaderForge.SFN_Distance,id:8521,x:31959,y:33444,varname:node_8521,prsc:2|A-789-XYZ,B-9510-XYZ;n:type:ShaderForge.SFN_Vector1,id:8419,x:31959,y:33664,varname:node_8419,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:679,x:31959,y:33728,varname:node_679,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:873,x:32988,y:33782,varname:node_873,prsc:2|A-5700-OUT,B-4324-OUT;n:type:ShaderForge.SFN_Vector4Property,id:9510,x:31691,y:33531,ptovrint:False,ptlb:_Position,ptin:_Position,varname:node_9510,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_Add,id:437,x:29919,y:32810,varname:node_437,prsc:2|A-9458-UVOUT,B-4889-OUT;n:type:ShaderForge.SFN_Add,id:5138,x:29904,y:33032,varname:node_5138,prsc:2|A-3921-UVOUT,B-4889-OUT;n:type:ShaderForge.SFN_Add,id:6836,x:29910,y:33344,varname:node_6836,prsc:2|A-2221-UVOUT,B-4889-OUT;n:type:ShaderForge.SFN_Tex2d,id:4674,x:29270,y:33495,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_4674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4889,x:29509,y:33552,varname:node_4889,prsc:2|A-4674-R,B-3485-OUT;n:type:ShaderForge.SFN_Slider,id:3485,x:29113,y:33671,ptovrint:False,ptlb:Distortion Amount,ptin:_DistortionAmount,varname:node_3485,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;proporder:6065-6816-7447-8385-3578-7760-9305-5344-4712-9542-7206-714-5909-2840-8212-4140-6516-308-4674-3485;pass:END;sub:END;*/

Shader "Sine VFX/Laser_v02Con" {
    Properties {
        _OpacityCutoff ("Opacity Cutoff", 2D) = "white" {}
        _Noise01 ("Noise 01", 2D) = "white" {}
        _Noise02 ("Noise 02", 2D) = "white" {}
        _Noise03Core ("Noise 03 Core", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Core ("Core", 2D) = "white" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 2
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 2
        _Progress ("Progress", Range(0, 1)) = 0
        _OpacityRemap1 ("Opacity Remap 1", Float ) = 0
        _OpacityRemap2 ("Opacity Remap 2", Float ) = 0
        _Noise1ScrollSpeed ("Noise 1 Scroll Speed", Float ) = 0
        _Noise2ScrollSpeed ("Noise 2 Scroll Speed", Float ) = 0
        _Noise3CoreScrollSpeed ("Noise 3 Core Scroll Speed", Float ) = 0
        _NoiseBoost ("Noise Boost", Float ) = 2
        _NoiseCoreAdd ("Noise Core Add", Float ) = 0.5
        _Distortion ("Distortion", 2D) = "white" {}
        _DistortionAmount ("Distortion Amount", Range(0, 1)) = 0.1
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform float _OpacityBoost;
            uniform sampler2D _Noise02; uniform float4 _Noise02_ST;
            uniform float _Progress;
            uniform sampler2D _OpacityCutoff; uniform float4 _OpacityCutoff_ST;
            uniform float _OpacityRemap1;
            uniform float _OpacityRemap2;
            uniform float _Noise1ScrollSpeed;
            uniform float _Noise2ScrollSpeed;
            uniform sampler2D _Core; uniform float4 _Core_ST;
            uniform float _NoiseBoost;
            uniform sampler2D _Noise03Core; uniform float4 _Noise03Core_ST;
            uniform float _Noise3CoreScrollSpeed;
            uniform float _NoiseCoreAdd;
            uniform float _Distance;
            uniform float4 _Position;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_5700_if_leA = step(distance(i.posWorld.rgb,_Position.rgb),_Distance);
                float node_5700_if_leB = step(_Distance,distance(i.posWorld.rgb,_Position.rgb));
                float node_8419 = 0.0;
                float4 _OpacityCutoff_var = tex2D(_OpacityCutoff,TRANSFORM_TEX(i.uv0, _OpacityCutoff));
                float node_2147 = 0.0;
                clip((lerp((node_5700_if_leA*1.0)+(node_5700_if_leB*node_8419),node_8419,node_5700_if_leA*node_5700_if_leB)*((_OpacityRemap1 + ( (_OpacityCutoff_var.r - node_2147) * (_OpacityRemap2 - _OpacityRemap1) ) / (1.0 - node_2147))-(1.0 - saturate(_Progress)))) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_1480 = _Time;
                float2 node_2221 = (i.uv0+(node_1480.g*_Noise3CoreScrollSpeed)*float2(-1,0));
                float4 _Noise03Core_var = tex2D(_Noise03Core,TRANSFORM_TEX(node_2221, _Noise03Core));
                float node_7454 = saturate((_Noise03Core_var.r+_NoiseCoreAdd));
                float2 node_3921 = (i.uv0+(_Noise1ScrollSpeed*node_1480.g)*float2(-1,0));
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_3921, _Noise01));
                float2 node_9458 = (i.uv0+(node_1480.g*_Noise2ScrollSpeed)*float2(-1,0));
                float4 _Noise02_var = tex2D(_Noise02,TRANSFORM_TEX(node_9458, _Noise02));
                float4 _Core_var = tex2D(_Core,TRANSFORM_TEX(i.uv0, _Core));
                float node_3560 = saturate(((node_7454*_Noise01_var.r*saturate((_NoiseBoost*_Noise02_var.r)))+(_Core_var.r*node_7454)));
                float2 node_3662 = float2(node_3560,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3662, _Ramp));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = (_Ramp_var.rgb*_Color.rgb*_FinalPower*_Mask_var.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_3560*_OpacityBoost*_Mask_var.r)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
