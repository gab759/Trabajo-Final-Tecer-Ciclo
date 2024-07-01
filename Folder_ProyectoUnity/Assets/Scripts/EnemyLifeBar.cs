using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    private HerenciaEnemy enemys;

    private void Start()
    {
        enemys = GetComponentInParent<HerenciaEnemy>();
        if (enemys == null)
        {
            Debug.Log("Estas loco no existe esto");
        }
    }

    private void Update()
    {
        transform.forward = Camera.main.transform.forward;

        if (enemys != null && lifeBar != null)
        {
            UpdateLifeBar();
        }
    }

    void UpdateLifeBar()
    {
        float fillAmount = (float)enemys.GetCurrentHP() / (float)enemys.GetMaxHP();
        lifeBar.fillAmount = fillAmount;
    }
}