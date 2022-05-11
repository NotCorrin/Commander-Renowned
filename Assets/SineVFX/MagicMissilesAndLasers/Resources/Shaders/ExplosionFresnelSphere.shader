// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33531,y:32505,varname:node_4795,prsc:2|emission-7014-OUT,voffset-3555-OUT;n:type:ShaderForge.SFN_Multiply,id:731,x:33003,y:32722,varname:node_731,prsc:2|A-9434-OUT,B-763-RGB,C-6883-RGB,D-852-OUT,E-6883-A;n:type:ShaderForge.SFN_Color,id:763,x:32571,y:32659,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_763,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:6883,x:32571,y:32813,varname:node_6883,prsc:2;n:type:ShaderForge.SFN_Slider,id:852,x:32414,y:32958,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_852,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_NormalVector,id:7150,x:30749,y:32499,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:5582,x:30749,y:32660,varname:node_5582,prsc:2;n:type:ShaderForge.SFN_Dot,id:7921,x:30959,y:32574,varname:node_7921,prsc:2,dt:3|A-7150-OUT,B-5582-OUT;n:type:ShaderForge.SFN_OneMinus,id:7747,x:31128,y:32574,varname:node_7747,prsc:2|IN-7921-OUT;n:type:ShaderForge.SFN_Power,id:4344,x:31332,y:32617,varname:node_4344,prsc:2|VAL-7747-OUT,EXP-9726-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9726,x:31128,y:32727,ptovrint:False,ptlb:Rim Exp,ptin:_RimExp,varname:node_9726,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_DepthBlend,id:1760,x:30836,y:32275,varname:node_1760,prsc:2|DIST-4386-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4386,x:30662,y:32275,ptovrint:False,ptlb:Depth Dist,ptin:_DepthDist,varname:node_4386,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_OneMinus,id:3845,x:30996,y:32275,varname:node_3845,prsc:2|IN-1760-OUT;n:type:ShaderForge.SFN_Clamp01,id:5651,x:31161,y:32275,varname:node_5651,prsc:2|IN-3845-OUT;n:type:ShaderForge.SFN_Power,id:4239,x:31346,y:32330,varname:node_4239,prsc:2|VAL-5651-OUT,EXP-6465-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6465,x:31161,y:32428,ptovrint:False,ptlb:Depth Power,ptin:_DepthPower,varname:node_6465,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:4685,x:31594,y:32466,varname:node_4685,prsc:2|A-4239-OUT,B-4344-OUT;n:type:ShaderForge.SFN_Subtract,id:3546,x:32210,y:32500,varname:node_3546,prsc:2|A-4685-OUT,B-6780-OUT;n:type:ShaderForge.SFN_Power,id:7166,x:31791,y:32544,varname:node_7166,prsc:2|VAL-4685-OUT,EXP-572-OUT;n:type:ShaderForge.SFN_ValueProperty,id:572,x:31594,y:32620,ptovrint:False,ptlb:Subtract Power Exp,ptin:_SubtractPowerExp,varname:node_572,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Clamp01,id:3837,x:32376,y:32500,varname:node_3837,prsc:2|IN-3546-OUT;n:type:ShaderForge.SFN_Multiply,id:6780,x:31978,y:32587,varname:node_6780,prsc:2|A-7166-OUT,B-2129-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2129,x:31791,y:32693,ptovrint:False,ptlb:Subtract Multiply,ptin:_SubtractMultiply,varname:node_2129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Tex2d,id:6826,x:32376,y:32659,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_6826,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3457-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5283,x:32571,y:32500,varname:node_5283,prsc:2|A-3837-OUT,B-6826-R;n:type:ShaderForge.SFN_TexCoord,id:944,x:31937,y:32806,varname:node_944,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3457,x:32092,y:32806,varname:node_3457,prsc:2,spu:0,spv:-0.5|UVIN-944-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2885,x:31250,y:33232,ptovrint:False,ptlb:Dissolve Mask,ptin:_DissolveMask,varname:node_2885,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7014,x:33244,y:32722,varname:node_7014,prsc:2|A-731-OUT,B-8670-OUT,C-9939-R;n:type:ShaderForge.SFN_If,id:8670,x:31958,y:33501,varname:node_8670,prsc:2|A-4011-OUT,B-4925-OUT,GT-3185-OUT,EQ-3185-OUT,LT-5076-OUT;n:type:ShaderForge.SFN_Vector1,id:4925,x:31668,y:33509,varname:node_4925,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Vector1,id:3185,x:31668,y:33571,varname:node_3185,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:5076,x:31668,y:33629,varname:node_5076,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2792,x:31250,y:33411,ptovrint:False,ptlb:Dissolve Add,ptin:_DissolveAdd,varname:node_2792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.65;n:type:ShaderForge.SFN_Add,id:2817,x:31450,y:33309,varname:node_2817,prsc:2|A-2885-R,B-2792-OUT;n:type:ShaderForge.SFN_Multiply,id:4011,x:31668,y:33370,varname:node_4011,prsc:2|A-2817-OUT,B-9004-Z;n:type:ShaderForge.SFN_TexCoord,id:9004,x:31450,y:33439,varname:node_9004,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_OneMinus,id:1911,x:31742,y:33132,varname:node_1911,prsc:2|IN-2817-OUT;n:type:ShaderForge.SFN_Add,id:7588,x:32780,y:32500,varname:node_7588,prsc:2|A-5283-OUT,B-881-OUT;n:type:ShaderForge.SFN_Clamp01,id:881,x:32267,y:33210,varname:node_881,prsc:2|IN-5159-OUT;n:type:ShaderForge.SFN_Power,id:234,x:31929,y:33169,varname:node_234,prsc:2|VAL-1911-OUT,EXP-5734-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5734,x:31742,y:33274,ptovrint:False,ptlb:Dissolve Edge Power,ptin:_DissolveEdgePower,varname:node_5734,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:5159,x:32115,y:33210,varname:node_5159,prsc:2|A-234-OUT,B-3609-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3609,x:31929,y:33311,ptovrint:False,ptlb:Dissolve Edge Boost,ptin:_DissolveEdgeBoost,varname:node_3609,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:3555,x:33032,y:33246,varname:node_3555,prsc:2|A-7956-OUT,B-48-OUT,C-2885-R,D-7798-OUT;n:type:ShaderForge.SFN_Slider,id:48,x:32603,y:33360,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_48,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4,max:1;n:type:ShaderForge.SFN_NormalVector,id:7956,x:32749,y:33188,prsc:2,pt:False;n:type:ShaderForge.SFN_VertexColor,id:7117,x:32572,y:33445,varname:node_7117,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:7798,x:32760,y:33445,varname:node_7798,prsc:2|IN-7117-A;n:type:ShaderForge.SFN_SwitchProperty,id:9434,x:32979,y:32329,ptovrint:False,ptlb:Glow Edges,ptin:_GlowEdges,varname:node_9434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5283-OUT,B-7588-OUT;n:type:ShaderForge.SFN_Tex2d,id:9939,x:33003,y:32873,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_9939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:763-852-9726-4386-6465-572-2129-6826-48-9434-2885-2792-5734-3609-9939;pass:END;sub:END;*/

Shader "Sine VFX/ExplosionFresnelSphere" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 1
        _RimExp ("Rim Exp", Float ) = 0
        _DepthDist ("Depth Dist", Float ) = 0
        _DepthPower ("Depth Power", Float ) = 0
        _SubtractPowerExp ("Subtract Power Exp", Float ) = 0
        _SubtractMultiply ("Subtract Multiply", Float ) = 2
        _Noise01 ("Noise 01", 2D) = "white" {}
        _OffsetPower ("Offset Power", Range(0, 1)) = 0.4
        [MaterialToggle] _GlowEdges ("Glow Edges", Float ) = 0
        _DissolveMask ("Dissolve Mask", 2D) = "white" {}
        _DissolveAdd ("Dissolve Add", Float ) = 0.65
        _DissolveEdgePower ("Dissolve Edge Power", Float ) = 0
        _DissolveEdgeBoost ("Dissolve Edge Boost", Float ) = 2
        _Mask ("Mask", 2D) = "white" {}
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
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform float _RimExp;
            uniform float _DepthDist;
            uniform float _DepthPower;
            uniform float _SubtractPowerExp;
            uniform float _SubtractMultiply;
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform sampler2D _DissolveMask; uniform float4 _DissolveMask_ST;
            uniform float _DissolveAdd;
            uniform float _DissolveEdgePower;
            uniform float _DissolveEdgeBoost;
            uniform float _OffsetPower;
            uniform fixed _GlowEdges;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 _DissolveMask_var = tex2Dlod(_DissolveMask,float4(TRANSFORM_TEX(o.uv0, _DissolveMask),0.0,0));
                v.vertex.xyz += (v.normal*_OffsetPower*_DissolveMask_var.r*(1.0 - o.vertexColor.a));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_4685 = (pow(saturate((1.0 - saturate((sceneZ-partZ)/_DepthDist))),_DepthPower)+pow((1.0 - abs(dot(i.normalDir,viewDirection))),_RimExp));
                float4 node_1984 = _Time;
                float2 node_3457 = (i.uv0+node_1984.g*float2(0,-0.5));
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_3457, _Noise01));
                float node_5283 = (saturate((node_4685-(pow(node_4685,_SubtractPowerExp)*_SubtractMultiply)))*_Noise01_var.r);
                float4 _DissolveMask_var = tex2D(_DissolveMask,TRANSFORM_TEX(i.uv0, _DissolveMask));
                float node_2817 = (_DissolveMask_var.r+_DissolveAdd);
                float node_8670_if_leA = step((node_2817*i.uv0.b),0.25);
                float node_8670_if_leB = step(0.25,(node_2817*i.uv0.b));
                float node_3185 = 1.0;
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((lerp( node_5283, (node_5283+saturate((pow((1.0 - node_2817),_DissolveEdgePower)*_DissolveEdgeBoost))), _GlowEdges )*_Color.rgb*i.vertexColor.rgb*_FinalPower*i.vertexColor.a)*lerp((node_8670_if_leA*0.0)+(node_8670_if_leB*node_3185),node_3185,node_8670_if_leA*node_8670_if_leB)*_Mask_var.r);
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
