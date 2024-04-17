using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Gun gun;
    public GameObject selectedGun;

    //Array that will hold all the guns
    //Gun[] guns;

    public float moveSpeed = 3;
    float speedMultiplier = 1;

    //Player Input
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;
    
    //Player Border
    public float minX, maxX, minY, maxY;

    

    // Start is called before the first frame update
    void Start()
    {
        //Gets access to all the guns scipts under the player
        //guns = transform.GetComponentsInChildren<Gun>();
       
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

        shoot = Input.GetMouseButtonDown(1);
        if(shoot)
        {
           /* shoot = false; 
            foreach(Gun gun in guns)
            {
                //gun.Shoot();
            }
               */ 
        }

        MovePlayer();
        
    }

    void MovePlayer()
    {

        //Position of the Player
        Vector2 pos = transform.position;

        //What will move the player
        float moveAmount = moveSpeed * speedMultiplier * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        //Functions for player Input
        if (moveUp)
        {
            move.y += moveAmount;

        }

        if (moveDown)
        {
            move.y -= moveAmount;

        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
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

    }//MovePlayer
}
