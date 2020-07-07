using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(MeshRenderer))]
public abstract class ShipPart : MonoBehaviour {
    [HideInInspector] public int health;
    public int maxHealth = 100;
    
    public int LostHealth => maxHealth - health;

    public abstract int VelocityModifier { get; }

    [HideInInspector] public MeshRenderer meshRenderer;

    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
        health = maxHealth;
    }
}
