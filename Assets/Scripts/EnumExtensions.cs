using System;

public static class EnumExtensions {
    public static PlayerSide otherSide(this PlayerSide side) {
        switch (side) {
            case PlayerSide.Left: return PlayerSide.Right;
            case PlayerSide.Right: return PlayerSide.Left;
            default: throw new Exception("wtf");
        }
    }
}