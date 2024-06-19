using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    [SerializeField] private GameObject Settings;

    public void GoGame()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void GoWin()
    {
        SceneManager.LoadScene("Win");
    }
    public void GoLose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void SettingsButoon()
    {
        Settings.SetActive(true);
        Time.timeScale = 0;
    }
    public void Atras()
    {
        Settings.SetActive(false);
        Time.timeScale = 1;
    }
}
