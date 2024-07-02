using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
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

        bool hasHit = Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer.value);
        if (hasHit)
        {
            return hit.point;
        }

        return Vector3.zero;
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

    public void GoCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Exit()
    {
        Debug.Log("Saliste del juego.");
        Application.Quit();
    }

    public void SettingsButton(GameObject settings)
    {
        settings.SetActive(true);
        Time.timeScale = 0;
    }

    public void Atras(GameObject settings)
    {
        settings.SetActive(false);
        Time.timeScale = 1;
    }
}