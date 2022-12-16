using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShot : WeaponBase
{

    void Start()
    {
        weaponLev = 0;
        StartCoroutine(FireCorou());
        velocity = 10;
    }

    void Update()
    {
        switch (weaponLev)
        {
            case 1:
            case 2:
                damage = Player.Instance.GetATKPower();
                break;
            case 3:
            case 4:
                damage = Player.Instance.GetATKPower() * 2;
                break;
            case 5:
                damage = Player.Instance.GetATKPower() * 3;
                break;
            default:
                break;
        }
    }

    IEnumerator FireCorou()
    {
        while (true)
        {
            switch (weaponLev)
            {
                case 1:
                    yield return new WaitForSeconds(1f);
                    Fire(damage, velocity);
                    break;
                case 2:
                    yield return new WaitForSeconds(0.6f);
                    Fire_2(damage, velocity);
                    break;
                case 3:
                    yield return new WaitForSeconds(0.5f);
                    Fire_3(damage, velocity);
                    break;
                case 4:
                    yield return new WaitForSeconds(0.4f);
                    Fire_4(damage, velocity);
                    break;
                case 5:
                    yield return new WaitForSeconds(0.03f);
                    Fire_5(damage, velocity);
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    void Fire(float damage, float velocity)
    {
        GameObject bullet = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180 + Random.Range(-10, 10))));
        GunProjectile sgbullet = bullet.GetComponent<GunProjectile>();
        sgbullet.SetDamage(damage);
        sgbullet.SetVelocity(velocity);
    }
    void Fire_2(float damage, float velocity)
    {
        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180-10)));
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180+10)));
        
        GunProjectile sgbulletL = bulletL.GetComponent<GunProjectile>();
        GunProjectile sgbulletR = bulletR.GetComponent<GunProjectile>();
        
        sgbulletL.SetDamage(damage);
        sgbulletR.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
    }
    void Fire_3(float damage, float velocity)
    {
        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180-15)));
        GameObject bulletM = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180)));
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180+15)));
        
        GunProjectile sgbulletL = bulletL.GetComponent<GunProjectile>();
        GunProjectile sgbulletM = bulletM.GetComponent<GunProjectile>();
        GunProjectile sgbulletR = bulletR.GetComponent<GunProjectile>();
        
        sgbulletL.SetDamage(damage);
        sgbulletM.SetDamage(damage);
        sgbulletR.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletM.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
    }
    void Fire_4(float damage, float velocity)
    {
        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180 - 10)));
        GameObject bulletL_2 = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180 - 20)));
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180 + 10)));
        GameObject bulletR_2 = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -180 + 20)));

        GunProjectile sgbulletL = bulletL.GetComponent<GunProjectile>();
        GunProjectile sgbulletL_2 = bulletL_2.GetComponent<GunProjectile>();
        GunProjectile sgbulletR = bulletR.GetComponent<GunProjectile>();
        GunProjectile sgbulletR_2 = bulletR_2.GetComponent<GunProjectile>();

        sgbulletL.SetDamage(damage);
        sgbulletL_2.SetDamage(damage);
        sgbulletR.SetDamage(damage);
        sgbulletR_2.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletL_2.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
        sgbulletR_2.SetVelocity(velocity);
    }
    void Fire_5(float damage, float velocity)
    {
        GameObject bullet = Instantiate(projectile[1], gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0,Random.Range(0, 360))));
        GunProjectile sgbullet = bullet.GetComponent<GunProjectile>();
        sgbullet.SetDamage(damage);
        sgbullet.SetVelocity(velocity);
    }
}
