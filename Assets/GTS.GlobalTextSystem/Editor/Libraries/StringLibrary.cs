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
/// Collection of tools and helpers for our global text system.
/// </summary>
namespace GTS.GlobalTextSystem.Libraries
{
    public class StringLibrary
    {
        /// <summary> The string KEY by which the EditorPrefs saves/loads GlobalFontData name.</summary>
        public const string GLOBAL_FONT_KEY = "GlobalFontData";

        /// <summary> The string which holds the save path for each GlobalFontData asset. </summary>
        public const string SAVE_PATH = "/Editor Default Resources/GTS.GlobalUIFontSettings/";

        /// <summary> Default Font, when not Font has been chosen, or could not be loaded. </summary>
        public const string ARIAL = "Arial";


        #region menu headings

        private const string INTRO = "Set to global ";

        public const string MENU_FONT = INTRO + "FONT";

        public const string MENU_FONT_STYLE = INTRO + "font STYLE";

        public const string MENU_FONT_SIZE = INTRO + "font SIZE";

        public const string MENU_LINE_SPACING = INTRO + "LINE SPACING";

        public const string MENU_RICH_TEXT = INTRO + "RICH TEXT support";

        public const string MENU_ALIGNMENT = INTRO + "ALIGNMENT";

        public const string MENU_BY_GEOMETRY = INTRO + "align BY GEOMETRY";

        public const string MENU_HORIZONTAL = INTRO + "HORIZONTAL overflow";

        public const string MENU_VERTICAL = INTRO + "VERTICAL overflow";

        public const string MENU_BEST_FIT = INTRO + "BEST FIT";

        public const string MENU_FONT_COLOR = INTRO + "font COLOR";

        public const string MENU_MATERIAL = INTRO + "MATERIAL";

        public const string MENU_RAYCAST = INTRO + "RAYCAST option";

        public const string MENU_SET_ALL = "Set to ALL global presets";

        #endregion
    }
}
