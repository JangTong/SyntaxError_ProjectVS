using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : WeaponBase
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponLev = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (weaponLev)
        {
            case 1:
                if (!gameObject.activeSelf) gameObject.SetActive(true);
                rateOfFire = 4;
                damage = Player.Instance.GetATKPower();
                break;
            case 2:
                rateOfFire = 3;
                damage = Player.Instance.GetATKPower();
                break;
            case 3:
                rateOfFire = 2;
                damage = Player.Instance.GetATKPower();
                break;
            case 4:
                rateOfFire = 1;
                damage = Player.Instance.GetATKPower() * 2;
                break;
            case 5:
                rateOfFire = 0.5f;
                damage = Player.Instance.GetATKPower() * 3;
                break;
            default:
                break;
        }

    }
}
