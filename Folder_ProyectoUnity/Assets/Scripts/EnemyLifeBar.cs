using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    private HerenciaEnemy enemyGoblin;

    private void Start()
    {
        enemyGoblin = GetComponentInParent<HerenciaEnemy>();
        if (enemyGoblin == null)
        {
            Debug.Log("Estas loco no existe esto");
        }
    }

    private void Update()
    {
        transform.forward = Camera.main.transform.forward;

        if (enemyGoblin != null && lifeBar != null)
        {
            UpdateLifeBar();
        }
    }

    void UpdateLifeBar()
    {
        float fillAmount = (float)enemyGoblin.GetCurrentHP() / (float)enemyGoblin.GetMaxHP();
        lifeBar.fillAmount = fillAmount;
    }
}