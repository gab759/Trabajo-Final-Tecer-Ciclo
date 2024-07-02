using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemys", order = 1)]
public class SObjEnemy : ScriptableObject
{
    public GameObject enemyType;
    public float life;
    public float damage;
    public float speed;
    public float coins;


}
