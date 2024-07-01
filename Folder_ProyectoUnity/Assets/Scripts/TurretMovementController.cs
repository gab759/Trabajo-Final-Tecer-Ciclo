using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovementController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; 

    void Update()
    {
        MoveTurretToMousePosition();
    }

    private void MoveTurretToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool hasHit = Physics.Raycast(ray, Mathf.Infinity, groundLayer.value);
        if (hasHit)
        {
            hit = Physics.RaycastAll(ray, Mathf.Infinity, groundLayer.value)[0];
            Vector3 newPosition = hit.point;
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
            GetComponent<HerenciaTower>().enabled = false;
        }
    }
}