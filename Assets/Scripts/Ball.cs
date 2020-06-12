using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Different speeds to add depth to the game
    float[] dirX = { -.08f, -.07f, -.06f, -.05f, .05f, .06f, .07f, .08f };
    float[] dirY = { -.08f, -.07f, -.06f, -.05f, .05f, .06f, .07f, .08f, 0 };
    // Speed of ball;
    float speedX = 0;
    float speedY = 0;
    // starting position
    Vector3 pos = new Vector3(0, 0, 0);



    // Use this for initialization
    void Start()
    {
        //Ball will move in a random direction at the start
        speedX = dirX[(Random.Range(1, 9)) - 1];
        speedY = dirY[(Random.Range(1, 10)) - 1];


    }

    // Update is called once per frame
    void Update()
    {
        //Moves ball once per frame
        transform.Translate(speedX, speedY, 0);

    }

    //Called when ball hits either goal to make new match
    void restart()
    {
        //moves back to 0,0,0
        transform.position = pos;
        //generates new speed for ball
        speedX = dirX[(Random.Range(1, 9)) - 1];
        speedY = dirY[(Random.Range(1, 10)) - 1];

    }

    // Behavior for ball collision
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Paddle_1" || col.gameObject.name == "Paddle_2")
        {
            //reverses X direction and "randomizes" ball Y direction to avoid stalemate of back and forth
            speedX *= -1;
            speedY = dirY[(Random.Range(1, 9)) - 1];
        }
        if (col.gameObject.name == "Boundary_top" || col.gameObject.name == "Boundary_bot")
        {
            //Richochets ball to continue
            speedY *= -1;
        }

        if (col.gameObject.name == "P1_goal" || col.gameObject.name == "P2_goal")
        {
            //call restart
            restart();

        }
    }
}
