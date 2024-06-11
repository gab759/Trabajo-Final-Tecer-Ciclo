using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MouseUI : MonoBehaviour
{
    private RectTransform rectTransform;
    private Button button;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    public void OnPointerEnter()
    {
        rectTransform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBack);
        //GetComponent<Image>().DOColor(Color.red, 0.2f);
    }

    public void OnPointerExit()
    {   
        rectTransform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        //GetComponent<Image>().DOColor(Color.white, 0.8f);
    }

    private void OnButtonClick()
    {
        rectTransform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 10, 1);
    }
}
