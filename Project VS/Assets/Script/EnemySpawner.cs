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
            Vector3 spawnPos = GetRandomPosition(); //랜덤 위치 return
            if (!Player.Instance.isDie)
            {
                GameObject instance = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //오브젝트의 위치
        Vector2 size = area.size;                   //box colider2d, 즉 맵의 크기 벡터

        //x, y축 랜덤 좌표 얻기
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
