using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineType : MonoBehaviour
{
    //a class holding all the attributes associated with lines for ease of use
    public GameObject startNode;
    public GameObject endNode;
    public Vector2 startPos;
    public Vector2 endPos;
    public bool lineValue;
    GameObject[] allLines;

    void Update()
    {
        allLines = GameObject.FindGameObjectsWithTag("Line");
    }
    void OnMouseOver()
    {
        transform.GetComponent<LineRenderer>().material.color = Color.yellow;
        if(Input.GetMouseButtonDown(1))
        {
            bool occupiedMoreThanOnce = false;
            foreach(GameObject line in allLines)
            {
                GameObject sNode = line.GetComponent<LineType>().startNode;
                if (startNode == sNode && line.GetComponent<LineType>() != transform.GetComponent<LineType>())
                    occupiedMoreThanOnce = true;
            }
            if(!occupiedMoreThanOnce)
                startNode.GetComponent<LogicInteractable>().occupied = false;

            endNode.GetComponent<LogicInteractable>().occupied = false;
            endNode.GetComponent<ConnectionControl>().lineValue = false;
            Destroy(gameObject);
        }
    }
}
