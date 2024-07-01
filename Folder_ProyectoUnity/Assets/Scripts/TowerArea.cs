using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArea : HerenciaTower
{
    [SerializeField] private BulletController bulletPrefabOverride;
    //private MyQueue<Transform> enemiesInRange = new MyQueue<Transform>();

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
            // Remove the enemy from the queue if it exits the trigger
            MyQueue<Transform> tempQueue = new MyQueue<Transform>();

            while (!enemiesInRange.IsEmpty())
            {
                Transform enemy = enemiesInRange.Dequeue();
                if (enemy != null && enemy != collider.transform)
                {
                    tempQueue.Enqueue(enemy);
                }
            }

            enemiesInRange = tempQueue;
        }
    }


    private void ShootAtEnemies()
    {
        MyQueue<Transform> tempQueue = new MyQueue<Transform>(); 

        while (!enemiesInRange.IsEmpty())
        {
            Transform enemy = enemiesInRange.Dequeue();
            if (enemy != null)
            {
                Vector3 directionEnemy = enemy.position - transform.position;
                Instantiate(bulletPrefabOverride, transform.position, Quaternion.identity).SetAngleBullet(directionEnemy.normalized);
            }

            tempQueue.Enqueue(enemy); 
        }

        enemiesInRange = tempQueue; 
    }
}