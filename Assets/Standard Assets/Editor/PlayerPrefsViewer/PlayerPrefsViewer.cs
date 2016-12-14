using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public enum PlayerPrefsValueType
{
    INT = 1,
    FLOAT = 2,
    STRING = 3
}

public class PlayerPrefsViewer : EditorWindow
{
    [MenuItem("Window/PlayerPrefsViewer")]
    public static void OpenEditor()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(PlayerPrefsViewer));
        window.minSize = new Vector2(200, 200);
        window.Show();
    }

    string keyStr = string.Empty;
    PlayerPrefsValueType type;
    int intValue;
    float floatValue;
    string strValue;

    void RememberLastInput(string key)
    {
        PlayerPrefs.SetString("PlayerPrefsViewer_Last_Input", key);
    }

    void OnGUI()
    {
        if (string.IsNullOrEmpty(keyStr))
        {
            keyStr = PlayerPrefs.GetString("PlayerPrefsViewer_Last_Input");
        }

        keyStr = EditorGUILayout.TextField("Key", keyStr);
        type = (PlayerPrefsValueType)EditorGUILayout.EnumPopup("Value Type", type);
        if (PlayerPrefs.HasKey(keyStr))
        {
            switch (type)
            {
                case PlayerPrefsValueType.INT:
                    intValue = EditorGUILayout.IntField("Value", intValue);
                    if (GUILayout.Button("Get"))
                    {
                        intValue = PlayerPrefs.GetInt(keyStr);
                        RememberLastInput(keyStr);
                    }
                    if (GUILayout.Button("Set"))
                    {
                        PlayerPrefs.SetInt(keyStr, intValue);
                        RememberLastInput(keyStr);
                    }
                    break;
                case PlayerPrefsValueType.FLOAT:
                    floatValue = EditorGUILayout.FloatField("Value", floatValue);
                    if (GUILayout.Button("Get"))
                    {
                        floatValue = PlayerPrefs.GetFloat(keyStr);
                        RememberLastInput(keyStr);
                    }
                    if (GUILayout.Button("Set"))
                    {
                        PlayerPrefs.SetFloat(keyStr, floatValue);
                        RememberLastInput(keyStr);
                    }
                    break;
                case PlayerPrefsValueType.STRING:
                    strValue = EditorGUILayout.TextField("Value", strValue);
                    if (GUILayout.Button("Get"))
                    {
                        strValue = PlayerPrefs.GetString(keyStr);
                        RememberLastInput(keyStr);
                    }
                    if (GUILayout.Button("Set"))
                    {
                        PlayerPrefs.SetString(keyStr, strValue);
                        RememberLastInput(keyStr);
                    }
                    break;
            }
            if (GUILayout.Button("Delete"))
            {
                PlayerPrefs.DeleteKey(keyStr);
                RememberLastInput(keyStr);
            }
        }
        else
        {
            switch (type)
            {
                case PlayerPrefsValueType.INT:
                    intValue = EditorGUILayout.IntField("Value", intValue);
                    if (GUILayout.Button("Add & Set"))
                    {
                        PlayerPrefs.SetInt(keyStr, intValue);
                        RememberLastInput(keyStr);
                    }
                    break;
                case PlayerPrefsValueType.FLOAT:
                    floatValue = EditorGUILayout.FloatField("Value", floatValue);
                    if (GUILayout.Button("Add & Set"))
                    {
                        PlayerPrefs.SetFloat(keyStr, floatValue);
                        RememberLastInput(keyStr);
                    }
                    break;
                case PlayerPrefsValueType.STRING:
                    strValue = EditorGUILayout.TextField("Value", strValue);
                    if (GUILayout.Button("Add & Set"))
                    {
                        PlayerPrefs.SetString(keyStr, strValue);
                        RememberLastInput(keyStr);
                    }
                    break;
            }
        }
    }
}
