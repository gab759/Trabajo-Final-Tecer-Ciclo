using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Enemy3 : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 scaleNew;
    //[SerializeField] private AnimationCurve scaleCurve; //posiblemente lo quite
    [SerializeField] private int life;
    public float speed = 3f;

    void Start()
    {
        originalScale = transform.localScale;
        scaleNew = originalScale * 1.5f;
        //transform.DOMove(transform.position + Vector3.left * speed * 5, 5f);

        //transform.DOScale(scaleNew, 6f).SetDelay(4f).SetEase(scaleCurve);
        transform.DOScale(scaleNew, 2f).SetDelay(7f).SetEase(Ease.OutBack);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muralla"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}