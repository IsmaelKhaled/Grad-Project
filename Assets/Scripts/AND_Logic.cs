using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND_Logic : MonoBehaviour {

	public bool topInput;
	public bool botInput;
	public bool output;
	public bool isActive;
	// Use this for initialization
	void Start () {
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if(isActive)
        foreach (Transform child in transform)
        {
            if (child.name == "Top Input Node")
                topInput = child.GetComponent<ConnectionControl>().lineValue;
            else if(child.name == "Bottom Input Node")
                botInput = child.GetComponent<ConnectionControl>().lineValue;               
        }


		if(topInput == true && botInput == true)
		{	
			output = true;
		}
		else
		{
			output = false;
		}

        transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue = output;

	}
}
