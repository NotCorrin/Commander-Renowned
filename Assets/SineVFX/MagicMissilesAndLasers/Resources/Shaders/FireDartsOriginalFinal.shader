// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33525,y:32766,varname:node_4795,prsc:2|emission-3653-OUT,alpha-219-OUT,voffset-8637-OUT;n:type:ShaderForge.SFN_Tex2d,id:8325,x:32618,y:32423,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_8325,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4925-OUT;n:type:ShaderForge.SFN_Append,id:4925,x:32446,y:32423,varname:node_4925,prsc:2|A-4141-R,B-3352-OUT;n:type:ShaderForge.SFN_Vector1,id:3352,x:32238,y:32495,varname:node_3352,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:7971,x:30628,y:32223,ptovrint:False,ptlb:ComTex,ptin:_ComTex,varname:node_7971,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9218,x:31130,y:32042,varname:node_9218,prsc:2,ntxv:0,isnm:False|UVIN-4218-OUT,TEX-7971-TEX;n:type:ShaderForge.SFN_Multiply,id:3653,x:32999,y:32467,varname:node_3653,prsc:2|A-8325-RGB,B-6740-OUT,C-2065-RGB;n:type:ShaderForge.SFN_Multiply,id:4546,x:32701,y:32959,varname:node_4546,prsc:2|A-9218-G,B-4141-A,C-9886-OUT,D-2081-B;n:type:ShaderForge.SFN_Slider,id:6740,x:32461,y:32615,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_6740,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:10;n:type:ShaderForge.SFN_VertexColor,id:4141,x:29544,y:32297,varname:node_4141,prsc:2;n:type:ShaderForge.SFN_Slider,id:9886,x:32297,y:33070,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9886,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4,max:4;n:type:ShaderForge.SFN_Clamp01,id:219,x:32876,y:32959,varname:node_219,prsc:2|IN-4546-OUT;n:type:ShaderForge.SFN_TexCoord,id:1500,x:29366,y:31507,varname:node_1500,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8637,x:32664,y:33488,varname:node_8637,prsc:2|A-5330-OUT,B-2946-OUT,C-1205-OUT;n:type:ShaderForge.SFN_Slider,id:1205,x:32075,y:33673,ptovrint:False,ptlb:Offset Power,ptin:_OffsetPower,varname:node_1205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_OneMinus,id:2946,x:31824,y:33298,varname:node_2946,prsc:2|IN-4141-R;n:type:ShaderForge.SFN_Add,id:8462,x:30387,y:31543,varname:node_8462,prsc:2|A-531-OUT,B-1922-OUT,C-1575-OUT;n:type:ShaderForge.SFN_Time,id:7717,x:29607,y:31788,varname:node_7717,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1922,x:29888,y:31846,varname:node_1922,prsc:2|A-7717-T,B-5717-OUT;n:type:ShaderForge.SFN_Slider,id:5717,x:29450,y:31933,ptovrint:False,ptlb:Scroll Speed,ptin:_ScrollSpeed,varname:node_5717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-4,cur:0,max:4;n:type:ShaderForge.SFN_Append,id:4218,x:31059,y:31746,varname:node_4218,prsc:2|A-8462-OUT,B-6322-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:3446,x:29946,y:33069,varname:node_3446,prsc:2;n:type:ShaderForge.SFN_Append,id:8458,x:30684,y:33019,varname:node_8458,prsc:2|A-3841-G,B-3841-B;n:type:ShaderForge.SFN_Append,id:5192,x:30684,y:33166,varname:node_5192,prsc:2|A-3841-B,B-3841-R;n:type:ShaderForge.SFN_Append,id:7532,x:30684,y:33317,varname:node_7532,prsc:2|A-3841-R,B-3841-G;n:type:ShaderForge.SFN_Tex2dAsset,id:2243,x:30895,y:33512,ptovrint:False,ptlb:World Offset Noise,ptin:_WorldOffsetNoise,varname:node_6395,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2396,x:31196,y:33022,varname:node_6397,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-8458-OUT,TEX-2243-TEX;n:type:ShaderForge.SFN_Tex2d,id:608,x:31196,y:33169,varname:node_2119,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-5192-OUT,TEX-2243-TEX;n:type:ShaderForge.SFN_Tex2d,id:963,x:31196,y:33320,varname:node_7954,prsc:2,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-7532-OUT,TEX-2243-TEX;n:type:ShaderForge.SFN_Panner,id:1292,x:30956,y:32919,varname:node_1292,prsc:2,spu:-0.5,spv:0|UVIN-8458-OUT;n:type:ShaderForge.SFN_Panner,id:2240,x:30956,y:33068,varname:node_2240,prsc:2,spu:-0.5,spv:0|UVIN-5192-OUT;n:type:ShaderForge.SFN_Panner,id:4580,x:30956,y:33217,varname:node_4580,prsc:2,spu:0.25,spv:0.25|UVIN-7532-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:7853,x:29946,y:33216,varname:node_7853,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:3841,x:30342,y:33145,varname:node_3841,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-1408-OUT;n:type:ShaderForge.SFN_Subtract,id:1408,x:30172,y:33145,varname:node_1408,prsc:2|A-3446-XYZ,B-7853-XYZ;n:type:ShaderForge.SFN_Append,id:5330,x:31416,y:33144,varname:node_5330,prsc:2|A-2396-R,B-608-G,C-963-B;n:type:ShaderForge.SFN_Tex2d,id:2081,x:31130,y:32205,varname:node_2081,prsc:2,ntxv:0,isnm:False|TEX-7971-TEX;n:type:ShaderForge.SFN_Add,id:5134,x:30405,y:31956,varname:node_5134,prsc:2|A-1500-V,B-4141-G;n:type:ShaderForge.SFN_Multiply,id:531,x:29743,y:31374,varname:node_531,prsc:2|A-1500-U,B-2355-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2355,x:29743,y:31299,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_2355,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Color,id:2065,x:32585,y:32733,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_2065,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:6322,x:30666,y:31896,ptovrint:False,ptlb:Random Offset V,ptin:_RandomOffsetV,varname:node_6322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1500-V,B-5134-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:1575,x:30033,y:32077,ptovrint:False,ptlb:Random Offset U,ptin:_RandomOffsetU,varname:_RandomOffsetV_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6912-OUT,B-4141-B;n:type:ShaderForge.SFN_Vector1,id:6912,x:29819,y:32044,varname:node_6912,prsc:2,v1:0;proporder:8325-7971-6740-9886-1205-5717-2243-2355-2065-6322-1575;pass:END;sub:END;*/

Shader "Sine VFX/FireDartsOriginalFinal" {
    Properties {
        _Ramp ("Ramp", 2D) = "white" {}
        _ComTex ("ComTex", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 10)) = 5
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 4
        _OffsetPower ("Offset Power", Range(0, 4)) = 0
        _ScrollSpeed ("Scroll Speed", Range(-4, 4)) = 0
        _WorldOffsetNoise ("World Offset Noise", 2D) = "white" {}
        _Tiling ("Tiling", Float ) = 0.5
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _RandomOffsetV ("Random Offset V", Float ) = 0
        [MaterialToggle] _RandomOffsetU ("Random Offset U", Float ) = 0
		_EdgeColor ("Edge Color", Color) = (0,0,0,1)
		_EdgeThickness ("Edge Thickness", Range(0, 4)) = 1
		_EdgePower ("Edge Power", Range(0,10)) = 2
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
            uniform sampler2D _ComTex; uniform float4 _ComTex_ST;
            uniform float _FinalPower;
            uniform float _OpacityBoost;
            uniform float _OffsetPower;
            uniform float _ScrollSpeed;
            uniform sampler2D _WorldOffsetNoise; uniform float4 _WorldOffsetNoise_ST;
            uniform float _Tiling;
            uniform float4 _Color;
            uniform fixed _RandomOffsetV;
            uniform fixed _RandomOffsetU;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 node_3841 = (mul(unity_ObjectToWorld, v.vertex).rgb-objPos.rgb).rgb;
                float2 node_8458 = float2(node_3841.g,node_3841.b);
                float4 node_6397 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_8458, _WorldOffsetNoise),0.0,0));
                float2 node_5192 = float2(node_3841.b,node_3841.r);
                float4 node_2119 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_5192, _WorldOffsetNoise),0.0,0));
                float2 node_7532 = float2(node_3841.r,node_3841.g);
                float4 node_7954 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_7532, _WorldOffsetNoise),0.0,0));
                v.vertex.xyz += (float3(node_6397.r,node_2119.g,node_7954.b)*(1.0 - o.vertexColor.r)*_OffsetPower);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
////// Lighting:
////// Emissive:
                float2 node_4925 = float2(i.vertexColor.r,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4925, _Ramp));
                float3 emissive = (_Ramp_var.rgb*_FinalPower*_Color.rgb);
                float3 finalColor = emissive;
                float4 node_7717 = _Time;
                float2 node_4218 = float2(((i.uv0.r*_Tiling)+(node_7717.g*_ScrollSpeed)+lerp( 0.0, i.vertexColor.b, _RandomOffsetU )),lerp( i.uv0.g, (i.uv0.g+i.vertexColor.g), _RandomOffsetV ));
                float4 node_9218 = tex2D(_ComTex,TRANSFORM_TEX(node_4218, _ComTex));
                float4 node_2081 = tex2D(_ComTex,TRANSFORM_TEX(i.uv0, _ComTex));
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_9218.g*i.vertexColor.a*_OpacityBoost*node_2081.b)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }




		// MY START

		GrabPass{ }
		Pass
		{
			//Blend One One
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu
			#pragma target 3.0
			uniform sampler2D _GrabTexture;
			uniform sampler2D _OffsetTex; uniform float4 _OffsetTex_ST;
            uniform float _OffsetPower;
            uniform float _ScrollSpeed;
			uniform sampler2D _WorldOffsetNoise; uniform float4 _WorldOffsetNoise_ST;

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 vertexColor : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 screen_uv : TEXCOORD1;
				float4 vertexColor : COLOR;
				UNITY_FOG_COORDS(1)
			};
			
			float distorttwo (float2 vsposition, float dx, float dy, float et)
			{
				float2 correctuv = (vsposition.xy + float2(dx * et, dy * et)) / _ScreenParams.xy;
				float4 imagef = tex2D(_GrabTexture, correctuv.xy);
				// desaturation
				imagef = 0.2126*imagef.r + 0.7152*imagef.g + 0.0722*imagef.b;
				return imagef;
			}

			v2f vert (appdata v)
			{

				v2f o = (v2f)0;
                o.uv = v.uv;
                o.vertexColor = v.vertexColor;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 node_3841 = (mul(unity_ObjectToWorld, v.vertex).rgb-objPos.rgb).rgb;
                float2 node_8458 = float2(node_3841.g,node_3841.b);
                float4 node_6397 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_8458, _WorldOffsetNoise),0.0,0));
                float2 node_5192 = float2(node_3841.b,node_3841.r);
                float4 node_2119 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_5192, _WorldOffsetNoise),0.0,0));
                float2 node_7532 = float2(node_3841.r,node_3841.g);
                float4 node_7954 = tex2Dlod(_WorldOffsetNoise,float4(TRANSFORM_TEX(node_7532, _WorldOffsetNoise),0.0,0));
                v.vertex.xyz += (float3(node_6397.r,node_2119.g,node_7954.b)*(1.0 - o.vertexColor.r)*_OffsetPower);
				o.vertex = UnityObjectToClipPos( v.vertex );
                o.screen_uv = float3(o.vertex.xy, o.vertex.w);                
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;

			}
			
			sampler2D _MainTex;
			float _Intensity;
			half4 _EdgeColor;
			float _EdgeThickness;
			float _EdgePower;			

			fixed4 frag (v2f i) : SV_Target
			{
				float changex;
				changex = 0.0;
				float changey;
				changey = 0.0;
				float2 correcterScreenUV = (i.screen_uv.xy / i.screen_uv.z + 1) * 0.5;
				correcterScreenUV.y = 1 - correcterScreenUV.y;
				// Need to decrease the number of itterations
				changex -= distorttwo(i.vertex.xy, -1.0, -1.0, _EdgeThickness * 1.375);
				changex -= distorttwo(i.vertex.xy, -1.0,  0.0, _EdgeThickness * 1.375);
				changex -= distorttwo(i.vertex.xy, -1.0,  1.0, _EdgeThickness * 1.375);
				changex += distorttwo(i.vertex.xy,  1.0, -1.0, _EdgeThickness * 1.375);
				changex += distorttwo(i.vertex.xy,  1.0,  0.0, _EdgeThickness * 1.375);
				changex += distorttwo(i.vertex.xy,  1.0,  1.0, _EdgeThickness * 1.375);
				changey -= distorttwo(i.vertex.xy, -1.0, -1.0, _EdgeThickness * 1.375);
				changey -= distorttwo(i.vertex.xy,  0.0, -1.0, _EdgeThickness * 1.375);
				changey -= distorttwo(i.vertex.xy,  1.0, -1.0, _EdgeThickness * 1.375);
				changey += distorttwo(i.vertex.xy, -1.0,  1.0, _EdgeThickness * 1.375);
				changey += distorttwo(i.vertex.xy,  0.0,  1.0, _EdgeThickness * 1.375);
				changey += distorttwo(i.vertex.xy,  1.0,  1.0, _EdgeThickness * 1.375);
				float output = abs(saturate((changex*changex + changey*changey)));
				float4 ccol = tex2D(_GrabTexture, correcterScreenUV);
				ccol += float4(output, output, output, 1.0) * _EdgeColor * _EdgePower * i.vertexColor.a;
				return ccol;
			}
			ENDCG
		}

		// MY END
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
