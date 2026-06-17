Shader "Custom/HologramURP"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (0,1,1,1)
        _Intensity ("Intensity", Float) = 2
        _Speed ("Pulse Speed", Float) = 2
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Pass
        {
            Name "ForwardPass"

            Blend SrcAlpha One
            ZWrite Off
            Cull Back

            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
            };

            float4 _BaseColor;
            float _Intensity;
            float _Speed;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;

                OUT.positionHCS =
                    TransformObjectToHClip(IN.positionOS.xyz);

                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float pulse =
                    abs(sin(_Time.y * _Speed));

                float brightness =
                    pulse * _Intensity;

                return half4(
                    _BaseColor.rgb * brightness,
                    pulse
                );
            }

            ENDHLSL
        }
    }
}