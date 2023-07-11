using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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
        "*.gitignore",
    };



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
    public void Init()
    {
        string[] commands = { "git init" };
        Run(commands);
        SetBaseExcludes();
    }
    public void SetBaseExcludes()
    {
        using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\.gitignore"))
        {
            foreach (string exclude in _excludes)
            {
                sw.WriteLine(exclude);
            }
        }
    }
    public void AddAll()
    {
        string[] commands = { "git add ." };
        Run(commands);
    }

    public void Commit(String message)
    {
        string[] commands = { $"git commit -m \"{ message }\"" };
        Run(commands);
    }
}
