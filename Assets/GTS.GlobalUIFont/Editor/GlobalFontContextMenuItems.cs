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
    class GlobalFontContextMenuItems
    {
        private const string menuName = "CONTEXT/Text/";

        #region Context MenuItems

        [MenuItem(menuName + "Set to global font")]
        private static void SetToGlobalFont(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT);
        }

        [MenuItem(menuName + "Set to global font style")]
        private static void SetToGlobalFontStyle(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT_STYLE);
        }

        [MenuItem(menuName + "Set to global font size")]
        private static void SetToGlobalFontSize(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT_SIZE);
        }

        [MenuItem(menuName + "Set to global line spacing")]
        private static void SetToGlobalLineSpacing(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.LINE_SPACING);
        }

        [MenuItem(menuName + "Set to global rich text support")]
        private static void SetToGlobalRichTextSupport(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.RICH_TEXT);
        }

        [MenuItem(menuName + "Set to global alignment")]
        private static void SetToGlobalalignment(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.ALIGNMENT);
        }

        [MenuItem(menuName + "Set to global align by geometry")]
        private static void SetToGlobalAlignByGeometry(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.ALIGN_BY_GEOMETRY);
        }

        [MenuItem(menuName + "Set to global Horizontal Overflow")]
        private static void SetToGlobalHorizontalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.HORIZONTAL_OVERFLOW);
        }

        [MenuItem(menuName + "Set to global Vertical Overflow")]
        private static void SetToGlobalVerticalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.VERTICAL_OVERFLOW);
        }

        [MenuItem(menuName + "Set to global Best fit ")]
        private static void SetToGlobalBestFit(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.BEST_FIT);
        }

        [MenuItem(menuName + "Set to global font color")]
        private static void SetToGlobalColor(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.COLOR);
        }

        [MenuItem(menuName + "Set to global Material")]
        private static void SetToGlobalMaterial(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.MATERIAL);
        }

        [MenuItem(menuName + "Set to global Raycast option")]
        private static void SetToGlobalRaycastOption(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.RAYCAST);
        }

        [MenuItem(menuName + "Set to all global presets", false, 110)]
        private static void ChangeToAllGlobalPresets(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            GlobalFontSystem.InitializeNewTextObject(thisText);
        }

        #endregion
    }
}
