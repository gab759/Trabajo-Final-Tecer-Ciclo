using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy3 : HerenciaEnemy
{
    private Vector3 originalScale;
    private Vector3 scaleNew;
    private bool hasScaled = false;
    private float speedBoost = 0.3f;

    void Start()
    {
        originalScale = transform.localScale;
        scaleNew = originalScale * 1.5f;
    }

    public override void Update()
    {
        base.Update();  

        if (currentHP < 10 && !hasScaled)  
        {
            IncreaseScaleAndSpeed();
        }
    }

    private void IncreaseScaleAndSpeed() //O(1) de tiempo asintotico
    {
        transform.DOScale(scaleNew, 2f).SetEase(Ease.OutBack);  
        speed += speedBoost;  
        hasScaled = true;  
    }
}