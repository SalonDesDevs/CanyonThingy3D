using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerInstantiating : MonoBehaviour {
    public Transform leftPlayer;
    public Transform rightPlayer;

    public GameObject prefabSpikes;

    public Vector3[] forwardSpawnOffsets;

    public void SpawnSpikes(PlayerSide side) {
        var player = side == PlayerSide.Left ? leftPlayer : rightPlayer;
        Vector3 targetPos = player.transform.position;
        targetPos += forwardSpawnOffsets[Random.Range(0, forwardSpawnOffsets.Length)];

        GameObject spike = Instantiate(prefabSpikes, targetPos, Quaternion.identity);
        spike.GetComponent<Spike>().player = player;
    }

    void Update() {
        /*
        if (Input.GetButtonDown("Jump")) {
            SpawnSpikes(PlayerSide.Left);
            //SpawnSpikes(PlayerSide.Right);
        }*/
    }

    void OnDrawGizmos() {
        if (leftPlayer == null || rightPlayer == null || prefabSpikes == null) {
            return;
        }

        Gizmos.color = Color.green;
        Vector3 origin = leftPlayer.position;
        Vector3 right = leftPlayer.right;
        Vector3 forward = leftPlayer.forward;
        foreach (Vector3 offset in forwardSpawnOffsets) {
            Gizmos.DrawLine(origin + offset - right, origin + offset + right);
            Gizmos.DrawLine(origin + offset + forward, origin + offset - forward);
        }
    }
}