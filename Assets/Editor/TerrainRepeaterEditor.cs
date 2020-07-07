using UnityEditor;
using UnityEngine;

namespace Editor {
[CustomEditor(typeof(TerrainRepeater))]
public class TerrainRepeaterEditor : UnityEditor.Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate")) {
            Cleanup();
            GenTerrain();
        } else if (GUILayout.Button("Destroy All")) {
            Cleanup();
        } else if (GUI.changed && !Application.isPlaying) {
            Debug.Log("Changed !");
            Cleanup();
            GenTerrain();
        }
    }

    void GenTerrain() {
        var terrain = target as TerrainRepeater;
        for (var i = 0; i < terrain.repeatCount; i++) {
            Instantiate(terrain.prefabTerrain, terrain.transform.position + terrain.offset * i,
                        Quaternion.identity, terrain.transform);
        }
    }

    void Cleanup() {
        var terrain = target as TerrainRepeater;
        while (terrain.transform.childCount > 0) {
            DestroyImmediate(terrain.transform.GetChild(0).gameObject);
        }
    }
}
}
