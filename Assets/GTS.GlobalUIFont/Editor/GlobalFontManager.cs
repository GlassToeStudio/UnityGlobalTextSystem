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
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Class that will check every Text asset's Font
    /// to see if it is the GlobalFontData.
    /// </summary>
    [InitializeOnLoad]
    class GlobalFontManager : Editor
    {
        #region properties

        /// <summary>
        /// Get or Set the Global Font to be used for Every Text Object.
        /// </summary>
        [SerializeField]public static FontData GlobalFontData { get; set; }

        /// <summary>
        /// Only returns true of GlobalFontData is found and legit.
        /// </summary>
        public static bool IsInit { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public static string globalFontName { get; set; }

        #endregion

        #region init

        /// <summary>
        /// Default static constructor.
        /// </summary>
        static GlobalFontManager()
        {
            Init();
        }

        /// <summary>
        /// Load the GlobalFontData FontData (if it exists) and subscribe to the 
        /// EditorApplication.hierarchyChanged Event.
        /// </summary>
        public static void Init()
        {
            globalFontName = EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, GlobalFontUtils.ARIAL);

            // Load GlobalFontData
            GlobalFontData = GlobalFontUtils.LoadGlobalFont(globalFontName);

            if(GlobalFontData == null)
            {
                //Debug.LogWarning(
                //    "<color=red>Global FontData not found! Please select one from Fonts/Select Global Font window!</color>."
                //    );

                return;
            }
            else if(GlobalFontData.font == null)
            {
                Debug.LogWarning(
                    "<color=red>Global Font not found! Please select one from Fonts/Select Global Font window!.</color>"
                    );

                return;
            }

            if(GlobalFontData.name == GlobalFontUtils.ARIAL)
            {
                StopListening();
                return;
            }

            StartListening();
        }

        #endregion

        #region Event

        /// <summary>
        /// Get newly created Text asset and get/set its font.
        /// </summary>
        private static void OnHierarchyChanged()
        {
            // Do not run while in play mode!
            if(Application.isEditor && !Application.isPlaying)
            {
                if(!IsSelectionCriteriaMet() || !IsGlobalFontCriteriaMet())
                {
                    return;
                }

                Selection.activeGameObject.GetComponentInChildren<Text>(true).SetFont(GlobalFontData.font);
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Loop through every Text object in the scene and change its font.
        /// </summary>
        public static void ChangeAllFonts()
        {
            if(IsGlobalFontCriteriaMet())
            {
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
        }

        public static void ChangeAllFontsColor()
        {
            if(IsGlobalFontCriteriaMet())
            {
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
        }

        public static void ChangeAllFontsSize()
        {
            if(IsGlobalFontCriteriaMet())
            {
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
        }

        #endregion

        #region private methods

        /// <summary>
        /// Change Every propery of the Text to the saved FontData.
        /// </summary>
        public static void InitializeNewTextObject(Text textObject)
        {
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

        /// <summary>
        /// Subscribe to the hierarchyChanged Event. IsInit = true;
        /// </summary>
        private static void StartListening()
        {
            if(!IsInit)
            {
#if UNITY_2018_1_OR_NEWER

                EditorApplication.hierarchyChanged += OnHierarchyChanged;

#else

                EditorApplication.hierarchyWindowChanged += OnHierarchyChanged;

#endif

                IsInit = true;
            }
        }

        /// <summary>
        /// Unsubscribe from the hierarchyChanged Event. IsInit = false;
        /// </summary>
        private static void StopListening()
        {
            if(IsInit)
            {
#if UNITY_2018_1_OR_NEWER

                EditorApplication.hierarchyChanged -= OnHierarchyChanged;

#else

                EditorApplication.hierarchyWindowChanged -= OnHierarchyChanged;

#endif
                IsInit = false;
            }
        }

        /// <summary>
        /// Checks that we have a created object (we could be deleting objects)
        /// And that the object, or its children, have Text.
        /// </summary>
        private static bool IsSelectionCriteriaMet()
        {
            if(Selection.activeGameObject == null)
            {
                return false;
            }

            if(Selection.activeGameObject.GetComponentInChildren<Text>(true) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Make sure we have set some Global Font Settings.
        /// </summary>
        private static bool IsGlobalFontCriteriaMet()
        {
            if(GlobalFontData == null)
            {
                if(globalFontName == GlobalFontUtils.ARIAL)
                {
                    return true;
                }

                //Debug.LogError(
                //    "<color=red>GlobalFontData is null, Have you set it?</color>"
                //    );

                return false;
            }

            if(GlobalFontData.font == null)
            {
                StopListening();

                Debug.LogError(
                    "<color=red>GlobalFont is null, did you delete the asset?</color>"
                    );

                return false;
            }

            return true;
        }

        #endregion
    }
}