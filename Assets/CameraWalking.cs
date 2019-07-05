using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalking : MonoBehaviour
{	public Vector3 direction;
	public Transform man;
	public Vector3 stop;
	float LastMove=0;
    float stepTime=0.01f;
    float Factor=0.01f;
    // Start is called before the first frame update
    void Start()
    {
         stop = new Vector3(0,0,0);
         direction=stop;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastMove > stepTime)
		{
			LastMove=Time.time;
			man.position += direction *Factor;
		}
		// --- Key Board --- //
        Keyboard();
        if(Input.GetKey(KeyCode.LeftShift))
		{
			Factor=0.1f;
		}
		else if(Input.GetKey(KeyCode.LeftControl))
		{
			Factor=1f;
		}
		else
		{
			Factor=0.01f;
		}
    }
    void Keyboard ()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			man.Rotate(0, 1, 0, Space.Self);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			man.Rotate(0, -1, 0, Space.Self);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			man.Rotate(-1, 0, 0, Space.Self);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			man.Rotate(1, 0, 0, Space.Self);
		}
		if(Input.GetKey(KeyCode.Q))
		{
			man.Rotate(0, 0, 1, Space.Self);
		}
		if(Input.GetKey(KeyCode.E))
		{
			man.Rotate(0, 0, -1, Space.Self);
		}
		//-----------------------------------//
		if(Input.GetKey(KeyCode.D))
        {
        	direction = Vector3.right;
        }
		if(Input.GetKey(KeyCode.W))
        {
        	direction = Vector3.forward;
        }
        if(Input.GetKey(KeyCode.S))
        {
        	direction = Vector3.back;
        }
        if(Input.GetKey(KeyCode.A))
        {
        	direction = Vector3.left;
        }
        if(Input.GetKey(KeyCode.Space))
        {
        	direction = stop;       
        }
        if(Input.GetKey(KeyCode.PageDown))
        {
        	direction = Vector3.down;       
        }
        if(Input.GetKey(KeyCode.PageUp))
        {
        	direction = Vector3.up;       
        }
	}
}
