using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GitWindow : EditorWindow
{
    [MenuItem("Tools/Git Editor")]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(GitWindow));
    }


    string _commitMessage = $"Changes {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}";
    bool _amend = false;
    private void OnGUI()
    {
        // COMMIT
        GUILayout.BeginVertical();
        GUILayout.Label("Git Commit");
        _commitMessage = EditorGUILayout.TextArea(_commitMessage, GUILayout.MinHeight(50), GUILayout.MaxHeight(150));
        
        GUILayout.Space(20);
        
        _amend = EditorGUILayout.Toggle("Amend", _amend);
        GUILayout.EndVertical();

        // coMMIT BUTTON
        GUILayout.Space(20);
        if (GUILayout.Button("Commit", GUILayout.Height(50)))
        {
            Debug.Log("Yes");
        }
    }
}
