using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionControl : MonoBehaviour {

	public LineRenderer lineRenderer;
	public GameObject Line;
    public bool lineValue;

	void Start () {
        lineValue = false;
	}
	
	void Update () {
        if (transform.tag == "Line")
        {
            transform.GetComponent<LineType>().lineValue = transform.GetComponent<LineType>().startNode.GetComponent<ConnectionControl>().lineValue;
            transform.GetComponent<LineType>().endNode.GetComponent<ConnectionControl>().lineValue = transform.GetComponent<LineType>().lineValue;
        }

        // Color the line to green if the line holds a "High"(Vcc) lineValue (true) or red if it holds a "Low"(Gnd) lineValue (false)
        if (transform.tag == "Line")
        {
            Color color = Color.red;
            if (transform.GetComponent<LineType>().lineValue == false)
                color = Color.red;
            else
                color = Color.green;
            foreach (Transform child in transform)
                child.GetComponent<Renderer>().material.color = color;
        }
	}
   

	public GameObject DrawLine(GameObject startObject, GameObject endObject, Color color) // draws a line betwen the center of 2 game objects
	{
        Vector2 startPosition = startObject.transform.position;
		Vector2 endPosition = endObject.transform.position;
        Vector2 offset = (endPosition - startPosition) / 2.0f;



        Transform line = Instantiate<GameObject>(Line, Vector3.zero, Quaternion.identity).transform;
        line.GetComponent<Renderer>().enabled = false;

        LineType lineProperties = line.GetComponent<LineType>();

        lineProperties.lineValue = startObject.GetComponent<ConnectionControl>().lineValue;
        lineProperties.startNode = startObject;
        lineProperties.endNode = endObject;
        lineProperties.type = "Line";


        //break line into 3 segments if certain conditions are met (Condition currently not active, it auto breaks lines into segments.)
        if (startPosition.x < endPosition.x)
        {
            Vector2 tempEnd1 = new Vector2(Random.Range(startPosition.x + offset.x / 6.0f,startPosition.x + offset.x / 2.0f), startPosition.y);
            Vector2 tempEnd2 = new Vector2(tempEnd1.x, endPosition.y);


            color = Color.blue; //just a default value, will be automatically modified in Update to red/green based on true/false

            GameObject line1 = DrawLine(startPosition, tempEnd1, color);
            GameObject line2 = DrawLine(tempEnd1, tempEnd2, color);
            GameObject line3 = DrawLine(tempEnd2, endPosition, color);

            line1.transform.SetParent(line);
            line2.transform.SetParent(line);
            line3.transform.SetParent(line);

            line1.GetComponent<ConnectionControl>().enabled = false;
            line2.GetComponent<ConnectionControl>().enabled = false;
            line3.GetComponent<ConnectionControl>().enabled = false;

            lineProperties.segments.Add(line1);
            lineProperties.segments.Add(line2);
            lineProperties.segments.Add(line3);

        }

        else if(startPosition.x > endPosition.x)
        {
            Vector2 tempEnd1 = new Vector2(startPosition.x + Random.Range(0.5f,1.5f), startPosition.y);
            Vector2 tempEnd2;
            if(startPosition.y > endPosition.y)
                tempEnd2 = new Vector2(tempEnd1.x, startPosition.y - (startPosition.y - endPosition.y) / Random.Range(2f, 4f));
            else
                tempEnd2 = new Vector2(tempEnd1.x, startPosition.y+(endPosition.y-startPosition.y)/Random.Range(2f,4f));
            Vector2 tempEnd3 = new Vector2(endPosition.x - Random.Range(0.5f, 1.5f), tempEnd2.y);
            Vector2 tempEnd4 = new Vector2(tempEnd3.x, endPosition.y);


            color = Color.blue; //just a default value, will be automatically modified in Update to red/green based on true/false

            GameObject line1 = DrawLine(startPosition, tempEnd1, color);
            GameObject line2 = DrawLine(tempEnd1, tempEnd2, color);
            GameObject line3 = DrawLine(tempEnd2, tempEnd3, color);
            GameObject line4 = DrawLine(tempEnd3, tempEnd4, color);
            GameObject line5 = DrawLine(tempEnd4, endPosition, color);

            line1.transform.SetParent(line);
            line2.transform.SetParent(line);
            line3.transform.SetParent(line);
            line4.transform.SetParent(line);
            line5.transform.SetParent(line);

            line1.GetComponent<ConnectionControl>().enabled = false;
            line2.GetComponent<ConnectionControl>().enabled = false;
            line3.GetComponent<ConnectionControl>().enabled = false;
            line4.GetComponent<ConnectionControl>().enabled = false;
            line5.GetComponent<ConnectionControl>().enabled = false;

            lineProperties.segments.Add(line1);
            lineProperties.segments.Add(line2);
            lineProperties.segments.Add(line3);
            lineProperties.segments.Add(line4);
            lineProperties.segments.Add(line5);


        }

        // the section below is deactivated (it was responsible of connecting lines straight without having to break it into segments, but it looked poor)

        //else 
        //{
        //    line.GetComponent<Renderer>().material.color = color;

        //    line.position = position;
        //    line.LookAt(startPosition);

        //    Vector3 currentScale = line.localScale;
        //    currentScale.z = (endPosition - startPosition).magnitude;
        //    line.localScale = currentScale;
        //    line.GetComponent<Renderer>().enabled = true;
        //}
        return line.gameObject;
	}

    public GameObject DrawLine(Vector2 startObject, Vector2 endObject, Color color) // draws a line between two 2D points
    {
        Vector2 startPosition = startObject;
        Vector2 endPosition = endObject;
        Vector2 offset = (endPosition - startPosition) / 2.0f;
        Vector2 position = startPosition + offset;
        
        

        Transform line = Instantiate<GameObject>(Line, Vector3.zero, Quaternion.identity).transform;
        line.GetComponent<Renderer>().material.color = color;

        line.GetComponent<LineType>().startPos = startPosition;
        line.GetComponent<LineType>().endPos = endPosition;
        line.GetComponent<LineType>().type = "Segment";

        //set line position to the midpoint between start and end point
        line.position = position;
        //set the forward vector on the line to look towards the start position (might cause issues later?)
        //the lines that follow are because there was a bug if the line was vertical its Y rotation was messed up.
        line.LookAt(startPosition);
        Vector2 rot = line.localRotation.eulerAngles;
        rot.Set(rot.x, 90);
        line.localRotation = Quaternion.Euler(rot);

        //set line scale
        Vector3 currentScale = line.localScale;
        currentScale.z = (endPosition - startPosition).magnitude;
        line.localScale = currentScale;
        return line.gameObject;
    }

}
