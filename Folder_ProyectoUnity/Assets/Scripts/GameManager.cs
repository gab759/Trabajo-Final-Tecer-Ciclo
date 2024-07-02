using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action OnWin;
    public static event Action OnLose;
    private int enemyCount = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        OnWin += GoWin;
        OnLose += GoLose;
    }

    private void OnDisable()
    {
        OnWin -= GoWin;
        OnLose -= GoLose;
    }

    private void GoWin()
    {
        SceneManager.LoadScene("Win");
    }

    private void GoLose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void TriggerWin()
    {
        OnWin?.Invoke();
    }

    public void TriggerLose()
    {
        OnLose?.Invoke();
    }
    public void AddEnemy()
    {
        enemyCount++;
    }
    public void RemoveEnemy()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            TriggerWin();
        }
    }
}