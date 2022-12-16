using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DmgFieldGenerator : WeaponBase
{
    GameObject fieldSp;
    Vector3 fieldSpScale;
    void Start()
    {
        weaponLev = 0;
        damage = 0;
        StartCoroutine(FireCorou());
    }

    void Update()
    {
        switch (weaponLev)
        {
            case 1:
            case 2:
            case 3:
                damage = Player.Instance.GetATKPower();
                break;
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
                    yield return new WaitForSeconds(4f);
                    Fire(damage, 1);
                    break;
                case 2:
                    yield return new WaitForSeconds(3f);
                    Fire(damage, 1.2f);
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    Fire(damage, 1.4f);
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    Fire(damage, 1.6f);
                    break;
                case 5:
                    yield return new WaitForSeconds(0.5f);
                    Fire(damage, 2f);
                    break;
                default:
                    yield return new WaitForSeconds(1f);
                    break;
            }
        }
    }
    void Fire(float damage, float scale)
    {
        GameObject field = Instantiate(projectile[0], gameObject.transform.position, gameObject.transform.rotation);
        DamageField compField = field.GetComponent<DamageField>();
        compField.SetDamage(damage);
        field.transform.localScale *= scale;
    }
}
