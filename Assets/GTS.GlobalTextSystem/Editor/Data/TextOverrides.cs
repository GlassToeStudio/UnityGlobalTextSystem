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
/// Small System that provides useful functionality to Unity's UI Text system.
/// </summary>>
namespace GTS.GlobalTextSystem.Data
{
    [System.Serializable]
    public class TextOverrides
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
