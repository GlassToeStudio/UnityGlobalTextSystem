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
/// Small System that provides useful functionality to Unity's UI Text system.
/// </summary>>
namespace GTS.GlobalTextSystem
{
    /// <summary>
    /// ScriptableObject to hold the global Text Settings. 
    /// </summary>
    public class TextData : ScriptableObject
    {
        [TextArea]
        public string text;

        [Header("Character")]
        public Font font;
        public FontStyle fontStyle = FontStyle.Normal;
        public int fontSize = 14;
        public float lineSpacing = 1.0f;
        public bool supportRichText = false;

        [Header("Paragraph")]
        public TextAnchor alignment = TextAnchor.MiddleCenter;
        public bool alignByGeometry = false;
        public HorizontalWrapMode horizontalOverflow = HorizontalWrapMode.Overflow;
        public VerticalWrapMode verticalOverflow = VerticalWrapMode.Truncate;
        public bool resizeTextForBestFit = false;
        
        [Space] // Could make custom Inspector for this.
        public int resizeTextMinSize = 0;
        public int resizeTextMaxSize = 60;

        [Space]
        public Color color = Color.black;
        public Material material;
        public bool raycastTarget = false;
    }
}