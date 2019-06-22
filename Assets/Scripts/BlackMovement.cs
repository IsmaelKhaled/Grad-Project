using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour {

    public int value = 4;
    Vector3 mousepos;
    Vector3 clickedPos;
    Vector3 offSet;
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


    /*void OnMouseDown()
    {
        clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offSet = transform.position - clickedPos;

    }*/

    /*void OnMouseDrag()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Round(mousepos.x), Mathf.Round(mousepos.y), 0) + offSet;
    }*/
}


 