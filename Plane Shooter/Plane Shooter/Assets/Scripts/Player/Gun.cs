using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    public Bullet bullet;

    //Vector2 to store localrotation of gun object
    public Vector2 objdirection;

    //Bullet Spawn Point
    //[SerializeField
    //private Transform attackPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        //Gets loccal rotation of the Gun object      
        objdirection =  (transform.localRotation * Vector2.right).normalized;

    }

    public void Shoot()
    {
       

        //Instantiate allows objects to be spawned
        GameObject go = Instantiate(bullet.gameObject, transform.position,  Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = objdirection;
        goBullet.transform.right = objdirection;
    }

}
