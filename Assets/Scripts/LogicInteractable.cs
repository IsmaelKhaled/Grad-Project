using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicInteractable : MonoBehaviour {

    static bool press = false;
    static bool draw = false;
    static GameObject firstClick;
    static GameObject secondClick;
    bool occupied = false; //added to fix a bug where an input node could have multiple liens connected to it
    bool togColor = true;
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
                togColor = false; //change the color of the firstClick node to remain yellow until a second click is made
                Debug.Log("Wow you just clicked once");
            }
            else if (press && ((gameObject.tag == "Input Node" && !occupied) ||
                            (gameObject.tag == "Output Node"&& firstClick.tag != "Output Node")))
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

                    //revert the firstClick node to its original color after the second click has been made
                    firstClick.GetComponent<SpriteRenderer>().color = origColor;
                    firstClick.GetComponent<LogicInteractable>().togColor = true;
                }
                
                Debug.Log("Wow you just clicked a second time");
            }
        }
    
    }
    void OnMouseExit()
        {
            if(togColor) //revert the node to its original color if the mouse exits the node and hasn't clicked inside
                gameObject.GetComponent<SpriteRenderer>().color = origColor;
        }
}
