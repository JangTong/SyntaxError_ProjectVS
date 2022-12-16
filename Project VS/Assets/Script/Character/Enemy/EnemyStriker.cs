using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStriker : Enemy
{
    Vector2 dir;

    void Start()
    {
        base.Start();
        dir = (player.position - transform.position).normalized;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90);
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
