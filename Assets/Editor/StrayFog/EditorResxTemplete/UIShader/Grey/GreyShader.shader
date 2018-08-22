// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Game/UI/Gray"
{	
   Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
			_AlphaTex ("Alpha (A)", 2D) = "white" {}

        _GrayScale ("GrayScale", Range(0,1)) = 1
		//MASK SUPPORT ADD
		[PerRendererData] _StencilComp ("Stencil Comparison", Float) = 8
		[PerRendererData] _Stencil ("Stencil ID", Float) = 0
		[PerRendererData] _StencilOp ("Stencil Operation", Float) = 0
		[PerRendererData] _StencilWriteMask ("Stencil Write Mask", Float) = 255
		[PerRendererData] _StencilReadMask ("Stencil Read Mask", Float) = 255
		[PerRendererData] _ColorMask ("Color Mask", Float) = 15
		//END
    }
 
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

		//MASK SUPPORT ADD
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp] 
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}
		ColorMask [_ColorMask]
		//END
       
        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Fog { Mode Off }		
        Blend SrcAlpha OneMinusSrcAlpha		
        Pass
        {
            CGPROGRAM
			#pragma multi_compile AlphaSplitON AlphaSplitOFF
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
           
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float2 texcoord : TEXCOORD0;
				float4 color:COLOR;
            };
 
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                half2 texcoord  : TEXCOORD0;
				float4 color:COLOR;
            };
           
            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
				OUT.color = IN.color;
				#ifdef UNITY_HALF_TEXEL_OFFSET
					OUT.vertex.xy += (_ScreenParams.zw-1.0)*float2(-1,1);
				#endif
                return OUT;
            }
           
            sampler2D _MainTex;
			sampler2D _AlphaTex;
            fixed _GrayScale;
 
            fixed4 frag(v2f IN) : SV_Target
            {
			#if AlphaSplitON
                fixed4 c = fixed4(tex2D(_MainTex, IN.texcoord).rgb , tex2D(_AlphaTex, IN.texcoord).r)* IN.color;
			#elif AlphaSplitOFF
				fixed4 c = tex2D(_MainTex, IN.texcoord)* IN.color;
			#endif
                fixed grayscale = Luminance(c.rgb);			
                c.rgb = lerp(c.rgb,grayscale.xxx,_GrayScale);
                return c;
            }
            ENDCG
        }
    }
}