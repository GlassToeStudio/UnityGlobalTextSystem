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

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{ 
    public static class MenuItems
    {
        [MenuItem("CONTEXT/Text/Set to Custom")]
        private static void SetTextToCustom(MenuCommand menuCommand)
        {
            GlobalFontManager.InitializeNewTextObject(menuCommand.context as Text);
        }

        [MenuItem("CONTEXT/Text/Set to Global Color")]
        private static void SetToGlobalColor(MenuCommand menuCommand)
        {
            var thisText = menuCommand.context as Text;
            thisText.SetFontColor(GlobalFontManager.GlobalFontData);
        }


        [MenuItem("GameObject/Global Font/Set to Custom", priority = 38, validate = false)]
        private static void NewMenuOption()
        {
            GlobalFontManager.InitializeNewTextObject(Selection.activeGameObject.GetComponent<Text>());
        }

        [MenuItem("GameObject/Global Font/Set to Custom", priority = 38, validate = true)]
        private static bool ValiedateNewMenuOption()
        {
            return (Selection.activeGameObject.GetComponent<Text>() != null);
        }
    }
}
