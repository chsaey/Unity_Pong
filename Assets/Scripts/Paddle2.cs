using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//copy of Paddle1 but with W and S and movement

public class Paddle2 : MonoBehaviour {
    public float speed = .08f;
    public bool top = false;
    public bool bot = false;
    Vector3 stopB = new Vector3(7, -3.9f, 0);
    Vector3 stopT = new Vector3(7, 3.9f, 0);

    // Use this for initialization
    void Start () {
       
      

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed, 0);
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Boundary_top")
        {
            top = true;
            transform.position = stopT;
        }
        if (col.gameObject.name == "Boundary_bot")
        {
            bot = true;
            transform.position = stopB;
        }

    }
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
