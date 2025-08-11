using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using lilToon;


namespace Koturn.LilToonPluralRimLight.Editor
{
    /// <summary>
    /// <see cref="ShaderGUI"/> for the custom shader variations of lilToon.
    /// </summary>
    public sealed class LilToonPluralRimLightInspector : lilToonInspector
    {
        /// <summary>
        /// Name of this custom shader.
        /// </summary>
        public const string ShaderName = "koturn/lilToonPluralRimLight";

        /// <summary>
        /// A flag whether to fold custom properties or not.
        /// </summary>
        private static bool isShowCustomProperties;

        // Custom properties
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_UseRim2nd".
        /// </summary>
        private MaterialProperty _useRim2nd;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndColorTex".
        /// </summary>
        private MaterialProperty _rim2ndColorTex;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndColor".
        /// </summary>
        private MaterialProperty _rim2ndColor;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndIndirColor".
        /// </summary>
        private MaterialProperty _rim2ndIndirColor;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndNormalStrength".
        /// </summary>
        private MaterialProperty _rim2ndNormalStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndBorder".
        /// </summary>
        private MaterialProperty _rim2ndBorder;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndBlur".
        /// </summary>
        private MaterialProperty _rim2ndBlur;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndFresnelPower".
        /// </summary>
        private MaterialProperty _rim2ndFresnelPower;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndEnableLighting".
        /// </summary>
        private MaterialProperty _rim2ndEnableLighting;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndShadowMask".
        /// </summary>
        private MaterialProperty _rim2ndShadowMask;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndVRParallaxStrength".
        /// </summary>
        private MaterialProperty _rim2ndVRParallaxStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndBackfaceMask".
        /// </summary>
        private MaterialProperty _rim2ndBackfaceMask;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndMainStrength".
        /// </summary>
        private MaterialProperty _rim2ndMainStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndDirStrength".
        /// </summary>
        private MaterialProperty _rim2ndDirStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndDirRange".
        /// </summary>
        private MaterialProperty _rim2ndDirRange;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndIndirRange".
        /// </summary>
        private MaterialProperty _rim2ndIndirRange;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndIndirBorder".
        /// </summary>
        private MaterialProperty _rim2ndIndirBorder;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndIndirBlur".
        /// </summary>
        private MaterialProperty _rim2ndIndirBlur;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndBlendMode".
        /// </summary>
        private MaterialProperty _rim2ndBlendMode;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim2ndApplyTransparency".
        /// </summary>
        private MaterialProperty _rim2ndApplyTransparency;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_UseRim3rd".
        /// </summary>
        private MaterialProperty _useRim3rd;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdColorTex".
        /// </summary>
        private MaterialProperty _rim3rdColorTex;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdColor".
        /// </summary>
        private MaterialProperty _rim3rdColor;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdIndirColor".
        /// </summary>
        private MaterialProperty _rim3rdIndirColor;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdNormalStrength".
        /// </summary>
        private MaterialProperty _rim3rdNormalStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdBorder".
        /// </summary>
        private MaterialProperty _rim3rdBorder;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdBlur".
        /// </summary>
        private MaterialProperty _rim3rdBlur;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdFresnelPower".
        /// </summary>
        private MaterialProperty _rim3rdFresnelPower;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdEnableLighting".
        /// </summary>
        private MaterialProperty _rim3rdEnableLighting;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdShadowMask".
        /// </summary>
        private MaterialProperty _rim3rdShadowMask;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdVRParallaxStrength".
        /// </summary>
        private MaterialProperty _rim3rdVRParallaxStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdBackfaceMask".
        /// </summary>
        private MaterialProperty _rim3rdBackfaceMask;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdMainStrength".
        /// </summary>
        private MaterialProperty _rim3rdMainStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdDirStrength".
        /// </summary>
        private MaterialProperty _rim3rdDirStrength;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdDirRange".
        /// </summary>
        private MaterialProperty _rim3rdDirRange;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdIndirRange".
        /// </summary>
        private MaterialProperty _rim3rdIndirRange;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdIndirBorder".
        /// </summary>
        private MaterialProperty _rim3rdIndirBorder;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdIndirBlur".
        /// </summary>
        private MaterialProperty _rim3rdIndirBlur;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdBlendMode".
        /// </summary>
        private MaterialProperty _rim3rdBlendMode;
        /// <summary>
        /// <see cref="MaterialProperty"/> of "_Rim3rdApplyTransparency".
        /// </summary>
        private MaterialProperty _rim3rdApplyTransparency;


        /// <summary>
        /// Load custom language file and make cache of shader properties.
        /// </summary>
        /// <param name="props">Properties of the material.</param>
        /// <param name="material">Target material.</param>
        protected override void LoadCustomProperties(MaterialProperty[] props, Material material)
        {
            isCustomShader = true;

            // If you want to change rendering modes in the editor, specify the shader here
            ReplaceToCustomShaders();
            isShowRenderMode = !material.shader.name.Contains("/[Optional] ");

            // If not, set isShowRenderMode to false
            //isShowRenderMode = false;

            LoadCustomLanguage(AssetGuid.LangCustom);

            _useRim2nd = FindProperty("_UseRim2nd", props);
            _rim2ndColorTex = FindProperty("_Rim2ndColorTex", props);
            _rim2ndColor = FindProperty("_Rim2ndColor", props);
            _rim2ndIndirColor = FindProperty("_Rim2ndIndirColor", props);
            _rim2ndNormalStrength = FindProperty("_Rim2ndNormalStrength", props);
            _rim2ndBorder = FindProperty("_Rim2ndBorder", props);
            _rim2ndBlur = FindProperty("_Rim2ndBlur", props);
            _rim2ndFresnelPower = FindProperty("_Rim2ndFresnelPower", props);
            _rim2ndEnableLighting = FindProperty("_Rim2ndEnableLighting", props);
            _rim2ndShadowMask = FindProperty("_Rim2ndShadowMask", props);
            _rim2ndVRParallaxStrength = FindProperty("_Rim2ndVRParallaxStrength", props);
            _rim2ndBackfaceMask = FindProperty("_Rim2ndBackfaceMask", props);
            _rim2ndMainStrength = FindProperty("_Rim2ndMainStrength", props);
            _rim2ndDirStrength = FindProperty("_Rim2ndDirStrength", props);
            _rim2ndDirRange = FindProperty("_Rim2ndDirRange", props);
            _rim2ndIndirRange = FindProperty("_Rim2ndIndirRange", props);
            _rim2ndIndirBorder = FindProperty("_Rim2ndIndirBorder", props);
            _rim2ndIndirBlur = FindProperty("_Rim2ndIndirBlur", props);
            _rim2ndBlendMode = FindProperty("_Rim2ndBlendMode", props);
            _rim2ndApplyTransparency = FindProperty("_Rim2ndApplyTransparency", props);
            _useRim3rd = FindProperty("_UseRim3rd", props);
            _rim3rdColorTex = FindProperty("_Rim3rdColorTex", props);
            _rim3rdColor = FindProperty("_Rim3rdColor", props);
            _rim3rdIndirColor = FindProperty("_Rim3rdIndirColor", props);
            _rim3rdNormalStrength = FindProperty("_Rim3rdNormalStrength", props);
            _rim3rdBorder = FindProperty("_Rim3rdBorder", props);
            _rim3rdBlur = FindProperty("_Rim3rdBlur", props);
            _rim3rdFresnelPower = FindProperty("_Rim3rdFresnelPower", props);
            _rim3rdEnableLighting = FindProperty("_Rim3rdEnableLighting", props);
            _rim3rdShadowMask = FindProperty("_Rim3rdShadowMask", props);
            _rim3rdVRParallaxStrength = FindProperty("_Rim3rdVRParallaxStrength", props);
            _rim3rdBackfaceMask = FindProperty("_Rim3rdBackfaceMask", props);
            _rim3rdMainStrength = FindProperty("_Rim3rdMainStrength", props);
            _rim3rdDirStrength = FindProperty("_Rim3rdDirStrength", props);
            _rim3rdDirRange = FindProperty("_Rim3rdDirRange", props);
            _rim3rdIndirRange = FindProperty("_Rim3rdIndirRange", props);
            _rim3rdIndirBorder = FindProperty("_Rim3rdIndirBorder", props);
            _rim3rdIndirBlur = FindProperty("_Rim3rdIndirBlur", props);
            _rim3rdBlendMode = FindProperty("_Rim3rdBlendMode", props);
            _rim3rdApplyTransparency = FindProperty("_Rim3rdApplyTransparency", props);
        }

        /// <summary>
        /// Draw custom properties.
        /// </summary>
        /// <param name="material">Target material.</param>
        protected override void DrawCustomProperties(Material material)
        {
            // GUIStyles Name   Description
            // ---------------- ------------------------------------
            // boxOuter         outer box
            // boxInnerHalf     inner box
            // boxInner         inner box without label
            // customBox        box (similar to unity default box)
            // customToggleFont label for box

            var titleLoc = GetLoc("sCustomShaderTitle");
            isShowCustomProperties = Foldout(titleLoc, titleLoc, isShowCustomProperties);
            if (!isShowCustomProperties)
            {
                return;
            }

            DrawRim2ndSettings();
            DrawRim3rdSettings();
        }

        /// <summary>
        /// Replace shaders to custom shaders.
        /// </summary>
        protected override void ReplaceToCustomShaders()
        {
            lts         = Shader.Find(ShaderName + "/lilToon");
            ltsc        = Shader.Find("Hidden/" + ShaderName + "/Cutout");
            ltst        = Shader.Find("Hidden/" + ShaderName + "/Transparent");
            ltsot       = Shader.Find("Hidden/" + ShaderName + "/OnePassTransparent");
            ltstt       = Shader.Find("Hidden/" + ShaderName + "/TwoPassTransparent");

            ltso        = Shader.Find("Hidden/" + ShaderName + "/OpaqueOutline");
            ltsco       = Shader.Find("Hidden/" + ShaderName + "/CutoutOutline");
            ltsto       = Shader.Find("Hidden/" + ShaderName + "/TransparentOutline");
            ltsoto      = Shader.Find("Hidden/" + ShaderName + "/OnePassTransparentOutline");
            ltstto      = Shader.Find("Hidden/" + ShaderName + "/TwoPassTransparentOutline");

            ltsoo       = Shader.Find(ShaderName + "/[Optional] OutlineOnly/Opaque");
            ltscoo      = Shader.Find(ShaderName + "/[Optional] OutlineOnly/Cutout");
            ltstoo      = Shader.Find(ShaderName + "/[Optional] OutlineOnly/Transparent");

            ltstess     = Shader.Find("Hidden/" + ShaderName + "/Tessellation/Opaque");
            ltstessc    = Shader.Find("Hidden/" + ShaderName + "/Tessellation/Cutout");
            ltstesst    = Shader.Find("Hidden/" + ShaderName + "/Tessellation/Transparent");
            ltstessot   = Shader.Find("Hidden/" + ShaderName + "/Tessellation/OnePassTransparent");
            ltstesstt   = Shader.Find("Hidden/" + ShaderName + "/Tessellation/TwoPassTransparent");

            ltstesso    = Shader.Find("Hidden/" + ShaderName + "/Tessellation/OpaqueOutline");
            ltstessco   = Shader.Find("Hidden/" + ShaderName + "/Tessellation/CutoutOutline");
            ltstessto   = Shader.Find("Hidden/" + ShaderName + "/Tessellation/TransparentOutline");
            ltstessoto  = Shader.Find("Hidden/" + ShaderName + "/Tessellation/OnePassTransparentOutline");
            ltstesstto  = Shader.Find("Hidden/" + ShaderName + "/Tessellation/TwoPassTransparentOutline");

            ltsl        = Shader.Find(ShaderName + "/lilToonLite");
            ltslc       = Shader.Find("Hidden/" + ShaderName + "/Lite/Cutout");
            ltslt       = Shader.Find("Hidden/" + ShaderName + "/Lite/Transparent");
            ltslot      = Shader.Find("Hidden/" + ShaderName + "/Lite/OnePassTransparent");
            ltsltt      = Shader.Find("Hidden/" + ShaderName + "/Lite/TwoPassTransparent");

            ltslo       = Shader.Find("Hidden/" + ShaderName + "/Lite/OpaqueOutline");
            ltslco      = Shader.Find("Hidden/" + ShaderName + "/Lite/CutoutOutline");
            ltslto      = Shader.Find("Hidden/" + ShaderName + "/Lite/TransparentOutline");
            ltsloto     = Shader.Find("Hidden/" + ShaderName + "/Lite/OnePassTransparentOutline");
            ltsltto     = Shader.Find("Hidden/" + ShaderName + "/Lite/TwoPassTransparentOutline");

            ltsref      = Shader.Find("Hidden/" + ShaderName + "/Refraction");
            ltsrefb     = Shader.Find("Hidden/" + ShaderName + "/RefractionBlur");
            ltsfur      = Shader.Find("Hidden/" + ShaderName + "/Fur");
            ltsfurc     = Shader.Find("Hidden/" + ShaderName + "/FurCutout");
            ltsfurtwo   = Shader.Find("Hidden/" + ShaderName + "/FurTwoPass");
            ltsfuro     = Shader.Find(ShaderName + "/[Optional] FurOnly/Transparent");
            ltsfuroc    = Shader.Find(ShaderName + "/[Optional] FurOnly/Cutout");
            ltsfurotwo  = Shader.Find(ShaderName + "/[Optional] FurOnly/TwoPass");
            ltsgem      = Shader.Find("Hidden/" + ShaderName + "/Gem");
            ltsfs       = Shader.Find(ShaderName + "/[Optional] FakeShadow");

            ltsover     = Shader.Find(ShaderName + "/[Optional] Overlay");
            ltsoover    = Shader.Find(ShaderName + "/[Optional] OverlayOnePass");
            ltslover    = Shader.Find(ShaderName + "/[Optional] LiteOverlay");
            ltsloover   = Shader.Find(ShaderName + "/[Optional] LiteOverlayOnePass");

            ltsm        = Shader.Find(ShaderName + "/lilToonMulti");
            ltsmo       = Shader.Find("Hidden/" + ShaderName + "/MultiOutline");
            ltsmref     = Shader.Find("Hidden/" + ShaderName + "/MultiRefraction");
            ltsmfur     = Shader.Find("Hidden/" + ShaderName + "/MultiFur");
            ltsmgem     = Shader.Find("Hidden/" + ShaderName + "/MultiGem");
        }


        /// <summary>
        /// Draw second rim light settings.
        /// </summary>
        private void DrawRim2ndSettings()
        {
            using (new EditorGUILayout.VerticalScope(boxOuter))
            {
                var me = m_MaterialEditor;
                lilEditorGUI.LocalizedProperty(me, _useRim2nd, false);
                if (_useRim2nd.floatValue == 1.0f)
                {
                    using (new EditorGUILayout.VerticalScope(boxInnerHalf))
                    {
                        if (!isLite)
                        {
                            lilEditorGUI.TextureGUI(me, false, ref edSet.isShowRimColorTex, colorMaskRGBAContent, _rim2ndColorTex, _rim2ndColor);
                            lilEditorGUI.LocalizedPropertyAlpha(_rim2ndColor);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndMainStrength);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndEnableLighting);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndShadowMask);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndBackfaceMask);
                            if (isTransparent)
                            {
                                lilEditorGUI.LocalizedProperty(me, _rim2ndApplyTransparency);
                            }
                            lilEditorGUI.LocalizedProperty(me, _rim2ndBlendMode);
                            lilEditorGUI.DrawLine();
                            lilEditorGUI.LocalizedProperty(me, _rim2ndDirStrength);
                            if (_rim2ndDirStrength.floatValue != 0.0f)
                            {
                                using (new EditorGUI.IndentLevelScope())
                                {
                                    lilEditorGUI.LocalizedProperty(me, _rim2ndDirRange);
                                    lilEditorGUI.InvBorderGUI(_rim2ndBorder);
                                    lilEditorGUI.LocalizedProperty(me, _rim2ndBlur);
                                    lilEditorGUI.DrawLine();
                                    lilEditorGUI.LocalizedProperty(me, _rim2ndIndirRange);
                                    lilEditorGUI.LocalizedProperty(me, _rim2ndIndirColor);
                                    lilEditorGUI.InvBorderGUI(_rim2ndIndirBorder);
                                    lilEditorGUI.LocalizedProperty(me, _rim2ndIndirBlur);
                                }
                                lilEditorGUI.DrawLine();
                            }
                            else
                            {
                                lilEditorGUI.InvBorderGUI(_rim2ndBorder);
                                lilEditorGUI.LocalizedProperty(me, _rim2ndBlur);
                            }
                            lilEditorGUI.LocalizedProperty(me, _rim2ndNormalStrength);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndFresnelPower);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndVRParallaxStrength);
                        }
                        else
                        {
                            lilEditorGUI.LocalizedProperty(me, _rim2ndColor);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndShadowMask);
                            lilEditorGUI.DrawLine();
                            lilEditorGUI.InvBorderGUI(_rim2ndBorder);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndBlur);
                            lilEditorGUI.LocalizedProperty(me, _rim2ndFresnelPower);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Draw third rim light settings.
        /// </summary>
        private void DrawRim3rdSettings()
        {
            using (new EditorGUILayout.VerticalScope(boxOuter))
            {
                var me = m_MaterialEditor;
                lilEditorGUI.LocalizedProperty(me, _useRim3rd, false);
                if (_useRim3rd.floatValue == 1.0f)
                {
                    using (new EditorGUILayout.VerticalScope(boxInnerHalf))
                    {
                        if (!isLite)
                        {
                            lilEditorGUI.TextureGUI(me, false, ref edSet.isShowRimColorTex, colorMaskRGBAContent, _rim3rdColorTex, _rim3rdColor);
                            lilEditorGUI.LocalizedPropertyAlpha(_rim3rdColor);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdMainStrength);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdEnableLighting);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdShadowMask);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdBackfaceMask);
                            if (isTransparent)
                            {
                                lilEditorGUI.LocalizedProperty(me, _rim3rdApplyTransparency);
                            }
                            lilEditorGUI.LocalizedProperty(me, _rim3rdBlendMode);
                            lilEditorGUI.DrawLine();
                            lilEditorGUI.LocalizedProperty(me, _rim3rdDirStrength);
                            if (_rim3rdDirStrength.floatValue != 0.0f)
                            {
                                using (new EditorGUI.IndentLevelScope())
                                {
                                    lilEditorGUI.LocalizedProperty(me, _rim3rdDirRange);
                                    lilEditorGUI.InvBorderGUI(_rim3rdBorder);
                                    lilEditorGUI.LocalizedProperty(me, _rim3rdBlur);
                                    lilEditorGUI.DrawLine();
                                    lilEditorGUI.LocalizedProperty(me, _rim3rdIndirRange);
                                    lilEditorGUI.LocalizedProperty(me, _rim3rdIndirColor);
                                    lilEditorGUI.InvBorderGUI(_rim3rdIndirBorder);
                                    lilEditorGUI.LocalizedProperty(me, _rim3rdIndirBlur);
                                }
                                lilEditorGUI.DrawLine();
                            }
                            else
                            {
                                lilEditorGUI.InvBorderGUI(_rim3rdBorder);
                                lilEditorGUI.LocalizedProperty(me, _rim3rdBlur);
                            }
                            lilEditorGUI.LocalizedProperty(me, _rim3rdNormalStrength);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdFresnelPower);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdVRParallaxStrength);
                        }
                        else
                        {
                            lilEditorGUI.LocalizedProperty(me, _rim3rdColor);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdShadowMask);
                            lilEditorGUI.DrawLine();
                            lilEditorGUI.InvBorderGUI(_rim3rdBorder);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdBlur);
                            lilEditorGUI.LocalizedProperty(me, _rim3rdFresnelPower);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Try to replace the shader of the selected material to custom lilToon shader.
        /// </summary>
        [MenuItem("Assets/" + ShaderName + "/Convert material to custom shader", false, 1100)]
#pragma warning disable IDE0052 // Remove unread private members
        private static void ConvertMaterialToCustomShaderMenu()
#pragma warning restore IDE0052 // Remove unread private members
        {
            foreach (var material in Selection.GetFiltered<Material>(SelectionMode.Assets))
            {
#if UNITY_2022_1_OR_NEWER
                if (material.parent != null)
                {
                    Debug.LogWarningFormat("Ignore {0} because it is Material Variant", AssetDatabase.GetAssetPath(material));
                    continue;
                }
#endif  // UNITY_2022_1_OR_NEWER

                var shader = GetCorrespondingCustomShader(material.shader);
                if (shader == null)
                {
                    Debug.LogWarningFormat("Ignore {0}. \"{1}\" is not original lilToon shader.", AssetDatabase.GetAssetPath(material), material.shader.name);
                    continue;
                }

                Undo.RecordObject(material, ShaderName + "/ConvertMaterialToCustomShaderMenu");

                var renderQueue = lilMaterialUtils.GetTrueRenderQueue(material);
                material.shader = shader;
                material.renderQueue = renderQueue;
            }
        }

        /// <summary>
        /// Menu validation method for <see cref="ConvertMaterialToCustomShaderMenu"/>.
        /// </summary>
        /// <returns>True if <see cref="ConvertMaterialToCustomShaderMenu"/> works, otherwise false.</returns>
        [MenuItem("Assets/" + ShaderName + "/Convert material to custom shader", true)]
#pragma warning disable IDE0051 // Remove unused private members
        private static bool ValidateConvertMaterialToCustomShaderMenu()
#pragma warning restore IDE0051 // Remove unused private members
        {
            foreach (var material in Selection.GetFiltered<Material>(SelectionMode.Assets))
            {
#if UNITY_2022_1_OR_NEWER
                if (material.parent != null)
                {
                    Debug.LogWarningFormat("Ignore {0} because it is Material Variant", AssetDatabase.GetAssetPath(material));
                    continue;
                }
#endif  // UNITY_2022_1_OR_NEWER

                if (GetCorrespondingCustomShaderName(material.shader.name) != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Try to replace the shader of the material to original lilToon shader.
        /// </summary>
        [MenuItem("Assets/" + ShaderName + "/Convert material to original shader", false, 1101)]
#pragma warning disable IDE0051 // Remove unused private members
        private static void ConvertMaterialToOriginalShaderMenu()
#pragma warning restore IDE0051 // Remove unused private members
        {
            foreach (var material in Selection.GetFiltered<Material>(SelectionMode.Assets))
            {
#if UNITY_2022_1_OR_NEWER
                if (material.parent != null)
                {
                    Debug.LogWarningFormat("Ignore {0} because it is Material Variant", AssetDatabase.GetAssetPath(material));
                    continue;
                }
#endif  // UNITY_2022_1_OR_NEWER

                var shader = GetCorrespondingOriginalShader(material.shader);
                if (shader == null)
                {
                    Debug.LogWarningFormat("Ignore {0}. \"{1}\" is not custom lilToon shader, \"" + ShaderName + "\".", AssetDatabase.GetAssetPath(material), material.shader.name);
                    continue;
                }

                Undo.RecordObject(material, ShaderName + "/ConvertMaterialToOriginalShaderMenu");

                var renderQueue = lilMaterialUtils.GetTrueRenderQueue(material);
                material.shader = shader;
                material.renderQueue = renderQueue;
            }
        }

        /// <summary>
        /// Menu validation method for <see cref="ValidateConvertMaterialToOriginalShaderMenu"/>.
        /// </summary>
        /// <returns>True if <see cref="ValidateConvertMaterialToOriginalShaderMenu"/> works, otherwise false.</returns>
        [MenuItem("Assets/" + ShaderName + "/Convert material to original shader", true)]
#pragma warning disable IDE0051 // Remove unused private members
        private static bool ValidateConvertMaterialToOriginalShader()
#pragma warning restore IDE0051 // Remove unused private members
        {
            foreach (var material in Selection.GetFiltered<Material>(SelectionMode.Assets))
            {
#if UNITY_2022_1_OR_NEWER
                if (material.parent != null)
                {
                    Debug.LogWarningFormat("Ignore {0} because it is Material Variant", AssetDatabase.GetAssetPath(material));
                    continue;
                }
#endif  // UNITY_2022_1_OR_NEWER

                if (GetCorrespondingOriginalShaderName(material.shader.name) != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Callback method for menu item which refreshes shader cache and reimport.
        /// </summary>
        [MenuItem("Assets/" + ShaderName + "/Refresh shader cache", false, 2000)]
#pragma warning disable IDE0052 // Remove unread private members
        private static void RefreshShaderCacheMenu()
#pragma warning restore IDE0052 // Remove unread private members
        {
            var result = NativeMethods.Open("Library/ShaderCache.db", out var pDb);
            if (result != 0)
            {
                Debug.LogErrorFormat("Failed to open Library/ShaderCache.db [{0}]", result);
                return;
            }

            try
            {
                result = NativeMethods.Execute(pDb, "DELETE FROM shadererrors");
                if (result != 0)
                {
                    Debug.LogErrorFormat("SQL failed [{0}]", result);
                    return;
                }
            }
            finally
            {
                result = NativeMethods.Close(pDb);
                if (result != 0)
                {
                    Debug.LogErrorFormat("Failed to close database [{0}]", result);
                }
            }

            var shaderDirPath = AssetDatabase.GUIDToAssetPath(AssetGuid.ShaderDir);
            if (shaderDirPath.Length == 0)
            {
                Debug.LogWarning("Cannot find file or directory corresponding to GUID: " + AssetGuid.ShaderDir);
                return;
            }
            if (!Directory.Exists(shaderDirPath))
            {
                Debug.LogWarningFormat("Directory not found: {0} ({1})", shaderDirPath, AssetGuid.ShaderDir);
                return;
            }

            AssetDatabase.ImportAsset(shaderDirPath, ImportAssetOptions.ImportRecursive);

            var lilToonShaderDir = AssetDatabase.GUIDToAssetPath(AssetGuid.LilToonShaderDir);
            if (lilToonShaderDir.Length == 0)
            {
                Debug.LogWarningFormat("Shader directory of lilToon not found: {0}", AssetGuid.LilToonShaderDir);
                return;
            }
            AssetDatabase.ImportAsset(lilToonShaderDir, ImportAssetOptions.ImportRecursive);
        }

        /// <summary>
        /// Menu validation method for <see cref="RefreshShaderCacheMenu"/>.
        /// </summary>
        /// <returns>True if <see cref="RefreshShaderCacheMenu"/> works, otherwise false.</returns>
        [MenuItem("Assets/" + ShaderName + "/Refresh shader cache", true)]
#pragma warning disable IDE0051 // Remove unused private members
        private static bool ValidateRefreshShaderCacheMenu()
#pragma warning restore IDE0051 // Remove unused private members
        {
            try
            {
                NativeMethods.Close(IntPtr.Zero);
                return true;
            }
            catch (DllNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Get a custom lilToon shader which is corresponding to specified original lilToon shader.
        /// </summary>
        /// <param name="originalShader">Original lilToon shader.</param>
        /// <returns>null if no custom lilToon shader is found, otherwise the one found.</returns>
        private static Shader GetCorrespondingCustomShader(Shader originalShader)
        {
            var customShaderName = GetCorrespondingCustomShaderName(originalShader.name);
            return customShaderName == null ? null : Shader.Find(customShaderName);
        }

        /// <summary>
        /// Get a custom lilToon shader name which is corresponding to specified original lilToon shader name.
        /// </summary>
        /// <param name="originalShaderName">Original lilToon shader name.</param>
        /// <returns>null if no custom lilToon shader name is found, otherwise the one found.</returns>
        private static string GetCorrespondingCustomShaderName(string originalShaderName)
        {
            switch (originalShaderName)
            {
                case "lilToon": return ShaderName + "/lilToon";
                case "Hidden/lilToonCutout": return "Hidden/" + ShaderName + "/Cutout";
                case "Hidden/lilToonTransparent": return "Hidden/" + ShaderName + "/Transparent";
                case "Hidden/lilToonOnePassTransparent": return "Hidden/" + ShaderName + "/OnePassTransparent";
                case "Hidden/lilToonTwoPassTransparent": return "Hidden/" + ShaderName + "/TwoPassTransparent";
                case "Hidden/lilToonOutline": return "Hidden/" + ShaderName + "/OpaqueOutline";
                case "Hidden/lilToonCutoutOutline": return "Hidden/" + ShaderName + "/CutoutOutline";
                case "Hidden/lilToonTransparentOutline": return "Hidden/" + ShaderName + "/TransparentOutline";
                case "Hidden/lilToonOnePassTransparentOutline": return "Hidden/" + ShaderName + "/OnePassTransparentOutline";
                case "Hidden/lilToonTwoPassTransparentOutline": return "Hidden/" + ShaderName + "/TwoPassTransparentOutline";
                case "_lil/[Optional] lilToonOutlineOnly": return ShaderName + "/[Optional] OutlineOnly/Opaque";
                case "_lil/[Optional] lilToonOutlineOnlyCutout": return ShaderName + "/[Optional] OutlineOnly/Cutout";
                case "_lil/[Optional] lilToonOutlineOnlyTransparent": return ShaderName + "/[Optional] OutlineOnly/Transparent";
                case "Hidden/lilToonTessellation": return "Hidden/" + ShaderName + "/Tessellation/Opaque";
                case "Hidden/lilToonTessellationCutout": return "Hidden/" + ShaderName + "/Tessellation/Cutout";
                case "Hidden/lilToonTessellationTransparent": return "Hidden/" + ShaderName + "/Tessellation/Transparent";
                case "Hidden/lilToonTessellationOnePassTransparent": return "Hidden/" + ShaderName + "/Tessellation/OnePassTransparent";
                case "Hidden/lilToonTessellationTwoPassTransparent": return "Hidden/" + ShaderName + "/Tessellation/TwoPassTransparent";
                case "Hidden/lilToonTessellationOutline": return "Hidden/" + ShaderName + "/Tessellation/OpaqueOutline";
                case "Hidden/lilToonTessellationCutoutOutline": return "Hidden/" + ShaderName + "/Tessellation/CutoutOutline";
                case "Hidden/lilToonTessellationTransparentOutline": return "Hidden/" + ShaderName + "/Tessellation/TransparentOutline";
                case "Hidden/lilToonTessellationOnePassTransparentOutline": return "Hidden/" + ShaderName + "/Tessellation/OnePassTransparentOutline";
                case "Hidden/lilToonTessellationTwoPassTransparentOutline": return "Hidden/" + ShaderName + "/Tessellation/TwoPassTransparentOutline";
                case "Hidden/lilToonLite": return ShaderName + "/lilToonLite";
                case "Hidden/lilToonLiteCutout": return "Hidden/" + ShaderName + "/Lite/Cutout";
                case "Hidden/lilToonLiteTransparent": return "Hidden/" + ShaderName + "/Lite/Transparent";
                case "Hidden/lilToonLiteOnePassTransparent": return "Hidden/" + ShaderName + "/Lite/OnePassTransparent";
                case "Hidden/lilToonLiteTwoPassTransparent": return "Hidden/" + ShaderName + "/Lite/TwoPassTransparent";
                case "Hidden/lilToonLiteOutline": return "Hidden/" + ShaderName + "/Lite/OpaqueOutline";
                case "Hidden/lilToonLiteCutoutOutline": return "Hidden/" + ShaderName + "/Lite/CutoutOutline";
                case "Hidden/lilToonLiteTransparentOutline": return "Hidden/" + ShaderName + "/Lite/TransparentOutline";
                case "Hidden/lilToonLiteOnePassTransparentOutline": return "Hidden/" + ShaderName + "/Lite/OnePassTransparentOutline";
                case "Hidden/lilToonLiteTwoPassTransparentOutline": return "Hidden/" + ShaderName + "/Lite/TwoPassTransparentOutline";
                case "Hidden/lilToonRefraction": return "Hidden/" + ShaderName + "/Refraction";
                case "Hidden/lilToonRefractionBlur": return "Hidden/" + ShaderName + "/RefractionBlur";
                case "Hidden/lilToonFur": return "Hidden/" + ShaderName + "/Fur";
                case "Hidden/lilToonFurCutout": return "Hidden/" + ShaderName + "/FurCutout";
                case "Hidden/lilToonFurTwoPass": return "Hidden/" + ShaderName + "/FurTwoPass";
                case "_lil/[Optional] lilToonFurOnlyTransparent": return ShaderName + "/[Optional] FurOnly/Transparent";
                case "_lil/[Optional] lilToonFurOnlyCutout": return ShaderName + "/[Optional] FurOnly/Cutout";
                case "_lil/[Optional] lilToonFurOnlyTwoPass": return ShaderName + "/[Optional] FurOnly/TwoPass";
                case "Hidden/lilToonGem": return "Hidden/" + ShaderName + "/Gem";
                case "_lil/[Optional] lilToonFakeShadow": return ShaderName + "/[Optional] FakeShadow";
                case "_lil/[Optional] lilToonOverlay": return ShaderName + "/[Optional] Overlay";
                case "_lil/[Optional] lilToonOverlayOnePass": return ShaderName + "/[Optional] OverlayOnePass";
                case "_lil/[Optional] lilToonLiteOverlay": return ShaderName + "/[Optional] LiteOverlay";
                case "_lil/[Optional] lilToonLiteOverlayOnePass": return ShaderName + "/[Optional] LiteOverlayOnePass";
                case "_lil/lilToonMulti": return ShaderName + "/lilToonMulti";
                case "Hidden/lilToonMultiOutline": return "Hidden/" + ShaderName + "/MultiOutline";
                case "Hidden/lilToonMultiRefraction": return "Hidden/" + ShaderName + "/MultiRefraction";
                case "Hidden/lilToonMultiFur": return "Hidden/" + ShaderName + "/MultiFur";
                case "Hidden/lilToonMultiGem": return "Hidden/" + ShaderName + "/MultiGem";
                default: return null;
            }
        }

        /// <summary>
        /// Get a original lilToon shader which is corresponding to specified custom lilToon shader.
        /// </summary>
        /// <param name="customShader">Custom lilToon shader.</param>
        /// <returns>null if no original lilToon shader is found, otherwise the one found.</returns>
        private static Shader GetCorrespondingOriginalShader(Shader customShader)
        {
            var customShaderName = GetCorrespondingOriginalShaderName(customShader.name);
            return customShaderName == null ? null : Shader.Find(customShaderName);
        }

        /// <summary>
        /// Get a original lilToon shader name which is corresponding to specified custom lilToon shader name.
        /// </summary>
        /// <param name="customShaderName">Custom lilToon shader name.</param>
        /// <returns>null if no original lilToon shader name is found, otherwise the one found.</returns>
        private static string GetCorrespondingOriginalShaderName(string customShaderName)
        {
            switch (customShaderName)
            {
                case ShaderName + "/lilToon": return "lilToon";
                case "Hidden/" + ShaderName + "/Cutout": return "Hidden/lilToonCutout";
                case "Hidden/" + ShaderName + "/Transparent": return "Hidden/lilToonTransparent";
                case "Hidden/" + ShaderName + "/OnePassTransparent": return "Hidden/lilToonOnePassTransparent";
                case "Hidden/" + ShaderName + "/TwoPassTransparent": return "Hidden/lilToonTwoPassTransparent";
                case "Hidden/" + ShaderName + "/OpaqueOutline": return "Hidden/lilToonOutline";
                case "Hidden/" + ShaderName + "/CutoutOutline": return "Hidden/lilToonCutoutOutline";
                case "Hidden/" + ShaderName + "/TransparentOutline": return "Hidden/lilToonTransparentOutline";
                case "Hidden/" + ShaderName + "/OnePassTransparentOutline": return "Hidden/lilToonOnePassTransparentOutline";
                case "Hidden/" + ShaderName + "/TwoPassTransparentOutline": return "Hidden/lilToonTwoPassTransparentOutline";
                case ShaderName + "/[Optional] OutlineOnly/Opaque": return "_lil/[Optional] lilToonOutlineOnly";
                case ShaderName + "/[Optional] OutlineOnly/Cutout": return "_lil/[Optional] lilToonOutlineOnlyCutout";
                case ShaderName + "/[Optional] OutlineOnly/Transparent": return "_lil/[Optional] lilToonOutlineOnlyTransparent";
                case "Hidden/" + ShaderName + "/Tessellation/Opaque": return "Hidden/lilToonTessellation";
                case "Hidden/" + ShaderName + "/Tessellation/Cutout": return "Hidden/lilToonTessellationCutout";
                case "Hidden/" + ShaderName + "/Tessellation/Transparent": return "Hidden/lilToonTessellationTransparent";
                case "Hidden/" + ShaderName + "/Tessellation/OnePassTransparent": return "Hidden/lilToonTessellationOnePassTransparent";
                case "Hidden/" + ShaderName + "/Tessellation/TwoPassTransparent": return "Hidden/lilToonTessellationTwoPassTransparent";
                case "Hidden/" + ShaderName + "/Tessellation/OpaqueOutline": return "Hidden/lilToonTessellationOutline";
                case "Hidden/" + ShaderName + "/Tessellation/CutoutOutline": return "Hidden/lilToonTessellationCutoutOutline";
                case "Hidden/" + ShaderName + "/Tessellation/TransparentOutline": return "Hidden/lilToonTessellationTransparentOutline";
                case "Hidden/" + ShaderName + "/Tessellation/OnePassTransparentOutline": return "Hidden/lilToonTessellationOnePassTransparentOutline";
                case "Hidden/" + ShaderName + "/Tessellation/TwoPassTransparentOutline": return "Hidden/lilToonTessellationTwoPassTransparentOutline";
                case ShaderName + "/lilToonLite": return "Hidden/lilToonLite";
                case "Hidden/" + ShaderName + "/Lite/Cutout": return "Hidden/lilToonLiteCutout";
                case "Hidden/" + ShaderName + "/Lite/Transparent": return "Hidden/lilToonLiteTransparent";
                case "Hidden/" + ShaderName + "/Lite/OnePassTransparent": return "Hidden/lilToonLiteOnePassTransparent";
                case "Hidden/" + ShaderName + "/Lite/TwoPassTransparent": return "Hidden/lilToonLiteTwoPassTransparent";
                case "Hidden/" + ShaderName + "/Lite/OpaqueOutline": return "Hidden/lilToonLiteOutline";
                case "Hidden/" + ShaderName + "/Lite/CutoutOutline": return "Hidden/lilToonLiteCutoutOutline";
                case "Hidden/" + ShaderName + "/Lite/TransparentOutline": return "Hidden/lilToonLiteTransparentOutline";
                case "Hidden/" + ShaderName + "/Lite/OnePassTransparentOutline": return "Hidden/lilToonLiteOnePassTransparentOutline";
                case "Hidden/" + ShaderName + "/Lite/TwoPassTransparentOutline": return "Hidden/lilToonLiteTwoPassTransparentOutline";
                case "Hidden/" + ShaderName + "/Refraction": return "Hidden/lilToonRefraction";
                case "Hidden/" + ShaderName + "/RefractionBlur": return "Hidden/lilToonRefractionBlur";
                case "Hidden/" + ShaderName + "/Fur": return "Hidden/lilToonFur";
                case "Hidden/" + ShaderName + "/FurCutout": return "Hidden/lilToonFurCutout";
                case "Hidden/" + ShaderName + "/FurTwoPass": return "Hidden/lilToonFurTwoPass";
                case ShaderName + "/[Optional] FurOnly/Transparent": return "_lil/[Optional] lilToonFurOnlyTransparent";
                case ShaderName + "/[Optional] FurOnly/Cutout": return "_lil/[Optional] lilToonFurOnlyCutout";
                case ShaderName + "/[Optional] FurOnly/TwoPass": return "_lil/[Optional] lilToonFurOnlyTwoPass";
                case "Hidden/" + ShaderName + "/Gem": return "Hidden/lilToonGem";
                case ShaderName + "/[Optional] FakeShadow": return "_lil/[Optional] lilToonFakeShadow";
                case ShaderName + "/[Optional] Overlay": return "_lil/[Optional] lilToonOverlay";
                case ShaderName + "/[Optional] OverlayOnePass": return "_lil/[Optional] lilToonOverlayOnePass";
                case ShaderName + "/[Optional] LiteOverlay": return "_lil/[Optional] lilToonLiteOverlay";
                case ShaderName + "/[Optional] LiteOverlayOnePass": return "_lil/[Optional] lilToonLiteOverlayOnePass";
                case ShaderName + "/lilToonMulti": return "_lil/lilToonMulti";
                case "Hidden/" + ShaderName + "/MultiOutline": return "Hidden/lilToonMultiOutline";
                case "Hidden/" + ShaderName + "/MultiRefraction": return "Hidden/lilToonMultiRefraction";
                case "Hidden/" + ShaderName + "/MultiFur": return "Hidden/lilToonMultiFur";
                case "Hidden/" + ShaderName + "/MultiGem": return "Hidden/lilToonMultiGem";
                default: return null;
            }
        }


        /// <summary>
        /// Provides some native methods of SQLite3.
        /// </summary>
        internal static class NativeMethods
        {
#if UNITY_EDITOR && !UNITY_EDITOR_WIN
            /// <summary>
            /// Native library name of SQLite3.
            /// </summary>
            private const string LibraryName = "sqlite3";
            /// <summary>
            /// Calling convention of library functions.
            /// </summary>
            private const CallingConvention CallConv = CallingConvention.Cdecl;
#else
            /// <summary>
            /// Native library name of SQLite3.
            /// </summary>
            private const string LibraryName = "winsqlite3";
            /// <summary>
            /// Calling convention of library functions.
            /// </summary>
            private const CallingConvention CallConv = CallingConvention.StdCall;
#endif
            /// <summary>
            /// Open database.
            /// </summary>
            /// <param name="filePath">SQLite3 database file path.</param>
            /// <param name="pDb">SQLite db handle.</param>
            /// <returns>Result code.</returns>
            /// <remarks>
            /// <seealso href="https://www.sqlite.org/c3ref/open.html"/>
            /// </remarks>
            [DllImport(LibraryName, EntryPoint = "sqlite3_open16", CallingConvention = CallConv, CharSet = CharSet.Unicode)]
            public static extern int Open(string filePath, out IntPtr pDb);

            /// <summary>
            /// Close database.
            /// </summary>
            /// <param name="pDb">SQLite db handle.</param>
            /// <returns>Result code.</returns>
            /// <remarks>
            /// <seealso href="https://www.sqlite.org/c3ref/close.html"/>
            /// </remarks>
            [DllImport(LibraryName, EntryPoint = "sqlite3_close", CallingConvention = CallConv)]
            public static extern int Close(IntPtr pDb);

            /// <summary>
            /// Execute specified SQL.
            /// </summary>
            /// <param name="pDb">SQLite db handle.</param>
            /// <param name="sql">SQL to be evaluated.</param>
            /// <param name="pCallback">Callback function.</param>
            /// <param name="pCallbackArg">1st argument to callback.</param>
            /// <param name="pErrMsg">Error message written here.</param>
            /// <returns>Result code.</returns>
            /// <remarks>
            /// <seealso href="https://www.sqlite.org/c3ref/exec.html"/>
            /// </remarks>
            [DllImport(LibraryName, EntryPoint = "sqlite3_exec", CallingConvention = CallConv)]
            public static extern int Execute(IntPtr pDb, string sql, IntPtr pCallback = default(IntPtr), IntPtr pCallbackArg = default(IntPtr), IntPtr pErrMsg = default(IntPtr));
        }
    }
}
