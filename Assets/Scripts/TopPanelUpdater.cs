using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class TopPanelUpdater : MonoBehaviour {
    public Player playerA, playerB;

    public Slider progressA, progressB;

    // Start is called before the first frame update
    void Start() {
        progressA.value = 0;
        progressB.value = 0;
    }

    // Update is called once per frame
    void Update() {
        progressA.value = Math.Min(1.0f, (float)playerA.distanceDone/(float)MagicValues.ObjectiveDist);
        progressB.value = Math.Min(1.0f, (float)playerB.distanceDone/(float)MagicValues.ObjectiveDist);
    }
}
