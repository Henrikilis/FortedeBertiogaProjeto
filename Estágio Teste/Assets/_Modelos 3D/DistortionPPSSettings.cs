// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( DistortionPPSRenderer ), PostProcessEvent.AfterStack, "Distortion", true )]
public sealed class DistortionPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "Screen" )]
	public TextureParameter _MainTex = new TextureParameter {  };
	[Tooltip( "Pixels X" )]
	public FloatParameter _PixelsX = new FloatParameter { value = 0f };
	[Tooltip( "Pixels Y" )]
	public FloatParameter _PixelsY = new FloatParameter { value = 0f };
}

public sealed class DistortionPPSRenderer : PostProcessEffectRenderer<DistortionPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "Distortion" ) );
		if(settings._MainTex.value != null) sheet.properties.SetTexture( "_MainTex", settings._MainTex );
		sheet.properties.SetFloat( "_PixelsX", settings._PixelsX );
		sheet.properties.SetFloat( "_PixelsY", settings._PixelsY );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
