using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Diagnostics;
using System;
using System.IO;
using Unity.VisualScripting;

public class GitController : MonoBehaviour
{
    private static void Run(string[] commands)
    {
        foreach (string command in commands)
        {
            Debug.Log(command);
            System.Diagnostics.Process.Start("cmd.exe", "/C" + command);
        }
    }

    [MenuItem("Tools/Git/Init")]
    public static void Init()
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
    public static void Add()
    {
        string[] commands = { "git add ." };
        Run(commands);
    }

    [MenuItem("Tools/Git/Open Folder")]
    public static void OpenFolder()
    {

        string[] commands = { "start .git" };
        Run(commands);
    }

    [MenuItem("Tools/Git/Rollback")]
    public static void Rollback()
    {
        string[] commands = { "git reset --hard" };
        Run(commands);
    }

    [MenuItem("Tools/Git/Status")]
    public static void Status()
    {
     
    }

    [MenuItem("Tools/Git/Shortlog 10")]
    public static void Shortlog10()
    {

    }

    [MenuItem("Tools/Git/Shortlog 20")]
    public static void Shortlog20()
    {

    }

    private static string[] _excludes = {
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