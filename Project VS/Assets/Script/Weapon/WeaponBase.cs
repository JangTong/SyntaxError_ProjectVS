using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected float damage;
    [SerializeField] protected float velocity;
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected float projectileSize;
    [SerializeField] protected int weaponLev;

    public float GetDamage() { return damage; }
    public void SetDamage(float damage) { this.damage = damage;}
    public float GetVelocity() { return velocity; }
    public void SetVelocity(float velocity) { this.velocity = velocity;}
    public float GetRate() { return rateOfFire; }
    public void SetRate(float rate) { this.rateOfFire = rate;}
    public int GetWeaponLev() { return weaponLev; }
    public void SetWeaponLev(int weaponLev) { this.weaponLev = weaponLev; }

    private void Awake()
    {
        weaponLev = 0;
    }
}
