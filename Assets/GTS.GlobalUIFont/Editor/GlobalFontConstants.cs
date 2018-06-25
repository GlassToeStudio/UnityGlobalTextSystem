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

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    public class GlobalFontConstants
    {
        /// <summary>
        /// The string KEY by which the EditorPrefs saves/loads GlobalFontData name.
        /// </summary>
        public const string GLOBAL_FONT_KEY = "GlobalFontData";

        /// <summary>
        /// The string which holds the save path for each GlobalFontData asset.
        /// </summary>
        public const string SAVE_PATH = "/Editor Default Resources/GTS.GlobalUIFontSettings/";

        /// <summary>
        /// Default Font, when not Font has been chosen, or could be loaded.
        /// </summary>
        public const string ARIAL = "Arial";
    }
}
