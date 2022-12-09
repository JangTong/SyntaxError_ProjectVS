using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Player plComp;
    [SerializeField] protected float damage;
    [SerializeField] protected float velocity;
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected float projectileSize;

    public float GetDamage() { return damage; }
    public void SetDamage(float damage) { this.damage = damage;}
    public float GetVelocity() { return velocity; }
    public void SetVelocity(float velocity) { this.velocity = velocity;}
    public float GetRate() { return rateOfFire; }
    public void SetRate(float rate) { this.rateOfFire = rate;}

    private void Awake()
    {
        player = gameObject;
        plComp = player.GetComponent<Player>();
    }
}
