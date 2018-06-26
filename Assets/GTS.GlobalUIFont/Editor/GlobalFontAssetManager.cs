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
namespace GTS.GlobalUIFont.Tools
{
    /// <summary>
    /// Some utility functions to load and save FontData assets.
    /// </summary>
    public static class GlobalFontAssetManager
    {

        #region public methods

        /// <summary>
        /// Set the passed in Font as the Global Font to be used for any new text object.
        /// </summary>
        /// <param name="selectedFont">Font to be set as global.</param>
        public static void SetGlobalFont(Font selectedFont)
        {
            if(!IfFileExists(selectedFont.name))
            {
                SaveFontAsset(selectedFont);
            }
            EditorPrefs.SetString(GlobalFontConstants.GLOBAL_FONT_KEY, selectedFont.name);
            GlobalFontManager.GlobalFontData = LoadFontAsset(selectedFont.name);
        }

        /// <summary>
        /// Load a FontData object from Assets/SAVE_PATH.
        /// </summary>
        /// <param name="assetName">name of the FontData asset to load.</param>
        /// <returns>The loaded FontData asset</returns>
        public static FontData LoadFontAsset(string assetName)
        {                       
            FontData data = (FontData)EditorGUIUtility.Load(
                string.Format(
                    "{0}{1}{2}{3}", "Assets", GlobalFontConstants.SAVE_PATH, assetName, ".asset")
                    );

            return data;
        }

        #endregion


        #region private methods

        /// <summary>
        /// Check if the current file exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>true if file exists</returns>
        private static bool IfFileExists(string fileName)
        {
            return File.Exists(string.Format("{0}{1}{2}.asset", Application.dataPath, GlobalFontConstants.SAVE_PATH, fileName));
        }

        /// <summary>
        /// Save the currently selected FontData, GlobalFontData, and save the name in EditorPrefs.
        /// </summary>
        /// <param name="font">Font used to create the new FontData asset.</param>
        private static void SaveFontAsset(Font font)
        {
            EditorPrefs.SetString(GlobalFontConstants.GLOBAL_FONT_KEY, font.name);
            CreateFontDataAsset(font);
        }

        /// <summary>
        /// Create and Save a new FontData asset.
        /// </summary>
        private static void CreateFontDataAsset(Font f)
        {
            var fontDataAsset = ScriptableObject.CreateInstance<FontData>();
            
            fontDataAsset.font = f;
            
            AssetDatabase.CreateAsset(
                fontDataAsset, 
                string.Format(
                    "{0}{1}{2}.asset", "Assets", GlobalFontConstants.SAVE_PATH, f.name)
                    );
            
            AssetDatabase.SaveAssets();
            
            AssetDatabase.Refresh();

            //Resources.UnloadUnusedAssets();
        }

        /// <summary>
        /// Create a FontAsset for built-in Arial font.
        /// </summary>
        public static void CreateDefaultFontAsset()
        {
            Font f = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            SaveFontAsset(f);
        }

        #endregion
    }
}