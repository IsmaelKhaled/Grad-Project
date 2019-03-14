using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicInteractable : MonoBehaviour {

    static bool press = false;
    static bool draw = false;
    static GameObject firstClick;
    static GameObject secondClick;
    bool occupied = false;
    Color origColor;
	
    void Start()
    {
        origColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        if(draw)
        {
            gameObject.GetComponent<ConnectionControl>().DrawLine(firstClick, secondClick, Color.red);
            draw = false;
        }

    }
    void OnMouseOver() // responsible for interacting with nodes (click on 2 nodes to draw)
    {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        if (Input.GetMouseButtonDown(0))
        {
            if(!press && ((gameObject.tag == "Input Node" && !occupied) ||
                            gameObject.tag == "Output Node"))
            {

                press = true;
                firstClick = gameObject;
                Debug.Log("Wow you just clicked once");
            }
            else if (press && ((gameObject.tag == "Input Node" && !occupied) ||
                            gameObject.tag == "Output Node"))
            {
                press = false;
                secondClick = gameObject;
                if (firstClick != secondClick && firstClick.tag != secondClick.tag)
                {
                    draw = true;
                    if (firstClick.tag == "Input Node")
                        firstClick.GetComponent<LogicInteractable>().occupied = true;
                    else if(secondClick.tag == "Input Node")
                        secondClick.GetComponent<LogicInteractable>().occupied = true;
                }
                
                Debug.Log("Wow you just clicked a second time");
                
            }
        }
    
    }
    void OnMouseExit()
        {
            gameObject.GetComponent<SpriteRenderer>().color = origColor;
        }
}
