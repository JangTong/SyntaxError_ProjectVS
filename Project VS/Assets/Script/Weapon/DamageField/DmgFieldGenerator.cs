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

        fieldSp = Instantiate(projectile[1], gameObject.transform.position, gameObject.transform.rotation);
        fieldSp.SetActive(false);
        fieldSpScale = fieldSp.transform.localScale;

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
            //if(!fieldSp.activeSelf && weaponLev > 0) { fieldSp.SetActive(true); }
            switch (weaponLev)
            {
                case 1:
                    yield return new WaitForSeconds(4f);
                    Fire(damage, 1);
                    //fieldSp.transform.localScale = fieldSpScale;
                    break;
                case 2:
                    yield return new WaitForSeconds(3f);
                    Fire(damage, 1.2f);
                    //.transform.localScale = fieldSpScale * 1.2f;
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    Fire(damage, 1.4f);
                    //fieldSp.transform.localScale = fieldSpScale * 1.4f;
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    Fire(damage*2, 1.6f);
                    //fieldSp.transform.localScale = fieldSpScale * 1.6f;
                    break;
                case 5:
                    yield return new WaitForSeconds(0.5f);
                    Fire(damage*3, 2f);
                    //fieldSp.transform.localScale = fieldSpScale * 2f;
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