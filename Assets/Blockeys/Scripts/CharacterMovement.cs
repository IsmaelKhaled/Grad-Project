using UnityEngine;
using System.Collections;
public class CharacterMovement : MonoBehaviour
{
    public GameObject theGrid;
    public float speed = 100;
    public Rigidbody2D rb;


    public delegate void MyMethod();
    public MyMethod val;

    // Use this for initialization
    void Start()
    {
       
    }

  

    public void Update()
    {
       // move();

        //val = theGrid.GetComponent<calcCols>().myList[0];
        /* float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");

         Vector3 tempVect = new Vector3(1, 0, 0);
         tempVect = tempVect.normalized * speed * Time.deltaTime;
         rb.MovePosition(rb.transform.position + tempVect);*/
    }

    void move()
    {
        Debug.Log("MOVE");
        theGrid.GetComponent<calcCols>().Execute();
    }
}