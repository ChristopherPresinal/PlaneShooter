using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Gun gun;

    //Array that will hold all the guns
    Gun[] guns;


    //Variable for attack cooldown
    public float attackTimer = 0.35f;
    public float currentAttackTimer = 0f;

    private bool canAttack;

    public float moveSpeed = 3;
    float speedMultiplier = 1;

    //Player Input
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    
    //Player Border
    public float minX, maxX, minY, maxY;

    

    // Start is called before the first frame update
    void Start()
    {
        //current attack timer stores the value of the attack timer
        currentAttackTimer = attackTimer;

        //Gets access to all the guns scipts under the player
        guns = transform.GetComponentsInChildren<Gun>();
       
    }

    // Update is called once per frame
    void Update()
    {

        //Player Inputs
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        //speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        MovePlayer();
        
    }

    void MovePlayer()
    {
        //Attack timer is set to in game Time
        attackTimer += Time.deltaTime;

        //Position of the Player
        Vector2 pos = transform.position;
        
        //What will move the player
        float moveAmount = moveSpeed * speedMultiplier * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;
        
        //Functions for player Input
        if(moveUp)
        {
            move.y += moveAmount;

        }

        if(moveDown)
        {
            move.y -= moveAmount;

        }

        if(moveLeft)
        {
            move.x -= moveAmount;
        }

        if(moveRight)
        {
            move.x += moveAmount;
        }

        //normalize speed when moving in an angle
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        //What move thes player
        pos += move;

        //Borders for Player 
        if (pos.x <= minX)
        {
            pos.x = minX;
        }
        if (pos.x >= maxX)
        {
            pos.x = maxX;
        }
        if (pos.y <= minY)
        {
            pos.y = minY;
        }
        if (pos.y >= maxY)
        {
            pos.y = maxY;
        }

        transform.position = pos;


     
        //if attack timer is greater that current Attack Timer, can Attack will be ture
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            //if can attack is true, the player will shoot, but will also set can attack to false along with restarting the attack timer
            if (canAttack)
            {
                attackTimer = 0f;
                canAttack = false;
                gun.Shoot();
            }

        }



    }//MovePlayer
}
