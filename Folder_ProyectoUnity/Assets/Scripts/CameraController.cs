using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 15f;
    public Vector2[] cameraLimit;
    private Vector2 movementInput;

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = movementInput.y * -1;
        float verticalInput = movementInput.x;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, cameraLimit[0].x, cameraLimit[1].x);
        newPosition.z = Mathf.Clamp(newPosition.z, cameraLimit[0].y, cameraLimit[1].y);

        transform.position = newPosition;
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
