using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Settings))]
public class SettingsInspector : Editor
{
    private SerializedProperty Health;

}
