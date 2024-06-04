using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerenciaTower : MonoBehaviour
{
    private float generationTime = 3f; 
    private float timeElapsed = 0f; 
    public BulletController bulletPrefab; 
    private Transform positionEnemyReference; 
    private Vector3 directionEnemy; 

    void Update()
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (positionEnemyReference == null)
            {
                positionEnemyReference = collider.gameObject.transform;
            }
        }
    }

   /* private void OnTriggerExit(Collider collision)
    {
        if (positionEnemyReference != null)
        {
            try
            {
                if (collision.gameObject.GetComponent<HerenciaEnemys>().index == positionEnemyReference.GetComponent<HerenciaEnemys>().index)
                {
                    this.positionEnemyReference = null;
                }
            }
            catch (System.NullReferenceException) { }
        }
    }*/
}