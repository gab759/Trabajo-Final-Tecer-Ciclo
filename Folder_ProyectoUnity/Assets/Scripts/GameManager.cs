using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject turret1Prefab;
    public GameObject turret2Prefab;
    public GameObject turret3Prefab;
    public LayerMask baseLayerMask;
    private int points;
    private int coins;
    public int vidaActual;
    private GameObject selectedTurretPrefab;

    public GameObject Settings;


    public void SettingsButoon()
    {
        Settings.SetActive(true);
    }
    public void Atras()
    {
        Settings.SetActive(false);
    }

    public void SelectTurret1()
    {
        selectedTurretPrefab = turret1Prefab;
    }

    public void SelectTurret2()
    {
        selectedTurretPrefab = turret2Prefab;
    }

    //public void SelectTurret3()
    //{
    //    selectedTurretPrefab = turret3Prefab;
    //}

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedTurretPrefab != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, baseLayerMask))
            {
                // Verificar si la posición ya tiene una torreta
                HerenciaTower baseComponent = hit.collider.GetComponent<HerenciaTower>();
                //if (baseComponent != null && !baseComponent.HasTurret())
                //{
                //    Instantiate(selectedTurretPrefab, hit.point, Quaternion.identity);
                //    baseComponent.SetTurret();
                //}
            }
        }
    }
}