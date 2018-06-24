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
using UnityEngine.UI;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Varius helper methods for the Text class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="fontSize">The font size to that is being compared.</param>
        /// <returns></returns>
        public static bool MatchFontSize(this Text t, int fontSize)
        {
            return t.fontSize == fontSize;
        }
        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="text">The Text obejct font size to that is being compared.</param>
        /// <returns></returns>
        public static bool MatchFontSize(this Text t, Text text)
        {
            return t.MatchFontSize(text.fontSize);
        }
        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="text">The FontData font size to that is being compared.</param>
        /// <returns></returns>
        public static bool MatchFontSize(this Text t, FontData fontData)
        {
            return t.MatchFontSize(fontData.fontSize);
        }

        /// <summary>
        /// Set the Font of this Text object with the passed in value.t.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="font">The font that this Text object will be set.</param>
        public static void SetFont(this Text t, Font font)
        {
            t.font = font;
        }
        /// <summary>
        /// Set the Font of this Text object with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="text">The Text object with font that this Text object will be set.</param>
        public static void SetFont(this Text t, Text text)
        {
            t.SetFont(text.font);
        }
        /// <summary>
        /// Set the Font of this Text object with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="fontData">The FontData with the font that this Text object will be set.</param>
        public static void SetFont(this Text t, FontData fontData)
        {
            t.SetFont(fontData.font);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontStyle"></param>
        public static void SetFontStyle(this Text t, FontStyle fontStyle)
        {
            t.fontStyle = fontStyle;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="text"></param>
        public static void SetFontStyle(this Text t, Text text)
        {
            t.SetFontStyle(text.fontStyle);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontData"></param>
        public static void SetFontStyle(this Text t, FontData fontData)
        {
            t.SetFontStyle(fontData.fontStyle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontSize"></param>
        public static void SetFontSize(this Text t, int fontSize)
        {
            t.fontSize = fontSize;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="text"></param>
        public static void SetFontSize(this Text t, Text text)
        {
            t.SetFontSize(text.fontSize);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontData"></param>
        public static void SetFontSize(this Text t, FontData fontData)
        {
            t.SetFontSize(fontData.fontSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="s"></param>
        public static void SetLineSpacing(this Text t, float s)
        {
            t.lineSpacing = s;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="s"></param>
        public static void SetLineSpacing(this Text t, Text s)
        {
            t.SetLineSpacing(s.lineSpacing);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="s"></param>
        public static void SetLineSpacing(this Text t, FontData s)
        {
            t.SetLineSpacing(s.lineSpacing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="r"></param>
        public static void SetRichText(this Text t, bool r)
        {
            t.supportRichText = r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="r"></param>
        public static void SetRichText(this Text t, Text r)
        {
            t.SetRichText(r.supportRichText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="r"></param>
        public static void SetRichText(this Text t, FontData r)
        {
            t.SetRichText(r.supportRichText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="c"></param>
        public static void SetFontColor(this Text t, Color c)
        {
            t.color = c;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="c"></param>
        public static void SetFontColor(this Text t, Text c)
        {
            t.SetFontColor(c.color);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="c"></param>
        public static void SetFontColor(this Text t, FontData c)
        {
            t.SetFontColor(c.color);
        }
    }
}
