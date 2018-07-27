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

using UnityEditor;
using UnityEngine;
using GTS.GlobalTextSystem.Libraries;

/// <summary>
/// Small System that provides useful functionality to Unity's UI Text system.
/// </summary>>
namespace GTS.GlobalTextSystem.Data
{
    [CustomEditor(typeof(TextData))]
    public class TextDataEditor : Editor
    {
        bool foldCharacter = true;
        bool foldParagraph = true;
        TextData myTarget;

        int startHorizontalWidth = 250;

        int startLabelWidth = 130;
        int endLabelWidth = 100;
        int startFieldWidth = 120;
        int endFieldWidth = 20;

        private void OnEnable()
        {
            myTarget = (TextData)target;
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            
            EditorGUILayout.LabelField("Text");
            myTarget.text = EditorGUILayout.TextField(myTarget.text, GUILayout.Height(40));

            #region Character

            foldCharacter = EditorGUILayout.Foldout(foldCharacter, "Character", 
                new GUIStyle(EditorStyles.foldout)
                {
                    fontStyle = FontStyle.Bold,
                });

            if(foldCharacter)
            {
                // Font
                StartSection();
                myTarget.font = (Font) EditorGUILayout.ObjectField("Font", myTarget.font, typeof(Font), true, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveFont = EditorGUILayout.Toggle(myTarget.overrides.SaveFont);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // FontStyle
                StartSection();
                myTarget.fontStyle = (FontStyle)EditorGUILayout.EnumPopup("FontStyle", myTarget.fontStyle, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveFontStyle = EditorGUILayout.Toggle(myTarget.overrides.SaveFontStyle);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // FontSize
                StartSection();
                myTarget.fontSize = EditorGUILayout.IntField("FontSize", myTarget.fontSize, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveFontSize = EditorGUILayout.Toggle(myTarget.overrides.SaveFontSize);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Line Spacing
                StartSection();
                myTarget.lineSpacing = EditorGUILayout.FloatField("Line Spacing", myTarget.lineSpacing, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveLineSpacing = EditorGUILayout.Toggle(myTarget.overrides.SaveLineSpacing);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Rich Text
                StartSection();
                myTarget.supportRichText = EditorGUILayout.Toggle("Rich Text", myTarget.supportRichText, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveRichText = EditorGUILayout.Toggle(myTarget.overrides.SaveRichText);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                EditorGUI.indentLevel = 0;
            }

            #endregion

            EditorGUILayout.Space();

            #region Paragraph

            foldParagraph = EditorGUILayout.Foldout(foldParagraph, "Paragraph",
                new GUIStyle(EditorStyles.foldout)
                {
                    fontStyle = FontStyle.Bold,
                });


            if(foldParagraph)
            {
                // Alignment
                StartSection();
                myTarget.alignment = (TextAnchor)EditorGUILayout.EnumPopup("Alignment", myTarget.alignment, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveAlignment = EditorGUILayout.Toggle(myTarget.overrides.SaveAlignment);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Align By Geometry
                StartSection();
                myTarget.alignByGeometry = EditorGUILayout.Toggle("Align By Geometry", myTarget.alignByGeometry, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveAlighnByGeometry = EditorGUILayout.Toggle(myTarget.overrides.SaveAlighnByGeometry);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Horizontal Overflow
                StartSection();
                myTarget.horizontalOverflow = (HorizontalWrapMode)EditorGUILayout.EnumPopup("Horizontal Overflow", myTarget.horizontalOverflow, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveHorizontalOverflow = EditorGUILayout.Toggle(myTarget.overrides.SaveHorizontalOverflow);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Vertical Overflow
                StartSection();
                myTarget.verticalOverflow = (VerticalWrapMode)EditorGUILayout.EnumPopup("Vertical Overflow", myTarget.verticalOverflow, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveVerticalOVerflow = EditorGUILayout.Toggle(myTarget.overrides.SaveVerticalOVerflow);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Best Fit
                StartSection();
                myTarget.resizeTextForBestFit = EditorGUILayout.Toggle("Best Fit", myTarget.resizeTextForBestFit, GUILayout.Width(startHorizontalWidth));
                MiddleSection();
                myTarget.overrides.SaveBestFit = EditorGUILayout.Toggle(myTarget.overrides.SaveBestFit);
                EditorGUILayout.LabelField("Apply to new.");
                EndSction();

                // Best Fit Options
                if(myTarget.resizeTextForBestFit)
                {
                    // Min Size
                    StartSection(2);
                    myTarget.resizeTextMinSize = EditorGUILayout.IntField("Min Size", myTarget.resizeTextMinSize, GUILayout.Width(startHorizontalWidth));
                    MiddleSection();
                    myTarget.overrides.SaveMinText = EditorGUILayout.Toggle(myTarget.overrides.SaveMinText);
                    EditorGUILayout.LabelField("Apply to new.");
                    EndSction();

                    // Max Size
                    StartSection(2);
                    myTarget.resizeTextMaxSize = EditorGUILayout.IntField("Max Size", myTarget.resizeTextMaxSize, GUILayout.Width(startHorizontalWidth));
                    MiddleSection();
                    myTarget.overrides.SaveMaxText = EditorGUILayout.Toggle(myTarget.overrides.SaveMaxText);
                    EditorGUILayout.LabelField("Apply to new.");
                    EndSction();
                }
                EditorGUI.indentLevel = 0;
            }

            #endregion

            EditorGUILayout.Space();

            #region Other

            // Color
            StartSection(0);
            myTarget.color = EditorGUILayout.ColorField("Color", myTarget.color, GUILayout.Width(startHorizontalWidth));
            MiddleSection();
            MiddleSection();
            myTarget.overrides.SaveColor = EditorGUILayout.Toggle(myTarget.overrides.SaveColor);
            EditorGUILayout.LabelField("Apply to new.");
            EndSction();

            // Material
            StartSection(0);
            myTarget.material = (Material)EditorGUILayout.ObjectField("Material", myTarget.material, typeof(Material), true, GUILayout.Width(startHorizontalWidth));
            MiddleSection();
            MiddleSection();
            myTarget.overrides.SaveMaterial = EditorGUILayout.Toggle(myTarget.overrides.SaveMaterial);
            EditorGUILayout.LabelField("Apply to new.");
            EndSction();

            // Raycast
            StartSection(0);
            myTarget.raycastTarget = EditorGUILayout.Toggle("Raycast Target", myTarget.raycastTarget, GUILayout.Width(startHorizontalWidth));
            MiddleSection();
            MiddleSection();
            myTarget.overrides.SaveRaycaset = EditorGUILayout.Toggle(myTarget.overrides.SaveRaycaset);
            EditorGUILayout.LabelField("Apply to new.");
            EndSction();

            #endregion

            UpdateDictionary();

            EditorUtility.SetDirty(target);
        }

        private void UpdateDictionary()
        {
            myTarget.SavedSettings[StringLibrary.FONT] = myTarget.overrides.SaveFont;
            myTarget.SavedSettings[StringLibrary.FONT_STYLE] = myTarget.overrides.SaveFontStyle;
            myTarget.SavedSettings[StringLibrary.FONT_SIZE] = myTarget.overrides.SaveFontSize;
            myTarget.SavedSettings[StringLibrary.LINE_SPACING] = myTarget.overrides.SaveLineSpacing;
            myTarget.SavedSettings[StringLibrary.RICH_TEXT] = myTarget.overrides.SaveRichText;
            myTarget.SavedSettings[StringLibrary.ALIGNMENT] = myTarget.overrides.SaveAlignment;
            myTarget.SavedSettings[StringLibrary.ALIGN_BY_GEOMETRY] = myTarget.overrides.SaveAlighnByGeometry;
            myTarget.SavedSettings[StringLibrary.HORIZONTAL_OVERFLOW] = myTarget.overrides.SaveHorizontalOverflow;
            myTarget.SavedSettings[StringLibrary.VERTICAL_OVERFLOW] = myTarget.overrides.SaveVerticalOVerflow;
            myTarget.SavedSettings[StringLibrary.BEST_FIT] = myTarget.overrides.SaveBestFit;
            myTarget.SavedSettings[StringLibrary.TEXT_MIN] = myTarget.overrides.SaveMinText;
            myTarget.SavedSettings[StringLibrary.TEXT_MAX] = myTarget.overrides.SaveMinText;
            myTarget.SavedSettings[StringLibrary.COLOR] = myTarget.overrides.SaveColor;
            myTarget.SavedSettings[StringLibrary.MATERIAL] = myTarget.overrides.SaveMaterial;
            myTarget.SavedSettings[StringLibrary.RAYCAST] = myTarget.overrides.SaveRaycaset;
        }

        private void StartSection(int indent = 1)
        {
            GUILayout.BeginHorizontal();
            EditorGUI.indentLevel = indent;
            EditorGUIUtility.labelWidth = startLabelWidth;
            EditorGUIUtility.fieldWidth = startFieldWidth;
        }
        private void MiddleSection(int indent = 0)
        {
            EditorGUI.indentLevel = indent;
            EditorGUIUtility.labelWidth = endLabelWidth;
            EditorGUIUtility.fieldWidth = endFieldWidth;
        }
        private void EndSction()
        {
            EditorGUILayout.EndHorizontal();
        }
    }
}