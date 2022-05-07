// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32838,y:32706,varname:node_3138,prsc:2|emission-895-RGB;n:type:ShaderForge.SFN_ScreenPos,id:164,x:31915,y:32812,varname:node_164,prsc:2,sctp:2;n:type:ShaderForge.SFN_SceneColor,id:895,x:32344,y:32884,varname:node_895,prsc:2|UVIN-2189-OUT;n:type:ShaderForge.SFN_Add,id:2189,x:32172,y:32884,varname:node_2189,prsc:2|A-164-UVOUT,B-5699-OUT;n:type:ShaderForge.SFN_Tex2d,id:8472,x:31538,y:32931,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_8472,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5850-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5699,x:31915,y:32979,varname:node_5699,prsc:2|A-5301-OUT,B-8018-OUT,C-8235-OUT,D-5741-R,E-2830-OUT;n:type:ShaderForge.SFN_Slider,id:8018,x:31549,y:33122,ptovrint:False,ptlb:Distortion Amount,ptin:_DistortionAmount,varname:node_8018,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_RemapRange,id:5301,x:31706,y:32931,varname:node_5301,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8472-R;n:type:ShaderForge.SFN_ValueProperty,id:8235,x:31706,y:33227,ptovrint:False,ptlb:Progress,ptin:_Progress,varname:node_8235,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:5741,x:31706,y:33307,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_5741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:4846,x:31435,y:33553,ptovrint:False,ptlb:_Distance,ptin:_Distance,varname:node_6531,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_If,id:2830,x:31706,y:33479,varname:node_2830,prsc:2|A-454-OUT,B-4846-OUT,GT-8384-OUT,EQ-8384-OUT,LT-6702-OUT;n:type:ShaderForge.SFN_Distance,id:454,x:31435,y:33397,varname:node_454,prsc:2|A-9355-XYZ,B-70-XYZ;n:type:ShaderForge.SFN_Vector1,id:8384,x:31435,y:33617,varname:node_8384,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:6702,x:31435,y:33681,varname:node_6702,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector4Property,id:70,x:31167,y:33484,ptovrint:False,ptlb:_Position,ptin:_Position,varname:node_9510,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_FragmentPosition,id:9355,x:31167,y:33332,varname:node_9355,prsc:2;n:type:ShaderForge.SFN_Panner,id:5850,x:31369,y:32931,varname:node_5850,prsc:2,spu:1,spv:0|UVIN-3802-UVOUT,DIST-3934-OUT;n:type:ShaderForge.SFN_TexCoord,id:3802,x:31193,y:32931,varname:node_3802,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3253,x:30806,y:32916,varname:node_3253,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3934,x:31193,y:33079,varname:node_3934,prsc:2|A-3253-T,B-9592-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9592,x:30806,y:33059,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_9592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:8472-8018-9592-5741;pass:END;sub:END;*/

Shader "Sine VFX/LaserDistortionCon" {
    Properties {
        _Distortion ("Distortion", 2D) = "white" {}
        _DistortionAmount ("Distortion Amount", Range(0, 1)) = 0.1
        _ScrollSpeed ("Scroll Speed", Float ) = 0
        _Mask ("Mask", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
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
            uniform sampler2D _GrabTexture;
            uniform sampler2D _Distortion; uniform float4 _Distortion_ST;
            uniform float _DistortionAmount;
            uniform float _Progress;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Distance;
            uniform float4 _Position;
            uniform float _ScrollSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float4 node_3253 = _Time;
                float2 node_5850 = (i.uv0+(node_3253.g*_ScrollSpeed)*float2(1,0));
                float4 _Distortion_var = tex2D(_Distortion,TRANSFORM_TEX(node_5850, _Distortion));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_2830_if_leA = step(distance(i.posWorld.rgb,_Position.rgb),_Distance);
                float node_2830_if_leB = step(_Distance,distance(i.posWorld.rgb,_Position.rgb));
                float node_8384 = 0.0;
                float3 emissive = tex2D( _GrabTexture, (sceneUVs.rg+((_Distortion_var.r*2.0+-1.0)*_DistortionAmount*_Progress*_Mask_var.r*lerp((node_2830_if_leA*1.0)+(node_2830_if_leB*node_8384),node_8384,node_2830_if_leA*node_2830_if_leB)))).rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
