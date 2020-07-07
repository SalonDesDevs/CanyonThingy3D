using UnityEngine;

public class ShipPartWeapon : ShipPart {
    public int velocityModifier;
    public override int VelocityModifier => velocityModifier;
}
