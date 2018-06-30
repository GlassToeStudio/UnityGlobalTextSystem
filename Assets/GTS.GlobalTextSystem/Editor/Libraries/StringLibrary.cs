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
        public const string SAVE_PATH = "/Editor Default Resources/GTS.GlobalTextSettings/";

        /// <summary> Default Font, when not Font has been chosen, or could not be loaded. </summary>
        public const string ARIAL = "Arial";

        public const string CONTEXT_MENU_PATH = "CONTEXT/Text/";

        public const string SYSTEM_MENU_PATH = "GameObject/Gloat Text/";

        public const string WINDOW_TITLE = "Global Text System/Settings";


        #region Text Properties

        public const string FONT = "font";

        public const string FONT_STYLE = "fontStyle";

        public const string FONT_SIZE = "fontSize";

        public const string LINE_SPACING = "lineSpacing";

        public const string RICH_TEXT = "supportRichText";

        public const string ALIGNMENT = "alignment";

        public const string ALIGN_BY_GEOMETRY = "alignByGeometry";

        public const string HORIZONTAL_OVERFLOW = "horizontalOverflow";

        public const string VERTICAL_OVERFLOW = "verticalOverflow";

        public const string BEST_FIT = "resizeTextForBestFit";

        public const string TEXT_MIN = "resizeTextMinSize";

        public const string TEXT_MAX = "resizeTextMaxSize";

        public const string COLOR = "color";

        public const string MATERIAL = "material";

        public const string RAYCAST = "raycastTarget";
        
        #endregion


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
