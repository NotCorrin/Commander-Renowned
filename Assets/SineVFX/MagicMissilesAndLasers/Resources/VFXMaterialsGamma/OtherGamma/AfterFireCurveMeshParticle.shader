// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-6224-OUT;n:type:ShaderForge.SFN_Tex2d,id:2920,x:32035,y:32620,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_2920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-9921-OUT;n:type:ShaderForge.SFN_Append,id:9921,x:31863,y:32620,varname:node_9921,prsc:2|A-9430-OUT,B-9148-OUT;n:type:ShaderForge.SFN_Vector1,id:9148,x:31644,y:32727,varname:node_9148,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:6224,x:32291,y:32693,varname:node_6224,prsc:2|A-2920-RGB,B-6782-RGB,C-8446-OUT,D-6954-RGB;n:type:ShaderForge.SFN_VertexColor,id:6782,x:32035,y:32779,varname:node_6782,prsc:2;n:type:ShaderForge.SFN_Slider,id:8446,x:31878,y:32926,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_8446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Subtract,id:9718,x:31483,y:32562,varname:node_9718,prsc:2|A-1364-OUT,B-8228-OUT;n:type:ShaderForge.SFN_VertexColor,id:1016,x:31114,y:32674,varname:node_1016,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:8228,x:31290,y:32674,varname:node_8228,prsc:2|IN-1016-A;n:type:ShaderForge.SFN_Clamp01,id:9430,x:31644,y:32562,varname:node_9430,prsc:2|IN-9718-OUT;n:type:ShaderForge.SFN_Multiply,id:9987,x:32338,y:32888,varname:node_9987,prsc:2|A-9430-OUT,B-2196-OUT;n:type:ShaderForge.SFN_Vector1,id:2196,x:32072,y:33033,varname:node_2196,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:6338,x:32512,y:32888,varname:node_6338,prsc:2|IN-9987-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1392,x:29761,y:32638,ptovrint:False,ptlb:Spark,ptin:_Spark,varname:node_1392,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:59c37a72bcb86374cb9dbffb99c4ed2f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8134,x:31101,y:32542,varname:node_8134,prsc:2,tex:59c37a72bcb86374cb9dbffb99c4ed2f,ntxv:0,isnm:False|TEX-1392-TEX;n:type:ShaderForge.SFN_Tex2d,id:8128,x:31029,y:32260,varname:node_8128,prsc:2,tex:59c37a72bcb86374cb9dbffb99c4ed2f,ntxv:0,isnm:False|UVIN-8441-OUT,TEX-1392-TEX;n:type:ShaderForge.SFN_TexCoord,id:9117,x:29561,y:32022,varname:node_9117,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Multiply,id:1364,x:31290,y:32542,varname:node_1364,prsc:2|A-8128-G,B-8134-R;n:type:ShaderForge.SFN_Add,id:7741,x:30066,y:32047,varname:node_7741,prsc:2|A-9562-OUT,B-9117-W;n:type:ShaderForge.SFN_Panner,id:1777,x:30445,y:31933,varname:node_1777,prsc:2,spu:0,spv:-0.35|UVIN-7741-OUT;n:type:ShaderForge.SFN_Tex2d,id:6748,x:30445,y:32097,varname:node_6748,prsc:2,tex:59c37a72bcb86374cb9dbffb99c4ed2f,ntxv:0,isnm:False|UVIN-7741-OUT,TEX-1392-TEX;n:type:ShaderForge.SFN_Add,id:8441,x:30830,y:32066,varname:node_8441,prsc:2|A-1777-UVOUT,B-5093-OUT;n:type:ShaderForge.SFN_Multiply,id:5093,x:30646,y:32169,varname:node_5093,prsc:2|A-6748-B,B-9496-OUT;n:type:ShaderForge.SFN_Slider,id:9496,x:30288,y:32235,ptovrint:False,ptlb:Distortion Amount,ptin:_DistortionAmount,varname:node_9496,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3891555,max:1;n:type:ShaderForge.SFN_Multiply,id:9562,x:29852,y:31966,varname:node_9562,prsc:2|A-9117-Z,B-9117-UVOUT;n:type:ShaderForge.SFN_Color,id:6954,x:32035,y:32439,ptovrint:False,ptlb:Fire Color,ptin:_FireColor,varname:node_6954,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7573529,c2:0.2951449,c3:0.2951449,c4:1;proporder:2920-8446-1392-9496-6954;pass:END;sub:END;*/

Shader "Sine VFX/AfterFireCurveMeshParticle" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 10)) = 1
        _Spark ("Spark", 2D) = "white" {}
        _DistortionAmount ("Distortion Amount", Range(0, 1)) = 0.3891555
        _FireColor ("Fire Color", Color) = (0.7573529,0.2951449,0.2951449,1)
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _FinalPower;
            uniform sampler2D _Spark; uniform float4 _Spark_ST;
            uniform float _DistortionAmount;
            uniform float4 _FireColor;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_794 = _Time;
                float2 node_7741 = ((i.uv0.b*i.uv0)+i.uv0.a);
                float4 node_6748 = tex2D(_Spark,TRANSFORM_TEX(node_7741, _Spark));
                float2 node_8441 = ((node_7741+node_794.g*float2(0,-0.35))+(node_6748.b*_DistortionAmount));
                float4 node_8128 = tex2D(_Spark,TRANSFORM_TEX(node_8441, _Spark));
                float4 node_8134 = tex2D(_Spark,TRANSFORM_TEX(i.uv0, _Spark));
                float node_9430 = saturate(((node_8128.g*node_8134.r)-(1.0 - i.vertexColor.a)));
                float2 node_9921 = float2(node_9430,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_9921, _Ramp));
                float3 emissive = (_Ramp_var.rgb*i.vertexColor.rgb*_FinalPower*_FireColor.rgb);
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
