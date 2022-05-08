// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33281,y:32724,varname:node_4795,prsc:2|emission-1284-OUT,alpha-9783-OUT;n:type:ShaderForge.SFN_TexCoord,id:887,x:29793,y:32527,varname:node_887,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:8579,x:29958,y:32527,varname:node_8579,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-887-UVOUT;n:type:ShaderForge.SFN_Length,id:1104,x:30353,y:32526,varname:node_1104,prsc:2|IN-7364-OUT;n:type:ShaderForge.SFN_OneMinus,id:4931,x:30519,y:32526,varname:node_4931,prsc:2|IN-1104-OUT;n:type:ShaderForge.SFN_ArcTan2,id:1472,x:30353,y:32661,varname:node_1472,prsc:2,attp:2|A-7364-R,B-7364-G;n:type:ShaderForge.SFN_ComponentMask,id:7364,x:30134,y:32526,varname:node_7364,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8579-OUT;n:type:ShaderForge.SFN_Append,id:931,x:31364,y:32628,varname:node_931,prsc:2|A-8856-OUT,B-1472-OUT;n:type:ShaderForge.SFN_Tex2d,id:3175,x:31535,y:32628,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_3175,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-931-OUT;n:type:ShaderForge.SFN_Append,id:7365,x:32078,y:32710,varname:node_7365,prsc:2|A-2060-OUT,B-8121-OUT;n:type:ShaderForge.SFN_Vector1,id:8121,x:31535,y:32788,varname:node_8121,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:3878,x:32249,y:32710,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_3878,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7365-OUT;n:type:ShaderForge.SFN_Multiply,id:1284,x:32540,y:32864,varname:node_1284,prsc:2|A-3878-RGB,B-572-RGB,C-6250-OUT,D-3692-R,E-5813-R;n:type:ShaderForge.SFN_Color,id:572,x:32249,y:32895,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_572,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:6250,x:32092,y:33062,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_6250,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_Slider,id:2047,x:32100,y:33507,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_2047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Multiply,id:1556,x:32539,y:33160,varname:node_1556,prsc:2|A-2060-OUT,B-2047-OUT,C-3692-R,D-5813-R;n:type:ShaderForge.SFN_Add,id:8856,x:30822,y:32466,varname:node_8856,prsc:2|A-8411-OUT,B-4931-OUT,C-8698-W,D-9493-OUT;n:type:ShaderForge.SFN_Time,id:1025,x:30170,y:32321,varname:node_1025,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8411,x:30519,y:32388,varname:node_8411,prsc:2|A-6400-OUT,B-1025-T;n:type:ShaderForge.SFN_ValueProperty,id:6400,x:30170,y:32269,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_6400,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:7362,x:31006,y:32720,varname:node_7362,prsc:2|A-4931-OUT,B-1472-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8352,x:31227,y:33541,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_8352,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3692,x:32249,y:33153,varname:node_3692,prsc:2,ntxv:0,isnm:False|UVIN-7362-OUT,TEX-8352-TEX;n:type:ShaderForge.SFN_Tex2d,id:5813,x:32249,y:33296,varname:node_5813,prsc:2,ntxv:0,isnm:False|UVIN-3623-OUT,TEX-8352-TEX;n:type:ShaderForge.SFN_VertexColor,id:6320,x:30598,y:33091,varname:node_6320,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4191,x:31014,y:32901,varname:node_4191,prsc:2|A-4931-OUT,B-9594-OUT;n:type:ShaderForge.SFN_Vector1,id:9594,x:30826,y:32972,varname:node_9594,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:4775,x:31201,y:32948,varname:node_4775,prsc:2|A-4191-OUT,B-5097-OUT;n:type:ShaderForge.SFN_Multiply,id:5097,x:30976,y:33192,varname:node_5097,prsc:2|A-4731-OUT,B-7865-OUT;n:type:ShaderForge.SFN_Vector1,id:7865,x:30779,y:33226,varname:node_7865,prsc:2,v1:2;n:type:ShaderForge.SFN_Append,id:3623,x:31402,y:32995,varname:node_3623,prsc:2|A-4775-OUT,B-1472-OUT;n:type:ShaderForge.SFN_OneMinus,id:4731,x:30779,y:33091,varname:node_4731,prsc:2|IN-8698-Z;n:type:ShaderForge.SFN_TexCoord,id:8698,x:30239,y:33047,varname:node_8698,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Multiply,id:2060,x:31748,y:32596,varname:node_2060,prsc:2|A-6238-OUT,B-3175-R;n:type:ShaderForge.SFN_ValueProperty,id:6238,x:31535,y:32541,ptovrint:False,ptlb:Texture Power,ptin:_TexturePower,varname:node_6238,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Clamp01,id:9783,x:32710,y:33160,varname:node_9783,prsc:2|IN-1556-OUT;n:type:ShaderForge.SFN_Tex2d,id:4774,x:29750,y:32786,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_4774,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9493,x:30182,y:32883,varname:node_9493,prsc:2|A-8082-OUT,B-565-OUT;n:type:ShaderForge.SFN_Slider,id:565,x:29788,y:32997,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_565,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_RemapRange,id:8082,x:29945,y:32804,varname:node_8082,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4774-R;proporder:3175-2047-3878-572-6250-6400-8352-6238-4774-565;pass:END;sub:END;*/

Shader "Sine VFX/RadialQuadExplosion" {
    Properties {
        _Noise01 ("Noise 01", 2D) = "white" {}
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 2
        _Ramp ("Ramp", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 2
        _ScrollSpeed ("Scroll Speed", Float ) = 0
        _Mask ("Mask", 2D) = "white" {}
        _TexturePower ("Texture Power", Float ) = 2
        _Distortion ("Distortion", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 1)) = 0.1
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
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform float _OpacityBoost;
            uniform float _ScrollSpeed;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _TexturePower;
            uniform sampler2D _Distortion; uniform float4 _Distortion_ST;
            uniform float _DistortionPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_1025 = _Time;
                float2 node_7364 = (i.uv0*2.0+-1.0).rg;
                float node_4931 = (1.0 - length(node_7364));
                float4 _Distortion_var = tex2D(_Distortion,TRANSFORM_TEX(i.uv0, _Distortion));
                float node_1472 = ((atan2(node_7364.r,node_7364.g)/6.28318530718)+0.5);
                float2 node_931 = float2(((_ScrollSpeed*node_1025.g)+node_4931+i.uv0.a+((_Distortion_var.r*2.0+-1.0)*_DistortionPower)),node_1472);
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_931, _Noise01));
                float node_2060 = (_TexturePower*_Noise01_var.r);
                float2 node_7365 = float2(node_2060,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_7365, _Ramp));
                float2 node_7362 = float2(node_4931,node_1472);
                float4 node_3692 = tex2D(_Mask,TRANSFORM_TEX(node_7362, _Mask));
                float2 node_3623 = float2(((node_4931-1.0)+((1.0 - i.uv0.b)*2.0)),node_1472);
                float4 node_5813 = tex2D(_Mask,TRANSFORM_TEX(node_3623, _Mask));
                float3 emissive = (_Ramp_var.rgb*_Color.rgb*_FinalPower*node_3692.r*node_5813.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_2060*_OpacityBoost*node_3692.r*node_5813.r)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
