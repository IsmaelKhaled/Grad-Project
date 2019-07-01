using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightFn : MonoBehaviour
{
    public delegate void MoveToRight();
    public MoveToRight value;
    public static GameObject thePlayer;
    public static float speed = 100;
    public static Rigidbody2D rb;
  
    // Start is called before the first frame update
    void Start()
    {
        value = MoveRight;
        thePlayer = GameObject.Find("CharaRef_13");
        rb = thePlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveRight(){

        //Debug.Log("Move Right");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 tempVect = new Vector3(1, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime/2;
        rb.MovePosition(rb.transform.position + tempVect);
        //
    }

    public void MoveLeft(){

        //Debug.Log("Move Right");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 tempVect = new Vector3(-1 , 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime/2;
        rb.MovePosition(rb.transform.position + tempVect);
        //
    }
    



}
