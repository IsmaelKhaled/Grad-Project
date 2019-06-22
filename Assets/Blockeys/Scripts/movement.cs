using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public int value = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag() //Click and drag for dice
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = (Vector2)objPosition;
    }
}
