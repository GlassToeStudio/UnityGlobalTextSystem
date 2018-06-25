using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace GTS.GlobalUIFont
{
    public class GlobalFontSystem
    {
        /// <summary>
        /// Loop through every Text object in the scene and change its font.
        /// </summary>
        public static void ChangeAllFonts()
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

            var textCount = 0;
            var fontChangedCount = 0;

            // All text objects in scene.
            var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

            foreach(Text t in allTextObjects)
            {
                textCount++;

                if(t.font != GlobalFontData.font)
                {
                    fontChangedCount++;

                    t.SetFont(GlobalFontData.font);
                }
            }

            Debug.Log(
                string.Format(
                    "{0} Total Text objects found. {1} Total fonts changed!",
                    textCount,
                    fontChangedCount
                    ));
        }

        public static void ChangeAllFontsColor()
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

            var textCount = 0;
            var fontChangedCount = 0;

            // All text objects in scene.
            var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

            foreach(Text t in allTextObjects)
            {
                textCount++;

                if(t.color != GlobalFontData.color)
                {
                    fontChangedCount++;

                    t.SetFontColor(GlobalFontData.color);
                }
            }

            Debug.Log(
                string.Format(
                    "{0} Total Text objects found. {1} Total fonts color changed!",
                    textCount,
                    fontChangedCount
                    ));
        }

        public static void ChangeAllFontsSize()
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;

            var textCount = 0;
            var fontChangedCount = 0;

            var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

            foreach(Text t in allTextObjects)
            {
                textCount++;

                if(!t.MatchFontSize(GlobalFontData))
                {
                    fontChangedCount++;

                    t.SetFontSize(GlobalFontData);
                }
            }

            Debug.Log(
                string.Format(
                    "{0} Total Text objects found. {1} Total fonts size changed!",
                    textCount,
                    fontChangedCount
                    ));
        }

        /// <summary>
        /// Change Every property of the Text to the saved FontData.
        /// </summary>
        public static void InitializeNewTextObject(Text textObject)
        {
            FontData GlobalFontData = GlobalFontManager.GlobalFontData;
            //textObject.text = GlobalFontData.text;

            textObject.SetFont(GlobalFontData);
            textObject.SetFontSize(GlobalFontData);
            textObject.SetFontSize(GlobalFontData);

            textObject.lineSpacing = GlobalFontData.lineSpacing;
            textObject.supportRichText = GlobalFontData.supportRichText;

            textObject.alignment = GlobalFontData.alignment;
            textObject.alignByGeometry = GlobalFontData.alignByGeometry;
            textObject.horizontalOverflow = GlobalFontData.horizontalOverflow;
            textObject.verticalOverflow = GlobalFontData.verticalOverflow;
            textObject.resizeTextForBestFit = GlobalFontData.resizeTextForBestFit;

            textObject.SetFontColor(GlobalFontData);

            textObject.material = GlobalFontData.material;
            textObject.raycastTarget = GlobalFontData.raycastTarget;
        }

    }
}
