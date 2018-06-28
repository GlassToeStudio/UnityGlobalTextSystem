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
using GTS.GlobalTextSystem.Tools;
using GTS.GlobalTextSystem.Menus;

/// <summary>
/// Small System that provides useful funtionality to Unitys UI Text system.
/// </summary>
namespace GTS.GlobalTextSystem
{
    /// <summary>
    /// The main entry point for the GlobalText System.
    /// Handles creating and setting up all class instances for the system to run.
    /// </summary>
    [InitializeOnLoad]
    class EntryPoint
    {
        /// <summary>
        /// Static constuctor. Created when Unity first loads.
        /// </summary>
        static EntryPoint()
        {
            // Retrieve the saved name of the current global text asset
            var textAssetName = EditorPrefs.GetString(StringLibrary.GLOBAL_FONT_KEY, StringLibrary.ARIAL);

            // Load the saved global text asset
            var globalTextAsset = AssetProcessor.LoadTextAsset(textAssetName);

            // If, for some reason, there is no text asset, create a defaul Arial text asset
            if(globalTextAsset == null)
            {
                AssetProcessor.CreateDefaultTextAsset();
                globalTextAsset = AssetProcessor.LoadTextAsset(textAssetName);
            }

            // Create the listener for notifications of newly create Text objects
            var hierarchyListener = new HierarchyListener();

            // Grab all, if any, Text objects in the scene
            var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(Text));

            // Create and initialie the GlobalFontSettings
            new GlobalTextSettings(globalTextAsset, allTextObjects);

            // Initialize the listener for the font settings window
            GlobalTextSettingsWindow.globalFontListner = hierarchyListener;

            // Start listening for the creation of text objects
            hierarchyListener.Listen();
        }
    }
}
