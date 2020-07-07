using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrayedUpdater : MonoBehaviour {
    public Player player;

    public GameObject panel;

    void Start() {
        panel.SetActive(true);
    }

    void Update() {
        panel.SetActive(!player.CanPlay);
    }
}
