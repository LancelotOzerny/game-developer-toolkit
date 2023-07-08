using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Diagnostics;

public class GitController : MonoBehaviour
{
    [MenuItem("Tools/Git/Init")]
    public static void Init()
    {

    }

    [MenuItem("Tools/Git/Add")]
    public static void Add()
    {

    }

    [MenuItem("Tools/Git/Open Folder")]
    public static void OpenFolder()
    {

    }

    [MenuItem("Tools/Git/Rollback")]
    public static void Rollback()
    {

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

    string[] excludes = {
        "/[Ll]ibrary /",
        "/[Tt]emp /",
        "/[Oo]bj /",
        "/[Bb]uild /",
        "/[Bb]uilds /",
        "/[Ll]ogs /",
        "/[Uu]ser[Ss]ettings /",
        "/[Mm]emoryCaptures /",
        "!/[Aa]ssets/**/*.meta",
        "/[Aa]ssets / Plugins / Editor / JetBrains *",
        ".vs /",
        ".gradle /",
        "ExportedObj /",
        ".consulo /",
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
        "crashlytics - build.properties",
        "/[Aa]ssets /[Aa]ddressable[Aa]ssets[Dd]ata/*/*.bin*",
        "/[Aa]ssets/[Ss]treamingAssets/aa.meta",
        "/[Aa]ssets/[Ss]treamingAssets/aa/*",
        "!*.dll",
        "!*.obj",
    };
}