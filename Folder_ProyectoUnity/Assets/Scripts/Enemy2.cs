using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float speed = 1f; 
    [SerializeField] private float dashMultiplier = 5f; 
    private float dashDuration = 0.5f; 
    private float dashCooldown = 1.5f; 

    private float timeElapsed = 0f;
    private float dashTimeElapsed = 0f;
    private bool isDashing = false;
    private float normalSpeed;
    private float dashSpeed;

    void Start()
    {
        normalSpeed = speed;
        dashSpeed = normalSpeed * dashMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (isDashing)
        {
            dashTimeElapsed += Time.deltaTime;
            if (dashTimeElapsed >= dashDuration)
            {
                isDashing = false;
                speed = normalSpeed;
                dashTimeElapsed = 0f;
            }
        }
        else
        {
            if (timeElapsed >= dashCooldown)
            {
                isDashing = true;
                speed = dashSpeed;
                timeElapsed = 0f;
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}