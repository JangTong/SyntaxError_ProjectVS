using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : WeaponBase
{
    private void Start()
    {
        StartCoroutine(OffLaser());
    }
    private void Update()
    {
        this.transform.rotation = Player.Instance.transform.rotation;
        this.transform.position = Player.Instance.transform.position + new Vector3(5 * Mathf.Cos((transform.rotation.eulerAngles.z + 90f) * Mathf.Deg2Rad), 5 * Mathf.Sin((transform.rotation.eulerAngles.z + 90f) * Mathf.Deg2Rad), 0);
    }

    IEnumerator OffLaser()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
