using System;
using UnityEngine;

public class ShipManager : MonoBehaviour {
    public ShipPartCore core;
    public ShipPartEngine[] engines;
    public ShipPartWeapon[] weapons;
    public ShipPartArmor[] armors;
    public ShipPartShield[] shields;

    public void Start() {
        core.gameObject.SetActive(true);
        EngineLevel = 1;
        WeaponLevel = 1;
        ArmorLevel = 0;
        ShieldLevel = 0;
    }

    public int MaxEngineLevel => engines.Length;
    uint engineLevel;

    public uint EngineLevel {
        get => engineLevel;
        set {
            bool[] states;
            switch (value) {
                case 1:
                    states = new[] {true, false, false};
                    break;
                case 2:
                    states = new[] {false, true, true};
                    break;
                default:
                    states = new[] {true, true, true};
                    break;
            }

            for (var i = 0; i < 3; i++) {
                engines[i].gameObject.SetActive(states[i]);
            }
        }
    }

    public int MaxWeaponLevel => weapons.Length;
    uint weaponLevel;

    public uint WeaponLevel {
        get => weaponLevel;
        set {
            weaponLevel = value;
            weapons[0].gameObject.SetActive(value > 0);
            weapons[1].gameObject.SetActive(value > 1);
        }
    }

    public int MaxArmorLevel => armors.Length;
    uint armorLevel;

    public uint ArmorLevel {
        get => armorLevel;
        set {
            armorLevel = value;
            armors[0].gameObject.SetActive(value > 0);
            armors[1].gameObject.SetActive(value > 1);
        }
    }

    public int MaxShieldLevel => shields.Length;
    uint shieldLevel;

    public uint ShieldLevel {
        get => shieldLevel;
        set {
            shieldLevel = value;
            shields[0].gameObject.SetActive(value > 0);
            shields[1].gameObject.SetActive(value > 1);
        }
    }
}
