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
using GTS.GlobalUIFont.Tools;

/// <summary>
/// Small System to change the global font from "Arial" to another font of your choosing.
/// </summary>
namespace GTS.GlobalUIFont
{
    /// <summary>
    /// Class that will check every Text asset's Font
    /// to see if it is the GlobalFontData.
    /// </summary>
    [InitializeOnLoad] 
    class GlobalFontManager
    {
        /// <summary>
        /// Get or Set the Global Font to be used for Every Text Object.
        /// </summary>
        public static FontData GlobalFontData { get; set;  }

        /// <summary>
        /// Default static constructor.
        /// </summary>
        static GlobalFontManager()
        {
            Init();
        }

        /// <summary>
        /// Load the saved global font data.
        /// </summary>
        static void Init()
        {
            var globalFontName = EditorPrefs.GetString(GlobalFontConstants.GLOBAL_FONT_KEY, GlobalFontConstants.ARIAL);

            GlobalFontData = GlobalFontAssetManager.LoadFontAsset(globalFontName);

            if(!HasGlobalFontData())
            {
                GlobalFontAssetManager.CreateDefaultFontAsset();
                return;
            }

            GlobalFontListener.Listen();
        }

       
        /// <summary>
        /// Make sure we have set some Global Font Settings.
        /// </summary>
        public static bool HasGlobalFontData()
        {
            return GlobalFontData != null;

        }
    }
}