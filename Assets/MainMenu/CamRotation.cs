using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
	public float speed=0.01f;
	public Transform target;
	void Update () 
	{
	    transform.LookAt(target);
		transform.RotateAround(target.position, transform.up, Time.deltaTime * speed);
	}

    // Update is called once per frame
}
