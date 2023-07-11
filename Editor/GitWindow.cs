using System;
using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;

public class GitWindow : EditorWindow
{
    // GIT WORK VARIABLES
    private string commitText = "";
    private bool amend = false;

    
    // STANDART METHODS
    [MenuItem("Tools/Git Editor")]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(GitWindow));
    }
    private void OnGUI()
    {
        if (GitController.Instance.Exists())
        {
            AreaIndexing();
            AreaPush();
            AreaCommit();
        }
        else
        {
            AreaInit();
        }
    }


    // VIEW METHOD
    private void AreaInit()
    {
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
    private void AreaCommit()
    {
        GUILayout.Label("Commit Area", GUILayout.Height(50));
        GUILayout.Space(10);
        commitText = GUILayout.TextField(commitText, GUILayout.Height(50));
        GUILayout.Space(10);
        amend = GUILayout.Toggle(amend, "Amend");
        GUILayout.Space(10);
        if (GUILayout.Button("Commit", GUILayout.Height(50)))
        {
            if (commitText.Length > 0)
            {
                GitController.Instance.Commit(commitText);
                commitText = "";
                amend = false;
            }
        }
    }
    private void AreaPush()
    {
        GUILayout.Label("Push Area", GUILayout.Height(50));
        GUILayout.Space(10);
        if (GUILayout.Button("Push Origin", GUILayout.Height(50)))
        {
            GitController.Instance.Push("origin", "master");
        }
    }
    private void AreaIndexing()
    {
        GUILayout.Label("Indexing Area", GUILayout.Height(50));
        GUILayout.Space(10);
        if (GUILayout.Button("Add All Files", GUILayout.Height(50)))
        {
            GitController.Instance.AddAll();
        }
    }
}