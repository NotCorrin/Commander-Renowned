// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33192,y:32988,varname:node_4795,prsc:2|emission-2800-OUT,voffset-3604-OUT;n:type:ShaderForge.SFN_Fresnel,id:4585,x:31994,y:32718,varname:node_4585,prsc:2;n:type:ShaderForge.SFN_Slider,id:7831,x:32449,y:33027,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_7831,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Tex2d,id:1357,x:32597,y:32810,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_1357,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0c1654a137d7df741b6e1a143703a9a8,ntxv:0,isnm:False|UVIN-4927-OUT;n:type:ShaderForge.SFN_Append,id:4927,x:32426,y:32810,varname:node_4927,prsc:2|A-501-OUT,B-2639-OUT;n:type:ShaderForge.SFN_Vector1,id:2639,x:32229,y:32892,varname:node_2639,prsc:2,v1:0;n:type:ShaderForge.SFN_NormalVector,id:253,x:31819,y:33903,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:1892,x:31819,y:34083,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_1892,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3333333,max:4;n:type:ShaderForge.SFN_Multiply,id:3604,x:32238,y:33825,varname:node_3604,prsc:2|A-2660-OUT,B-253-OUT,C-1892-OUT;n:type:ShaderForge.SFN_Multiply,id:2800,x:32873,y:32962,varname:node_2800,prsc:2|A-1357-RGB,B-7831-OUT,C-6234-RGB;n:type:ShaderForge.SFN_Add,id:501,x:32213,y:32637,varname:node_501,prsc:2|A-2317-OUT,B-4585-OUT;n:type:ShaderForge.SFN_Panner,id:7463,x:30400,y:33178,varname:node_7463,prsc:2,spu:0,spv:-1|UVIN-1100-UVOUT,DIST-9851-OUT;n:type:ShaderForge.SFN_Multiply,id:2317,x:31994,y:32579,varname:node_2317,prsc:2|A-462-OUT,B-201-OUT;n:type:ShaderForge.SFN_Fresnel,id:9274,x:31195,y:32365,varname:node_9274,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:3983,x:31362,y:32365,varname:node_3983,prsc:2|IN-9274-OUT;n:type:ShaderForge.SFN_Multiply,id:462,x:31541,y:32365,varname:node_462,prsc:2|A-3983-OUT,B-3983-OUT;n:type:ShaderForge.SFN_NormalVector,id:2013,x:29574,y:32761,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:7093,x:29925,y:32761,varname:node_7093,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1809-XYZ;n:type:ShaderForge.SFN_Multiply,id:159,x:30299,y:32813,varname:node_159,prsc:2|A-5339-OUT,B-4141-OUT,C-9080-OUT;n:type:ShaderForge.SFN_Fresnel,id:4141,x:29925,y:32914,varname:node_4141,prsc:2|EXP-847-OUT;n:type:ShaderForge.SFN_Add,id:9150,x:30776,y:32963,varname:node_9150,prsc:2|A-7463-UVOUT,B-159-OUT;n:type:ShaderForge.SFN_Slider,id:9080,x:29768,y:33077,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_9080,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Transform,id:1809,x:29751,y:32761,varname:node_1809,prsc:2,tffrom:0,tfto:3|IN-2013-OUT;n:type:ShaderForge.SFN_Slider,id:847,x:29574,y:32971,ptovrint:False,ptlb:Distortion Fresnel Exp,ptin:_DistortionFresnelExp,varname:node_847,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Color,id:6234,x:32606,y:33129,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6234,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Normalize,id:5339,x:30120,y:32761,varname:node_5339,prsc:2|IN-7093-OUT;n:type:ShaderForge.SFN_Tex2d,id:2272,x:31387,y:32846,ptovrint:False,ptlb:Space Tex,ptin:_SpaceTex,varname:node_2272,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6197-UVOUT;n:type:ShaderForge.SFN_Add,id:5300,x:31601,y:33005,varname:node_5300,prsc:2|A-2453-R,B-2272-R;n:type:ShaderForge.SFN_Clamp01,id:201,x:31756,y:33005,varname:node_201,prsc:2|IN-5300-OUT;n:type:ShaderForge.SFN_ScreenPos,id:6197,x:31197,y:32846,varname:node_6197,prsc:2,sctp:2;n:type:ShaderForge.SFN_TexCoord,id:1100,x:30216,y:33178,varname:node_1100,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2dAsset,id:2829,x:30368,y:33383,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_2829,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3690,x:31180,y:33517,varname:node_3690,prsc:2,ntxv:0,isnm:False|UVIN-7463-UVOUT,TEX-2829-TEX;n:type:ShaderForge.SFN_Tex2d,id:2453,x:31169,y:33232,varname:node_2453,prsc:2,ntxv:0,isnm:False|UVIN-9150-OUT,TEX-2829-TEX;n:type:ShaderForge.SFN_Add,id:2660,x:31516,y:33598,varname:node_2660,prsc:2|A-3690-R,B-2053-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2053,x:31180,y:33670,ptovrint:False,ptlb:Offset Add,ptin:_OffsetAdd,varname:node_2053,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Time,id:151,x:29701,y:33274,varname:node_151,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9851,x:29919,y:33334,varname:node_9851,prsc:2|A-151-T,B-4186-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4186,x:29701,y:33424,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_4186,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7831-1357-1892-9080-847-6234-2272-2829-2053-4186;pass:END;sub:END;*/

Shader "Sine VFX/StartSphereV3" {
    Properties {
        _FinalPower ("Final Power", Range(0, 4)) = 1
        _Ramp ("Ramp", 2D) = "white" {}
        _OffsetPower ("Offset Power", Range(0, 4)) = 0.3333333
        _DistortionPower ("Distortion Power", Range(0, 4)) = 1
        _DistortionFresnelExp ("Distortion Fresnel Exp", Range(0, 4)) = 0
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _SpaceTex ("Space Tex", 2D) = "white" {}
        _Noise01 ("Noise 01", 2D) = "white" {}
        _OffsetAdd ("Offset Add", Float ) = 0
        _ScrollSpeed ("Scroll Speed", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float _FinalPower;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _OffsetPower;
            uniform float _DistortionPower;
            uniform float _DistortionFresnelExp;
            uniform float4 _Color;
            uniform sampler2D _SpaceTex; uniform float4 _SpaceTex_ST;
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform float _OffsetAdd;
            uniform float _ScrollSpeed;
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
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_151 = _Time;
                float2 node_7463 = (o.uv0+(node_151.g*_ScrollSpeed)*float2(0,-1));
                float4 node_3690 = tex2Dlod(_Noise01,float4(TRANSFORM_TEX(node_7463, _Noise01),0.0,0));
                v.vertex.xyz += ((node_3690.r+_OffsetAdd)*v.normal*_OffsetPower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
////// Lighting:
////// Emissive:
                float node_3983 = (1.0 - (1.0-max(0,dot(normalDirection, viewDirection))));
                float4 node_151 = _Time;
                float2 node_7463 = (i.uv0+(node_151.g*_ScrollSpeed)*float2(0,-1));
                float2 node_9150 = (node_7463+(normalize(mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb.rg)*pow(1.0-max(0,dot(normalDirection, viewDirection)),_DistortionFresnelExp)*_DistortionPower));
                float4 node_2453 = tex2D(_Noise01,TRANSFORM_TEX(node_9150, _Noise01));
                float4 _SpaceTex_var = tex2D(_SpaceTex,TRANSFORM_TEX(sceneUVs.rg, _SpaceTex));
                float2 node_4927 = float2((((node_3983*node_3983)*saturate((node_2453.r+_SpaceTex_var.r)))+(1.0-max(0,dot(normalDirection, viewDirection)))),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4927, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_Color.rgb);
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
