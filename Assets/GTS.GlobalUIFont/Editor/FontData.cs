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

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// ScriptableObject to hold the GlobalFontData. 
    /// </summary>
    public class FontData : ScriptableObject
    {
        //[TextArea]
        //public string text;

        /// <summary>
        /// The font to be used as the Global UI text font. 
        /// </summary>
        [Header("Character")]
        public Font font;
        //public FontStyle fontStyle;
        //public int fontSize;
        //public float lineSpacing;
        //public bool richText;

        //[Header("Paragraph")]
        //public TextAnchor alignment;
        //public bool alignByGeometry;
        //public HorizontalWrapMode horizontalOverflow;
        //public VerticalWrapMode verticalOverflow;
        //public bool  bestFit;
        public Color color;
        //public Material material;
        //public bool RayCastTarget;
    }
}