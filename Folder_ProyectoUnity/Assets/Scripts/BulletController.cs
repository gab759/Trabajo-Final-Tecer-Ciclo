using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Movement Variable")]
    public float speed = 40;
    [SerializeField] private int damage = 1;

    private Rigidbody _compRigidbody;
    private Vector3 referenceAngle;

    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") || collider.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }
    public int GetDamage()
    {
        return damage;
    }
    private void Start()
    {
        _compRigidbody.velocity = referenceAngle * speed;
    }

    public void SetAngleBullet(Vector3 directionBullet)
    {
        referenceAngle = directionBullet;
        transform.rotation = Quaternion.LookRotation(directionBullet);

    }
}
