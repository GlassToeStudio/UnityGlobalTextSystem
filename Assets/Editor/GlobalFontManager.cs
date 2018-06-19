using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GlobalUITextFontUtility
{
    /// <summary>
    /// Class that will check every Text asset's Font
    /// to see if it is the GlobalFontData.
    /// </summary>
    [System.Serializable, InitializeOnLoad]
    static class GlobalFontManager
    {
        /// <summary>
        /// Get or Set the Global Font to be used for Every Text Object.
        /// </summary>
        public static FontData GlobalFontData { get; set; }

        /// <summary>
        /// Only returns true of GlobalFontData is found and legit.
        /// </summary>
        public static bool IsInit { get; set; }

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
            string globalFontName = EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, string.Empty);

            // Load GlobalFontData
            GlobalFontData = GlobalFontUtils.LoadGlobalFont(globalFontName);

            if(GlobalFontData == null)
            {
                Debug.LogWarning(
                    "<color=red>Global FontData not found! Please select one from Fonts/Select Global Font window!</color>."
                    );

                return;
            }
            else if(GlobalFontData.font == null)
            {
                Debug.LogWarning(
                    "<color=red>Global Font not found! Please select one from Fonts/Select Global Font window!.</color>"
                    );

                return;
            }


            if(GlobalFontData.name == "Arial")
            {
                StopListening();
                return;
            }

            StartListening();
        }


        /// <summary>
        /// Get all Text assets in scene and get/set their font.
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

                Selection.activeGameObject.GetComponentInChildren<Text>(true).font = GlobalFontData.font;

            }
        }

        /// <summary>
        /// Subscribe to the hierarchyChanged Event. IsInit = true;
        /// </summary>
        public static void StartListening()
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
        public static void StopListening()
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
        /// Loop through every Text object in the scene and change its font.
        /// </summary>
        public static void ChangeAllFonts()
        {
            if(IsGlobalFontCriteriaMet())
            {
                var textCount = 0;
                var fontChangedCount = 0;

                // Get all Text objects in the scene.
                var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

                // Loop each Text object and get/set its font.
                // This will change the font for every Text object
                // in the scene. Is this what we want?
                foreach(Text t in allTextObjects)
                {
                    textCount++;
                    if(t.font != GlobalFontData.font)
                    {
                        fontChangedCount++;
                        t.font = GlobalFontData.font;
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

        /// <summary>
        /// Checks that we have a created object (we could be deleting objects)
        /// And that the object, or its children, have Text.
        /// </summary>
        private static bool IsSelectionCriteriaMet()
        {
            // So we can delete Text Objects
            if(Selection.activeGameObject == null)
            {
                return false;
            }


            // If there is no Text object, abort.
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
            // If a GlobalFontData is not set, abort.
            if(GlobalFontData == null)
            {
                StopListening();

                Debug.LogError(
                    "<color=red>GlobalFontData is null, Have you set it?</color>"
                    );

                return false;
            }

            // If the font property of GlobalFontData is not set, abort.
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
    }
}