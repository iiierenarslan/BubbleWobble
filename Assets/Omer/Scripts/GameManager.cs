using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    public GameObject[] pausePanel;

    private bool isPaused;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        isPaused = false;
        for (int i = 0; i < pausePanel.Length; i++)
        {
            pausePanel[i].SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            for (int i = 0; i < pausePanel.Length; i++)
            {
                pausePanel[i].SetActive(true);
            }
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            for (int i = 0; i < pausePanel.Length; i++)
            {
                pausePanel[i].SetActive(false);
            }
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        audioSource.Play();
        SceneManager.LoadScene(1);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        audioSource.Play();
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
        audioSource.Play();
    }


    public void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }
}
