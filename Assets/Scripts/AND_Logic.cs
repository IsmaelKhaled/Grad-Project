using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND_Logic : MonoBehaviour {

	public int topInput;
	public int botInput;
	public int output;
	public bool isActive;
	// Use this for initialization
	void Start () {
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive){
			if(topInput == 1 && botInput == 1)
			{	
				output = 1;
			}
			else
			{
				output = 0;
			}
		
		}
	}
}
