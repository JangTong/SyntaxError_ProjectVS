using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : WeaponBase
{
    void Start()
    {
        weaponLev = 0;
        StartCoroutine(FireCorou());
    }

    void Update()
    {
        damage = Player.Instance.GetATKPower();
    }
    IEnumerator FireCorou()
    {
        while (true)
        {
            switch (weaponLev)
            {
                case 1:
                    yield return new WaitForSeconds(2f);
                    Fire_1(damage, velocity);
                    break;
                case 2:
                    yield return new WaitForSeconds(1.6f);
                    Fire_2(damage * 2, velocity);
                    break;
                case 3:
                    yield return new WaitForSeconds(1.2f);
                    Fire_3(damage * 2, velocity);
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    Fire_4(damage * 2, velocity);
                    break;
                case 5:
                    yield return new WaitForSeconds(0.4f);
                    Fire_5(damage * 3, velocity);
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    void Fire_1(float damage, float velocity)
    {
        GameObject laser = Instantiate(projectile[0], gameObject.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        LaserProjectile compLaser = laser.GetComponent<LaserProjectile>();
        compLaser.SetDamage(damage);
    }
    void Fire_2(float damage, float velocity)
    {
        GameObject laser = Instantiate(projectile[0], gameObject.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        LaserProjectile compLaser = laser.GetComponent<LaserProjectile>();
        compLaser.SetDamage(damage);
    }
    void Fire_3(float damage, float velocity)
    {
        GameObject laser = Instantiate(projectile[0], gameObject.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        LaserProjectile compLaser = laser.GetComponent<LaserProjectile>();
        compLaser.SetDamage(damage);
    }
    void Fire_4(float damage, float velocity)
    {
        GameObject laser = Instantiate(projectile[0], gameObject.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        LaserProjectile compLaser = laser.GetComponent<LaserProjectile>();
        compLaser.SetDamage(damage);
    }
    void Fire_5(float damage, float velocity)
    {
        GameObject laser = Instantiate(projectile[1], gameObject.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0), gameObject.transform.rotation);
        LaserProjectile compLaser = laser.GetComponent<LaserProjectile>();
        compLaser.SetDamage(damage);
    }
}
