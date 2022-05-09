// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32962,y:32693,varname:node_4795,prsc:2|emission-1516-OUT,alpha-9767-OUT;n:type:ShaderForge.SFN_Tex2d,id:2946,x:32163,y:32920,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_2946,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3126-OUT;n:type:ShaderForge.SFN_Append,id:3126,x:31990,y:32920,varname:node_3126,prsc:2|A-9384-OUT,B-4940-OUT;n:type:ShaderForge.SFN_Vector1,id:4940,x:31770,y:33066,varname:node_4940,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:2701,x:31093,y:32716,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_2701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5408-OUT;n:type:ShaderForge.SFN_TexCoord,id:2677,x:30497,y:32589,varname:node_2677,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:2717,x:30705,y:32745,varname:node_2717,prsc:2|A-2677-V,B-961-OUT;n:type:ShaderForge.SFN_Append,id:5408,x:30912,y:32716,varname:node_5408,prsc:2|A-2677-U,B-2717-OUT;n:type:ShaderForge.SFN_VertexColor,id:6748,x:30325,y:32803,varname:node_6748,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:961,x:30497,y:32803,varname:node_961,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6748-A;n:type:ShaderForge.SFN_Tex2d,id:99,x:31508,y:32905,ptovrint:False,ptlb:Gradient 2,ptin:_Gradient2,varname:node_99,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7220,x:31512,y:33073,varname:node_7220,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:7745,x:31345,y:33198,varname:node_7745,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:2839,x:31512,y:33198,varname:node_2839,prsc:2|IN-7745-OUT;n:type:ShaderForge.SFN_Multiply,id:1516,x:32391,y:32971,varname:node_1516,prsc:2|A-2946-RGB,B-8496-OUT,C-7529-RGB;n:type:ShaderForge.SFN_Slider,id:8496,x:32006,y:33105,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_8496,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Vector1,id:9008,x:32401,y:33172,varname:node_9008,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:8298,x:32163,y:32790,varname:Opacity,prsc:2|IN-3749-OUT;n:type:ShaderForge.SFN_Get,id:9767,x:32705,y:33066,varname:node_9767,prsc:2|IN-8298-OUT;n:type:ShaderForge.SFN_Multiply,id:9384,x:31770,y:32920,varname:node_9384,prsc:2|A-4616-OUT,B-99-R,C-7220-R,D-2839-OUT;n:type:ShaderForge.SFN_Clamp01,id:3749,x:31990,y:32790,varname:node_3749,prsc:2|IN-9384-OUT;n:type:ShaderForge.SFN_Tex2d,id:5357,x:31093,y:32532,ptovrint:False,ptlb:Fire Texture,ptin:_FireTexture,varname:node_5357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c21d4a73d02870842be67f7332a4910c,ntxv:0,isnm:False|UVIN-7138-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5058,x:31317,y:32690,varname:node_5058,prsc:2|A-5357-R,B-2701-R,C-2273-OUT;n:type:ShaderForge.SFN_Clamp01,id:4616,x:31479,y:32690,varname:node_4616,prsc:2|IN-5058-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2273,x:31093,y:32900,ptovrint:False,ptlb:Pre Power,ptin:_PrePower,varname:node_2273,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Panner,id:7138,x:30925,y:32532,varname:node_7138,prsc:2,spu:0,spv:0.05|UVIN-2677-UVOUT;n:type:ShaderForge.SFN_Color,id:7529,x:32163,y:33206,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:2946-2701-99-8496-5357-2273-7529;pass:END;sub:END;*/

Shader "Sine VFX/CurveParticleAlphaBlendedV2" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Gradient2 ("Gradient 2", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 10)) = 1
        _FireTexture ("Fire Texture", 2D) = "white" {}
        _PrePower ("Pre Power", Float ) = 2
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _Gradient2; uniform float4 _Gradient2_ST;
            uniform float _FinalPower;
            uniform sampler2D _FireTexture; uniform float4 _FireTexture_ST;
            uniform float _PrePower;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
////// Lighting:
////// Emissive:
                float4 node_4059 = _Time;
                float2 node_7138 = (i.uv0+node_4059.g*float2(0,0.05));
                float4 _FireTexture_var = tex2D(_FireTexture,TRANSFORM_TEX(node_7138, _FireTexture));
                float2 node_5408 = float2(i.uv0.r,(i.uv0.g+(i.vertexColor.a*2.0+-1.0)));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_5408, _Mask));
                float4 _Gradient2_var = tex2D(_Gradient2,TRANSFORM_TEX(i.uv0, _Gradient2));
                float node_9384 = (saturate((_FireTexture_var.r*_Mask_var.r*_PrePower))*_Gradient2_var.r*i.vertexColor.r*(1.0 - (1.0-max(0,dot(normalDirection, viewDirection)))));
                float2 node_3126 = float2(node_9384,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3126, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_Color.rgb);
                float3 finalColor = emissive;
                float Opacity = saturate(node_9384);
                fixed4 finalRGBA = fixed4(finalColor,Opacity);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
