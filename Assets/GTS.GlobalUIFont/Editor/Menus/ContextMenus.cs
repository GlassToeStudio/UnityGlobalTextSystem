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
using UnityEngine.UI;
using GTS.GlobalTextSystem.Tools;

/// <summary>
/// Menus for controlling the properties of one or all Text objects.
/// </summary>
namespace GTS.GlobalTextSystem.Menus
{
    class ContextMenus
    {
        //TODO: Move to StringLibrary
        private const string menuName = "CONTEXT/Text/";

        #region Context MenuItems

        [MenuItem(menuName + StringLibrary.MENU_FONT)]
        private static void SetToGlobalFont(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_STYLE)]
        private static void SetToGlobalFontStyle(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT_STYLE);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_SIZE)]
        private static void SetToGlobalFontSize(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.FONT_SIZE);
        }

        [MenuItem(menuName + StringLibrary.MENU_LINE_SPACING)]
        private static void SetToGlobalLineSpacing(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.LINE_SPACING);
        }

        [MenuItem(menuName + StringLibrary.MENU_RICH_TEXT)]
        private static void SetToGlobalRichTextSupport(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.RICH_TEXT);
        }

        [MenuItem(menuName + StringLibrary.MENU_ALIGNMENT)]
        private static void SetToGlobalalignment(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.ALIGNMENT);
        }

        [MenuItem(menuName + StringLibrary.MENU_BY_GEOMETRY)]
        private static void SetToGlobalAlignByGeometry(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.ALIGN_BY_GEOMETRY);
        }

        [MenuItem(menuName + StringLibrary.MENU_HORIZONTAL)]
        private static void SetToGlobalHorizontalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.HORIZONTAL_OVERFLOW);
        }

        [MenuItem(menuName + StringLibrary.MENU_VERTICAL)]
        private static void SetToGlobalVerticalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.VERTICAL_OVERFLOW);
        }

        [MenuItem(menuName + StringLibrary.MENU_BEST_FIT)]
        private static void SetToGlobalBestFit(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.BEST_FIT);
        }

        [MenuItem(menuName + StringLibrary.MENU_FONT_COLOR)]
        private static void SetToGlobalColor(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.COLOR);
        }

        [MenuItem(menuName + StringLibrary.MENU_MATERIAL)]
        private static void SetToGlobalMaterial(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.MATERIAL);
        }

        [MenuItem(menuName + StringLibrary.MENU_RAYCAST)]
        private static void SetToGlobalRaycastOption(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(TextProperty.RAYCAST);
        }

        [MenuItem(menuName +StringLibrary.MENU_SET_ALL, false, 110)]
        private static void ChangeToAllGlobalPresets(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            PropertyLibrary.ChangeAllProperties(thisText);
        }

        #endregion
    }
}
