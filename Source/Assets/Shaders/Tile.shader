Shader "Cone/Tile" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Wallpaper ("Wallpaper", 2D) = "white" {}
	}
	
    SubShader {
        Pass {
        	LOD 100
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _Wallpaper;
			
			struct vertIn
			{
				float4 vertex : POSITION;
				float4 tc : TEXCOORD0;
			};
			
            struct vertOut {
                float4 pos : SV_POSITION;
                float4 scrPos : TEXCOORD1;
                float2 tc;
            };

            vertOut vert(vertIn i) {
                vertOut o;
                o.pos = mul (UNITY_MATRIX_MVP, i.vertex);
                o.scrPos = ComputeScreenPos(o.pos);
                o.tc = i.tc.xy;
                return o;
            }

            fixed4 frag(vertOut i) : COLOR0 {
                float2 wcoord = i.scrPos.xy / i.scrPos.w;
                fixed4 tex = tex2D(_MainTex, i.tc);
                return tex2D(_Wallpaper, wcoord) * (1 - tex.a) + tex * tex.a;
            }

            ENDCG
        }
    }
    
	Fallback "Unlit/Texture"
}