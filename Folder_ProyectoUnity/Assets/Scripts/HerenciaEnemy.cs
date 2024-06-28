using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HerenciaEnemy : MonoBehaviour
{
    public static Action enemyKilled;

    [SerializeField] protected int maxHP = 100;
    protected int currentHP;
    protected float speed = 3f;
    protected Transform playerTransform;
    protected Rigidbody rb;
    protected Collider enemyCollider;
    protected Vector3 vectorToMove;

    //protected AudioSource _audio;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemyCollider = GetComponent<Collider>();
        //_audio = GetComponent<AudioSource>();
        currentHP = maxHP;
    }

    public virtual void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(vectorToMove, Vector3.zero);
    }
    void FixedUpdate()
    {
        rb.velocity = (vectorToMove - transform.position).normalized * speed;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Muralla"))
        {
            SceneManager.LoadScene("Lose");
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
        enemyKilled?.Invoke();
        Destroy(gameObject);
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }
    public void ChangeMovePosition(Vector3 destiny)
    {
        vectorToMove = destiny;
    }
    public void GoToNode(MyGrafo mygrafo)
    {
        mygrafo.SelectionPath(gameObject);
    }
}