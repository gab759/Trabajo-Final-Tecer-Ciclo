using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneGameManager : MonoBehaviour
{
    public GameObject currentTurret;
    public GameObject turret1Prefab;
    public GameObject turret2Prefab;
    public int turret1Cost = 20; 
    public int turret2Cost = 40; 
    public LayerMask groundLayer;
    public TextMeshProUGUI coinsText; 
    public int playerCoins = 100; 

    private void Start()
    {
        GameManager.OnEnemyDeathCoin += AddCoins;
        UpdateCoinsText(playerCoins);
    }

    private void OnDestroy()
    {
        GameManager.OnEnemyDeathCoin -= AddCoins;
    }

    public void CreateTurret1()
    {
        if (currentTurret == null && playerCoins >= turret1Cost)
        {
            Vector3 spawnPosition = GetMouseWorldPosition();
            if (spawnPosition != Vector3.zero)
            {
                spawnPosition.y += 6.677f;
                currentTurret = Instantiate(turret1Prefab, spawnPosition, Quaternion.identity);
                playerCoins -= turret1Cost; 
                UpdateCoinsText(playerCoins); 
            }
        }
    }

    public void CreateTurret2()
    {
        if (currentTurret == null && playerCoins >= turret2Cost)
        {
            Vector3 spawnPosition = GetMouseWorldPosition();
            if (spawnPosition != Vector3.zero)
            {
                spawnPosition.y += 6.677f;
                currentTurret = Instantiate(turret2Prefab, spawnPosition, Quaternion.identity);
                playerCoins -= turret2Cost;
                UpdateCoinsText(playerCoins); 
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, groundLayer.value);

        if (hits.Length > 0)
        {
            return hits[0].point;
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

    private void UpdateCoinsText(int coins)
    {
        if (coinsText != null)
        {
            coinsText.text = coins.ToString();
        }
    }

    private void AddCoins(int coins)
    {
        playerCoins += coins;
        //Debug.Log("Player Coins: " + playerCoins);
        UpdateCoinsText(playerCoins); 
    }
}