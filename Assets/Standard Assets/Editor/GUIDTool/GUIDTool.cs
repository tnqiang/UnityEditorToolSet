using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GUIDTool : EditorWindow 
{
    string strContent;
    string findResult;

    [MenuItem("Tools/GUIDTools/OpenWindow")]
    public static void OpenGUIDWindow()
    {
        GUIDTool wnd = (GUIDTool)EditorWindow.GetWindow(typeof(GUIDTool));
        wnd.titleContent = new GUIContent("GUID Window");
        wnd.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("GUID:", new GUILayoutOption[] { GUILayout.Width(40) });
        strContent = GUILayout.TextField(strContent);
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Get & Ping"))
        {
            string path = AssetDatabase.GUIDToAssetPath(strContent);
            Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);
            if (obj != null)
            {
                EditorGUIUtility.PingObject(obj);
                findResult = string.Empty;
            }
            else
            {
                findResult = string.Format("The specified GUID {0} NOT find", strContent);
            }
        }
        if (!string.IsNullOrEmpty(findResult))
        {
            GUIStyle errorStyle = new GUIStyle(EditorStyles.textField);
            errorStyle.normal.textColor = Color.red;
            GUILayout.Label(findResult,errorStyle);
        }
    }

    [MenuItem("Tools/GUIDTools/GetGUID")]
    public static void DisplayGUID()
    {
        Object obj = Selection.activeObject;
        if (obj != null)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            string guid = AssetDatabase.AssetPathToGUID(path);

            EditorUtility.DisplayDialog("GUID", guid, "OK");
        }
    }
}
