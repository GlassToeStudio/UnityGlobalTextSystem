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
using GTS.GlobalUIFont.Tools;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Class that will check every Text asset's Font
    /// to see if it is the GlobalFontData.
    /// </summary>
    class GlobalFontListener
    {
        #region properties

        /// <summary>
        /// True when listening for hierarchy changes.
        /// </summary>
        private static bool isListening;

        #endregion


        #region init

        /// <summary>
        /// Default static constructor.
        /// </summary>
        static GlobalFontListener()
        {
            // Nothing
        }

        /// <summary>
        /// Load the GlobalFontData FontData (if it exists) and subscribe to the 
        /// EditorApplication.hierarchyChanged Event.
        /// </summary>
        public static void Listen()
        {
            if(!GlobalFontManager.HasGlobalFontData())
            {
                StopListening();
                return;
            }

            if(GlobalFontManager.GlobalFontData.name == GlobalFontConstants.ARIAL)
            {
                StopListening();
                return;
            }

            StartListening();
        }

        #endregion


        #region events

        /// <summary>
        /// Get newly created Text asset and get/set its font.
        /// </summary>
        private static void OnHierarchyChanged()
        {
            // Do not run while in play mode!
            if(Application.isEditor && !Application.isPlaying)
            {
                if(!IsValidObject() || !GlobalFontManager.HasGlobalFontData())
                {
                    return;
                }

                Selection.activeGameObject.GetComponentInChildren<Text>(true).SetFont(GlobalFontManager.GlobalFontData.font);
            }
        }

        #endregion


        #region private methods

        /// <summary>
        /// Subscribe to the hierarchyChanged Event. IsListening = true;
        /// </summary>
        private static void StartListening()
        {
            if(!isListening)
            {
            #if UNITY_2018_1_OR_NEWER

                EditorApplication.hierarchyChanged += OnHierarchyChanged;

            #else

                EditorApplication.hierarchyWindowChanged += OnHierarchyChanged;

            #endif

                isListening = true;
            }
        }

        /// <summary>
        /// Un-subscribe from the hierarchyChanged Event. IsListening = false;
        /// </summary>
        private static void StopListening()
        {
            if(isListening)
            {
            #if UNITY_2018_1_OR_NEWER

                EditorApplication.hierarchyChanged -= OnHierarchyChanged;

            #else

                EditorApplication.hierarchyWindowChanged -= OnHierarchyChanged;

            #endif
                isListening = false;
            }
        }

        /// <summary>
        /// Checks that we have a created object (we could be deleting objects)
        /// And that the object, or its children, have Text.
        /// </summary>
        private static bool IsValidObject()
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

        #endregion
    }
}