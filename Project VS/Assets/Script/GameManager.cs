using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    bool isPause = false;
    float gameTimer = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Update()
    {
        gameTimer += Time.deltaTime;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null) return null;
            return instance;
        }
    }

    public float GetTimer () { return gameTimer; }

    //게임 시간 조작 함수
    public void PauseGame()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }
    public void ResumeGame()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
