using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1,0);
    public float speed = 5;
    

    Gun gun;

    GameObject bulletObj;

    public Vector2 velocity;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        velocity = direction * speed;
        

    }

    private void FixedUpdate()
    {

        Vector2 temp = transform.position;
        temp += velocity * Time.fixedDeltaTime;
        transform.position = temp;
    }
}

