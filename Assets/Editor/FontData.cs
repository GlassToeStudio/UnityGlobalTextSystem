using UnityEngine;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GlobalUITextFontUtility
{
    /// <summary>
    /// ScriptableObject to hold the GlobalFontData. 
    /// </summary>
    public class FontData : ScriptableObject
    {
        /// <summary>
        /// The font to be used as the Global UI text font. 
        /// </summary>
        public Font font;


        //TODO: Could Save Other Settings.

        /*
         * text
         * fontStyle
         * fontSize
         * lineSpacing
         * supportRichText
         * alignment
         * alignByGeometry
         * horizontalOverflow
         * verticalOverflow
         * resizeTextForBestFit
         * Color
         * Material
         * RayCastTarget
         * 
         */
    }
}