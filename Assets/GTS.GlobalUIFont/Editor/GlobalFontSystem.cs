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
using System.Collections.Generic;
using GTS.GlobalUIFont.Tools;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    public static class GlobalFontSystem
    {
        #region public methods

        public static void ChangeAllFonts()
        {
            ChangeProperty(TextProperty.FONT);
        }

        public static void ChangeAllFontStyle()
        {
            ChangeProperty(TextProperty.FONT_STYLE);
        }

        public static void ChangeAllFontSize()
        {
            ChangeProperty(TextProperty.FONT_SIZE);
        }

        public static void ChangeAllLineSpacing()
        {
            ChangeProperty(TextProperty.LINE_SPACING);
        }

        public static void ChangeAllRichText()
        {
            ChangeProperty(TextProperty.RICH_TEXT);
        }

        public static void ChangeAllAlignment()
        {
            ChangeProperty(TextProperty.ALIGNMENT);
        }

        public static void ChangeAllAlignByGeometry()
        {
            ChangeProperty(TextProperty.ALIGN_BY_GEOMETRY);
        }

        public static void ChangeAllHorizontalOverflow()
        {
            ChangeProperty(TextProperty.HORIZONTAL_OVERFLOW);
        }

        public static void ChangeAllVerticalOverflow()
        {
            ChangeProperty(TextProperty.VERTICAL_OVERFLOW);
        }

        public static void ChangeAllBestFit()
        {
            ChangeProperty(TextProperty.BEST_FIT);
        }

        public static void ChangeAllColor()
        {
            ChangeProperty(TextProperty.COLOR);
        }

        public static void ChangeAllMaterial()
        {
            ChangeProperty(TextProperty.MATERIAL);
        }

        public static void ChangeAllRaycastTarget()
        {
            ChangeProperty(TextProperty.RAYCAST);
        }

        /// <summary>
        /// Change Every property of the Text to the saved FontData.
        /// </summary>
        public static void InitializeNewTextObject(Text textObject)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

            if(GlobalFontData == null)
            {
                return;
            }
            //textObject.text = GlobalFontData.text;

            Undo.RecordObject(textObject, "Change all properties");
            textObject.SetFont(GlobalFontData);
            textObject.SetFontSize(GlobalFontData);
            textObject.SetFontSize(GlobalFontData);
            textObject.lineSpacing = GlobalFontData.lineSpacing;
            textObject.supportRichText = GlobalFontData.supportRichText;

            textObject.alignment = GlobalFontData.alignment;
            textObject.alignByGeometry = GlobalFontData.alignByGeometry;
            textObject.horizontalOverflow = GlobalFontData.horizontalOverflow;
            textObject.verticalOverflow = GlobalFontData.verticalOverflow;
            textObject.resizeTextForBestFit = GlobalFontData.resizeTextForBestFit;

            textObject.SetFontColor(GlobalFontData);
            textObject.material = GlobalFontData.material;
            textObject.raycastTarget = GlobalFontData.raycastTarget;
        }

        /// <summary>
        /// Change Text property of this Text based on TextProperty Type.
        /// </summary>
        public static void ChangeProperty(this Text t, TextProperty prop)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;
            if(GlobalFontData == null)
            {
                return;
            }

            switch(prop)
            {
                case TextProperty.FONT:
                    DoAction(t, t.font, GlobalFontData.font, prop);
                    break;
                case TextProperty.FONT_STYLE:
                    DoAction(t, t.fontStyle, GlobalFontData.fontStyle, prop);
                    break;
                case TextProperty.FONT_SIZE:
                    DoAction(t, t.fontSize, GlobalFontData.fontSize, prop);
                    break;
                case TextProperty.LINE_SPACING:
                    DoAction(t, t.lineSpacing, GlobalFontData.lineSpacing, prop);
                    break;
                case TextProperty.RICH_TEXT:
                    DoAction(t, t.supportRichText, GlobalFontData.supportRichText, prop);
                    break;
                case TextProperty.ALIGNMENT:
                    DoAction(t, t.alignment, GlobalFontData.alignment, prop);
                    break;
                case TextProperty.ALIGN_BY_GEOMETRY:
                    DoAction(t, t.alignByGeometry, GlobalFontData.alignByGeometry, prop);
                    break;
                case TextProperty.HORIZONTAL_OVERFLOW:
                    DoAction(t, t.horizontalOverflow, GlobalFontData.horizontalOverflow, prop);
                    break;
                case TextProperty.VERTICAL_OVERFLOW:
                    DoAction(t, t.verticalOverflow, GlobalFontData.verticalOverflow, prop);
                    break;
                case TextProperty.BEST_FIT:
                    DoAction(t, t.resizeTextForBestFit, GlobalFontData.resizeTextForBestFit, prop);
                    break;
                case TextProperty.COLOR:
                    DoAction(t, t.color, GlobalFontData.color, prop);
                    break;
                case TextProperty.MATERIAL:
                    DoAction(t, t.material, GlobalFontData.material, prop);
                    break;
                case TextProperty.RAYCAST:
                    DoAction(t, t.raycastTarget, GlobalFontData.raycastTarget, prop);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region private

        /// <summary>
        /// Change Text property of all Text based on TextProperty Type.
        /// </summary>
        private static void ChangeProperty(TextProperty prop)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

            if(GlobalFontData == null)
            {
                return;
            }

            var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

            var all = allTextObjects.Length;
            var changed = 0;

            foreach(Text t in allTextObjects)
            {
                switch(prop)
                {
                    case TextProperty.FONT:
                        DoAction(t, t.font, GlobalFontData.font, prop, ref changed);
                        break;
                    case TextProperty.FONT_STYLE:
                        DoAction(t, t.fontStyle, GlobalFontData.fontStyle, prop, ref changed);
                        break;
                    case TextProperty.FONT_SIZE:
                        DoAction(t, t.fontSize, GlobalFontData.fontSize, prop, ref changed);
                        break;
                    case TextProperty.LINE_SPACING:
                        DoAction(t, t.lineSpacing, GlobalFontData.lineSpacing, prop, ref changed);
                        break;
                    case TextProperty.RICH_TEXT:
                        DoAction(t, t.supportRichText, GlobalFontData.supportRichText, prop, ref changed);
                        break;
                    case TextProperty.ALIGNMENT:
                        DoAction(t, t.alignment, GlobalFontData.alignment, prop, ref changed);
                        break;
                    case TextProperty.ALIGN_BY_GEOMETRY:
                        DoAction(t, t.alignByGeometry, GlobalFontData.alignByGeometry, prop, ref changed);
                        break;
                    case TextProperty.HORIZONTAL_OVERFLOW:
                        DoAction(t, t.horizontalOverflow, GlobalFontData.horizontalOverflow, prop, ref changed);
                        break;
                    case TextProperty.VERTICAL_OVERFLOW:
                        DoAction(t, t.verticalOverflow, GlobalFontData.verticalOverflow, prop, ref changed);
                        break;
                    case TextProperty.BEST_FIT:
                        DoAction(t, t.resizeTextForBestFit, GlobalFontData.resizeTextForBestFit, prop, ref changed);
                        break;
                    case TextProperty.COLOR:
                        DoAction(t, t.color, GlobalFontData.color, prop, ref changed);
                        break;
                    case TextProperty.MATERIAL:
                        DoAction(t, t.material, GlobalFontData.material, prop, ref changed);
                        break;
                    case TextProperty.RAYCAST:
                        DoAction(t, t.raycastTarget, GlobalFontData.raycastTarget, prop, ref changed);
                        break;
                    default:
                        break;
                }
            }

            ShowMessge(all, changed);
        }

        /// <summary>
        /// Call the appropriate method to change this propert type T.
        /// </summary>
        private static void DoAction<T>(this Text t, T fromValue, T toValue, TextProperty prop)
        {
            int noCounter = 0;
            DoAction(t, fromValue, toValue, prop, ref noCounter);
        }
        /// <summary>
        /// Call the appropriate method to change this propert type T.
        /// </summary>
        private static void DoAction<T>(Text t, T fromValue, T toValue, TextProperty prop, ref int compareValues)
        {
            if(!EqualityComparer<T>.Default.Equals(fromValue, toValue))
            {
                compareValues++;

                switch(prop)
                {
                    case TextProperty.FONT:
                        Undo.RecordObject(t, "Set font");
                        t.SetFont(toValue);
                        break;
                    case TextProperty.FONT_STYLE:
                        Undo.RecordObject(t, "Set font style");
                        t.SetFontStyle(toValue);
                        break;
                    case TextProperty.FONT_SIZE:
                        Undo.RecordObject(t, "Set font size");
                        t.SetFontSize(toValue);
                        break;
                    case TextProperty.LINE_SPACING:
                        Undo.RecordObject(t, "Set line spacing");
                        t.SetLineSpacing(toValue);
                        break;
                    case TextProperty.RICH_TEXT:
                        Undo.RecordObject(t, "Set rich text");
                        t.SetRichText(toValue);
                        break;
                    case TextProperty.ALIGNMENT:
                        Undo.RecordObject(t, "Set alignment");
                        t.SetAlignment(toValue);
                        break;
                    case TextProperty.ALIGN_BY_GEOMETRY:
                        Undo.RecordObject(t, "Set align by geometry");
                        t.SetAlignByGeometry(toValue);
                        break;
                    case TextProperty.HORIZONTAL_OVERFLOW:
                        Undo.RecordObject(t, "Set horizontal overflow");
                        t.SetHorizontalOverflow(toValue);
                        break;
                    case TextProperty.VERTICAL_OVERFLOW:
                        Undo.RecordObject(t, "Set vertical overflow");
                        t.SetVerticalOverflow(toValue);
                        break;
                    case TextProperty.BEST_FIT:
                        Undo.RecordObject(t, "Set best fit");
                        t.SetBestFit(toValue);
                        break;
                    case TextProperty.COLOR:
                        Undo.RecordObject(t, "Set color");
                        t.SetFontColor(toValue);
                        break;
                    case TextProperty.MATERIAL:
                        Undo.RecordObject(t, "Set material");
                        t.SetMaterial(toValue);
                        break;
                    case TextProperty.RAYCAST:
                        Undo.RecordObject(t, "Set raycast");
                        t.SetRaycastTarget(toValue);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Display total text objects found, and the total changed.
        /// </summary>
        private static void ShowMessge(int all, int changed)
        {
        //    Debug.Log(
        //        string.Format(
        //            "{0} Total Text objects found. {1} Total objects changed!",
        //            all,
        //            changed
        //            ));
        }

        #endregion
    }
}
