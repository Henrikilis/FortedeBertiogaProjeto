// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "GhostObject"
{
	Properties
	{
		_MainTex("MainTex", 2D) = "white" {}
		_GhostColor("GhostColor", Color) = (1,1,1,1)
		_NoiseScale("NoiseScale", Float) = 1
		_GlowStrength("GlowStrength", Float) = 1
		_DistortionStrength("DistortionStrength", Float) = 0
		_TextureStrength("TextureStrength", Float) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _NoiseScale;
		uniform float _DistortionStrength;
		uniform float _TextureStrength;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float4 _GhostColor;
		uniform float _GlowStrength;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 uv_TexCoord4 = v.texcoord.xy * float2( 2,2 );
			float2 panner5 = ( 0.3 * _Time.y * float2( 1,0 ) + uv_TexCoord4);
			float simplePerlin2D6 = snoise( panner5*_NoiseScale );
			simplePerlin2D6 = simplePerlin2D6*0.5 + 0.5;
			float smoothstepResult7 = smoothstep( -0.25 , 1.98 , simplePerlin2D6);
			float temp_output_14_0 = ( smoothstepResult7 * _DistortionStrength );
			float3 temp_cast_0 = (temp_output_14_0).xxx;
			v.vertex.xyz += temp_cast_0;
			v.vertex.w = 1;
			float3 temp_cast_1 = (temp_output_14_0).xxx;
			v.normal = temp_cast_1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float4 tex2DNode1 = tex2D( _MainTex, uv_MainTex );
			float4 temp_output_17_0 = ( _TextureStrength * tex2DNode1 );
			o.Albedo = temp_output_17_0.rgb;
			float2 uv_TexCoord4 = i.uv_texcoord * float2( 2,2 );
			float2 panner5 = ( 0.3 * _Time.y * float2( 1,0 ) + uv_TexCoord4);
			float simplePerlin2D6 = snoise( panner5*_NoiseScale );
			simplePerlin2D6 = simplePerlin2D6*0.5 + 0.5;
			float smoothstepResult7 = smoothstep( -0.25 , 1.98 , simplePerlin2D6);
			float4 temp_output_8_0 = ( smoothstepResult7 * _GhostColor );
			o.Emission = ( temp_output_17_0 + ( temp_output_8_0 * _GlowStrength ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18712
974;73;480;655;1525.145;1401.154;5.915455;False;False
Node;AmplifyShaderEditor.Vector2Node;3;-1178.45,404.531;Inherit;False;Constant;_Vector0;Vector 0;4;0;Create;True;0;0;0;False;0;False;2,2;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;4;-1011.374,367.7951;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;5;-773.9468,528.9758;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0;False;1;FLOAT;0.3;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-710.8815,700.9514;Inherit;False;Property;_NoiseScale;NoiseScale;2;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;6;-567.4503,424.0026;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1.47;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;7;-297.0273,366.7476;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;-0.25;False;2;FLOAT;1.98;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;2;-682.0217,-8.189547;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.ColorNode;9;-164.0464,651.151;Inherit;False;Property;_GhostColor;GhostColor;1;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;16;205.798,-15.17947;Inherit;False;Property;_TextureStrength;TextureStrength;5;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;13;86.92589,728.689;Inherit;False;Property;_GlowStrength;GlowStrength;3;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;69.2409,517.9426;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-386.8515,69.92252;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;15;-37.84969,435.1876;Inherit;False;Property;_DistortionStrength;DistortionStrength;4;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;386.3129,59.3186;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;322.1625,620.0331;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;155.4504,328.2874;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;310.6774,201.9016;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;19;605.1917,272.6835;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;788.6124,67.75134;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;GhostObject;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;3;0
WireConnection;5;0;4;0
WireConnection;6;0;5;0
WireConnection;6;1;11;0
WireConnection;7;0;6;0
WireConnection;8;0;7;0
WireConnection;8;1;9;0
WireConnection;1;0;2;0
WireConnection;17;0;16;0
WireConnection;17;1;1;0
WireConnection;12;0;8;0
WireConnection;12;1;13;0
WireConnection;14;0;7;0
WireConnection;14;1;15;0
WireConnection;10;0;8;0
WireConnection;10;1;1;0
WireConnection;19;0;17;0
WireConnection;19;1;12;0
WireConnection;0;0;17;0
WireConnection;0;2;19;0
WireConnection;0;11;14;0
WireConnection;0;12;14;0
ASEEND*/
//CHKSM=E355E9F69CB3ED9C8FF65FB43A265FF29B4EA6A3