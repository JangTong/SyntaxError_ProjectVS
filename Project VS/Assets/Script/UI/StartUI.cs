using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;

    void Start()
    {
        GameManager.Instance.PauseGame();
        panel.SetActive(true);
        panel2.SetActive(false);
    }

    void Update()
    {
        if(Input.anyKey && panel.activeSelf)
        {
            GameManager.Instance.ResumeGame();
            panel.SetActive(false);
            panel2.SetActive(true);
        }
    }
}