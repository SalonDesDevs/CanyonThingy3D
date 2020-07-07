using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(ShipManager))]
public class Player : MonoBehaviour {
    public PlayerSide side;
    public int distanceDone = 0;
    public uint energy = 0;
    private float nextUpdate = -1;
    public uint timeAlive;

    [HideInInspector] public List<ShipPart> parts;
    [HideInInspector]
    public ShipManager shipManager;

    public int Speed => TotalHealth <= 0 ? 0 : parts.Select(part => part.VelocityModifier).Sum();

    public int TotalHealth => parts.Select(part => part.health).Sum();

    public int TotalMaxHealth => parts.Select(part => part.maxHealth).Sum();

    public bool CanPlay { get; private set; } = false;

    public bool CanPlayDelayed { get; private set; } = false;

    public bool IsArrived => distanceDone >= MagicValues.ObjectiveDist;

    void Start() {
        parts = new List<ShipPart>(GetComponentsInChildren<ShipPart>());
        shipManager = GetComponent<ShipManager>();
        
        nextUpdate = Time.time + (side == PlayerSide.Left ? 3 : 13);
        timeAlive = 0;
    }

    void Update() {
        var time = Time.time;
        if (time < nextUpdate || TotalHealth <= 0) {
            return;
        }

        nextUpdate = time + 1; // 1s interval
        parts = new List<ShipPart>(GetComponentsInChildren<ShipPart>());

        if (timeAlive % 10 == 0) {
            // switch player
            CanPlay = !CanPlay;
            parts.RemoveAll(part => part is ShipPartShield); // reset shield
        } else {
            // play for 1 second
            energy = Math.Min(energy + 1, MagicValues.MaxEnergy);
            distanceDone += Speed;
        }

        timeAlive++;
    }

    public void Damage(int amount, bool fromBack) {
        if (shipManager.ShieldLevel > 0) {
            shipManager.shields[shipManager.ShieldLevel - 1].health -= amount;
        } else if (shipManager.ArmorLevel > 0) {
            shipManager.armors[shipManager.ArmorLevel - 1].health -= amount;
        } else if (fromBack && shipManager.EngineLevel > 1) {
            shipManager.engines[shipManager.EngineLevel].health -= amount;
        } else if (!fromBack && shipManager.WeaponLevel > 0) {
            shipManager.weapons[shipManager.WeaponLevel - 1].health -= amount;
        } else {
            shipManager.core.health -= amount;
        }
    }

    public void Repair(int amount) {
        int rem = amount;

        // Heal core
        
        int coreToHeal = shipManager.core.LostHealth;
        shipManager.core.health += Math.Min(rem, coreToHeal);
        rem -= coreToHeal;

        if (rem <= 0) return;

        // Heal engines
        
        for (var i = 0; i < shipManager.EngineLevel && rem > 0; i++) {
            int engineToHeal = shipManager.engines[i].LostHealth;
            shipManager.engines[i].health += Math.Min(rem, engineToHeal);
        }
        
        if (rem <= 0) return;
        
        // Heal weapons

        for (var i = 0; i < shipManager.WeaponLevel && rem > 0; i++) {
            int weaponToHeal = shipManager.weapons[i].LostHealth;
            shipManager.weapons[i].health += Math.Min(rem, weaponToHeal);
        }
        
        if (rem <= 0) return;
        
        // Heal shields

        for (var i = 0; i < shipManager.ShieldLevel && rem > 0; i++) {
            int shieldToHeal = shipManager.shields[i].LostHealth;
            shipManager.shields[i].health += Math.Min(rem, shieldToHeal);
        }
    }
}
