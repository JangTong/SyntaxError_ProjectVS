using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int atkPower;
    [SerializeField] public bool isDie;

    protected SpriteRenderer spriteRenderer;

    public int GetATKPower() { return atkPower; }
    public void SetATKPower(int atkPower) { this.atkPower = atkPower; }
    public int GetHealth() { return health; }   
    public void SetHealth(int health) { this.health = health; }
    public int GetMaxHealth() { return maxHealth; }
    public void SetMaxHealth(int maxHealth) { this.maxHealth = maxHealth; }
    public int GetMoveSpeed() { return moveSpeed; }
    public void SetMoveSpeed(int moveSpeed) { this.moveSpeed = moveSpeed; }
    public void ResetHealth() { health = maxHealth; }


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetHealth();
    }
}
