using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRepeater : MonoBehaviour {
    public Transform player;
    public GameObject prefabTerrain;
    public Vector3 offset;
    [Range(0, 100)] public uint repeatCount;
    [Range(0.0f, 1000.0f)] public float deactivateRange;

    List<GameObject> chunks;

    void Start() {
        chunks = new List<GameObject>();
        for (var i = 0; i < transform.childCount; i++) {
            chunks.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update() {
        foreach (GameObject chunk in chunks) {
            if (Vector3.Distance(player.transform.position, chunk.transform.position) <= deactivateRange) {
                if (!chunk.activeSelf) {
                    chunk.SetActive(true);
                }
            } else if (chunk.activeSelf) {
                chunk.SetActive(false);
            }
        }
    }

    void OnDrawGizmos() {
        if (player == null) return;
        Gizmos.DrawWireSphere(player.position, deactivateRange);
    }
}
