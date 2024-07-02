using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneGameManager : MonoBehaviour
{

    public static event Action OnWin;
    public static event Action OnLose;

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

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void GoGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void GoSettings()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Exit()
    {
        Debug.Log("Saliste del juego.");
        Application.Quit();
    }

    public void SettingsButton()
    {
        Settings.SetActive(true);
        Time.timeScale = 0;
    }

    public void Atras()
    {
        Settings.SetActive(false);
        Time.timeScale = 1;
    }

    [SerializeField] private GameObject Settings;
    public GameObject currentTurret;
    public GameObject turret1Prefab;
    public GameObject turret2Prefab;
    public LayerMask groundLayer;

    public void CreateTurret1()
    {
        if (currentTurret == null)
        {
            Vector3 spawnPosition = GetMouseWorldPosition();
            if (spawnPosition != Vector3.zero)
            {
                spawnPosition.y += 6.677f;
                currentTurret = Instantiate(turret1Prefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    public void CreateTurret2()
    {
        if (currentTurret == null)
        {
            Vector3 spawnPosition = GetMouseWorldPosition();
            if (spawnPosition != Vector3.zero)
            {
                spawnPosition.y += 6.677f;
                currentTurret = Instantiate(turret2Prefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool hasHit = Physics.Raycast(ray, Mathf.Infinity, groundLayer.value);
        if (hasHit)
        {
            hit = Physics.RaycastAll(ray, Mathf.Infinity, groundLayer.value)[0];
            return hit.point;
        }

        return Vector3.zero;
    }
}