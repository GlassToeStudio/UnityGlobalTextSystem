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

using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using GTS.GlobalTextSystem.Tools;

/// <summary>
/// Collection of tools and helpers for our global text system.
/// </summary>
namespace GTS.GlobalTextSystem.Libraries
{
    /// <summary>
    /// Helper methods for changing one or all properties for one or all Text objects.
    /// </summary>
    public static class PropertyLibrary
    {
        // Self explanatory naming.

        public static void ChangeAllFonts()
        {
            ChangePropertyForAllText(StringLibrary.FONT);
        }

        public static void ChangeAllFontStyle()
        {
            ChangePropertyForAllText(StringLibrary.FONT_STYLE);
        }

        public static void ChangeAllFontSize()
        {
            ChangePropertyForAllText(StringLibrary.FONT_SIZE);
        }

        public static void ChangeAllLineSpacing()
        {
            ChangePropertyForAllText(StringLibrary.LINE_SPACING);
        }

        public static void ChangeAllRichText()
        {
            ChangePropertyForAllText(StringLibrary.RICH_TEXT);
        }

        public static void ChangeAllAlignment()
        {
            ChangePropertyForAllText(StringLibrary.ALIGNMENT);
        }

        public static void ChangeAllAlignByGeometry()
        {
            ChangePropertyForAllText(StringLibrary.ALIGN_BY_GEOMETRY);
        }

        public static void ChangeAllHorizontalOverflow()
        {
            ChangePropertyForAllText(StringLibrary.HORIZONTAL_OVERFLOW);
        }

        public static void ChangeAllVerticalOverflow()
        {
            ChangePropertyForAllText(StringLibrary.VERTICAL_OVERFLOW);
        }

        public static void ChangeAllBestFit()
        {
            ChangePropertyForAllText(StringLibrary.BEST_FIT);
        }

        /// <summary>
        /// Currently does not use reflection.
        /// </summary>
        public static void ChangeAllColor()
        {
            var textSettings = GlobalTextSettings.TextSettings;

            if(textSettings == null)
            {
                return;
            }

            var allTextObjects = GlobalTextSettings.AllTextObjects;

            foreach(Text t in allTextObjects)
            {
                Undo.RecordObject(t, "change color");
                t.SetFontColor(textSettings);
            }

        }

        public static void ChangeAllMaterial()
        {
            ChangePropertyForAllText(StringLibrary.MATERIAL);
        }

        public static void ChangeAllRaycastTarget()
        {
            ChangePropertyForAllText(StringLibrary.RAYCAST);
        }

        /// <summary>
        /// Change Every property of the Text to the saved TextData.
        /// </summary>
        public static void ChangeAllProperties(Text textObject)
        {
            var textSettings = GlobalTextSettings.TextSettings;

            if(textSettings == null)
            {
                return;
            }

            Undo.RecordObject(textObject, "Change all properties");

            textObject.SetFont(textSettings);
            textObject.SetFontSize(textSettings);
            textObject.SetFontSize(textSettings);
            textObject.lineSpacing = textSettings.lineSpacing;
            textObject.supportRichText = textSettings.supportRichText;

            textObject.alignment = textSettings.alignment;
            textObject.alignByGeometry = textSettings.alignByGeometry;
            textObject.horizontalOverflow = textSettings.horizontalOverflow;
            textObject.verticalOverflow = textSettings.verticalOverflow;
            textObject.resizeTextForBestFit = textSettings.resizeTextForBestFit;

            textObject.SetFontColor(textSettings);
            textObject.material = textSettings.material;
            textObject.raycastTarget = textSettings.raycastTarget;
        }

        /// <summary>
        /// Change Text property of this Text object based on property name.
        /// </summary>
        public static void ChangeProperty(this Text t, string key)
        {
            Undo.RecordObject(t, "change " + key);
            var prop = t.GetType().GetProperty(key);
            if(GlobalTextSettings.TextSettings.SavedSettings[key] == true)
            {
                var globalProp = GlobalTextSettings.TextSettings.GetType().GetProperty(key);
                prop.SetValue(t, globalProp.GetValue(GlobalTextSettings.TextSettings, null), null);
            }
        }

        /// <summary>
        /// Change Text property of every Text object based on property name.
        /// </summary>
        private static void ChangePropertyForAllText(string key)
        {
            var textSettings = GlobalTextSettings.TextSettings;

            if(textSettings == null)
            {
                return;
            }

            var allTextObjects = GlobalTextSettings.AllTextObjects;

            foreach(Text t in allTextObjects)
            {
                t.ChangeProperty(key);
            }
        }
    }
}
