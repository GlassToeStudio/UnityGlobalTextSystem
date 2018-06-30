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
    /// Some nasty code in here, beware!
    /// </summary>
    public static class PropertyLibrary
    {

        #region public methods

        // Self explanatory naming.

        public static void ChangeAllFonts()
        {
            ChangeProperty(StringLibrary.FONT);
        }

        public static void ChangeAllFontStyle()
        {
            ChangeProperty(StringLibrary.FONT_STYLE);
        }

        public static void ChangeAllFontSize()
        {
            ChangeProperty(StringLibrary.FONT_SIZE);
        }

        public static void ChangeAllLineSpacing()
        {
            ChangeProperty(StringLibrary.LINE_SPACING);
        }

        public static void ChangeAllRichText()
        {
            ChangeProperty(StringLibrary.RICH_TEXT);
        }

        public static void ChangeAllAlignment()
        {
            ChangeProperty(StringLibrary.ALIGNMENT);
        }

        public static void ChangeAllAlignByGeometry()
        {
            ChangeProperty(StringLibrary.ALIGN_BY_GEOMETRY);
        }

        public static void ChangeAllHorizontalOverflow()
        {
            ChangeProperty(StringLibrary.HORIZONTAL_OVERFLOW);
        }

        public static void ChangeAllVerticalOverflow()
        {
            ChangeProperty(StringLibrary.VERTICAL_OVERFLOW);
        }

        public static void ChangeAllBestFit()
        {
            ChangeProperty(StringLibrary.BEST_FIT);
        }

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
            ChangeProperty(StringLibrary.MATERIAL);
        }

        public static void ChangeAllRaycastTarget()
        {
            ChangeProperty(StringLibrary.RAYCAST);
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

        #endregion


        #region private

        /// <summary>
        /// Change Text property of all Text based on type name.
        /// </summary>
        private static void ChangeProperty(string key)
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
        
        #endregion
    }
}
