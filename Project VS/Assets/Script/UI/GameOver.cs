using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public Button restart;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        restart = transform.Find("Restart").GetComponent<Button>();
        exit = transform.Find("Exit").GetComponent<Button>();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Instance.isDie)
        {
            panel.SetActive(true);
            restart.onClick.AddListener(Restart);
            exit.onClick.AddListener(Exit);
        }
    }

    void Restart()
    {
        GameManager.Instance.ResetGame();
        panel.SetActive(false);
        restart.onClick.RemoveListener(Restart);
    }

    void Exit()
    {
        GameManager.Instance.ExitGame();
        panel.SetActive(false);
        exit.onClick.RemoveListener(Exit);
    }
}