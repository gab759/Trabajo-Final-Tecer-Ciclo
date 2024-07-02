using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public GameObject sceneGameManagerPrefab;

    void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(sceneGameManagerPrefab);
        }
    }
}