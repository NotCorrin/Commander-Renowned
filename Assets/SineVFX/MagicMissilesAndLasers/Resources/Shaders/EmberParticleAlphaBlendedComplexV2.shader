// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33283,y:32684,varname:node_4795,prsc:2|emission-3740-OUT,alpha-5052-OUT;n:type:ShaderForge.SFN_Tex2d,id:8372,x:32257,y:32678,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_8372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-3897-OUT;n:type:ShaderForge.SFN_Tex2d,id:7336,x:30935,y:32459,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_7336,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0dd9474e9eb343949a507099c441e538,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:3897,x:32088,y:32678,varname:node_3897,prsc:2|A-6517-OUT,B-446-OUT;n:type:ShaderForge.SFN_Vector1,id:446,x:31892,y:32760,varname:node_446,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:3740,x:32517,y:32735,varname:node_3740,prsc:2|A-8372-RGB,B-83-OUT,C-1056-RGB,D-1290-R;n:type:ShaderForge.SFN_Slider,id:83,x:32100,y:32863,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_83,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Subtract,id:1257,x:31564,y:32543,varname:node_1257,prsc:2|A-6587-OUT,B-4518-OUT;n:type:ShaderForge.SFN_VertexColor,id:8819,x:31150,y:32726,varname:node_8819,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:4518,x:31333,y:32726,varname:node_4518,prsc:2|IN-8819-A;n:type:ShaderForge.SFN_Clamp01,id:6517,x:31735,y:32543,varname:node_6517,prsc:2|IN-1257-OUT;n:type:ShaderForge.SFN_Color,id:1056,x:32257,y:32505,ptovrint:False,ptlb:Fire Color,ptin:_FireColor,varname:node_1056,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9790,x:32547,y:33117,varname:node_9790,prsc:2|A-6517-OUT,B-9859-OUT,C-1290-R;n:type:ShaderForge.SFN_Slider,id:9859,x:32081,y:33254,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9859,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:4;n:type:ShaderForge.SFN_Clamp01,id:5052,x:32876,y:33117,varname:node_5052,prsc:2|IN-4183-OUT;n:type:ShaderForge.SFN_Tex2d,id:1290,x:32081,y:33034,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_1290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b5fb2c87ff6949440be8a1420b9af71a,ntxv:0,isnm:False|UVIN-8209-OUT;n:type:ShaderForge.SFN_TexCoord,id:6415,x:31251,y:33016,varname:node_6415,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Add,id:6916,x:31590,y:33131,varname:node_6916,prsc:2|A-6415-U,B-6415-Z,C-7856-OUT;n:type:ShaderForge.SFN_Append,id:8209,x:31908,y:33034,varname:node_8209,prsc:2|A-6916-OUT,B-6415-V;n:type:ShaderForge.SFN_Time,id:9892,x:31038,y:33201,varname:node_9892,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7856,x:31286,y:33250,varname:node_7856,prsc:2|A-9892-T,B-1996-OUT;n:type:ShaderForge.SFN_Slider,id:1996,x:30881,y:33342,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_1996,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:4183,x:32715,y:33117,varname:node_4183,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9790-OUT;n:type:ShaderForge.SFN_TexCoord,id:159,x:32424,y:33966,varname:node_159,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3260,x:31148,y:32422,varname:node_3260,prsc:2|A-3133-OUT,B-7336-R;n:type:ShaderForge.SFN_Slider,id:3133,x:30778,y:32344,ptovrint:False,ptlb:Mask Power,ptin:_MaskPower,varname:node_3133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Clamp01,id:6587,x:31323,y:32422,varname:node_6587,prsc:2|IN-3260-OUT;proporder:8372-7336-83-1056-9859-1290-1996-3133;pass:END;sub:END;*/

Shader "Sine VFX/EmberParticleAlphaBlendedComplexV2" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 10)) = 0
        _FireColor ("Fire Color", Color) = (0.5,0.5,0.5,1)
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 4
        _Noise01 ("Noise 01", 2D) = "white" {}
        _ScrollSpeed ("Scroll Speed", Range(-1, 1)) = 1
        _MaskPower ("Mask Power", Range(0, 4)) = 2
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
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _FinalPower;
            uniform float4 _FireColor;
            uniform float _OpacityBoost;
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform float _ScrollSpeed;
            uniform float _MaskPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_6517 = saturate((saturate((_MaskPower*_Mask_var.r))-(1.0 - i.vertexColor.a)));
                float2 node_3897 = float2(node_6517,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3897, _Ramp));
                float4 node_9892 = _Time;
                float2 node_8209 = float2((i.uv0.r+i.uv0.b+(node_9892.g*_ScrollSpeed)),i.uv0.g);
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_8209, _Noise01));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_FireColor.rgb*_Noise01_var.r);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate(((node_6517*_OpacityBoost*_Noise01_var.r)*2.0+-1.0)));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
