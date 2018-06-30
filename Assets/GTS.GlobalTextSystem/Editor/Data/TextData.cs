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
using System.Collections.Generic;
using GTS.GlobalTextSystem.Libraries;

/// <summary>
/// Small System that provides useful functionality to Unity's UI Text system.
/// </summary>>
namespace GTS.GlobalTextSystem.Data
{
    /// <summary>
    /// ScriptableObject to hold the global Text Settings. 
    /// </summary>
    public class TextData : ScriptableObject
    {
        public string text = "This holds all of your settings for Text Objects!";

        [SerializeField]
        public Font font { get; set; }
        public FontStyle fontStyle { get; set; }// = FontStyle.Normal;
        public int fontSize { get; set; } //= 14;
        public float lineSpacing { get; set; } //= 1.0f;
        public bool supportRichText { get; set; } //= false;

        public TextAnchor alignment { get; set; } //= TextAnchor.MiddleCenter;
        public bool alignByGeometry { get; set; } //= false;
        public HorizontalWrapMode horizontalOverflow { get; set; } //= HorizontalWrapMode.Overflow;
        public VerticalWrapMode verticalOverflow { get; set; } //= VerticalWrapMode.Truncate;
        public bool resizeTextForBestFit { get; set; } //= false;

        public int resizeTextMinSize { get; set; } //= 0;
        public int resizeTextMaxSize { get; set; } //= 60;

        public Color color { get; set; } //= Color.black;
        public Material material { get; set; }
        public bool raycastTarget { get; set; } //= false;

        public Overrides overrides;

        public Dictionary<string, bool> SavedSettings = new Dictionary<string, bool>()
        {
            { StringLibrary.FONT, true },
            { StringLibrary.FONT_STYLE, false },
            { StringLibrary.FONT_SIZE, false },
            { StringLibrary.LINE_SPACING, false },
            { StringLibrary.RICH_TEXT, false },
            { StringLibrary.ALIGNMENT, false },
            { StringLibrary.ALIGN_BY_GEOMETRY, false },
            { StringLibrary.HORIZONTAL_OVERFLOW, false },
            { StringLibrary.VERTICAL_OVERFLOW, false },
            { StringLibrary.BEST_FIT, false },
            { StringLibrary.TEXT_MIN, false },
            { StringLibrary.TEXT_MAX, false },
            { StringLibrary.COLOR, true },
            { StringLibrary.MATERIAL, false },
            { StringLibrary.RAYCAST, false }
        };
    }

    [System.Serializable]
    public class Overrides
    {
        public bool saveFont { get; set; }
        public bool saveFontStyle { get; set; }
        public bool saveFontSize { get; set; }
        public bool saveLineSpacing { get; set; }
        public bool saveRichText { get; set; }

        public bool saveAlignment { get; set; }
        public bool saveAlighnByGeometry { get; set; }
        public bool saveHorizontalOverflow { get; set; }
        public bool saveVerticalOVerflow { get; set; }
        public bool saveBestFit { get; set; }
        public bool saveMinText { get; set; }
        public bool saveMaxText { get; set; }

        public bool saveColor { get; set; }
        public bool saveMaterial { get; set; }
        public bool saveRaycaset { get; set; }
    }
}