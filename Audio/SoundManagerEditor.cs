#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundManager))]
public class SoundManagerEditor : Editor
{
    void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Next Song"))
        {
            SoundManager.NextSong();
        }
    }
}
#endif