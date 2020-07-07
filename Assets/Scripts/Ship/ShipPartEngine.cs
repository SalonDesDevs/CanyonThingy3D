using DefaultNamespace;
using UnityEngine;

public class ShipPartEngine : ShipPart {
    public int power;

    public override int VelocityModifier => power - (maxHealth - health) / health;
}
