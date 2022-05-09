// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33010,y:32682,varname:node_4795,prsc:2|emission-3740-OUT;n:type:ShaderForge.SFN_Tex2d,id:8372,x:32257,y:32678,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_8372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-3897-OUT;n:type:ShaderForge.SFN_Tex2d,id:7336,x:31362,y:32504,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_7336,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0dd9474e9eb343949a507099c441e538,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:3897,x:32088,y:32678,varname:node_3897,prsc:2|A-6517-OUT,B-446-OUT;n:type:ShaderForge.SFN_Vector1,id:446,x:31892,y:32760,varname:node_446,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:3740,x:32517,y:32735,varname:node_3740,prsc:2|A-8372-RGB,B-83-OUT,C-1056-RGB;n:type:ShaderForge.SFN_Slider,id:83,x:32100,y:32863,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_83,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Subtract,id:1257,x:31564,y:32543,varname:node_1257,prsc:2|A-7336-R,B-4518-OUT;n:type:ShaderForge.SFN_VertexColor,id:8819,x:31150,y:32726,varname:node_8819,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:4518,x:31333,y:32726,varname:node_4518,prsc:2|IN-8819-A;n:type:ShaderForge.SFN_Clamp01,id:6517,x:31735,y:32543,varname:node_6517,prsc:2|IN-1257-OUT;n:type:ShaderForge.SFN_Color,id:1056,x:32257,y:32505,ptovrint:False,ptlb:Fire Color,ptin:_FireColor,varname:node_1056,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:8372-7336-83-1056;pass:END;sub:END;*/

Shader "Sine VFX/EmberParticle" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 10)) = 0
        _FireColor ("Fire Color", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _FinalPower;
            uniform float4 _FireColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
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
                float2 node_3897 = float2(saturate((_Mask_var.r-(1.0 - i.vertexColor.a))),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3897, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_FireColor.rgb);
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
