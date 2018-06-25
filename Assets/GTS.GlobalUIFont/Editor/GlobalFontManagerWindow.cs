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
        private static string fontDisplayName = GlobalFontConstants.ARIAL;

        Color fontColor;

        #endregion

        #region init

        /// <summary>
        /// Show and initialize the custom Global Font Selection window..
        /// </summary>
        [MenuItem("Global Font/Settings")]
        private static void ShowWindow()
        {
            GlobalFontManagerWindow w = GetWindow<GlobalFontManagerWindow>(false, "Global UI Font", true);
            w.minSize = new Vector2(200, 400);
            w.maxSize = new Vector2(200, 400);
            w.autoRepaintOnSceneChange = true;

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
                fontDisplayName = GlobalFontConstants.ARIAL;
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

            OnFontSelectorClosed();

            ChangeAllFontsColorButton();

            ChangeAllFontSizeButton();

            CloseWindowButton();

            //TODO: Debug Only
            DeletePrefsButton();
        }

        #endregion

        #region private methods

        /// <summary>
        /// Listens for ObjectSelectorClosedEvent.
        /// Will Get/Set the global font.
        /// </summary>
        private void OnFontSelectorClosed()
        {
            if(Event.current.commandName == "ObjectSelectorClosed")
            {
                if(EditorGUIUtility.GetObjectPickerObject() != null)
                {
                    var selectedFont = (Font)EditorGUIUtility.GetObjectPickerObject();

                    SetGlobalFontData(selectedFont);

                    fontDisplayName = selectedFont.name;
                }

                this.Repaint();

                GlobalFontListener.Listen();
            }
        }

        /// <summary>
        /// Checks if a FontData assets is created, else it creates one.
        /// </summary>
        /// <param name="selectedFont"></param>
        private void SetGlobalFontData(Font selectedFont)
        {
            GlobalFontAssetManager.SetGlobalFont(selectedFont);
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
            EditorGUILayout.ObjectField(GlobalFontManager.GlobalFontData.font, typeof(Font), true);
        }

        /// <summary>
        /// Reset to Unity standard font, "Arial".
        /// </summary>
        private void ResetFontButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Reset Font"))
            {
                var selctedFont = GlobalFontConstants.ARIAL;

                GlobalFontManager.GlobalFontData = GlobalFontAssetManager.LoadFontAsset(selctedFont);

                GlobalFontListener.Listen();

                fontDisplayName = selctedFont;

                this.Repaint();
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
                GlobalFontSystem.ChangeAllFonts();
                RepaintAll();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChangeAllFontsColorButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts Color In Scene"))
            {
                GlobalFontSystem.ChangeAllFontsColor();
                RepaintAll();
            }
            GlobalFontManager.GlobalFontData.color = EditorGUILayout.ColorField(GlobalFontManager.GlobalFontData.color);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChangeAllFontSizeButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts Size In Scene"))
            {
                GlobalFontSystem.ChangeAllFontsSize();
                RepaintAll();
            }
            GlobalFontManager.GlobalFontData.fontSize = EditorGUILayout.IntField(GlobalFontManager.GlobalFontData.fontSize);
        }

        /// <summary>
        /// FClose this window
        /// </summary>
        private void CloseWindowButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Close"))
            {
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RepaintAll()
        {
            SceneView.lastActiveSceneView.Repaint();
            SceneView.RepaintAll();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
            this.Repaint();
        }

        #endregion

        #region debug

        /// <summary>
        /// Debug Only: Delete EditorPrefs.
        /// </summary>
        private void DeletePrefsButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Delete Editor Prefs"))
            {
                Debug.Log("Before: " + EditorPrefs.GetString(GlobalFontConstants.GLOBAL_FONT_KEY, GlobalFontConstants.ARIAL));
                EditorPrefs.DeleteAll();
                Debug.Log("After: " + EditorPrefs.GetString(GlobalFontConstants.GLOBAL_FONT_KEY, GlobalFontConstants.ARIAL));
            }
        }

        #endregion
    }
}