using UnityEngine;
using UnityEditor;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GlobalUITextFontUtility
{
    /// <summary>
    /// Some utility functions to load and save FontData assets.
    /// </summary>
    public static class GlobalFontUtils
    {
        /// <summary>
        /// The string KEY by which the EditorPrefs saves/loads GlobalFontData name.
        /// </summary>
        public const string GLOBAL_FONT_KEY = "GlobalFontData";
        
        /// <summary>
        /// The string which holds the save path for each GlobalFontData asset.
        /// </summary>
        public const string SAVE_PATH = "Assets/Editor Default Resources/";
        
        /// <summary>
        /// Save the currently selected FontData, GlobalFontData, and save the name in EditorPrefs.
        /// <para>returns: FontData</para>
        /// </summary>
        public static void SaveGlobalFont(Font f)
        {
            EditorPrefs.SetString(GLOBAL_FONT_KEY, f.name);
            
            CreateFontDataAsset(f);
        }
        
        /// <summary>
        /// Create, Save, and Return a new FontData asset.
        /// <para>returns: FontData</para>
        /// </summary>
        private static void CreateFontDataAsset(Font f)
        {
            var fontDataAsset = ScriptableObject.CreateInstance<FontData>();
            
            fontDataAsset.font = f;
            
            AssetDatabase.CreateAsset(fontDataAsset, string.Format("{0}{1}.asset", SAVE_PATH, f.name));
            
            AssetDatabase.SaveAssets();
            
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Load a FontData object from "Default Editor Resources".
        /// <para>returns: FontData</para>
        /// </summary>
        public static FontData LoadGlobalFont(string globalFontName)
        {            
            if(globalFontName == string.Empty)
            {
                Debug.LogWarning("<color=red>No Global Font Asset Saved!</color>");
                return null;
            }
            
            EditorPrefs.SetString(GLOBAL_FONT_KEY, globalFontName);

            FontData data = (FontData)EditorGUIUtility.Load ("Assets/Editor Default Resources/" + globalFontName + ".asset");

            return data;
        }
    }
}