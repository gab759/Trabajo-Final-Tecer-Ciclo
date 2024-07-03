using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : HerenciaEnemy
{
    [SerializeField] private float dashMultiplier = 5f;
    private float dashDuration = 0.2f;
    private float dashCooldown = 4f;

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

    public override void Update()
    {
        base.Update();
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
    }

    public override void FixedUpdate()
    {
        if (vectorToMove != Vector3.zero)
        {
            rb.velocity = (vectorToMove - transform.position).normalized * speed;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}