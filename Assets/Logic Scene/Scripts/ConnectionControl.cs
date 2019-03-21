using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionControl : MonoBehaviour {
    
    public GameObject linePrefab;
    public bool lineValue;
    	
	void FixedUpdate () {
        UpdateLines();
	}
   

	public GameObject CreateLine(GameObject startObject, GameObject endObject) // draws a line betwen the center of 2 game objects
	{
        Vector2 startPosition = startObject.transform.position;
		Vector2 endPosition = endObject.transform.position;
        Vector2 offset = (endPosition - startPosition);
        
        GameObject currentLine = Instantiate<GameObject>(linePrefab);
        LineRenderer lr = currentLine.GetComponent<LineRenderer>();

        LineType lineProperties = currentLine.GetComponent<LineType>();
        lineProperties.lineValue = startObject.GetComponent<ConnectionControl>().lineValue;
        lineProperties.startNode = startObject;
        lineProperties.endNode = endObject;


        //break line into 3 segments if certain conditions are met (Condition currently not active, it auto breaks lines into segments.)
        if (startPosition.x < endPosition.x || (startPosition.x > endPosition.x && startObject.tag == "Input Node"))
        {
            Vector2 tempEnd1 = new Vector2(Random.Range(startPosition.x + offset.x / 6.0f,startPosition.x + offset.x / 2.0f), startPosition.y);
            Vector2 tempEnd2 = new Vector2(tempEnd1.x, endPosition.y);

            Vector3[] positions = GetPosArray(startPosition, tempEnd1, tempEnd2, endPosition);

            lr.positionCount = positions.Length;
            lr.SetPositions(positions);
        }

        else if (startPosition.x > endPosition.x) //first click x position is higher than the second click x position, the line should be broken into 5 segments(6 points)
        {
            Vector2 tempEnd1 = new Vector2(startPosition.x + Random.Range(0.5f, 1.5f), startPosition.y);
            Vector2 tempEnd2 = new Vector2(tempEnd1.x, startPosition.y + (endPosition.y - startPosition.y) / Random.Range(2f, 4f));
            Vector2 tempEnd3 = new Vector2(endPosition.x - Random.Range(0.5f, 1.5f), tempEnd2.y);
            Vector2 tempEnd4 = new Vector2(tempEnd3.x, endPosition.y);

            Vector3[] positions = GetPosArray(startPosition,tempEnd1,tempEnd2,tempEnd3,tempEnd4,endPosition);

            lr.positionCount = positions.Length;
            lr.SetPositions(positions);
           

        }
        return currentLine.gameObject;
	}



    //-----------------THIS FUNCTION IS NOW USELESS AND SHOULD BE REMOVED LATER--------------------------


    //public GameObject DrawLine(Vector2 startObject, Vector2 endObject, Color color) // draws a line between two 2D points
    //{
    //    Vector2 startPosition = startObject;
    //    Vector2 endPosition = endObject;
    //    Vector2 offset = (endPosition - startPosition) / 2.0f;
    //    Vector2 position = startPosition + offset;
        
        

    //    Transform line = Instantiate<GameObject>(linePrefab, Vector3.zero, Quaternion.identity).transform;
    //    line.GetComponent<Renderer>().material.color = color;

    //    line.GetComponent<LineType>().startPos = startPosition;
    //    line.GetComponent<LineType>().endPos = endPosition;

    //    //set line position to the midpoint between start and end point
    //    line.position = position;
    //    //set the forward vector on the line to look towards the start position (might cause issues later?)
    //    //the lines that follow are because there was a bug if the line was vertical its Y rotation was messed up.
    //    line.LookAt(startPosition);
    //    Vector2 rot = line.localRotation.eulerAngles;
    //    rot.Set(rot.x, 90);
    //    line.localRotation = Quaternion.Euler(rot);

    //    //set line scale
    //    Vector3 currentScale = line.localScale;
    //    currentScale.z = (endPosition - startPosition).magnitude;
    //    line.localScale = currentScale;
    //    return line.gameObject;
    //}

    //-------------------------------------------------------------------------

    private void UpdateLines() //Updates line color and node/line lineValues
    {
        if (transform.tag == "Line")
        {
            //set the line lineValue to the start node lineValue
            transform.GetComponent<LineType>().lineValue = transform.GetComponent<LineType>().startNode.GetComponent<ConnectionControl>().lineValue;
            //set the endNode lineValue to the line lineValue
            transform.GetComponent<LineType>().endNode.GetComponent<ConnectionControl>().lineValue = transform.GetComponent<LineType>().lineValue;

            // Color the line to green if the line holds a "High"(Vcc) lineValue (true) or red if it holds a "Low"(Gnd) lineValue (false)
            Color color = Color.red;
            if (transform.GetComponent<LineType>().lineValue == false)
                color = Color.red;
            else
                color = Color.green;
            transform.GetComponent<LineRenderer>().material.color = color;
        }
    }

    private Vector3[] GetPosArray(params Vector3[] pos)
        /*
          Places all the positions given as parameters in an array
          and returns it to later be set as positions for vertices of the Line Renderer.
        */
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (Vector3 p in pos)
        {
            positions.Add(p);
        }
        return positions.ToArray();
    }

}
