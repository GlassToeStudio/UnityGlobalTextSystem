/*
================================================================================
    Product:    Unity-Set-Global_UI-Text_Font
    Developer:  GlassToeStudio@gmail.com
    Source:     https://github.com/GlassToeStudio/Unity-Set-Global-UI-Text-Font
    Company:    GlassToeStudio
    Website:    http://glasstoestudio.weebly.com/
    Date:       June 19, 2018
=================================================================================
    MIT License
================================================================================
*/

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using GTS.GlobalUIFont.Tools;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont.Menus
{ 
    public static class GlobalFontMenuItems
    {
        private const string menuName = "GameObject/Global Font/";
        
        #region Menu Items
        
        [MenuItem(menuName + "Change All Properties!", priority = 138)]
        private static void SetTextToCustom()
        {
            GlobalFontSystem.InitializeNewTextObject(Selection.activeGameObject.GetComponent<Text>());
        }

        [MenuItem(menuName + "Set to global font")]
        private static void SetTextToGlobalFont()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT);
        }

        [MenuItem(menuName + "Set to global font style")]
        private static void SetToGlobalFontStyle()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT_STYLE);
        }

        [MenuItem(menuName + "Set to global font size")]
        private static void SetToGlobalFontSize()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT_SIZE);
        }

        [MenuItem(menuName + "Set to global line spacing")]
        private static void SetToGlobalLineSpacing()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.LINE_SPACING);
        }

        [MenuItem(menuName + "Set to global rich text support")]
        private static void SetToGlobalRichTextSupport()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.RICH_TEXT);
        }

        [MenuItem(menuName + "Set to global alignment")]
        private static void SetToGlobalalignment()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.ALIGNMENT);
        }

        [MenuItem(menuName + "Set to global align by geometry")]
        private static void SetToGlobalAlignByGeometry()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.ALIGN_BY_GEOMETRY);
        }

        [MenuItem(menuName + "Set to global Horizontal Overflow")]
        private static void SetToGlobalHorizontalOverflow()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.HORIZONTAL_OVERFLOW);
        }

        [MenuItem(menuName + "Set to global Vertical Overflow")]
        private static void SetToGlobalVerticalOverflow()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.VERTICAL_OVERFLOW);
        }

        [MenuItem(menuName + "Set to global Best fit ")]
        private static void SetToGlobalBestFit()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.BEST_FIT);
        }

        [MenuItem(menuName + "Set to global font color")]
        private static void SetToGlobalColor()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.COLOR);
        }

        [MenuItem(menuName + "Set to global Material")]
        private static void SetToGlobalMaterial()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.MATERIAL);
        }

        [MenuItem(menuName + "Set to global Raycast option")]
        private static void SetToGlobalRaycastOption()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.RAYCAST);
        }

        #endregion


        #region menu item validators

        [MenuItem(menuName + "Change All Properties!", priority = 138, validate = true)]
        private static bool SetTextToCustomValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global font", priority = 138, validate = true)]
        private static bool SetTextToGlobalFontValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global font style", priority = 138, validate = true)]
        private static bool SetToGlobalFontStyleValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global font size", priority = 138, validate = true)]
        private static bool SetToGlobalFontSizeValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global line spacing", priority = 138, validate = true)]
        private static bool SetToGlobalLineSpacingValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global rich text support", priority = 138, validate = true)]
        private static bool SetToGlobalRichTextSupportValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global alignment", priority = 138, validate = true)]
        private static bool SetToGlobalalignmentValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global align by geometry", priority = 138, validate = true)]
        private static bool SetToGlobalAlignByGeometryValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global Horizontal Overflow", priority = 138, validate = true)]
        private static bool SetToGlobalHorizontalOverflowValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global Vertical Overflow", priority = 138, validate = true)]
        private static bool SetToGlobalVerticalOverflowValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global Best fit ", priority = 138, validate = true)]
        private static bool SetToGlobalBestFitValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global font color", priority = 138, validate = true)]
        private static bool SetToGlobalColorValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global Material", priority = 138, validate = true)]
        private static bool SetToGlobalMaterialValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        [MenuItem(menuName + "Set to global Raycast option", priority = 138, validate = true)]
        private static bool SetToGlobalRaycastOptionValidator()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }

        #endregion

    }
}
