using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsPanelUpdater : MonoBehaviour {
    public Player player;

    public GameObject panel;

    void Start() {
        panel.SetActive(false);
    }

    void Update() {
        panel.SetActive(player.CanPlay);
    }
}
