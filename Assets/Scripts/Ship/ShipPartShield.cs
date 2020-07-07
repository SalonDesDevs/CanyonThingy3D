using UnityEngine;

public class ShipPartShield : ShipPart {
    public int velocityModifier;
    public override int VelocityModifier => velocityModifier;
}
