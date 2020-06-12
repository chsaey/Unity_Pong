using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    //Paddle speed
    public float speed = .08f;
    //used for testing
    public bool top = false;
    public bool bot = false;
    //Slight problem with paddle not colliding properly. This fixes it so it will atleast collide by moving paddle in bounds if collision.
    Vector3 stopB = new Vector3(-7, -3.9f, 0);
    Vector3 stopT = new Vector3(-7, 3.9f, 0);


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //controls for paddle
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed, 0);

        }
    }
    //collision detection
    void OnCollisionStay(Collision col)
    {   //checks top collision
        if (col.gameObject.name == "Boundary_top")
        {
            top = true;
            transform.position = stopT;
        }
        //checks top collision
        if (col.gameObject.name == "Boundary_bot")
        {
            bot = true;
            transform.position = stopB;
        }

    }

    //testing
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Boundary_top")
        {
            top = false;
        }
        if (col.gameObject.name == "Boundary_bot")
        {
            bot = false;
        }

    }

}
