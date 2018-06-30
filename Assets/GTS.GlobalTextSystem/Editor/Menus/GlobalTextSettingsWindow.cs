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
using GTS.GlobalTextSystem.Tools;
using GTS.GlobalTextSystem.Libraries;

/// <summary>
/// Menus for controlling the properties of one or all Text objects.
/// </summary>
namespace GTS.GlobalTextSystem.Menus
{
    /// <summary>
    /// Custom Window to adjust all Text in the scene.
    /// </summary>
    public class GlobalTextSettingsWindow : EditorWindow
    {
        /// <summary> Name of the current Text asset, to be displayed in the Window.</summary>
        private static string fontDisplayName = StringLibrary.ARIAL;

        public static HierarchyListener hierarchyListener { private get; set; }

        /// <summary>
        /// Show and initialize the custom Global Text Settings window..
        /// </summary>
        [MenuItem(StringLibrary.WINDOW_TITLE)]
        private static void ShowWindow()
        {
            GlobalTextSettingsWindow w = GetWindow<GlobalTextSettingsWindow>(true, "Global Text Settings", true);

            w.minSize = new Vector2(200, 400);
            w.maxSize = new Vector2(200, 400);

            //w.autoRepaintOnSceneChange = true;

            GlobalTextSettings.UpdateTextObjects();

            // Display current Font name.
            if(GlobalTextSettings.TextSettings != null)
            {
                if(GlobalTextSettings.TextSettings.font != null)
                {
                    fontDisplayName = GlobalTextSettings.TextSettings.font.name;
                }
            }
            else
            {
                fontDisplayName = StringLibrary.ARIAL;
            }
        }

        /// <summary>
        /// Draw the window and its components. Listen for Button Clicks.
        /// </summary>
        private void OnGUI()
        {
            // Show Global Font Name
            EditorGUILayout.LabelField("Global Font: ", fontDisplayName);

            ResetFontButton();

            SelectFont();
            
            OnFontSelectorClosed();

            ChangeAllFontsButton();
            
            ChangeAllFontsColorRealTime();

            ChangeAllFontSizeButton();

            CloseWindowButton();

            //TODO: Debug Only
            DeletePrefsButton();

            
        }

        /// <summary>
        /// Listens for ObjectSelectorClosed Event. Will Get/Set the global font.
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
                        Debug.LogError("No Font Assets Found!");
                    }

                    SetGlobalFontData(selectedFont);

                    fontDisplayName = selectedFont.name;
                }

                RepaintAll();

                // May or may not be listening, depending on the Text asset that is chosen.
                hierarchyListener.Listen();
            }
        }

        /// <summary>
        /// Checks if a TextData assets is created, else it creates one.
        /// </summary>
        private void SetGlobalFontData(Font selectedFont)
        {
            GlobalTextSettings.TextSettings = AssetProcessor.SetGlobalFont(selectedFont);
            GlobalTextSettings.UpdateProperties();
            RepaintAll();
        }


        #region buttons

        /// <summary>
        /// Reset to Unity's standard font, "Arial".
        /// </summary>
        private void ResetFontButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Reset Font"))
            {
                var selctedFont = StringLibrary.ARIAL;

                AssetProcessor.CreateDefaultTextAsset();
                GlobalTextSettings.TextSettings = AssetProcessor.LoadTextAsset(selctedFont);

                hierarchyListener.Listen();

                fontDisplayName = selctedFont;
                RepaintAll();
            }
        }

        /// <summary>
        /// Open a Font selector and select a Font to use for the Text Asset Settings.
        /// </summary>
        private void SelectFont()
        {
            EditorGUILayout.Space();

            GUILayout.Label("Select Font");

            if(GlobalTextSettings.TextSettings != null)
            {
                EditorGUILayout.ObjectField(GlobalTextSettings.TextSettings.font, typeof(Font), true);
                RepaintAll();
            }
            else
            {
                EditorGUILayout.ObjectField(null, typeof(Font), true);
                RepaintAll();
            }           
        }

        /// <summary>
        /// Change the fonts of all Text Objects in the scene.
        /// </summary>
        private void ChangeAllFontsButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts In Scene"))
            {
                PropertyLibrary.ChangeAllFonts();
                RepaintAll();
            }

        }

        /// <summary>
        /// Change the font color of all Text objects in the scene, in real-time.
        /// </summary>
        private void ChangeAllFontsColorRealTime()
        {
            EditorGUILayout.Space();

            GUILayout.Label("Change All Fonts Color In Scene");
            Selection.activeObject = GlobalTextSettings.TextSettings;
            if(GlobalTextSettings.TextSettings != null)
            {
                // Allows us to use the Color Picker to change color.
                if(Event.current.commandName == "ColorPickerChanged")
                {
                    GlobalTextSettings.TextSettings.color = EditorGUILayout.ColorField(GlobalTextSettings.TextSettings.color);

                    PropertyLibrary.ChangeAllColor();
                }
                // Allows us to use the dropper to change color.
                else if(Event.current.commandName == "EyeDropperClicked")
                {
                    GlobalTextSettings.TextSettings.color = EditorGUILayout.ColorField(GlobalTextSettings.TextSettings.color);

                    PropertyLibrary.ChangeAllColor();
                }
                else
                {
                    // Do not change color when a new TextData is loaded.
                    EditorGUILayout.ColorField(GlobalTextSettings.TextSettings.color);
                }
                RepaintAll();
            }
            else
            {
                // No TextData, show Black.
                EditorGUILayout.ColorField(Color.black);
                RepaintAll();
            }

            
        }

        /// <summary>
        /// Change the FontSize of every Text in the scene.
        /// </summary>
        private void ChangeAllFontSizeButton()
        {
            EditorGUILayout.Space();

            if(GUILayout.Button("Change All Fonts Size In Scene"))
            {
                PropertyLibrary.ChangeAllFontSize();
                RepaintAll();
            }

            if(GlobalTextSettings.TextSettings != null)
            {
                GlobalTextSettings.TextSettings.fontSize = EditorGUILayout.IntField(GlobalTextSettings.TextSettings.fontSize);
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
                RepaintAll();
                this.Close();
            }

        }

        /// <summary>
        /// TODO: Need to figure out what to repaint...
        /// Make sure we repaint when changes happen...
        /// </summary>
        private void RepaintAll()
        {
            if(SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.Repaint();
            }
            if(SceneView.currentDrawingSceneView != null)
            {
                SceneView.currentDrawingSceneView.Repaint();
            }

            SceneView.RepaintAll();
            EditorApplication.RepaintAnimationWindow();
            EditorApplication.RepaintHierarchyWindow();
            EditorApplication.RepaintProjectWindow();
            
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();

            Repaint();
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
                EditorPrefs.SetString(StringLibrary.GLOBAL_FONT_KEY, string.Empty);
                RepaintAll();
            }
        }

        #endregion
    }
}