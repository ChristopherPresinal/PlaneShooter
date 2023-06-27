using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 0f;
    public float deletePosition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        RemoveEnemy();
    }

    void EnemyMove()
    {
        Vector3 temp = transform.position;
        temp.x -= enemySpeed * Time.deltaTime;
        transform.position = temp;

    }//EnemyMove

    void RemoveEnemy()
    {
        Vector3 pos = transform.position;

        if(pos.x <= deletePosition)
        {
            Destroy(gameObject);
        }

    }//Remove Enemy
}
