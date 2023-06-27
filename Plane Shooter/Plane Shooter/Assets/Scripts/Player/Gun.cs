using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;

    //Vector2 to store localrotation of gun object
    Vector2 direction;

    //Bullet Spawn Point
    [SerializeField]
    private Transform attackPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gets loccal rotation of the Gun object      
        direction =  (transform.localRotation * Vector2.right).normalized;
    }

    public void Shoot()
    {

        //Instantiate allows objects to be spawned
        GameObject go = Instantiate(bullet.gameObject, attackPoints.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;                       
    }
}
