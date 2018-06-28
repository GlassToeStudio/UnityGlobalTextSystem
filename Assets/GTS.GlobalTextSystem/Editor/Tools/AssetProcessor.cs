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
/// Collection of tools and helpers for our global text system.
/// </summary>
namespace GTS.GlobalTextSystem.Tools
{
    /// <summary>
    /// Some utility functions to Load, Save, and Create TextData assets.
    /// </summary>
    public static class AssetProcessor
    {
        #region public methods

        /// <summary>
        /// Set the passed in Font as the Global Font and create a TextData asset.
        /// Return the the TextData asset of the same name.
        /// </summary>
        public static TextData SetGlobalFont(Font selectedFont)
        {
            if(!FileExists(selectedFont.name))
            {
                SaveFontAsset(selectedFont);
            }

            EditorPrefs.SetString(StringLibrary.GLOBAL_FONT_KEY, selectedFont.name);

            return LoadTextAsset(selectedFont.name);
        }

        /// <summary>
        /// Load a TextData object from StringLibrary.SAVE_PATH
        /// </summary>
        public static TextData LoadTextAsset(string assetName)
        {                          
            TextData data = (TextData)EditorGUIUtility.Load(
                string.Format(
                    "{0}{1}{2}{3}", "Assets", StringLibrary.SAVE_PATH, assetName, ".asset")
                    );

            return data;
        }

        #endregion


        #region private methods

        /// <summary>
        /// Check if the current TextData asset exists.
        /// </summary>
        private static bool FileExists(string fileName)
        {
            return File.Exists(string.Format("{0}{1}{2}.asset", Application.dataPath, StringLibrary.SAVE_PATH, fileName));
        }

        /// <summary>
        /// Create a TextData asset from the passed in Font, and save the name in EditorPrefs.
        /// </summary>
        private static void SaveFontAsset(Font font)
        {
            EditorPrefs.SetString(StringLibrary.GLOBAL_FONT_KEY, font.name);

            var fontDataAsset = ScriptableObject.CreateInstance<TextData>();

            fontDataAsset.font = font;

            AssetDatabase.CreateAsset(
                fontDataAsset,
                string.Format(
                    "{0}{1}{2}.asset", "Assets", StringLibrary.SAVE_PATH, font.name)
                    );

            AssetDatabase.SaveAssets();

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Create a FontAsset for built-in Arial font.
        /// </summary>
        public static void CreateDefaultTextAsset()
        {
            Font f = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            SaveFontAsset(f);
        }

        #endregion
    }
}