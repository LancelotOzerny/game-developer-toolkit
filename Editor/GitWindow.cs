using System;
using System.IO;

using UnityEditor;
using UnityEngine;

public class GitWindow : EditorWindow
{
    private string commitText = "";



    [MenuItem("Tools/Git Editor")]
    public static void Show()
    {
        EditorWindow.GetWindow(typeof(GitWindow));
    }


    string _commitMessage = $"Changes {DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}";
    bool _amend = false;
    
    private void OnGUI()
    {
        if (GitController.Instance.Exists())
        {
            InitView();
        }
    }


    private void InitView()
    {
        if (commitText == string.Empty) commitText = "Начало проекта. Подготовил необходимые для проекта ресурсы.";

        GUILayout.Space(10);
        GUILayout.Label("Commit Message");
        GUILayout.Space(10);
        commitText = GUILayout.TextField(commitText, GUILayout.Height(100));
        GUILayout.Space(10);
        if (GUILayout.Button("Git initialize", GUILayout.Height(50)))
        {
            GitController.Instance.Init();
        }
    }
}

public class GitController
{
    private static GitController instance = null;
    public static GitController Instance 
    {
        get
        {
            if (instance == null) instance = new GitController(); 
            return instance;
        } 
    }
    
    public bool Exists()
    {
        return Directory.Exists(Directory.GetCurrentDirectory() + "/.git");
    }

    private void Run(string[] commands)
    {
        foreach (string command in commands)
        {
            Debug.Log(command);
            System.Diagnostics.Process.Start("cmd.exe", "/C" + command);
        }
    }

    [MenuItem("Tools/Git/Init")]
    public void Init()
    {
        string[] commands = { "git init" };
        Run(commands);

        using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\.git\\info\\exclude"))
        {
            foreach (string exclude in _excludes)
            {
                sw.WriteLine(exclude);
            }
        }
    }

    [MenuItem("Tools/Git/Add")]
    public void Add()
    {
        string[] commands = { "git add ." };
        Run(commands);
    }

    [MenuItem("Tools/Git/Open Folder")]
    public void OpenFolder()
    {

        string[] commands = { "start .git" };
        Run(commands);
    }

    [MenuItem("Tools/Git/Rollback")]
    public void Rollback()
    {
        string[] commands = { "git reset --hard" };
        Run(commands);
    }

    private string[] _excludes = {
        "/[Ll]ibrary/",
        "/[Tt]emp/",
        "/[Oo]bj/",
        "/[Bb]uild/",
        "/[Bb]uilds/",
        "/[Ll]ogs/",
        "/[Uu]ser[Ss]ettings/",
        "/[Mm]emoryCaptures/",
        "!/[Aa]ssets/**/*.meta",
        "/[Aa]ssets/Plugins/Editor/JetBrains*",
        ".vs/",
        ".gradle/",
        "ExportedObj/",
        ".consulo/",
        "*.csproj",
        "*.unityproj",
        "*.sln",
        "*.suo",
        "*.tmp",
        "*.user",
        "*.userprefs",
        "*.pidb",
        "*.booproj",
        "*.svd",
        "*.pdb",
        "*.mdb",
        "*.opendb",
        "*.apk",
        "*.unitypackage",
        "*.VC.db",
        "*.pidb.meta",
        "*.pdb.meta",
        "*.mdb.meta",
        "sysinfo.txt",
        "/[Aa]ssets/[Aa]ddressable[Aa]ssets[Dd]ata/*/*.bin*",
        "/[Aa]ssets/[Ss]treamingAssets/aa.meta",
        "/[Aa]ssets/[Ss]treamingAssets/aa/*",
        "!*.dll",
        "!*.obj",
    };
}
