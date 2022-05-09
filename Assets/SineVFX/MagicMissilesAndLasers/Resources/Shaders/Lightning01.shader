// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33631,y:33130,varname:node_4795,prsc:2|emission-6013-OUT,voffset-9058-OUT;n:type:ShaderForge.SFN_Tex2d,id:4603,x:32195,y:32668,ptovrint:False,ptlb:Mask 01,ptin:_Mask01,varname:node_4603,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2735-OUT;n:type:ShaderForge.SFN_Multiply,id:8595,x:32518,y:32777,varname:node_8595,prsc:2|A-4603-R,B-1367-RGB,C-1318-OUT,D-3002-OUT;n:type:ShaderForge.SFN_Color,id:1367,x:32195,y:32854,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1367,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:1318,x:32038,y:33018,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_1318,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_TexCoord,id:1067,x:31029,y:32571,varname:node_1067,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:4118,x:30503,y:33613,varname:node_4118,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4407,x:30713,y:33686,varname:node_4407,prsc:2|A-4118-T,B-8349-OUT;n:type:ShaderForge.SFN_Slider,id:8349,x:30346,y:33760,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_8349,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:4;n:type:ShaderForge.SFN_Add,id:2735,x:31962,y:32699,varname:node_2735,prsc:2|A-1067-UVOUT,B-2043-OUT;n:type:ShaderForge.SFN_Tex2d,id:2298,x:31224,y:33249,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_2298,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9931-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2043,x:31643,y:33363,varname:node_2043,prsc:2|A-9668-OUT,B-7210-OUT,C-5206-A,D-1758-R;n:type:ShaderForge.SFN_Slider,id:7210,x:31224,y:33431,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_7210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_RemapRange,id:9668,x:31391,y:33249,varname:node_9668,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2298-R;n:type:ShaderForge.SFN_VertexColor,id:765,x:32195,y:33098,varname:node_765,prsc:2;n:type:ShaderForge.SFN_VertexColor,id:5206,x:31381,y:33515,varname:node_5206,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:4882,x:30374,y:33246,varname:node_4882,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9931,x:31049,y:33249,varname:node_9931,prsc:2,spu:0.25,spv:0|UVIN-995-OUT,DIST-4407-OUT;n:type:ShaderForge.SFN_Add,id:89,x:30607,y:33288,varname:node_89,prsc:2|A-4882-U,B-4434-OUT;n:type:ShaderForge.SFN_Append,id:995,x:30812,y:33302,varname:node_995,prsc:2|A-89-OUT,B-4882-V;n:type:ShaderForge.SFN_VertexColor,id:9987,x:30109,y:33406,varname:node_9987,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:7582,x:32214,y:33303,varname:node_7582,prsc:2|IN-765-A;n:type:ShaderForge.SFN_Tex2d,id:2578,x:32344,y:33629,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_2578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6013,x:32904,y:32868,varname:node_6013,prsc:2|A-8595-OUT,B-9946-OUT,C-765-R;n:type:ShaderForge.SFN_OneMinus,id:9946,x:32508,y:33646,varname:node_9946,prsc:2|IN-2578-R;n:type:ShaderForge.SFN_Multiply,id:4434,x:30325,y:33483,varname:node_4434,prsc:2|A-9987-G,B-8584-OUT;n:type:ShaderForge.SFN_Vector1,id:8584,x:30109,y:33535,varname:node_8584,prsc:2,v1:25;n:type:ShaderForge.SFN_Tex2d,id:1758,x:31381,y:33669,ptovrint:False,ptlb:Mask 02,ptin:_Mask02,varname:node_1758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3002,x:32457,y:33290,varname:node_3002,prsc:2|A-7582-OUT,B-7582-OUT,C-7582-OUT,D-7582-OUT,E-3062-OUT;n:type:ShaderForge.SFN_Vector1,id:3062,x:32214,y:33432,varname:node_3062,prsc:2,v1:8;n:type:ShaderForge.SFN_Multiply,id:9058,x:32921,y:34129,varname:node_9058,prsc:2|A-2618-OUT,B-4044-OUT,C-9777-OUT;n:type:ShaderForge.SFN_Slider,id:4044,x:32448,y:34417,ptovrint:False,ptlb:Offset To Center,ptin:_OffsetToCenter,varname:node_4044,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:2160,x:32149,y:34021,varname:node_2160,prsc:2;n:type:ShaderForge.SFN_Subtract,id:2618,x:32600,y:34114,varname:node_2618,prsc:2|A-242-OUT,B-2160-XYZ;n:type:ShaderForge.SFN_Vector3,id:242,x:32149,y:34189,varname:node_242,prsc:2,v1:-9.04,v2:2.342,v3:-5.35;n:type:ShaderForge.SFN_Tex2d,id:7268,x:32370,y:33841,ptovrint:False,ptlb:Offset Mask,ptin:_OffsetMask,varname:node_7268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:9777,x:32544,y:33841,varname:node_9777,prsc:2|IN-7268-R;proporder:4603-1367-1318-8349-2298-7210-2578-1758-4044-7268;pass:END;sub:END;*/

Shader "Sine VFX/Lightning01" {
    Properties {
        _Mask01 ("Mask 01", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 2
        _ScrollSpeed ("Scroll Speed", Range(0, 4)) = 0.5
        _Distortion ("Distortion", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 1)) = 0.1
        _Mask ("Mask", 2D) = "white" {}
        _Mask02 ("Mask 02", 2D) = "white" {}
        _OffsetToCenter ("Offset To Center", Range(0, 1)) = 0.1
        _OffsetMask ("Offset Mask", 2D) = "white" {}
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
            uniform sampler2D _Mask01; uniform float4 _Mask01_ST;
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform float _ScrollSpeed;
            uniform sampler2D _Distortion; uniform float4 _Distortion_ST;
            uniform float _DistortionPower;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Mask02; uniform float4 _Mask02_ST;
            uniform float _OffsetToCenter;
            uniform sampler2D _OffsetMask; uniform float4 _OffsetMask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 _OffsetMask_var = tex2Dlod(_OffsetMask,float4(TRANSFORM_TEX(o.uv0, _OffsetMask),0.0,0));
                v.vertex.xyz += ((float3(-9.04,2.342,-5.35)-mul(unity_ObjectToWorld, v.vertex).rgb)*_OffsetToCenter*(1.0 - _OffsetMask_var.r));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_4118 = _Time;
                float2 node_9931 = (float2((i.uv0.r+(i.vertexColor.g*25.0)),i.uv0.g)+(node_4118.g*_ScrollSpeed)*float2(0.25,0));
                float4 _Distortion_var = tex2D(_Distortion,TRANSFORM_TEX(node_9931, _Distortion));
                float4 _Mask02_var = tex2D(_Mask02,TRANSFORM_TEX(i.uv0, _Mask02));
                float2 node_2735 = (i.uv0+((_Distortion_var.r*2.0+-1.0)*_DistortionPower*i.vertexColor.a*_Mask02_var.r));
                float4 _Mask01_var = tex2D(_Mask01,TRANSFORM_TEX(node_2735, _Mask01));
                float node_7582 = (1.0 - i.vertexColor.a);
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((_Mask01_var.r*_Color.rgb*_FinalPower*(node_7582*node_7582*node_7582*node_7582*8.0))*(1.0 - _Mask_var.r)*i.vertexColor.r);
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
