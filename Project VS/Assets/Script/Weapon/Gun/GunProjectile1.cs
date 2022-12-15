using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile1 : WeaponBase
{
    void Update()
    {
        MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ProjectileBorder") Destroy(this.gameObject);
    }

    private void MoveProjectile()
    {
        transform.Translate(new Vector2(0, Time.deltaTime * velocity));
    }
}
