using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    void Start()
    {
        weaponLev = 1;
        StartCoroutine(FireCorou());
    }

    void Update()
    {
        damage = Player.Instance.GetATKPower();
    }

    void Fire(float damage, float velocity)
    {
        GameObject bullet = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        GunProjectile sgbullet = bullet.GetComponent<GunProjectile>();
        sgbullet.SetDamage(damage);
        sgbullet.SetVelocity(velocity);
    }

    IEnumerator FireCorou()
    {
        while(true)
        {
            switch (weaponLev)
            {
                case 1:
                    yield return new WaitForSeconds(0.1f);
                    Fire(damage, velocity);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
}
