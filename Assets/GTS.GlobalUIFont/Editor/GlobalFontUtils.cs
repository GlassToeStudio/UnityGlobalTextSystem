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
    /// Some utility functions to load and save FontData assets.
    /// </summary>
    public static class GlobalFontUtils
    {
        #region constants

        /// <summary>
        /// The string KEY by which the EditorPrefs saves/loads GlobalFontData name.
        /// </summary>
        public const string GLOBAL_FONT_KEY = "GlobalFontData";
        
        /// <summary>
        /// The string which holds the save path for each GlobalFontData asset.
        /// </summary>
        public const string SAVE_PATH = "/Editor Default Resources/GTS.GlobalUIFontSettings/";

        public const string ARIAL = "Arial";

        #endregion

        #region public methods

        /// <summary>
        /// Load a FontData object from "Default Editor Resources".
        /// <para>returns: FontData</para>
        /// </summary>
        public static FontData LoadGlobalFont(string globalFontName)
        {
            if(globalFontName == string.Empty)
            {
                //Debug.LogWarning("<color=red>No Global Font Asset Saved!</color>");
                return null;
            }

            EditorPrefs.SetString(GLOBAL_FONT_KEY, globalFontName);

            FontData data = (FontData)EditorGUIUtility.Load(
                string.Format(
                    "{0}{1}{2}{3}", "Assets", SAVE_PATH, globalFontName, ".asset")
                    );

            return data;
        }

        /// <summary>
        /// Save the currently selected FontData, GlobalFontData, and save the name in EditorPrefs.
        /// </summary>
        public static void SaveGlobalFont(Font f)
        {
            EditorPrefs.SetString(GLOBAL_FONT_KEY, f.name);
            
            CreateFontDataAsset(f);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Create, Save, and Return a new FontData asset.
        /// </summary>
        private static void CreateFontDataAsset(Font f)
        {
            var fontDataAsset = ScriptableObject.CreateInstance<FontData>();
            
            fontDataAsset.font = f;
            
            AssetDatabase.CreateAsset(
                fontDataAsset, 
                string.Format(
                    "{0}{1}{2}.asset", "Assets", SAVE_PATH, f.name)
                    );
            
            AssetDatabase.SaveAssets();
            
            AssetDatabase.Refresh();

            Resources.UnloadUnusedAssets();
        }

        #endregion
    }
}