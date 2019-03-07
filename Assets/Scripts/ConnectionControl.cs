using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionControl : MonoBehaviour {

	public LineRenderer lineRenderer;
	public GameObject Line;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
   

	public void DrawLine(GameObject startObject, GameObject endObject, Color color) // draws a line betwen the center of 2 game objects
	{
		Vector2 startPosition = startObject.transform.position;
		Vector2 endPosition = endObject.transform.position;
        Vector2 offset = (endPosition - startPosition) / 2.0f;
		Vector2 position = startPosition + offset;


        //break line into 3 segments if certain conditions are met
        if (Mathf.Abs(startPosition.y - endPosition.y) > 0.5 && Mathf.Abs(startPosition.x - endPosition.x) > 1)
        {
            Vector2 tempEnd1 = new Vector2(startPosition.x + offset.x / 2.0f, startPosition.y);
            Vector2 tempEnd2 = new Vector2(tempEnd1.x, endPosition.y);
            DrawLine(startPosition, tempEnd1, color);
            DrawLine(tempEnd1,tempEnd2,color);
            DrawLine(tempEnd2, endPosition,color);
            
        }

        else
        {

		    Transform line = Instantiate<GameObject>(Line, Vector3.zero, Quaternion.identity).transform;
		    line.GetComponent<Renderer>().material.color = color;

		    line.position = position;
		    line.LookAt(startPosition);

		    Vector3 currentScale = line.localScale;
		    currentScale.z = (endPosition - startPosition).magnitude;
		    line.localScale = currentScale;
        }
	}

    public void DrawLine(Vector2 startObject, Vector2 endObject, Color color) // draws a line between two 2D points
    {
        Vector2 startPosition = startObject;
        Vector2 endPosition = endObject;
        Vector2 offset = (endPosition - startPosition) / 2.0f;
        Vector2 position = startPosition + offset;


        Transform line = Instantiate<GameObject>(Line, Vector3.zero, Quaternion.identity).transform;
        line.GetComponent<Renderer>().material.color = color;

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
    }

}
