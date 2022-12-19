using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Enemy
{
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        MoveProjectile();
    }


    private void MoveProjectile()
    {
        transform.Translate(new Vector2(0, -Time.deltaTime * moveSpeed));
    }
}
