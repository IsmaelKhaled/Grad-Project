using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineType : MonoBehaviour
{
    //a class holding all the attributes associated with lines for ease of use
    //public string type;
    public GameObject startNode;
    public GameObject endNode;
    public Vector2 startPos;
    public Vector2 endPos;
    public bool lineValue;
   // public List<GameObject> segments;

    void OnMouseOver()
    {
        transform.GetComponent<LineRenderer>().material.color = Color.yellow;
        if(Input.GetMouseButtonDown(1))
        {
            startNode.GetComponent<LogicInteractable>().occupied = false;
            endNode.GetComponent<LogicInteractable>().occupied = false;
            endNode.GetComponent<ConnectionControl>().lineValue = false;
            Destroy(gameObject);
        }
    }
}
