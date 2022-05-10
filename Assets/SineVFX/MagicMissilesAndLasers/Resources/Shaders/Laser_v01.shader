// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33213,y:32665,varname:node_4795,prsc:2|emission-730-OUT,alpha-283-OUT,clip-6857-OUT;n:type:ShaderForge.SFN_Tex2d,id:6816,x:30796,y:32823,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_6816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1671-OUT;n:type:ShaderForge.SFN_Tex2d,id:3578,x:32418,y:33476,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_3578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9305,x:32418,y:33016,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_9305,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3662-OUT;n:type:ShaderForge.SFN_Append,id:3662,x:32246,y:33016,varname:node_3662,prsc:2|A-5412-OUT,B-7633-OUT;n:type:ShaderForge.SFN_Vector1,id:7633,x:32049,y:33114,varname:node_7633,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:5837,x:32661,y:33110,varname:node_5837,prsc:2|A-9305-RGB,B-5344-RGB,C-4712-OUT,D-3578-R;n:type:ShaderForge.SFN_Color,id:5344,x:32418,y:33193,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_5344,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:4712,x:32261,y:33371,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_4712,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_Clamp01,id:5412,x:31956,y:32743,varname:node_5412,prsc:2|IN-9003-OUT;n:type:ShaderForge.SFN_TexCoord,id:1327,x:29296,y:32433,varname:node_1327,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:1671,x:30393,y:32660,varname:node_1671,prsc:2|A-5984-OUT,B-5031-OUT;n:type:ShaderForge.SFN_Slider,id:3829,x:29361,y:32834,ptovrint:False,ptlb:UV Stretch,ptin:_UVStretch,varname:node_3829,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Time,id:715,x:29563,y:32249,varname:node_715,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8979,x:29799,y:32283,varname:node_8979,prsc:2|A-715-T,B-5431-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5431,x:29563,y:32392,ptovrint:False,ptlb:Scroll Speed 01,ptin:_ScrollSpeed01,varname:node_5431,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-1;n:type:ShaderForge.SFN_Multiply,id:978,x:29738,y:32667,varname:node_978,prsc:2|A-1899-OUT,B-3829-OUT,C-8846-OUT;n:type:ShaderForge.SFN_Add,id:5984,x:30083,y:32665,varname:node_5984,prsc:2|A-1327-U,B-978-OUT;n:type:ShaderForge.SFN_RemapRange,id:1899,x:29559,y:32604,varname:node_1899,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-1327-V;n:type:ShaderForge.SFN_Tex2d,id:8183,x:29334,y:32943,ptovrint:False,ptlb:Mask 02,ptin:_Mask02,varname:node_8183,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5031,x:30083,y:32418,varname:node_5031,prsc:2|A-1327-V,B-8979-OUT;n:type:ShaderForge.SFN_Add,id:8846,x:29530,y:33008,varname:node_8846,prsc:2|A-8183-R,B-1649-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1649,x:29334,y:33123,ptovrint:False,ptlb:UV Stretch Boost,ptin:_UVStretchBoost,varname:node_1649,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:1959,x:32661,y:33654,varname:node_1959,prsc:2|A-2997-OUT,B-9542-OUT,C-3578-R,D-1684-OUT;n:type:ShaderForge.SFN_Slider,id:9542,x:32261,y:33842,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:4;n:type:ShaderForge.SFN_Add,id:4612,x:31028,y:32918,varname:node_4612,prsc:2|A-6816-R,B-490-R;n:type:ShaderForge.SFN_Tex2d,id:490,x:30796,y:33018,ptovrint:False,ptlb:Core,ptin:_Core,varname:node_490,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Clamp01,id:6755,x:31195,y:32918,varname:node_6755,prsc:2|IN-4612-OUT;n:type:ShaderForge.SFN_Tex2d,id:7447,x:30796,y:32632,ptovrint:False,ptlb:Noise 02,ptin:_Noise02,varname:node_7447,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7151-OUT;n:type:ShaderForge.SFN_Subtract,id:9003,x:31796,y:32743,varname:node_9003,prsc:2|A-9702-OUT,B-2759-OUT;n:type:ShaderForge.SFN_Append,id:7151,x:30393,y:32460,varname:node_7151,prsc:2|A-5984-OUT,B-5591-OUT;n:type:ShaderForge.SFN_Time,id:4069,x:29561,y:31992,varname:node_4069,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1594,x:29797,y:32026,varname:node_1594,prsc:2|A-4069-T,B-7527-OUT;n:type:ShaderForge.SFN_Add,id:5591,x:30083,y:32205,varname:node_5591,prsc:2|A-1327-V,B-1594-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7527,x:29561,y:32132,ptovrint:False,ptlb:Scroll Speed 02,ptin:_ScrollSpeed02,varname:node_7527,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Clamp01,id:2997,x:31973,y:33209,varname:node_2997,prsc:2|IN-8042-OUT;n:type:ShaderForge.SFN_Add,id:8042,x:31801,y:33209,varname:node_8042,prsc:2|A-6755-OUT,B-2759-OUT;n:type:ShaderForge.SFN_RemapRange,id:139,x:30992,y:32672,varname:node_139,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7447-R;n:type:ShaderForge.SFN_Clamp01,id:2759,x:31158,y:32647,varname:node_2759,prsc:2|IN-7447-R;n:type:ShaderForge.SFN_Multiply,id:9702,x:31620,y:32743,varname:node_9702,prsc:2|A-6755-OUT,B-1684-OUT;n:type:ShaderForge.SFN_Clamp01,id:1684,x:31151,y:33336,varname:node_1684,prsc:2|IN-3146-OUT;n:type:ShaderForge.SFN_Clamp01,id:283,x:32830,y:33654,varname:node_283,prsc:2|IN-1959-OUT;n:type:ShaderForge.SFN_Add,id:730,x:32908,y:32940,varname:node_730,prsc:2|A-5837-OUT,B-1670-RGB;n:type:ShaderForge.SFN_Color,id:1670,x:32616,y:32633,ptovrint:False,ptlb:Smoke Color,ptin:_SmokeColor,varname:node_1670,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:3146,x:30777,y:33328,ptovrint:False,ptlb:Progress,ptin:_Progress,varname:node_3146,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:3635,x:32066,y:34264,ptovrint:False,ptlb:Opacity Cutoff,ptin:_OpacityCutoff,varname:node_6065,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7151-OUT;n:type:ShaderForge.SFN_Subtract,id:6857,x:32683,y:34268,varname:node_6857,prsc:2|A-851-OUT,B-3779-OUT;n:type:ShaderForge.SFN_OneMinus,id:3779,x:32066,y:34068,varname:node_3779,prsc:2|IN-1684-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:851,x:32334,y:34331,varname:node_851,prsc:2|IN-3635-R,IMIN-8501-OUT,IMAX-3086-OUT,OMIN-8760-OUT,OMAX-1355-OUT;n:type:ShaderForge.SFN_Vector1,id:8501,x:32066,y:34429,varname:node_8501,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3086,x:32066,y:34495,varname:node_3086,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:8760,x:32066,y:34575,ptovrint:False,ptlb:Opacity Remap 1,ptin:_OpacityRemap1,varname:node_714,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:1355,x:32066,y:34651,ptovrint:False,ptlb:Opacity Remap 2,ptin:_OpacityRemap2,varname:_OpacityRemap2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:6816-7447-3578-8183-490-9305-5344-4712-3829-1649-5431-7527-9542-1670-3146-3635-8760-1355;pass:END;sub:END;*/

Shader "Sine VFX/Laser_v01" {
    Properties {
        _Noise01 ("Noise 01", 2D) = "white" {}
        _Noise02 ("Noise 02", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
        _Mask02 ("Mask 02", 2D) = "white" {}
        _Core ("Core", 2D) = "white" {}
        _Ramp ("Ramp", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _FinalPower ("Final Power", Range(0, 10)) = 2
        _UVStretch ("UV Stretch", Range(0, 4)) = 0
        _UVStretchBoost ("UV Stretch Boost", Float ) = 2
        _ScrollSpeed01 ("Scroll Speed 01", Float ) = -1
        _ScrollSpeed02 ("Scroll Speed 02", Float ) = 0
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 2
        _SmokeColor ("Smoke Color", Color) = (0.5,0.5,0.5,1)
        _Progress ("Progress", Range(0, 1)) = 0
        _OpacityCutoff ("Opacity Cutoff", 2D) = "white" {}
        _OpacityRemap1 ("Opacity Remap 1", Float ) = 0
        _OpacityRemap2 ("Opacity Remap 2", Float ) = 0
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
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float4 _Color;
            uniform float _FinalPower;
            uniform float _UVStretch;
            uniform float _ScrollSpeed01;
            uniform sampler2D _Mask02; uniform float4 _Mask02_ST;
            uniform float _UVStretchBoost;
            uniform float _OpacityBoost;
            uniform sampler2D _Core; uniform float4 _Core_ST;
            uniform sampler2D _Noise02; uniform float4 _Noise02_ST;
            uniform float _ScrollSpeed02;
            uniform float4 _SmokeColor;
            uniform float _Progress;
            uniform sampler2D _OpacityCutoff; uniform float4 _OpacityCutoff_ST;
            uniform float _OpacityRemap1;
            uniform float _OpacityRemap2;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Mask02_var = tex2D(_Mask02,TRANSFORM_TEX(i.uv0, _Mask02));
                float node_5984 = (i.uv0.r+((i.uv0.g*2.0+-1.0)*_UVStretch*(_Mask02_var.r+_UVStretchBoost)));
                float4 node_4069 = _Time;
                float2 node_7151 = float2(node_5984,(i.uv0.g+(node_4069.g*_ScrollSpeed02)));
                float4 _OpacityCutoff_var = tex2D(_OpacityCutoff,TRANSFORM_TEX(node_7151, _OpacityCutoff));
                float node_8501 = 0.0;
                float node_1684 = saturate(_Progress);
                clip(((_OpacityRemap1 + ( (_OpacityCutoff_var.r - node_8501) * (_OpacityRemap2 - _OpacityRemap1) ) / (1.0 - node_8501))-(1.0 - node_1684)) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_715 = _Time;
                float2 node_1671 = float2(node_5984,(i.uv0.g+(node_715.g*_ScrollSpeed01)));
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_1671, _Noise01));
                float4 _Core_var = tex2D(_Core,TRANSFORM_TEX(i.uv0, _Core));
                float node_6755 = saturate((_Noise01_var.r+_Core_var.r));
                float4 _Noise02_var = tex2D(_Noise02,TRANSFORM_TEX(node_7151, _Noise02));
                float node_2759 = saturate(_Noise02_var.r);
                float2 node_3662 = float2(saturate(((node_6755*node_1684)-node_2759)),0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_3662, _Ramp));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((_Ramp_var.rgb*_Color.rgb*_FinalPower*_Mask_var.r)+_SmokeColor.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((saturate((node_6755+node_2759))*_OpacityBoost*_Mask_var.r*node_1684)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
