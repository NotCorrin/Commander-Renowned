// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32653,varname:node_4795,prsc:2|emission-8013-OUT,alpha-8910-OUT,clip-2614-OUT,voffset-4910-OUT;n:type:ShaderForge.SFN_Tex2d,id:7507,x:31838,y:32299,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_7507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6857-OUT;n:type:ShaderForge.SFN_Multiply,id:8013,x:32121,y:32427,varname:node_8013,prsc:2|A-7507-RGB,B-775-R,C-5941-RGB,D-7371-OUT;n:type:ShaderForge.SFN_Tex2d,id:775,x:31838,y:32478,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_775,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5941,x:31838,y:32660,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:7371,x:31681,y:32825,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_7371,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_Tex2d,id:1344,x:30890,y:32297,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_1344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4575-UVOUT;n:type:ShaderForge.SFN_Panner,id:4575,x:30720,y:32297,varname:node_4575,prsc:2,spu:0,spv:1|UVIN-7717-UVOUT,DIST-6167-OUT;n:type:ShaderForge.SFN_Time,id:8289,x:30274,y:32328,varname:node_8289,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6167,x:30472,y:32386,varname:node_6167,prsc:2|A-8289-T,B-3490-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3490,x:30274,y:32466,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_3490,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_TexCoord,id:7717,x:30472,y:32233,varname:node_7717,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:6857,x:31664,y:32299,varname:node_6857,prsc:2|A-8577-OUT,B-6577-OUT;n:type:ShaderForge.SFN_Vector1,id:6577,x:31487,y:32333,varname:node_6577,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:8910,x:32095,y:32964,varname:node_8910,prsc:2|A-2846-OUT,B-6554-OUT,C-775-R;n:type:ShaderForge.SFN_Slider,id:6554,x:31681,y:33063,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_6554,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Multiply,id:4910,x:32099,y:33238,varname:node_4910,prsc:2|A-5694-OUT,B-9293-OUT,C-8343-OUT;n:type:ShaderForge.SFN_NormalVector,id:9293,x:31830,y:33301,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:8343,x:31673,y:33468,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_8343,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Set,id:6740,x:31169,y:32242,varname:Result,prsc:2|IN-1344-R;n:type:ShaderForge.SFN_Get,id:8577,x:31466,y:32280,varname:node_8577,prsc:2|IN-6740-OUT;n:type:ShaderForge.SFN_Get,id:2846,x:31803,y:32981,varname:node_2846,prsc:2|IN-6740-OUT;n:type:ShaderForge.SFN_Get,id:5694,x:31809,y:33249,varname:node_5694,prsc:2|IN-6740-OUT;n:type:ShaderForge.SFN_Tex2d,id:7425,x:31516,y:33897,ptovrint:False,ptlb:Opacity Cutoff,ptin:_OpacityCutoff,varname:node_6065,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Subtract,id:2614,x:32133,y:33901,varname:node_2614,prsc:2|A-6580-OUT,B-5884-OUT;n:type:ShaderForge.SFN_OneMinus,id:5884,x:31516,y:33701,varname:node_5884,prsc:2|IN-4672-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6580,x:31784,y:33964,varname:node_6580,prsc:2|IN-7425-R,IMIN-8935-OUT,IMAX-1945-OUT,OMIN-354-OUT,OMAX-3750-OUT;n:type:ShaderForge.SFN_Vector1,id:8935,x:31516,y:34062,varname:node_8935,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1945,x:31516,y:34128,varname:node_1945,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:354,x:31516,y:34208,ptovrint:False,ptlb:Opacity Remap 1,ptin:_OpacityRemap1,varname:node_714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:3750,x:31516,y:34284,ptovrint:False,ptlb:Opacity Remap 2,ptin:_OpacityRemap2,varname:_OpacityRemap2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Slider,id:5736,x:30465,y:33551,ptovrint:False,ptlb:Progress,ptin:_Progress,varname:node_5736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:4672,x:30781,y:33551,varname:node_4672,prsc:2|IN-5736-OUT;proporder:7507-775-5941-7371-1344-3490-6554-8343-7425-354-3750-5736;pass:END;sub:END;*/

Shader "Sine VFX/LaserConMesh" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 2
        _Noise01 ("Noise 01", 2D) = "white" {}
        _ScrollSpeed ("Scroll Speed", Float ) = 0
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 2
        _OffsetPower ("Offset Power", Range(0, 1)) = 0.1
        _OpacityCutoff ("Opacity Cutoff", 2D) = "white" {}
        _OpacityRemap1 ("Opacity Remap 1", Float ) = 0
        _OpacityRemap2 ("Opacity Remap 2", Float ) = 0
        _Progress ("Progress", Range(0, 1)) = 0
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
            Cull Off
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
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform float _ScrollSpeed;
            uniform float _OpacityBoost;
            uniform float _OffsetPower;
            uniform sampler2D _OpacityCutoff; uniform float4 _OpacityCutoff_ST;
            uniform float _OpacityRemap1;
            uniform float _OpacityRemap2;
            uniform float _Progress;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_8289 = _Time;
                float2 node_4575 = (o.uv0+(node_8289.g*_ScrollSpeed)*float2(0,1));
                float4 _Noise01_var = tex2Dlod(_Noise01,float4(TRANSFORM_TEX(node_4575, _Noise01),0.0,0));
                float Result = _Noise01_var.r;
                v.vertex.xyz += (Result*v.normal*_OffsetPower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _OpacityCutoff_var = tex2D(_OpacityCutoff,TRANSFORM_TEX(i.uv0, _OpacityCutoff));
                float node_8935 = 0.0;
                clip(((_OpacityRemap1 + ( (_OpacityCutoff_var.r - node_8935) * (_OpacityRemap2 - _OpacityRemap1) ) / (1.0 - node_8935))-(1.0 - saturate(_Progress))) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_8289 = _Time;
                float2 node_4575 = (i.uv0+(node_8289.g*_ScrollSpeed)*float2(0,1));
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_4575, _Noise01));
                float Result = _Noise01_var.r;
                float2 node_6857 = float2(Result,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_6857, _Ramp));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = (_Ramp_var.rgb*_Mask_var.r*_Color.rgb*_FinalPower);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(Result*_OpacityBoost*_Mask_var.r));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
