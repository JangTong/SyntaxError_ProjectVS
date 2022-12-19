using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    int direction;
    public int playerLev;
    public int maxExp;
    public int exp;
    public bool levelup;
    public bool isRandom;
    [SerializeField]bool isHit;
    bool onBooster;
    int boosterCoolTime;
    static Player instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

        base.Awake();

        direction = 0;
        playerLev = 1;
        maxExp = 15;
        exp = 0;
        levelup = false;
        isRandom = false;
        isHit = false;
        onBooster = false;
        boosterCoolTime = 5;
    }

    void Update()
    {
        MovePlayer();
        levelUp();
    }

    public static Player Instance
    {
        get
        {
            if (instance != null) return instance;
            return null;
        }
    }

    private void MovePlayer()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(inputX, inputY);

        if (Input.GetKeyDown(KeyCode.Space) && !onBooster) StartCoroutine(Booster());
        else if (inputX == 0)
        {
            if (inputY == 1) direction = 0;
            else if (inputY == -1) direction = 180;
        }
        else if (inputX == -1)
        {
            if (inputY == 1) direction = 45;
            else if (inputY == 0) direction = 90;
            else if (inputY == -1) direction = 135;
        }
        else if (inputX == 1)
        {
            if (inputY == 1) direction = 315;
            else if (inputY == 0) direction = 270;
            else if (inputY == -1) direction = 225;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, direction), Time.deltaTime * 10);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
    }

    private void levelUp()
    {
        if (exp >= maxExp)
        {
            playerLev += 1;
            if (playerLev < 6) maxExp = 10 * playerLev;
            else maxExp = (int)(75 * Mathf.Pow(1.3f, (playerLev - 5)));
            exp = 0;
            levelup = true;
            isRandom = true;

            GameManager.Instance.PauseGame();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            OnHit(enemy.GetATKPower());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            OnHit(enemy.GetATKPower());
        }
    }

    public void OnHit(int damage)
    {
        if (health <= damage && !isHit)
        {
            health = 0;
            isDie = true;
            isHit = true;
            gameObject.SetActive(false);
        }
        else if (!isHit)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            isHit = true;
            health -= damage;
            StartCoroutine(OffHit());
        }
    }
    IEnumerator OffHit()
    {
        yield return new WaitForSeconds(0.2f);
        isHit = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Booster()
    {
        //booster on
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        onBooster = true;
        moveSpeed *= 5;
        isHit = true;
        yield return new WaitForSeconds(0.2f);

        //booster off and cooling time start
        spriteRenderer.color = new Color(1, 1, 1, 1);
        moveSpeed /= 5;
        isHit = false;
        yield return new WaitForSeconds(boosterCoolTime);
        onBooster = false;
    }

    public bool GetBooster() { return onBooster; }
    public void SetBooster(bool onBooster) { this.onBooster = onBooster; }
    public int GetBoosterCoolTime() { return boosterCoolTime; }
    public void SetBoosterCoolTime(int boosterCoolTime) { this.boosterCoolTime = boosterCoolTime; }
    public bool GetIsHit() { return isHit; }
    public void SetIsHit(bool isHit) { this.isHit = isHit; }
}
