using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    void Start()
    {
        weaponLev = 1;
        StartCoroutine(FireCorou());
        velocity = 10;
    }

    void Update()
    {
        damage = Player.Instance.GetATKPower();
    }
    IEnumerator FireCorou()
    {
        while(true)
        {
            switch (weaponLev)
            {
                case 1:
                    yield return new WaitForSeconds(0.5f);
                    Fire_1(damage, velocity);
                    break;
                case 2:
                    yield return new WaitForSeconds(0.33f);
                    Fire_2(damage, velocity);
                    break;
                case 3:
                    yield return new WaitForSeconds(0.3f);
                    Fire_3(damage, velocity);
                    break;
                case 4:
                    yield return new WaitForSeconds(0.2f);
                    Fire_4(damage, velocity);
                    break;
                case 5:
                    yield return new WaitForSeconds(0.15f);
                    Fire_5(damage, velocity);
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    void Fire_1(float damage, float velocity)
    {
        GameObject bullet = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation);
        GunProjectile sgbullet = bullet.GetComponent<GunProjectile>();
        sgbullet.SetDamage(damage);
        sgbullet.SetVelocity(velocity);
    }
    void Fire_2(float damage, float velocity)
    {
        Quaternion bulletLPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 180));
        Quaternion bulletRPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));

        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.1f * Mathf.Cos(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0.1f * Mathf.Sin(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.1f * Mathf.Cos(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0.1f * Mathf.Sin(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);

        GunProjectile sgbulletL = bulletL.GetComponent<GunProjectile>();
        GunProjectile sgbulletR = bulletR.GetComponent<GunProjectile>();

        sgbulletL.SetDamage(damage);
        sgbulletR.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
    }
    void Fire_3(float damage, float velocity)
    {
        Quaternion bulletLPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 180));
        Quaternion bulletRPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));

        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.2f * Mathf.Cos(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0.2f * Mathf.Sin(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.2f * Mathf.Cos(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0.2f * Mathf.Sin(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletM = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation);

        GunProjectile sgbulletL = bulletL.GetComponent<GunProjectile>();
        GunProjectile sgbulletR = bulletR.GetComponent<GunProjectile>();
        GunProjectile sgbulletM = bulletM.GetComponent<GunProjectile>();

        sgbulletL.SetDamage(damage);
        sgbulletR.SetDamage(damage);
        sgbulletM.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
        sgbulletM.SetVelocity(velocity);
    }
    void Fire_4(float damage, float velocity)
    {
        Quaternion bulletLPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 180));
        Quaternion bulletRPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));

        GameObject bulletL = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.3f * Mathf.Cos((bulletLPos.eulerAngles.z - 60f) * Mathf.Deg2Rad), 0.3f * Mathf.Sin((bulletLPos.eulerAngles.z - 60f) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletL_2 = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.3f * Mathf.Cos(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0.3f * Mathf.Sin(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.3f * Mathf.Cos((bulletRPos.eulerAngles.z + 60f) * Mathf.Deg2Rad), 0.3f * Mathf.Sin((bulletRPos.eulerAngles.z + 60f) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR_2 = Instantiate(projectile[0], gameObject.transform.position + new Vector3(0.3f * Mathf.Cos(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0.3f * Mathf.Sin(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);

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
        Quaternion bulletLPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 180));
        Quaternion bulletRPos = gameObject.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 0));

        GameObject bulletL = Instantiate(projectile[1], gameObject.transform.position + new Vector3(0.4f * Mathf.Cos((bulletLPos.eulerAngles.z - 45f) * Mathf.Deg2Rad), 0.4f * Mathf.Sin((bulletLPos.eulerAngles.z - 45f) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletL_2 = Instantiate(projectile[1], gameObject.transform.position + new Vector3(0.4f * Mathf.Cos(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0.4f * Mathf.Sin(bulletLPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletM = Instantiate(projectile[1], gameObject.transform.position + new Vector3(0.4f * Mathf.Cos((bulletLPos.eulerAngles.z - 90f) * Mathf.Deg2Rad), 0.4f * Mathf.Sin((bulletLPos.eulerAngles.z - 90f) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR = Instantiate(projectile[1], gameObject.transform.position + new Vector3(0.4f * Mathf.Cos((bulletRPos.eulerAngles.z + 45f) * Mathf.Deg2Rad), 0.4f * Mathf.Sin((bulletRPos.eulerAngles.z + 45f) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        GameObject bulletR_2 = Instantiate(projectile[1], gameObject.transform.position + new Vector3(0.4f * Mathf.Cos(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0.4f * Mathf.Sin(bulletRPos.eulerAngles.z * Mathf.Deg2Rad), 0), gameObject.transform.rotation);

        GunProjectile1 sgbulletL = bulletL.GetComponent<GunProjectile1>();
        GunProjectile1 sgbulletL_2 = bulletL_2.GetComponent<GunProjectile1>();
        GunProjectile1 sgbulletM = bulletM.GetComponent<GunProjectile1>();
        GunProjectile1 sgbulletR = bulletR.GetComponent<GunProjectile1>();
        GunProjectile1 sgbulletR_2 = bulletR_2.GetComponent<GunProjectile1>();

        sgbulletL.SetDamage(damage);
        sgbulletL_2.SetDamage(damage);
        sgbulletM.SetDamage(damage);
        sgbulletR.SetDamage(damage);
        sgbulletR_2.SetDamage(damage);

        sgbulletL.SetVelocity(velocity);
        sgbulletL_2.SetVelocity(velocity);
        sgbulletM.SetVelocity(velocity);
        sgbulletR.SetVelocity(velocity);
        sgbulletR_2.SetVelocity(velocity);
    }

}
