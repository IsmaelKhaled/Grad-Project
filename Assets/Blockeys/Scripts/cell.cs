using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class cell : MonoBehaviour {

   
    public int id;
    public GameObject theGrid;

    public delegate void MyMethod();
    public MyMethod val;


    bool collided = false;
    public GameObject collidingObject; // used in calcCols to get colliding object (the die) in a cell
    private AudioSource source;
    public AudioClip moveDice;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
       
    }
	
	// Update is called once per frame
	void Update () {
        if (collidingObject == null)
            collided = false;
	}




    void OnTriggerStay2D(Collider2D col) //When a dice enters a cell (and the mouse is not held anymore)
    {
        if (!collided && !Input.GetKey(KeyCode.Mouse0))
        {
            if (col.tag == "Right")
            {
                val = new MyMethod(col.GetComponent<MoveRightFn>().MoveRight);
            }
            else if (col.tag == "Left")
            {
                val = new MyMethod(col.GetComponent<MoveRightFn>().MoveLeft);
            }

            //Debug.Log(val);
            //this.val();
            collided = true;
            collidingObject = col.gameObject;
            collidingObject.transform.position = transform.position;
            source.PlayOneShot(moveDice, 1);
            theGrid.GetComponent<calcCols>().Execute();


        }
    }
    void OnTriggerExit2D(Collider2D col) //If a dice enters a cell but is just passing through, ignore it
    {
        if (collided && collidingObject == col.gameObject)
        {
           
            collided = false;
            collidingObject = null;
        }
    }
}
