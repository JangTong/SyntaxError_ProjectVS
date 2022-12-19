using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyArr_30;
    public GameObject[] enemyArr_60;
    public GameObject[] enemyArr_90;
    public GameObject[] enemyArr_120;
    public GameObject[] enemyArr_150;
    public GameObject[] enemyArr_180;
    public GameObject[] enemyArr_210;
    public GameObject[] enemyArr_240;
    public GameObject[] enemyArr_270;
    public GameObject[] enemyArr_300;
    public GameObject[] enemyElite;
    public GameObject healItem;

    private BoxCollider2D area;


    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine(Spawn());
        StartCoroutine(SpawnHeal());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 spawnPos = GetRandomPosition(); //·£´ý À§Ä¡ return
            if (!Player.Instance.isDie)
            {
                if (GameManager.Instance.GetTimer() < 30)
                {
                    GameObject instance = Instantiate(enemyArr_30[Random.Range(0, enemyArr_30.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(1f); //delay
                }
                else if(GameManager.Instance.GetTimer() < 60)
                {
                    GameObject instance = Instantiate(enemyArr_60[Random.Range(0, enemyArr_60.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 90)
                {
                    GameObject instance = Instantiate(enemyArr_90[Random.Range(0, enemyArr_90.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 120)
                {
                    GameObject instance = Instantiate(enemyArr_120[Random.Range(0, enemyArr_120.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                }
                else if (GameManager.Instance.GetTimer() < 150)
                {
                    GameObject instance = Instantiate(enemyArr_150[Random.Range(0, enemyArr_150.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 180)
                {
                    GameObject instance = Instantiate(enemyArr_180[Random.Range(0, enemyArr_180.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 210)
                {
                    GameObject instance = Instantiate(enemyArr_210[Random.Range(0, enemyArr_210.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 240)
                {
                    GameObject instance = Instantiate(enemyArr_240[Random.Range(0, enemyArr_240.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 270)
                {
                    GameObject instance = Instantiate(enemyArr_270[Random.Range(0, enemyArr_270.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f);
                }
                else if (GameManager.Instance.GetTimer() < 300)
                {
                    GameObject instance = Instantiate(enemyArr_300[Random.Range(0, enemyArr_300.Length)], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                }
                else if(GameManager.Instance.GetTimer() >= 300)
                {
                    GameObject instance = Instantiate(enemyElite[4], spawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                    break;
                }
            }
            else break;
        }
    }
    private IEnumerator SpawnHeal()
    {
        while (true)
        {
            Vector3 spawnPos = GetRandomPosition();
            GameObject instance = Instantiate(healItem, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20f);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //¿ÀºêÁ§Æ®ÀÇ À§Ä¡
        Vector2 size = area.size;                   //box colider2d, Áï ¸ÊÀÇ Å©±â º¤ÅÍ

        //x, yÃà ·£´ý ÁÂÇ¥ ¾ò±â
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
}
