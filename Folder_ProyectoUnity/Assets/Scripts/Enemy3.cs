using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy3 : HerenciaEnemy
{
    private Vector3 originalScale;
    private Vector3 scaleNew;
    //[SerializeField] private AnimationCurve scaleCurve; //posiblemente lo quite

    void Start()
    {
        originalScale = transform.localScale;
        scaleNew = originalScale * 1.5f;
        //transform.DOMove(transform.position + Vector3.left * speed * 5, 5f);

        //transform.DOScale(scaleNew, 6f).SetDelay(4f).SetEase(scaleCurve);
        transform.DOScale(scaleNew, 2f).SetDelay(15f).SetEase(Ease.OutBack);
    }

}