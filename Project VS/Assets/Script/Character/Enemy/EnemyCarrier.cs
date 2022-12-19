using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarrier : Enemy
{
    [SerializeField] GameObject[] enemyCarrier;
    [SerializeField] float spawnRate;

    void Start()
    {
        base.Start();
        StartCoroutine(EnemyLaunch());
    }

    private IEnumerator EnemyLaunch()
    {
        while (!isDie && !Player.Instance.isDie)
        {
            GameObject instance_1 = Instantiate(enemyCarrier[Random.Range(0, enemyCarrier.Length)], transform.position + new Vector3(0.2f * Mathf.Cos((transform.rotation.eulerAngles.z) * Mathf.Deg2Rad), 0.2f * Mathf.Sin((transform.rotation.eulerAngles.z) * Mathf.Deg2Rad), 0), transform.rotation);
            GameObject instance_2 = Instantiate(enemyCarrier[Random.Range(0, enemyCarrier.Length)], transform.position + new Vector3(0.2f * Mathf.Cos((transform.rotation.eulerAngles.z - 180) * Mathf.Deg2Rad), 0.2f * Mathf.Sin((transform.rotation.eulerAngles.z - 180) * Mathf.Deg2Rad), 0), transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
