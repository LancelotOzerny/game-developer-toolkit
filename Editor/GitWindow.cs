using UnityEditor;
using UnityEngine;

namespace Lancy
{
    public class GitWindow : EditorWindow
    {
        private GitView _view = new GitView();
        private GUIContent[] _tabs = {
            new GUIContent("Commits"),
            new GUIContent("Branches"),
            new GUIContent("Remote"),
        };
        private int _currentTab = 0;

        [MenuItem("Tools/Git Editor")]
        public static void Show()
        {
            EditorWindow.GetWindow(typeof(GitWindow));
        }

        string commitText = "";
        bool isAmend = false;

        private void OnGUI()
        {
            // Repository is exist
            if (GitController.Instance.Exists() == false)
            {
                if (_view.Init()) GitController.Instance.Init();
                return;
            }

            // Repository is not exist
            _currentTab = GUILayout.Toolbar(_currentTab, _tabs);
            switch(_tabs[_currentTab].text.ToLower())
            {
                case "commits":
                    if (_view.Commit(ref commitText, ref isAmend))
                    {
                        if (commitText == string.Empty)
                        {
                            Debug.LogWarning("Enter commit message");
                            return;
                        }

                        if (isAmend)
                        {
                            GitController.Instance.Amend(commitText);
                            isAmend = false;
                            return;
                        }

                        GitController.Instance.Commit(commitText);
                        commitText = string.Empty;
                    }
                    break;
            }
        }
    }

    public class GitView
    {
        public bool Init()
        {
            return GUILayout.Button("Инициализировать репозиторий", GUILayout.Height(50 ));
        }

        public bool Commit(ref string commitText, ref bool amend)
        {
            GUILayout.Label("Commit Area", GUILayout.Height(50));
            commitText = GUILayout.TextArea(commitText, GUILayout.Height(100));
            amend = GUILayout.Toggle(amend, "Amend", GUILayout.Height(50));
            return GUILayout.Button("Commit", GUILayout.Height(50));
        }
    }
}

public class GitWindow : EditorWindow
{
    // STANDART METHODS
    [MenuItem("Tools/Old Git Editor")]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(GitWindow));
    }

    private void OnGUI()
    {
        AreaIndexing();
        AreaPush();
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