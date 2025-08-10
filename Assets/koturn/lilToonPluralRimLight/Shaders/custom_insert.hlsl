#if defined(LIL_LITE)
    #define OVERRIDE_RIMLIGHT \
        lilGetRim(fd); \
        lilGetRim2nd(fd); \
        lilGetRim3rd(fd);
#else
    #define OVERRIDE_RIMLIGHT \
        lilGetRim(fd LIL_SAMP_IN(sampler_MainTex)); \
        lilGetRim2nd(fd LIL_SAMP_IN(sampler_MainTex)); \
        lilGetRim3rd(fd LIL_SAMP_IN(sampler_MainTex));
#endif  // defined(LIL_LITE)


// Rim Light 2nd
#if defined(LIL_FEATURE_RIMLIGHT) && !defined(LIL_LITE)
    void lilGetRim2nd(inout lilFragData fd LIL_SAMP_IN_FUNC(samp))
    {
        if(_UseRim2nd)
        {
            #if defined(LIL_FEATURE_RIMLIGHT_DIRECTION)
                // Color
                float4 rimColor = _Rim2ndColor;
                float4 rimIndirColor = _Rim2ndIndirColor;
                #if defined(LIL_FEATURE_RimColorTex)
                    float4 rimColorTex = LIL_SAMPLE_2D_ST(_Rim2ndColorTex, samp, fd.uvMain);
                    rimColor *= rimColorTex;
                    rimIndirColor *= rimColorTex;
                #endif
                rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.albedo, _Rim2ndMainStrength);

                // View direction
                float3 V = lilBlendVRParallax(fd.headV, fd.V, _Rim2ndVRParallaxStrength);

                // Normal
                float3 N = fd.N;
                #if defined(LIL_FEATURE_NORMAL_1ST) || defined(LIL_FEATURE_NORMAL_2ND)
                    N = lerp(fd.origN, fd.N, _Rim2ndNormalStrength);
                #endif
                float nvabs = abs(dot(N,V));

                // Factor
                float lnRaw = dot(fd.L, N) * 0.5 + 0.5;
                float lnDir = saturate((lnRaw + _Rim2ndDirRange) / (1.0 + _Rim2ndDirRange));
                float lnIndir = saturate((1.0-lnRaw + _Rim2ndIndirRange) / (1.0 + _Rim2ndIndirRange));
                float rim = pow(saturate(1.0 - nvabs), _Rim2ndFresnelPower);
                rim = fd.facing < (_Rim2ndBackfaceMask-1.0) ? 0.0 : rim;
                float rimDir = lerp(rim, rim*lnDir, _Rim2ndDirStrength);
                float rimIndir = rim * lnIndir * _Rim2ndDirStrength;

                rimDir = lilTooningScale(_AAStrength, rimDir, _Rim2ndBorder, _Rim2ndBlur);
                rimIndir = lilTooningScale(_AAStrength, rimIndir, _Rim2ndIndirBorder, _Rim2ndIndirBlur);

                rimDir = lerp(rimDir, rimDir * fd.shadowmix, _Rim2ndShadowMask);
                rimIndir = lerp(rimIndir, rimIndir * fd.shadowmix, _Rim2ndShadowMask);
                #if LIL_RENDER == 2 && !defined(LIL_REFRACTION)
                    if(_Rim2ndApplyTransparency)
                    {
                        rimDir *= fd.col.a;
                        rimIndir *= fd.col.a;
                    }
                #endif

                // Blend
                #if !defined(LIL_PASS_FORWARDADD)
                    float3 rimLightMul = 1 - _Rim2ndEnableLighting + fd.lightColor * _Rim2ndEnableLighting;
                #else
                    float3 rimLightMul = _Rim2ndBlendMode < 3 ? fd.lightColor * _Rim2ndEnableLighting : 1;
                #endif
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimColor.rgb * rimLightMul, rimDir * rimColor.a, _Rim2ndBlendMode);
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimIndirColor.rgb * rimLightMul, rimIndir * rimIndirColor.a, _Rim2ndBlendMode);
            #else
                // Color
                float4 rimColor = _Rim2ndColor;
                #if defined(LIL_FEATURE_RimColorTex)
                    rimColor *= LIL_SAMPLE_2D_ST(_Rim2ndColorTex, samp, fd.uvMain);
                #endif
                rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.albedo, _Rim2ndMainStrength);

                // Normal
                float3 N = fd.N;
                #if defined(LIL_FEATURE_NORMAL_1ST) || defined(LIL_FEATURE_NORMAL_2ND)
                    N = lerp(fd.origN, fd.N, _Rim2ndNormalStrength);
                #endif
                float nvabs = abs(dot(N,fd.V));

                // Factor
                float rim = pow(saturate(1.0 - nvabs), _Rim2ndFresnelPower);
                rim = fd.facing < (_Rim2ndBackfaceMask-1.0) ? 0.0 : rim;
                rim = lilTooningScale(_AAStrength, rim, _Rim2ndBorder, _Rim2ndBlur);
                #if LIL_RENDER == 2 && !defined(LIL_REFRACTION)
                    if(_Rim2ndApplyTransparency) rim *= fd.col.a;
                #endif
                rim = lerp(rim, rim * fd.shadowmix, _Rim2ndShadowMask);

                // Blend
                #if !defined(LIL_PASS_FORWARDADD)
                    rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.lightColor, _Rim2ndEnableLighting);
                #else
                    if(_Rim2ndBlendMode < 3) rimColor.rgb *= fd.lightColor * _Rim2ndEnableLighting;
                #endif
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimColor.rgb, rim * rimColor.a, _Rim2ndBlendMode);
            #endif
        }
    }
#elif defined(LIL_LITE)
    void lilGetRim2nd(inout lilFragData fd)
    {
        if(_UseRim2nd)
        {
            float rim = pow(saturate(1.0 - fd.nvabs), _Rim2ndFresnelPower);
            rim = lilTooningScale(_AAStrength, rim, _Rim2ndBorder, _Rim2ndBlur);
            rim = lerp(rim, rim * fd.shadowmix, _Rim2ndShadowMask);
            fd.col.rgb += rim * fd.triMask.g * _Rim2ndColor.rgb * fd.lightColor;
        }
    }
#endif


// Rim Light 3rd
#if defined(LIL_FEATURE_RIMLIGHT) && !defined(LIL_LITE)
    void lilGetRim3rd(inout lilFragData fd LIL_SAMP_IN_FUNC(samp))
    {
        if(_UseRim3rd)
        {
            #if defined(LIL_FEATURE_RIMLIGHT_DIRECTION)
                // Color
                float4 rimColor = _Rim3rdColor;
                float4 rimIndirColor = _Rim3rdIndirColor;
                #if defined(LIL_FEATURE_RimColorTex)
                    float4 rimColorTex = LIL_SAMPLE_2D_ST(_Rim3rdColorTex, samp, fd.uvMain);
                    rimColor *= rimColorTex;
                    rimIndirColor *= rimColorTex;
                #endif
                rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.albedo, _Rim3rdMainStrength);

                // View direction
                float3 V = lilBlendVRParallax(fd.headV, fd.V, _Rim3rdVRParallaxStrength);

                // Normal
                float3 N = fd.N;
                #if defined(LIL_FEATURE_NORMAL_1ST) || defined(LIL_FEATURE_NORMAL_2ND)
                    N = lerp(fd.origN, fd.N, _Rim3rdNormalStrength);
                #endif
                float nvabs = abs(dot(N,V));

                // Factor
                float lnRaw = dot(fd.L, N) * 0.5 + 0.5;
                float lnDir = saturate((lnRaw + _Rim3rdDirRange) / (1.0 + _Rim3rdDirRange));
                float lnIndir = saturate((1.0-lnRaw + _Rim3rdIndirRange) / (1.0 + _Rim3rdIndirRange));
                float rim = pow(saturate(1.0 - nvabs), _Rim3rdFresnelPower);
                rim = fd.facing < (_Rim3rdBackfaceMask-1.0) ? 0.0 : rim;
                float rimDir = lerp(rim, rim*lnDir, _Rim3rdDirStrength);
                float rimIndir = rim * lnIndir * _Rim3rdDirStrength;

                rimDir = lilTooningScale(_AAStrength, rimDir, _Rim3rdBorder, _Rim3rdBlur);
                rimIndir = lilTooningScale(_AAStrength, rimIndir, _Rim3rdIndirBorder, _Rim3rdIndirBlur);

                rimDir = lerp(rimDir, rimDir * fd.shadowmix, _Rim3rdShadowMask);
                rimIndir = lerp(rimIndir, rimIndir * fd.shadowmix, _Rim3rdShadowMask);
                #if LIL_RENDER == 2 && !defined(LIL_REFRACTION)
                    if(_Rim3rdApplyTransparency)
                    {
                        rimDir *= fd.col.a;
                        rimIndir *= fd.col.a;
                    }
                #endif

                // Blend
                #if !defined(LIL_PASS_FORWARDADD)
                    float3 rimLightMul = 1 - _Rim3rdEnableLighting + fd.lightColor * _Rim3rdEnableLighting;
                #else
                    float3 rimLightMul = _Rim3rdBlendMode < 3 ? fd.lightColor * _Rim3rdEnableLighting : 1;
                #endif
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimColor.rgb * rimLightMul, rimDir * rimColor.a, _Rim3rdBlendMode);
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimIndirColor.rgb * rimLightMul, rimIndir * rimIndirColor.a, _Rim3rdBlendMode);
            #else
                // Color
                float4 rimColor = _Rim3rdColor;
                #if defined(LIL_FEATURE_RimColorTex)
                    rimColor *= LIL_SAMPLE_2D_ST(_Rim3rdColorTex, samp, fd.uvMain);
                #endif
                rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.albedo, _Rim3rdMainStrength);

                // Normal
                float3 N = fd.N;
                #if defined(LIL_FEATURE_NORMAL_1ST) || defined(LIL_FEATURE_NORMAL_2ND)
                    N = lerp(fd.origN, fd.N, _Rim3rdNormalStrength);
                #endif
                float nvabs = abs(dot(N,fd.V));

                // Factor
                float rim = pow(saturate(1.0 - nvabs), _Rim3rdFresnelPower);
                rim = fd.facing < (_Rim3rdBackfaceMask-1.0) ? 0.0 : rim;
                rim = lilTooningScale(_AAStrength, rim, _Rim3rdBorder, _Rim3rdBlur);
                #if LIL_RENDER == 2 && !defined(LIL_REFRACTION)
                    if(_Rim3rdApplyTransparency) rim *= fd.col.a;
                #endif
                rim = lerp(rim, rim * fd.shadowmix, _Rim3rdShadowMask);

                // Blend
                #if !defined(LIL_PASS_FORWARDADD)
                    rimColor.rgb = lerp(rimColor.rgb, rimColor.rgb * fd.lightColor, _Rim3rdEnableLighting);
                #else
                    if(_Rim3rdBlendMode < 3) rimColor.rgb *= fd.lightColor * _Rim3rdEnableLighting;
                #endif
                fd.col.rgb = lilBlendColor(fd.col.rgb, rimColor.rgb, rim * rimColor.a, _Rim3rdBlendMode);
            #endif
        }
    }
#elif defined(LIL_LITE)
    void lilGetRim3rd(inout lilFragData fd)
    {
        if(_UseRim3rd)
        {
            float rim = pow(saturate(1.0 - fd.nvabs), _Rim3rdFresnelPower);
            rim = lilTooningScale(_AAStrength, rim, _Rim3rdBorder, _Rim3rdBlur);
            rim = lerp(rim, rim * fd.shadowmix, _Rim3rdShadowMask);
            fd.col.rgb += rim * fd.triMask.g * _Rim3rdColor.rgb * fd.lightColor;
        }
    }
#endif
