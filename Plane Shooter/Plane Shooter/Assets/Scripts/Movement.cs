using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;

    public float minY, maxY;

    //Bullet Object
    [SerializeField]
    private GameObject bullet;

    //Bullet Spawn Point
    [SerializeField]
    private Transform attackPoints;

    //Variable for attack cooldown
    public float attackTimer = 0.35f;
    public float currentAttackTimer = 0f;

    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        //current attack timer stores the value of the attack timer
        currentAttackTimer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Moves The Player Up
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            //Stops Player from Exiting Play Area
            if (temp.y > maxY)
            {
                temp.y = maxY;
            }

            transform.position = temp;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            //Moves The Player Up
            //Vector3 temp holds transform.position that way it can be manipulated
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            //Stops Player from Exiting Play Area
            if (temp.y < minY)
            {
                temp.y = minY;
            }

            //This updates the transform position 
            transform.position = temp;
        }

    }//MovePlayer

    void Attack()
    {
        //Attack timer is set to in game Time
        attackTimer += Time.deltaTime;

        //if attack timer is greater that current Attack Timer, can Attack will be ture
        if(attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }

        //Allows Player To Shoot
        if(Input.GetKey(KeyCode.Space))
        {
            //if can attack is true, the player will shoot, but will also set can attack to false along with restarting the attack timer
            if(canAttack)
            {
                attackTimer = 0f;
                canAttack = false;

                //Instantiate allows objects to be spawned
                Instantiate(bullet, attackPoints.position, Quaternion.identity);
            }
        }
    }//Attack
}
