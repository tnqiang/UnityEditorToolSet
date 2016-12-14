using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;

public class AssetPathUtil
{
    [MenuItem("Assets/CopyPath(s)")]
    public static void CopyPaths()
    {
        UnityEngine.Object[] goes = Selection.objects;
        string paths = string.Empty;

        for(int i=0; goes != null && i < goes.Length; ++i)
        {
            paths += AssetDatabase.GetAssetPath(goes[i]) + ";";
        }
        TextEditor te = new TextEditor();
        te.text = paths;
        te.OnFocus();
        te.Copy();
    }

    [MenuItem("GameObject/Copy Hierarchy", false, 0)]
    public static void CopyHierarchy()
    {
        Transform trans = Selection.activeTransform;
        string str = string.Empty;
        bool isFirst = true;
        while (trans != null)
        {
            if (!isFirst) str = "/" + str;
            str = trans.name + str;
            isFirst = false;
            trans = trans.parent;
        }
        TextEditor te = new TextEditor();
        te.text = str;
        te.OnFocus();
        te.Copy();
    }
}
