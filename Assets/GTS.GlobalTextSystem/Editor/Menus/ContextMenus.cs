/*StringLibrary.CONTEXT_MENU_PATH
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
using GTS.GlobalTextSystem.Libraries;

/// <summary>
/// Menus for controlling the properties of one or all Text objects.
/// </summary>
namespace GTS.GlobalTextSystem.Menus
{
    class ContextMenus
    {      

        #region Context MenuItems

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_FONT)]
        private static void SetToGlobalFont(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.FONT);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_FONT_STYLE)]
        private static void SetToGlobalFontStyle(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.FONT_STYLE);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_FONT_SIZE)]
        private static void SetToGlobalFontSize(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.FONT_SIZE);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_LINE_SPACING)]
        private static void SetToGlobalLineSpacing(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.LINE_SPACING);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_RICH_TEXT)]
        private static void SetToGlobalRichTextSupport(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.RICH_TEXT);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_ALIGNMENT)]
        private static void SetToGlobalalignment(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.ALIGNMENT);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_BY_GEOMETRY)]
        private static void SetToGlobalAlignByGeometry(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.ALIGN_BY_GEOMETRY);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_HORIZONTAL)]
        private static void SetToGlobalHorizontalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.HORIZONTAL_OVERFLOW);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_VERTICAL)]
        private static void SetToGlobalVerticalOverflow(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.VERTICAL_OVERFLOW);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_BEST_FIT)]
        private static void SetToGlobalBestFit(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.BEST_FIT);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_FONT_COLOR)]
        private static void SetToGlobalColor(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.COLOR);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_MATERIAL)]
        private static void SetToGlobalMaterial(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.MATERIAL);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH + StringLibrary.MENU_RAYCAST)]
        private static void SetToGlobalRaycastOption(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.ChangeProperty(StringLibrary.RAYCAST);
        }

        [MenuItem(StringLibrary.CONTEXT_MENU_PATH +StringLibrary.MENU_SET_ALL, false, 110)]
        private static void ChangeToAllGlobalPresets(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            PropertyLibrary.ChangeAllProperties(thisText);
        }

        #endregion
    }
}
