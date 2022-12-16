using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{
    [SerializeField] protected Transform player;
    [SerializeField] protected int enemyScore;
    [SerializeField] protected int dropExp;
    Color defaultColor;

    protected void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        defaultColor = spriteRenderer.color;
    }

    void Update()
    {
        TracePlayer();
    }

    protected void TracePlayer()
    {
        Vector2 dir;
        dir = (player.position - transform.position).normalized;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90), Time.deltaTime * 10);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBorder") Destroy(this.gameObject);
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            WeaponBase projectile = collision.gameObject.GetComponent<WeaponBase>();
            OnHit((int)projectile.GetDamage());
        }
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.Instance.GetIsHit() && Player.Instance.GetBooster()) OnHit(Player.Instance.GetATKPower());
        }
    }

    protected void OnHit(int damage)
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        if (health <= damage) Die();
        else health -= damage;

        Invoke("OffHit", 0.1f);
    }

    protected void OffHit()
    {
        spriteRenderer.color = defaultColor;
    }

    protected void Die()
    {
        health = 0;
        isDie = true;
        Player.Instance.exp += dropExp;
        GameManager.Instance.gameScore += enemyScore;
        Destroy(this.gameObject);
    }
}
