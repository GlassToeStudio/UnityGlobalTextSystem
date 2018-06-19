using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GlobalUITextFontUtility
{
    /// <summary>
    /// Custom Window to set the Global Font.
    /// </summary>
    public class GlobalFontManagerWindow : EditorWindow
    {
        /// <summary>
        /// Name of the Global Font, to be displayed in the Window.
        /// </summary>
        private static string fontDisplayName;

        /// <summary>
        /// Show and initialize the custom Global Font Selection window..
        /// </summary>
        [MenuItem("Font/Select Global Font")]
        private static void ShowWindow()
        {
            GetWindow<GlobalFontManagerWindow>(true, "Select Global Font", true);

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
                fontDisplayName = "No font chosen";
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

        private void OnSelectorClosed()
        {
            if(Event.current.commandName == "ObjectSelectorClosed")
            {
                if(EditorGUIUtility.GetObjectPickerObject() != null)
                {
                    var selectedFont = (Font)EditorGUIUtility.GetObjectPickerObject();

                    fontDisplayName = selectedFont.name;

                    if(!File.Exists(string.Format("{0}/Editor Default Resources/{1}.asset", Application.dataPath, selectedFont.name)))
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

                    this.Close();
                }
            }
        }

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
                EditorPrefs.SetString(GlobalFontUtils.GLOBAL_FONT_KEY, "Arial");
                GlobalFontManager.Init();
                fontDisplayName = "Arial";
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


        /// <summary>
        /// Debug Only: Delete EditorPrefs.
        /// </summary>
        private void DeletePrefsButton()
        {/*
            EditorGUILayout.Space();

            if(GUILayout.Button("Delete Editor Prefs"))
            {
                Debug.Log("Before: " + EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, string.Empty));
                EditorPrefs.DeleteAll();
                Debug.Log("After: " + EditorPrefs.GetString(GlobalFontUtils.GLOBAL_FONT_KEY, string.Empty));
            }
        */
        }
    }
}