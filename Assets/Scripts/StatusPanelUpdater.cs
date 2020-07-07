using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Met à jour la barre de statut d'un joueur.
 * Quand c'est au joueur de gauche de jouer, ses infos
 * sont affichées à droite. Et vice-versa.
 */
public class StatusPanelUpdater : MonoBehaviour
{
    public Player player;

    public Text lifeTxt, energyTxt, speedTxt;

    public GameObject panel;

    void Start() {
        lifeTxt.text = "?";
        energyTxt.text = "?";
        speedTxt.text = "?";
        panel.SetActive(false);
    }

    void Update() {
        lifeTxt.text = $"{player.TotalHealth.ToString()}/{player.TotalMaxHealth.ToString()}";
        energyTxt.text = player.energy.ToString();
        speedTxt.text = player.Speed.ToString();
        panel.SetActive(player.CanPlay);
    }
}
