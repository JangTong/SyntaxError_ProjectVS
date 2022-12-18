using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] GameObject[] enemyCarrier;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] GameObject item;

    enum State { walk, strike, shot, spawn};
    State state = State.walk;
    
    Vector2 dir;
    bool onStrike = false;
    void Start()
    {
        base.Start();
        StartCoroutine(BossPatern());
    }

    void Update()
    {
        if (state != State.strike) base.Update();
        else
        {
            if (!onStrike)
            {
                onStrike = true;
            }
            EnemyStrike();
        }
    }

    IEnumerator BossPatern()
    {
        while (true)
        {
            state= State.strike;
            moveSpeed *= 8;
            for (int i = 0; i < 3; i++)
            {
                dir = (player.position - transform.position).normalized;
                yield return new WaitForSeconds(1f);
            }

            state = State.walk;
            moveSpeed /= 8;
            onStrike = false;
            yield return new WaitForSeconds(3f);
            DropItems();
            yield return new WaitForSeconds(3f);

            state = State.shot;
            for (int i = 0; i < 5; i++)
            {
                EnemyShot();
                yield return new WaitForSeconds(1f);
            }

            state = State.spawn;
            for (int i = 0; i < 2; i++)
            {
                EnemyLaunch();
                yield return new WaitForSeconds(3f);
            }
        }
    }

    void EnemyStrike()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90);
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    void EnemyLaunch()
    {
        GameObject instance_1 = Instantiate(enemyCarrier[Random.Range(0, enemyCarrier.Length)], transform.position + new Vector3(1 * Mathf.Cos((transform.rotation.eulerAngles.z) * Mathf.Deg2Rad), 1 * Mathf.Sin((transform.rotation.eulerAngles.z) * Mathf.Deg2Rad), 0), transform.rotation);
        GameObject instance_2 = Instantiate(enemyCarrier[Random.Range(0, enemyCarrier.Length)], transform.position + new Vector3(1 * Mathf.Cos((transform.rotation.eulerAngles.z - 180) * Mathf.Deg2Rad), 1 * Mathf.Sin((transform.rotation.eulerAngles.z - 180) * Mathf.Deg2Rad), 0), transform.rotation);
    }

    void EnemyShot()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject bullet = Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, i * 20)));
        }
    }
    void DropItems()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(item, gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, i * 30)));
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
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
        GameManager.Instance.gameScore += enemyScore;
        SoundManager.Instance.HitSound();
        GameManager.Instance.isClear = true;
        Destroy(this.gameObject);
    }
}
