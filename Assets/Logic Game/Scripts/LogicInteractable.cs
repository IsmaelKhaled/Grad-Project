using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicInteractable : MonoBehaviour
{

    static bool press = false;
    static bool draw = false;
    static GameObject firstClick;
    static GameObject secondClick;
    public bool occupied = false; //added to fix a bug where an input node could have multiple liens connected to it
    bool togColor = true;
    Color origColor;
    public bool disabled;

    void Start()
    {
        if (disabled)
            this.enabled = false;
        origColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        if (disabled)
            return;
        if (draw)
        {
            gameObject.GetComponent<ConnectionControl>().CreateLine(firstClick, secondClick);
            draw = false;
        }

        if (press && Input.GetMouseButton(1)) //Cancel first click
        {
            press = false;
            togColor = true;
            firstClick.GetComponent<SpriteRenderer>().color = firstClick.GetComponent<LogicInteractable>().origColor;
            Debug.Log("First click has been cleared!");
        }

    }
    void OnMouseOver() // responsible for interacting with nodes (click on 2 nodes to draw)
    {
        if (disabled)
            return;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        if (Input.GetMouseButtonDown(0))
        {
            if (!press && ((gameObject.tag == "Input Node" && !occupied) ||
                            gameObject.tag == "Output Node"))
            {
                press = true;
                firstClick = gameObject;
                togColor = false; //change the color of the firstClick node to remain yellow until a second click is made
                Debug.Log("Wow you just clicked once");
            }

            else if (press && ((gameObject.tag == "Input Node" && !occupied) ||
                            (gameObject.tag == "Output Node" && firstClick.tag != "Output Node")))
            {
                press = false;
                secondClick = gameObject;
                if (firstClick != secondClick && firstClick.tag != secondClick.tag)
                {
                    if (firstClick.tag == "Input Node") //Swap the nodes if the first click was an input node (First click should always be an output node)
                    {
                        firstClick.GetComponent<LogicInteractable>().occupied = true;
                        secondClick.GetComponent<LogicInteractable>().occupied = true;
                        GameObject temp = firstClick;
                        firstClick = secondClick;
                        secondClick = temp;
                    }
                    else if (secondClick.tag == "Input Node")
                    {
                        secondClick.GetComponent<LogicInteractable>().occupied = true;
                        firstClick.GetComponent<LogicInteractable>().occupied = true;
                    }

                    //revert the firstClick node to its original color after the second click has been made
                    firstClick.GetComponent<SpriteRenderer>().color = firstClick.GetComponent<LogicInteractable>().origColor;
                    firstClick.GetComponent<LogicInteractable>().togColor = true;
                    secondClick.GetComponent<SpriteRenderer>().color = secondClick.GetComponent<LogicInteractable>().origColor;
                    secondClick.GetComponent<LogicInteractable>().togColor = true;

                    draw = true;
                }

                Debug.Log("Wow you just clicked a second time");
            }
        }

    }
    void OnMouseExit()
    {
        if (disabled)
            return;
        if (togColor) //revert the node to its original color if the mouse exits the node and hasn't clicked inside
            gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<LogicInteractable>().origColor;
    }
}
