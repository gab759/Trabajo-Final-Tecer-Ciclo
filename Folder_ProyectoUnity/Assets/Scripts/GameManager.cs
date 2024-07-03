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
    public static event Action OnButtonHover;
    public static event Action OnWallDamage;
    public static event Action<int> OnEnemyDeathCoin; 
    public static event Action OnEnemyDeathSoundCoin;
    public static event Action OnArrowShot; 

    public AudioClip buttonHoverSound;
    public AudioClip wallDamageSound;
    public AudioClip enemyDeathSound;
    public AudioClip arrowShotSound; 

    private AudioSource audioSource;
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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OnButtonHover += PlayButtonHoverSound;
        OnWallDamage += PlayWallDamageSound;
        OnEnemyDeathSoundCoin += PlayEnemyDeathCoinSound;
        OnArrowShot += PlayArrowShotSound;
        OnWin += GoWin;
        OnLose += GoLose;
    }

    private void OnDestroy()
    {
        OnButtonHover -= PlayButtonHoverSound;
        OnWallDamage -= PlayWallDamageSound;
        OnEnemyDeathSoundCoin -= PlayEnemyDeathCoinSound;
        OnArrowShot -= PlayArrowShotSound; 
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

    public void TriggerEnemyDeath(int coins)
    {
        OnEnemyDeathCoin?.Invoke(coins); 
    }

    public void TriggerEnemyDeathCoinSound()
    {
        OnEnemyDeathSoundCoin?.Invoke();
    }

    public void TriggerButtonHover()
    {
        OnButtonHover?.Invoke();
    }

    public void TriggerWallDamage()
    {
        OnWallDamage?.Invoke();
    }

    public void TriggerArrowShot()
    {
        OnArrowShot?.Invoke(); 
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

    private void PlayButtonHoverSound()
    {
        PlaySound(buttonHoverSound);
    }

    private void PlayWallDamageSound()
    {
        PlaySound(wallDamageSound);
    }

    private void PlayEnemyDeathCoinSound()
    {
        PlaySound(enemyDeathSound);
    }

    private void PlayArrowShotSound()
    {
        PlaySound(arrowShotSound); 
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}