using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class DoorOpen : MonoBehaviour
{
    public Vector3 OpenForce;
    public Vector3 CloseForce;
    bool Open = true;
    Rigidbody body;
    HingeJoint hinge;
    public float MaxAngle = 85;
    public float MinAngle = 0.5f;
    public bool Locked = false;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }
    private void Update()
    {
        /*Debug.Log(body.velocity);*/
        //Debug.Log(transform.localEulerAngles);
        if((transform.localEulerAngles.z >= MaxAngle || transform.localEulerAngles.z <= MinAngle) && body.angularVelocity != Vector3.zero && body.velocity != Vector3.zero)
        {
            body.angularVelocity = Vector3.zero;
            body.velocity = Vector3.zero;
        }
        /*if(transform.eulerAngles.y%180 >= 94 && Open == false)
        {
            body.AddForce(OpenForce*-1, ForceMode.Impulse);
        }
        if (transform.eulerAngles.y % 180 <= 0 && Open == true)
        {
            body.AddForce(CloseForce*-1, ForceMode.Impulse);
        }*/
        
    }
    private void OnMouseDown()
    {
        if (!Locked)
        {

            if (Open)
            {
                if (body.angularVelocity != Vector3.zero && body.velocity != Vector3.zero)
                {
                    body.AddForce(CloseForce * -1, ForceMode.Impulse);
                }
                body.AddForce(OpenForce, ForceMode.Impulse);
                Open = false;
            }
            else if (!Open)
            {
                if (body.angularVelocity != Vector3.zero && body.velocity != Vector3.zero)
                {
                    body.AddForce(OpenForce * -1, ForceMode.Impulse);
                }
                body.AddForce(CloseForce, ForceMode.Impulse);
                Open = true;
            }
        }
    }
}
