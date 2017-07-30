Shader "Hidden/PixelizeShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_PixelV("V Pixel count", float) = 100
		_PixelU("U Pixel count", float) = 100
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			float _PixelV;
			float _PixelU;
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;
				uv.x *= _PixelU;
				uv.y *= _PixelV;
				uv.x = round(uv.x);
				uv.y = round(uv.y);
				uv.x /= _PixelU;
				uv.y /= _PixelV;
				fixed4 col = tex2D(_MainTex, uv);
				col = ((col.r + col.g + col.b) / 3) * half4(0.83f, 0.78f, 0.39f, 1.0f);
				return col;
			}
			ENDCG
		}
	}
}
