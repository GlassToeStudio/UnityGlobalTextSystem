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
        private int _fontSize = 12;
        public int fontSize { get { return _fontSize; } set { this._fontSize = value; } }
        private float _lineSpacing = 1f; //= 1.0f;
        public float lineSpacing { get { return _lineSpacing; } set { this._lineSpacing = value; } }
        public bool supportRichText { get; set; } //= false;

        public TextAnchor alignment { get; set; } //= TextAnchor.MiddleCenter;
        public bool alignByGeometry { get; set; } //= false;
        public HorizontalWrapMode horizontalOverflow { get; set; } //= HorizontalWrapMode.Overflow;
        public VerticalWrapMode verticalOverflow { get; set; } //= VerticalWrapMode.Truncate;
        public bool resizeTextForBestFit { get; set; } //= false;

        public int resizeTextMinSize { get; set; } //= 0;
        public int resizeTextMaxSize { get; set; } //= 60;

        private Color _color = Color.black;
        public Color color { get { return _color; } set { this._color = value; } }
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
        private bool _saveFont = true;
        public bool saveFont { get { return _saveFont; } set { _saveFont = value; } }
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

        private bool _saveColor = true;
        public bool saveColor { get { return _saveColor; } set { _saveColor = value; } }
        public bool saveMaterial { get; set; }
        public bool saveRaycaset { get; set; }
    }
}