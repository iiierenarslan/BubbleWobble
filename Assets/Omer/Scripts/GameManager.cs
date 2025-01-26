using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource[] audioSource;
    
    public GameObject[] pausePanel;
    public GameObject[] Objectives;
    public GameObject colliderObj;

    public GameObject finishObject;

    public bool isPaused;
    public int count = 0;

    public static GameManager instance;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        colliderObj = GameObject.Find("StartCollider");
        isPaused = false;
        for (int i = 0; i < pausePanel.Length; i++)
        {
            pausePanel[i].SetActive(false);
        }
    }


    void Update()
    {
        HandlePause();
        if (count >= 40)
        {
            colliderObj.SetActive(false);
            Objectives[0].gameObject.SetActive(false);
            Objectives[1].gameObject.SetActive(true);
        }
        else if (count >= 400) 
        {
            SceneManager.LoadScene(2);
        }
    }

    void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            for (int i = 0; i < pausePanel.Length; i++)
            {
                pausePanel[i].SetActive(true);
                audioSource[1].Stop();
            }
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            for (int i = 0; i < pausePanel.Length; i++)
            {
                pausePanel[i].SetActive(false);
                audioSource[1].Play();
            }
            Time.timeScale = 1;
        }
    }


    public void StartGame()
    {
        audioSource[0].Play();
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        audioSource[0].Play();
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        for (int i = 0; i < pausePanel.Length; i++)
        {
            pausePanel[i].SetActive(false);
        }
        audioSource[0].Play();
        audioSource[1].Play();

    }


    public void QuitGame()
    {
        audioSource[0].Play();
        Application.Quit();
    }
}
