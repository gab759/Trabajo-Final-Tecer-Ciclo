using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] private int life;
    public float speed = 3f;
    private float timeElapsed = 0f;
    private bool scaled = false; 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 5f && !scaled)
        {
            transform.localScale *= 3;
            scaled = true; 
        }
    }
}