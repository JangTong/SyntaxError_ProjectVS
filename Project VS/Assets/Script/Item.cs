using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 15) Destroy(gameObject);
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int afterHp = Player.Instance.GetHealth() + 10;
            if(afterHp > Player.Instance.GetMaxHealth()) Player.Instance.SetHealth(Player.Instance.GetMaxHealth());
            else Player.Instance.SetHealth(afterHp);
            Destroy(gameObject);
        }
    }
}
