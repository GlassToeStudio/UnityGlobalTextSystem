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
/// Small System that provides useful funtionality to Unitys UI Text system.
/// </summary>
namespace GTS.GlobalTextSystem
{
    /// <summary>
    /// Holds static references for our GlobalTextAsset and Text Objects.
    /// </summary>
    public class GlobalTextSettings
    {
        /// <summary> The Global Data to apply to all Text objects. </summary>
        public static TextData TextSettings { get; set; }

        /// <summary>  Always up-to-date list of all Text objects in the scene. </summary>
        public static object[] AllTextObjects { get; set; }

        /// <summary>
        /// Holds static references for our GlobalTextAsset and Text Objects.
        /// </summary>
        public GlobalTextSettings(TextData textSettings, object[] allTextObjects)
        {
            TextSettings = textSettings;
            AllTextObjects = allTextObjects;
        }
    }
}