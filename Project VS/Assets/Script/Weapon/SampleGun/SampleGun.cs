using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGun : WeaponBase
{
    void Start()
    {
        StartCoroutine(FireCorou());
    }

    void Update()
    {
        damage = plComp.GetATKPower();
    }

    void Fire()
    {
        GameObject bullet = Instantiate(projectile, player.transform.position, player.transform.rotation);
        SampleGunProjectile sgbullet = bullet.GetComponent<SampleGunProjectile>();
        sgbullet.SetDamage(damage);
        sgbullet.SetVelocity(velocity);
    }

    IEnumerator FireCorou()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            Fire();
        }
    }
}
