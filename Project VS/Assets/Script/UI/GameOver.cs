using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public Button restart;
    public Button exit;
    public TMP_Text endingText;
    
    void Start()
    {
        restart = transform.Find("Restart").GetComponent<Button>();
        exit = transform.Find("Exit").GetComponent<Button>();
        panel.SetActive(false);
    }

    void Update()
    {
        if(GameManager.Instance.isClear || Player.Instance.isDie)
        {
            if(GameManager.Instance.isClear) endingText.text = "CLEAR!";
            else if(Player.Instance.isDie) endingText.text = "GAME OVER";
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