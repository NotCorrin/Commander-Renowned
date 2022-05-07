// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-1516-OUT;n:type:ShaderForge.SFN_Tex2d,id:2946,x:32163,y:32920,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_2946,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3126-OUT;n:type:ShaderForge.SFN_Append,id:3126,x:31990,y:32920,varname:node_3126,prsc:2|A-7421-OUT,B-4940-OUT;n:type:ShaderForge.SFN_Vector1,id:4940,x:31770,y:33039,varname:node_4940,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:2701,x:31603,y:32701,ptovrint:False,ptlb:Gradient,ptin:_Gradient,varname:node_2701,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5408-OUT;n:type:ShaderForge.SFN_TexCoord,id:2677,x:30912,y:32585,varname:node_2677,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:2717,x:31120,y:32741,varname:node_2717,prsc:2|A-2677-V,B-961-OUT;n:type:ShaderForge.SFN_Append,id:5408,x:31327,y:32712,varname:node_5408,prsc:2|A-2677-U,B-2717-OUT;n:type:ShaderForge.SFN_VertexColor,id:6748,x:30740,y:32799,varname:node_6748,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:961,x:30912,y:32799,varname:node_961,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6748-A;n:type:ShaderForge.SFN_Multiply,id:7421,x:31770,y:32903,varname:node_7421,prsc:2|A-2701-R,B-99-R,C-7220-R,D-2839-OUT;n:type:ShaderForge.SFN_Tex2d,id:99,x:31508,y:32905,ptovrint:False,ptlb:Gradient 2,ptin:_Gradient2,varname:node_99,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7220,x:31512,y:33073,varname:node_7220,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:7745,x:31345,y:33198,varname:node_7745,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:2839,x:31512,y:33198,varname:node_2839,prsc:2|IN-7745-OUT;n:type:ShaderForge.SFN_Multiply,id:1516,x:32391,y:32971,varname:node_1516,prsc:2|A-2946-RGB,B-8496-OUT;n:type:ShaderForge.SFN_Slider,id:8496,x:32006,y:33105,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_8496,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;proporder:2946-2701-99-8496;pass:END;sub:END;*/

Shader "Sine VFX/StartSphereCurveParticleAdditive" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _Gradient ("Gradient", 2D) = "white" {}
        _Gradient2 ("Gradient 2", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 4)) = 2
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform sampler2D _Gradient2; uniform float4 _Gradient2_ST;
            uniform float _FinalPower;
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
                float2 node_5408 = float2(i.uv0.r,(i.uv0.g+(i.vertexColor.a*2.0+-1.0)));
                float4 _Gradient_var = tex2D(_Gradient,TRANSFORM_TEX(node_5408, _Gradient));
                float4 _Gradient2_var = tex2D(_Gradient2,TRANSFORM_TEX(i.uv0, _Gradient2));
                float2 node_3126 = float2((_Gradient_var.r*_Gradient2_var.r*i.vertexColor.r*(1.0 - (1.0-max(0,dot(normalDirection, viewDirection))))),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3126, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower);
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
