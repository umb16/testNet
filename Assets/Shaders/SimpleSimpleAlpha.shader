// Unlit alpha-blended shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Unlit/Color" {
Properties {
	_Color ("Color", Color) = (1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 100
	//ZWrite Off
	Pass {
		SetTexture [_MainTex] {
			   		ConstantColor [_Color]
					Combine texture * constant  } 
	}
}
}
