using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionControl : MonoBehaviour {

	LineRenderer lineRenderer;
	public GameObject Line;
	// Use this for initialization
	void Start () {
		//  GameObject AND = transform.Find("AND").gameObject;
		// GameObject AND1 = transform.Find("AND (1)").gameObject;
    	// Transform start = AND1.transform.Find("Output Location");
		// Transform end = AND.transform.Find("Top Input Location");
		
		// DrawLine(start.gameObject,end.gameObject,Color.green);
	
	        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void DrawLine(GameObject startObject, GameObject endObject, Color color)
	{
		Vector2 startPosition = startObject.transform.position;
		Vector2 endPosition = endObject.transform.position;
		Vector2 offset = (endPosition - startPosition) / 2.0f;
		Vector2 position = startPosition + offset;
		
		Transform line = Instantiate<GameObject>(Line, Vector3.zero, Quaternion.identity).transform;
		line.GetComponent<Renderer>().material.color = color;

		line.position = position;
		line.LookAt(startPosition);

		Vector3 currentScale = line.localScale;
		currentScale.z = (endPosition - startPosition).magnitude;
		line.localScale = currentScale;
	}

}
