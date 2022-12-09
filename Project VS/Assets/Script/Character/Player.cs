using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    int direction = 0;
    int level = 1;
    bool isHit = false;
    bool onBooster = false;

    private void Start()
    {
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");
        Vector2 dir= new Vector2(inputX, inputY);

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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
            StartCoroutine(OffHit());
            Destroy(this.gameObject); //None Objectpolling
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
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        onBooster = true;
        moveSpeed *= 5;
        isHit = true;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        moveSpeed /= 5;
        isHit = false;
        yield return new WaitForSeconds(5);
        onBooster = false;
    }

    public bool GetBooster() { return onBooster; }
}
