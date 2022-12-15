using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{
    [SerializeField] Transform player;
    [SerializeField] Sprite[] sprite;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        TracePlayer();
    }

    void TracePlayer()
    {
        Vector2 dir;
        dir = (player.position - transform.position).normalized;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90), Time.deltaTime * 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBorder") Destroy(this.gameObject);
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            WeaponBase projectile = collision.gameObject.GetComponent<WeaponBase>();
            OnHit((int)projectile.GetDamage());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.GetIsHit() && player.GetBooster()) OnHit(player.GetATKPower());
        }

    }

    void OnHit(int damage)
    {
        spriteRenderer.sprite = sprite[1];
        if(health <= damage)
        {
            health = 0;
            isDie = true;
            Destroy(this.gameObject);
        }
        else health -= damage;

        Invoke("OffHit", 0.1f);
    }

    void OffHit()
    {
        spriteRenderer.sprite = sprite[0];
    }
}
