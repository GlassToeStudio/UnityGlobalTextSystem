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
        private bool saveFont = true;
        public bool SaveFont { get { return saveFont; } set { saveFont = value; } }
        public bool SaveFontStyle { get; set; }
        public bool SaveFontSize { get; set; }
        public bool SaveLineSpacing { get; set; }
        public bool SaveRichText { get; set; }

        public bool SaveAlignment { get; set; }
        public bool SaveAlighnByGeometry { get; set; }
        public bool SaveHorizontalOverflow { get; set; }
        public bool SaveVerticalOVerflow { get; set; }
        public bool SaveBestFit { get; set; }
        public bool SaveMinText { get; set; }
        public bool SaveMaxText { get; set; }

        private bool saveColor = true;
        public bool SaveColor { get { return saveColor; } set { saveColor = value; } }
        public bool SaveMaterial { get; set; }
        public bool SaveRaycaset { get; set; }
    }
}
