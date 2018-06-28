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
using GTS.GlobalTextSystem.Tools;

/// <summary>/// Menus for controlling the properties of one or all Text objects./// </summary>ry>
namespace GTS.GlobalTextSystem.Menus
{ 
    public static class SystemMenus
    {
        //TODO: Move to StringLibrary
        private const string menuName = "GameObject/Global Font/";

        #region Menu Items

        [MenuItem(menuName + StringLibrary.MENU_SET_ALL, priority = 138)]
        private static void SetTextToCustom()
        {
            PropertyLibrary.ChangeAllProperties(Selection.activeGameObject.GetComponent<Text>());
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT)]
        private static void SetTextToGlobalFont()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_STYLE)]
        private static void SetToGlobalFontStyle()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT_STYLE);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_SIZE)]
        private static void SetToGlobalFontSize()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.FONT_SIZE);
        }

        [MenuItem(menuName + StringLibrary.MENU_LINE_SPACING)]
        private static void SetToGlobalLineSpacing()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.LINE_SPACING);
        }

        [MenuItem(menuName + StringLibrary.MENU_RICH_TEXT)]
        private static void SetToGlobalRichTextSupport()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.RICH_TEXT);
        }

        [MenuItem(menuName + StringLibrary.MENU_ALIGNMENT)]
        private static void SetToGlobalalignment()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.ALIGNMENT);
        }

        [MenuItem(menuName + StringLibrary.MENU_BY_GEOMETRY)]
        private static void SetToGlobalAlignByGeometry()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.ALIGN_BY_GEOMETRY);
        }

        [MenuItem(menuName + StringLibrary.MENU_HORIZONTAL)]
        private static void SetToGlobalHorizontalOverflow()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.HORIZONTAL_OVERFLOW);
        }

        [MenuItem(menuName + StringLibrary.MENU_VERTICAL)]
        private static void SetToGlobalVerticalOverflow()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.VERTICAL_OVERFLOW);
        }

        [MenuItem(menuName + StringLibrary.MENU_BEST_FIT)]
        private static void SetToGlobalBestFit()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.BEST_FIT);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_COLOR)]
        private static void SetToGlobalColor()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.COLOR);
        }

        [MenuItem(menuName + StringLibrary.MENU_MATERIAL)]
        private static void SetToGlobalMaterial()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.MATERIAL);
        }

        [MenuItem(menuName + StringLibrary.MENU_RAYCAST)]
        private static void SetToGlobalRaycastOption()
        {
            var thisText = Selection.activeGameObject.GetComponent<Text>();
            thisText.ChangeProperty(TextProperty.RAYCAST);
        }

        #endregion


        #region menu item validators
        [MenuItem(menuName + StringLibrary.MENU_SET_ALL, priority = 138, validate = true)]
        private static bool SetTextToCustomValidator()
        {
            return isTextObject();
        }

        //[MenuItem(menuName + "Set to global FONT", priority = 138, validate = true)]
        [MenuItem(menuName + StringLibrary.MENU_FONT, priority = 138, validate = true)]
        private static bool SetTextToGlobalFontValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_STYLE, priority = 138, validate = true)]
        private static bool SetToGlobalFontStyleValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_SIZE, priority = 138, validate = true)]
        private static bool SetToGlobalFontSizeValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_LINE_SPACING, priority = 138, validate = true)]
        private static bool SetToGlobalLineSpacingValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_RICH_TEXT, priority = 138, validate = true)]
        private static bool SetToGlobalRichTextSupportValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_ALIGNMENT, priority = 138, validate = true)]
        private static bool SetToGlobalalignmentValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_BY_GEOMETRY, priority = 138, validate = true)]
        private static bool SetToGlobalAlignByGeometryValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_HORIZONTAL, priority = 138, validate = true)]
        private static bool SetToGlobalHorizontalOverflowValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_VERTICAL, priority = 138, validate = true)]
        private static bool SetToGlobalVerticalOverflowValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_BEST_FIT, priority = 138, validate = true)]
        private static bool SetToGlobalBestFitValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_COLOR, priority = 138, validate = true)]
        private static bool SetToGlobalColorValidator()
        {
            return isTextObject();
            
        }

        [MenuItem(menuName + StringLibrary.MENU_MATERIAL, priority = 138, validate = true)]
        private static bool SetToGlobalMaterialValidator()
        {
            return isTextObject();
        }

        [MenuItem(menuName + StringLibrary.MENU_RAYCAST, priority = 138, validate = true)]
        private static bool SetToGlobalRaycastOptionValidator()
        {
            return isTextObject();
        }

        #endregion

        private static bool isTextObject()
        {
            if(Selection.activeGameObject == null)
            {
                return false;
            }
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }
    }
}
