using System;
using UnityEngine;
using UnityEngine.UI;

public class DeadUpdater : MonoBehaviour {
    public Player player;
    public GameObject panel;

    void Start() {
        panel.SetActive(false);
    }

    void Update() {
        if (player.TotalHealth <= 0) {
            panel.SetActive(true);
        }
    }
}