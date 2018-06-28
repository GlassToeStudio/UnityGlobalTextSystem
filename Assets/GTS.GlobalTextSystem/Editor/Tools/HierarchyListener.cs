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
using GTS.GlobalTextSystem.Libraries;

/// <summary>
/// Small System that provides useful functionality to Unity's UI Text system.
/// </summary>
namespace GTS.GlobalTextSystem.Tools
{
    /// <summary>
    /// Listen for the creation of new Text objects, change their font to the global font.
    /// </summary>
    public class HierarchyListener
    {
        /// <summary> True when listening for hierarchy changes.</summary>
        private bool isListening = false;

        /// <summary>
        /// Listen for new text objects to be created, as long as we have some global data saved.
        /// </summary>
        public void Listen()
        {
            // Nothing to change the font to
            if(GlobalTextSettings.TextSettings == null)
            {
                StopListening();
                return;
            }

            // No need to listen of the default font is Arial
            if(GlobalTextSettings.TextSettings.name == StringLibrary.ARIAL)
            {
                StopListening();
                return;
            }

            StartListening();
        }

        #region event

        /// <summary>
        /// Get newly created Text asset and get/set its font.
        /// </summary>
        private void OnHierarchyChanged()
        {
            // Do not run while in play mode!
            if(Application.isEditor && !Application.isPlaying)
            {
                if(!IsValidObject() || GlobalTextSettings.TextSettings == null)
                {
                    return;
                }

                // New text object created, update the static list of all Text objects.
                GlobalTextSettings.AllTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

                Selection.activeGameObject.GetComponentInChildren<Text>(true).SetFont(GlobalTextSettings.TextSettings.font);
            }
        }

        #endregion


        #region private methods

        /// <summary>
        /// Subscribe to the hierarchyChanged Event. isListening = true;
        /// </summary>
        private void StartListening()
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
        /// Un-subscribe from the hierarchyChanged Event. isListening = false;
        /// </summary>
        private void StopListening()
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
        /// and that the object, or its children, have Text.
        /// </summary>
        private bool IsValidObject()
        {
            if(Selection.activeGameObject == null)
            {
                // We deleted an object update the static list of all Text objects.
                GlobalTextSettings.AllTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

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