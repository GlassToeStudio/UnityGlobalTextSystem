using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace GTS.GlobalUIFont
{
    public class GlobalFontSystem
    {
        /// <summary>
        /// Loop through every Text object in the scene and change its font.
        /// </summary>
        public static void ChangeAllFonts()
        {
            ChangeAllT(TextProperty.FONT);
        }

        public static void ChangeAllFontStyle()
        {
            ChangeAllT(TextProperty.FONT_STYLE);
        }

        public static void ChangeAllFontSize()
        {
            ChangeAllT(TextProperty.FONT_SIZE);
        }

        public static void ChangeAllLineSpacing()
        {
            ChangeAllT(TextProperty.LINE_SPACING);
        }

        public static void ChangeAllRichText()
        {
            ChangeAllT(TextProperty.RICH_TEXT);
        }

        public static void ChangeAllAlignment()
        {
            ChangeAllT(TextProperty.ALIGNMENT);
        }

        public static void ChangeAllAlignByGeometry()
        {
            ChangeAllT(TextProperty.ALIGN_BY_GEOMETRY);
        }

        public static void ChangeAllHorizontalOverflow()
        {
            ChangeAllT(TextProperty.HORIZONTAL_OVERFLOW);
        }

        public static void ChangeAllVerticalOverflow()
        {
            ChangeAllT(TextProperty.VERTICAL_OVERFLOW);
        }

        public static void ChangeAllBestFit()
        {
            ChangeAllT(TextProperty.BEST_FIT);
        }

        public static void ChangeAllColor()
        {
            ChangeAllT(TextProperty.COLOR);
        }

        public static void ChangeAllMaterial()
        {
            ChangeAllT(TextProperty.MATERIAL);
        }

        public static void ChangeAllRaycastTarget()
        {
            ChangeAllT(TextProperty.RAYCAST);
        }



        /// <summary>
        /// Change Every property of the Text to the saved FontData.
        /// </summary>
        public static void InitializeNewTextObject(Text textObject)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;
            //textObject.text = GlobalFontData.text;

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

        #region private

        private static void ChangeAllT(TextProperty prop)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

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

        private static void DoAction<T>(Text t, T fromValue, T toValue, TextProperty prop, ref int compareValues)
        {
            if(!EqualityComparer<T>.Default.Equals(fromValue, toValue))
            {
                compareValues++;

                switch(prop)
                {
                    case TextProperty.FONT:
                        t.SetFont(toValue);
                        break;
                    case TextProperty.FONT_STYLE:
                        t.SetFontStyle(toValue);
                        break;
                    case TextProperty.FONT_SIZE:
                        t.SetFontSize(toValue);
                        break;
                    case TextProperty.LINE_SPACING:
                        t.lineSpacing = Convert.ToSingle(toValue);
                        break;
                    case TextProperty.RICH_TEXT:
                        t.supportRichText = Convert.ToBoolean(toValue);
                        break;
                    case TextProperty.ALIGNMENT:
                        t.alignment = (TextAnchor)Enum.Parse(typeof(T), toValue.ToString());
                        break;
                    case TextProperty.ALIGN_BY_GEOMETRY:
                        t.alignByGeometry = Convert.ToBoolean(toValue);
                        break;
                    case TextProperty.HORIZONTAL_OVERFLOW:
                        t.horizontalOverflow = (HorizontalWrapMode)Enum.Parse(typeof(T), toValue.ToString());
                        break;
                    case TextProperty.VERTICAL_OVERFLOW:
                        t.verticalOverflow = (VerticalWrapMode)Enum.Parse(typeof(T), toValue.ToString());
                        break;
                    case TextProperty.BEST_FIT:
                        t.resizeTextForBestFit = Convert.ToBoolean(toValue);
                        break;
                    case TextProperty.COLOR:
                        t.SetFontColor(toValue);
                        break;
                    case TextProperty.MATERIAL:
                        t.material = (Material)Convert.ChangeType(toValue, typeof(Material));
                        break;
                    case TextProperty.RAYCAST:
                        t.raycastTarget = Convert.ToBoolean(toValue);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowMessge(int all, int changed)
        {
            Debug.Log(
                string.Format(
                    "{0} Total Text objects found. {1} Total fonts size changed!",
                    all,
                    changed
                    ));
        }

        #endregion
    }
}
