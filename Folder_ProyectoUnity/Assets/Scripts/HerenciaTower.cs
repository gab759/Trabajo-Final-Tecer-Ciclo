using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerenciaTower : MonoBehaviour
{
    protected float generationTime = 3f;
    protected float timeElapsed = 0f;
    [SerializeField] protected BulletController bulletPrefab;
    protected Transform positionEnemyReference;
    protected Vector3 directionEnemy;
    [SerializeField] protected MyQueue<Transform> enemiesInRange = new MyQueue<Transform>();

    protected virtual void Update()
    {
        if (positionEnemyReference != null)
        {
            directionEnemy = positionEnemyReference.position - transform.position;

            float angle = Mathf.Atan2(directionEnemy.z, directionEnemy.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, -angle, 0f);

            if (timeElapsed >= generationTime)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation).SetAngleBullet(directionEnemy.normalized);
                timeElapsed = 0;
            }
        }
        timeElapsed += Time.deltaTime;
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (positionEnemyReference == null)
            {
                positionEnemyReference = collider.transform;
            }
        }
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (positionEnemyReference == collider.transform)
            {
                positionEnemyReference = NextTarget();
            }
        }
    }

    protected virtual Transform NextTarget()
    {
        if (enemiesInRange.IsEmpty())
        {
            return null;
        }

        Transform nextEnemy = enemiesInRange.Dequeue();

        while (nextEnemy == null && !enemiesInRange.IsEmpty())
        {
            nextEnemy = enemiesInRange.Dequeue();
        }
        return nextEnemy;
    }
}
