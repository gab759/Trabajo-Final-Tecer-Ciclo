using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerController : MonoBehaviour
{
    public SceneGameManager gameManager;
    private GameObject newTurret = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTurret();
        }
    }

    private void PlaceTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Base")))
        {
            HerenciaTower baseTower = hit.collider.GetComponent<HerenciaTower>();
            if (baseTower != null && !baseTower.HasTurret && gameManager.currentTurret != null)
            {
                Vector3 turretPosition = hit.collider.transform.position + new Vector3(0, 6.677f, 0);
                Quaternion turretRotation = Quaternion.Euler(0f, 0f, 0f);

                newTurret = Instantiate(gameManager.currentTurret, turretPosition, turretRotation);
                newTurret.GetComponent<TurretMovementController>().enabled = false;
                newTurret.GetComponent<HerenciaTower>().enabled = true;

                baseTower.HasTurret = true; //FALTA

                Destroy(gameManager.currentTurret);
                gameManager.currentTurret = null;
            }
        }
    }
}