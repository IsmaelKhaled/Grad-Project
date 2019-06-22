using UnityEngine;
using System.Collections;
public class CharacterMovement : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
    }

  

    public void Update()
    {
       /* float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 tempVect = new Vector3(1, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);*/
    }

    void move()
    {

    }
}