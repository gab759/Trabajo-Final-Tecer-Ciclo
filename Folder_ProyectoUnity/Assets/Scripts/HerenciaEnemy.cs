using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HerenciaEnemy : MonoBehaviour
{
    [SerializeField] protected int maxHP = 10;
    protected int currentHP;
    protected float speed = 2f;
    protected Rigidbody rb;
    [SerializeField] protected Vector3 vectorToMove;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHP = maxHP;
        GameManager.Instance.AddEnemy(); 
    }

    public virtual void Update()
    {
        transform.LookAt(vectorToMove, Vector3.zero);
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = (vectorToMove - transform.position).normalized * speed;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muralla"))
        {
            Destroy(gameObject);
            GameManager.Instance.RemoveEnemy(); 
        }

        if (other.CompareTag("Bullet"))
        {
            BulletController bullet = other.GetComponent<BulletController>();
            if (bullet != null)
            {
                TakeDamage(bullet.GetDamage());
                Destroy(other.gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Kill();
        }
    }

    protected virtual void Kill()
    {
        GameManager.Instance.RemoveEnemy(); 
        Destroy(gameObject);
    }

    public int GetCurrentHP() => currentHP;
    public int GetMaxHP() => maxHP;

    public void ChangeMovePosition(Vector3 destiny)
    {
        vectorToMove = destiny;
    }
}