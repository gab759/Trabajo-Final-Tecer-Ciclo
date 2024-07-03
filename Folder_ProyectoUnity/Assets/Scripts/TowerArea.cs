using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArea : HerenciaTower
{
    protected override void Update()
    {
        base.Update();
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= generationTime)
        {
            timeElapsed = 0;
            ShootAtEnemies();
        }
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);

        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Enqueue(collider.transform);
        }
    }

    protected override void OnTriggerExit(Collider collider)
    {
        base.OnTriggerExit(collider);

        if (collider.CompareTag("Enemy"))
        {
            RemoveEnemyFromQueue(collider.transform);
        }
    }

    private void ShootAtEnemies() //O(n) de tiempo asintotico
    {
        MyQueue<Transform> tempQueue = new MyQueue<Transform>();

        while (!enemiesInRange.IsEmpty())
        {
            Transform enemy = enemiesInRange.Dequeue();
            if (enemy != null)
            {
                Vector3 directionEnemy = enemy.position - transform.position;
                Instantiate(bulletPrefab, transform.position, Quaternion.identity).SetAngleBullet(directionEnemy.normalized);
                GameManager.Instance.TriggerArrowShot();
                tempQueue.Enqueue(enemy);
            }
        }

        enemiesInRange = tempQueue;
    }

    private void RemoveEnemyFromQueue(Transform enemyTransform) //O(n) de tiempo asintotico
    {
        MyQueue<Transform> tempQueue = new MyQueue<Transform>();

        while (!enemiesInRange.IsEmpty())
        {
            Transform enemy = enemiesInRange.Dequeue();
            if (enemy != null && enemy != enemyTransform)
            {
                tempQueue.Enqueue(enemy);
            }
        }

        enemiesInRange = tempQueue;
    }
}
