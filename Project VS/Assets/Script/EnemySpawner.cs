using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private BoxCollider2D area;


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 spawnPos = GetRandomPosition(); //���� ��ġ return
            if (!Player.Instance.isDie)
            {
                GameObject instance = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //������Ʈ�� ��ġ
        Vector2 size = area.size;                   //box colider2d, �� ���� ũ�� ����

        //x, y�� ���� ��ǥ ���
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
