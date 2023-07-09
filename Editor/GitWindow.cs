using System;
using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;

public class GitWindow : EditorWindow
{
    [MenuItem("Tools/Git Editor")]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(GitWindow));
    }



    // GIT WORK METHODS
    private string commitText = "";
    private bool amend = false;



    private void OnGUI()
    {
        if (GitController.Instance.Exists())
        {
            GUILayout.Space(10);
            if (GUILayout.Button("Add All Files", GUILayout.Height(50)))
            {
                GitController.Instance.AddAll();
            }
        }
        else
        {
            InitView();
        }
    }

    private void InitView()
    {
        if (commitText == string.Empty) commitText = "Начало проекта. Подготовил необходимые для проекта ресурсы.";
        
        GUILayout.Space(10);
        if (GUILayout.Button("Git initialize", GUILayout.Height(50)))
        {
            try
            {
                GitController.Instance.Init();
            }
            catch (Exception e)
            {
                bool check = Directory.Exists(Directory.GetCurrentDirectory() + "\\.git\\info");
                Debug.Log(check ? "True" : "False");
            }

            GitController.Instance.AddAll();
        }
    }
}