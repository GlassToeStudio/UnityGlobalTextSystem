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

using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Various helper methods for the Text class.
    /// </summary>
    public static class GlobalFontExtensions
    {
        /// <summary>
        /// Set the Font of this Text object with the passed in value.
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
        /// Set the Font of this Text object with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="toValue">The generic T with the font that this Text object will be set.</param>
        public static void SetFont<T>(this Text t, T toValue)
        {
            t.SetFont(toValue as Font);
        }

        /// <summary>
        /// Set the FontStyle of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontStyle">The FontStyle that this Text object will be set.</param>
        public static void SetFontStyle(this Text t, FontStyle fontStyle)
        {
            t.fontStyle = fontStyle;
        }
        /// <summary>
        /// Set the FontStyle of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="text">The Text with the FontStyle that this Text object will be set.</param>
        public static void SetFontStyle(this Text t, Text text)
        {
            t.SetFontStyle(text.fontStyle);
        }
        /// <summary>
        /// Set the FontStyle of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontData">The FontData with FontStyle that this Text object will be set.</param>
        public static void SetFontStyle(this Text t, FontData fontData)
        {
            t.SetFontStyle(fontData.fontStyle);
        }
        /// <summary>
        /// Set the FontStyle of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontData">The FontData with FontStyle that this Text object will be set.</param>
        public static void SetFontStyle<T>(this Text t, T toValue)
        {
            t.SetFontStyle((FontStyle)Enum.Parse(typeof(T), toValue.ToString()));
        }
        

        /// <summary>
        /// Set the FontSize of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontSize">The FontSize that this Text object will be set.</param>
        public static void SetFontSize(this Text t, int fontSize)
        {
            t.fontSize = fontSize;
        }
        /// <summary>
        /// Set the FontSize of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="text">The Text with the FontSize that this Text object will be set.</param>
        public static void SetFontSize(this Text t, Text text)
        {
            t.SetFontSize(text.fontSize);
        }
        /// <summary>
        /// Set the FontSize of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontData">The FontData with the FontSize that this Text object will be set.</param>
        public static void SetFontSize(this Text t, FontData fontData)
        {
            t.SetFontSize(fontData.fontSize);
        }
        /// <summary>
        /// Set the FontSize of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontData">The FontData with the T that this Text object will be set.</param>
        public static void SetFontSize<T>(this Text t, T toValue)
        {
            t.SetFontSize(Convert.ToInt32(toValue));
        }


        /// <summary>
        /// Set the Line Spacing of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="lineSpacing">The Line Spacing that this Text object will be set.</param>
        public static void SetLineSpacing(this Text t, float lineSpacing)
        {
            t.lineSpacing = lineSpacing;
        }
        /// <summary>
        /// Set the Line Spacing of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="text">The Text with the Line Spacing that this Text object will be set.</param>
        public static void SetLineSpacing(this Text t, Text text)
        {
            t.SetLineSpacing(text.lineSpacing);
        }
        /// <summary>
        /// Set the Line Spacing of this Text object with the passed in value.
        /// </summary>
        /// <param name="t">this Text object</param>
        /// <param name="fontData">The FontData with the Line Spacing that this Text object will be set.</param>
        public static void SetLineSpacing(this Text t, FontData fontData)
        {
            t.SetLineSpacing(fontData.lineSpacing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="supportRichText"></param>
        public static void SetRichText(this Text t, bool supportRichText)
        {
            t.supportRichText = supportRichText;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="text"></param>
        public static void SetRichText(this Text t, Text text)
        {
            t.SetRichText(text.supportRichText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontData"></param>
        public static void SetRichText(this Text t, FontData fontData)
        {
            t.SetRichText(fontData.supportRichText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="color"></param>
        public static void SetFontColor(this Text t, Color color)
        {
            t.color = color;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="text"></param>
        public static void SetFontColor(this Text t, Text text)
        {
            t.SetFontColor(text.color);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontData"></param>
        public static void SetFontColor(this Text t, FontData fontData)
        {
            t.SetFontColor(fontData.color);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="fontData"></param>
        public static void SetFontColor<T>(this Text t, T toValue)
        {
            t.SetFontColor((Color)Convert.ChangeType(toValue, typeof(Color)));
        }

        // Need the rest of the extensions.


        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="fontSize">The font size to that is being compared.</param>
        /// <returns>true if font sizes are equal.</returns>
        public static bool MatchFontSize(this Text t, int fontSize)
        {
            return t.fontSize == fontSize;
        }
        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="text">The Text object font size to that is being compared.</param>
        /// <returns>true if font sizes are equal.</returns>
        public static bool MatchFontSize(this Text t, Text text)
        {
            return t.MatchFontSize(text.fontSize);
        }
        /// <summary>
        /// Compares this font size with the passed in value.
        /// </summary>
        /// <param name="t"> this Text object</param>
        /// <param name="fontData">The FontData font size to that is being compared.</param>
        /// <returns>true if font sizes are equal.</returns>
        public static bool MatchFontSize(this Text t, FontData fontData)
        {
            return t.MatchFontSize(fontData.fontSize);
        }
    }
}
