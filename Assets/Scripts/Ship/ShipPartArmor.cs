using UnityEngine;

public class ShipPartArmor : ShipPart {
    public int velocityModifier;
    public override int VelocityModifier => velocityModifier;
}
