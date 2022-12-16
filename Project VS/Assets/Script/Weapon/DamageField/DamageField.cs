using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : WeaponBase
{
    private void Start()
    {
        StartCoroutine(OffField());
    }
    void Update()
    {
        this.transform.position = Player.Instance.transform.position;
    }

    IEnumerator OffField()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
