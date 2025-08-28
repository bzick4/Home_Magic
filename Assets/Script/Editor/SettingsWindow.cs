using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class SettingsWindow : EditorWindow
{

    private string[] _settingsList;
    private bool _isButtonPress;


    [MenuItem("Window/Game Settings Window")]
        public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        _settingsList = AssetDatabase.FindAssets("t:settings");
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);
        foreach (var file in _settingsList)
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(file), EditorStyles.label);
        }
        _isButtonPress = GUILayout.Button("Health");

        if (_isButtonPress)
        {
            foreach (var file in _settingsList)
            {
                var _settingsFile = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(file));
                _settingsFile._HeroHealth += 12;
            }
            AssetDatabase.SaveAssets();
        }

           
    }
}
