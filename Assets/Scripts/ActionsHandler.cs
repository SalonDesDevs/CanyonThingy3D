using System;
using UnityEngine;
using DefaultNamespace;

public class ActionsHandler : MonoBehaviour {
    public Player player;
    public ShipManager playerShip;
    private PowerInstantiating pi;

    void Start() {
        GameObject sys = GameObject.FindGameObjectWithTag("GameController"); // get the System object
        pi = sys.GetComponent<PowerInstantiating>();
        playerShip = player.GetComponent<ShipManager>();
    }

    private void DoAction(uint cost, Action a) {
        if (player.energy >= cost) {
            a();
            player.energy -= cost;
        }
    }

    public void DoRepair() {
        DoAction(MagicValues.RepairCost, () => { player.Repair(MagicValues.RepairPower); });
    }

    public void DoObstacle() {
        Debug.Log("doObstacle");
        DoAction(MagicValues.ObstacleCost, () => { pi.SpawnSpikes(player.side.otherSide()); });
    }

    public void DoUpgradeShield() {
        if (playerShip.ShieldLevel < playerShip.MaxShieldLevel) {
            DoAction(MagicValues.ShieldCost, () => { playerShip.ShieldLevel += 1; });
        }
    }

    public void DoMissile() {
        DoAction(MagicValues.MissileCost, () => {
            // TODO
        });
    }

    public void DoSkyAttack() {
        DoAction(MagicValues.SkyAttackCost, () => {
            // TODO
        });
    }

    public void DoUpgradeEngine() {
        if (playerShip.EngineLevel < playerShip.MaxEngineLevel) {
            DoAction(MagicValues.UpgradeCost, () => {
                playerShip.EngineLevel += 1;
                playerShip.engines[playerShip.EngineLevel - 1].power = 100;
            });
        }
    }
}
