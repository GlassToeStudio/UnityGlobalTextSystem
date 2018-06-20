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

using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Custom Window to set the Global Font.
    /// </summary>
    public class GlobalFontManagerWindow : EditorWindow
    {
        #region fields

        /// <summary>
        /// Name of the Global Font, to be displayed in the Window.
        /// </summary>
        private static string fontDisplayName = GlobalFontUtils.ARIAL;

        #endregion

        #region init

        /// <summary>
        /// Show and initialize the custom Global Font Selection window..
        /// </summary>
        [MenuItem("Global Font/Settings")]
        private static void ShowWindow()
        {
            GlobalFontManagerWindow w = GetWindow<GlobalFontManagerWindow>(false, "Global UI Font", true);
            w.minSize = new Vector2(200, 110);
            w.maxSize = new Vector2(200, 110);

            // Display current Font name.
            if(GlobalFontManager.GlobalFontData != null)
            {
                if(GlobalFontManager.GlobalFontData.font != null)
                {
                    fontDisplayName = GlobalFontManager.GlobalFontData.font.name;
                }
            }
            else
            {
                fontDisplayName = GlobalFontUtils.ARIAL;
            }
        }

        /// <summary>
        /// Draw the window and its components. Listen for Button CLicks.
        /// </summary>
        private void OnGUI()
        {
            // Show Global Font Name
            EditorGUILayout.LabelField("Global Font: ", fontDisplayName);

            SelectFontButton();

            ResetFontButton();

            ChangeAllFontsButton();

            OnSelectorClosed();

            //TODO: Debug Only
            DeletePrefsButton();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Listens for ObjectSelectorClosedEvent.
        /// Will Get/Set the global font.
        /// </summary>
        private void OnSelectorClosed()
        {
            if(Event.current.commandName == "ObjectSelectorClosed")
            {
                if(EditorGUIUtility.GetObjectPickerObject() != null)
                {
                    var selectedFont = (Font)EditorGUIUtility.GetObjectPickerObject();

                    SetGlobalFontData(selectedFont);

                    fontDisplayName = selectedFont.name;
                }
            }
        }

        /// <summary>
        /// Checks if a FontData assets is created, else it creates one.
        /// </summary>
        /// <param name="selectedFont"></param>
        private void SetGlobalFontData(Font selectedFont)
        {
            if(!File.Exists(string.Format("{0}{1}{2}.asset", Application.dataPath, GlobalFontUtils.SAVE_PATH, selectedFont.name)))
            {
                GlobalFontUtils.SaveGlobalFont(selectedFont);
                GlobalFontManager.Init();
            }
            else
            {
                if(!GlobalFontManager.IsInit)
                {
                    EditorPrefs.SetString(GlobalFontUtils.GLOBAL_FONT_KEY, selectedFont.name);
                    GlobalFontManager.Init();
                }
                else
                {
                    GlobalFontManager.GlobalFontData = GlobalFontUtils.LoadGlobalFont(selectedFont.name);
                }
            }
        }

        #endregion

        #region buttons

        /// <summary>
        /// Open a Font selector and select a Font.
        /// </summary>
        private void SelectFontButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Select Font"))
            {
                EditorGUIUtility.ShowObjectPicker<Font>(null, true, "", GUIUtility.GetControlID(FocusType.Passive) + 100);
            }
        }

        /// <summary>
        /// Reset to Unity standard font, "Arial".
        /// </summary>
        private void ResetFontButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Reset Font"))
            {
                var selctedFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

                SetGlobalFontData(selctedFont);

                fontDisplayName = selctedFont.name;

                SceneView.RepaintAll();
            }
        }

        /// <summary>
        /// Find all Text in the scene and change its font.
        /// </summary>
        private void ChangeAllFontsButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts In Scene"))
            {
                GlobalFontManager.ChangeAllFonts();
            }
        }

            #region debug
            /// <summary>
            /// Debug Only: Delete EditorPrefs.
            /// </summary>
            private void DeletePrefsButton()
            {
                EditorGUILayout.Space();

                //if(GUILayout.Button("Delete Editor Prefs"))
                //{
                //    Debug.Log("Before: " + EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, GlobalFontUtils.ARIAL));
                //    EditorPrefs.DeleteAll();
                //    Debug.Log("After: " + EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, GlobalFontUtils.ARIAL));
                //}
            }
            #endregion

        #endregion
    }
}