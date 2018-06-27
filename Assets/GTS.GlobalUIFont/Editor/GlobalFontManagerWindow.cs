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
using GTS.GlobalUIFont.Tools;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont.Menus
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

            ResetFontButton();

            SelectFont();
            
            ChangeAllFontsButton();

            OnFontSelectorClosed();

            ChangeAllFontsColorRealTime();

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
                    if(selectedFont == null)
                    {
                        Debug.Log("Why you pick none");
                    }

                    SetGlobalFontData(selectedFont);

                    fontDisplayName = selectedFont.name;
                }

                this.RepaintAll();

                GlobalFontListener.Listen();
            }
        }

        /// <summary>
        /// Checks if a FontData assets is created, else it creates one.
        /// </summary>
        private void SetGlobalFontData(Font selectedFont)
        {
            GlobalFontAssetManager.SetGlobalFont(selectedFont);
        }

        #endregion

        #region buttons

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
        /// Open a Font selector and select a Font.
        /// </summary>
        private void SelectFont()
        {
            EditorGUILayout.Space();

            GUILayout.Label("Select Font");

            if(GlobalFontManager.GlobalFontData != null)
            {
                EditorGUILayout.ObjectField(GlobalFontManager.GlobalFontData.font, typeof(Font), true);
            }
            else
            {
                EditorGUILayout.ObjectField(null, typeof(Font), true);
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
        /// Will gather all text objects in the scene and change their color in realtime.
        /// </summary>
        private void ChangeAllFontsColorRealTime()
        {
            EditorGUILayout.Space();

            GUILayout.Label("Change All Fonts Color In Scene");

            if(GlobalFontManager.GlobalFontData != null)
            {
                GlobalFontManager.GlobalFontData.color = EditorGUILayout.ColorField(GlobalFontManager.GlobalFontData.color);
                //test
                GlobalFontSystem.ChangeAllColor();
                RepaintAll();
            }
            else
            {
                EditorGUILayout.ColorField(Color.black);
            }
        }

        /// <summary>
        /// Change the FontSize of evrey Text in the scene.
        /// </summary>
        private void ChangeAllFontSizeButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts Size In Scene"))
            {
                GlobalFontSystem.ChangeAllFontSize();
                RepaintAll();
            }
            if(GlobalFontManager.GlobalFontData != null)
            {
                GlobalFontManager.GlobalFontData.fontSize = EditorGUILayout.IntField(GlobalFontManager.GlobalFontData.fontSize);
            }
            else
            {
                EditorGUILayout.IntField(0);
            }
        }

        /// <summary>
        /// Close this window
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
        /// Make sure we repaint when chagnes happen.
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