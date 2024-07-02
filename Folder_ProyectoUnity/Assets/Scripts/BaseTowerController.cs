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
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerMask.GetMask("Base"));

        if (hits.Length > 0)
        {
            RaycastHit hit = hits[0];
            if (hit.collider != null && hit.collider.CompareTag("Base") && gameManager.currentTurret != null)
            {
                Vector3 turretPosition = hit.collider.transform.position + new Vector3(0, 6.677f, 0);
                Quaternion turretRotation = Quaternion.Euler(0f, 0f, 0f);

                newTurret = Instantiate(gameManager.currentTurret, turretPosition, turretRotation);
                newTurret.GetComponent<TurretMovementController>().enabled = false;
                newTurret.GetComponent<HerenciaTower>().enabled = true;
                hit.collider.enabled = false;
                Destroy(gameManager.currentTurret);
                gameManager.currentTurret = null;
            }
        }
    }
}