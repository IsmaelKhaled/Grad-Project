using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyLogic : MonoBehaviour {

    private GameObject output;
    private bool lineValue;
    private Color origColor;
    private TextMesh supplyText;

    void Start()
    {
        output = transform.Find("Output Node").gameObject;
        supplyText = transform.Find("Supply Text").GetComponent<TextMesh>();

        lineValue = output.GetComponent<ConnectionControl>().lineValue;
        origColor = gameObject.GetComponent<SpriteRenderer>().color;
        supplyText.color = lineValue ? Color.green : Color.red;
    }
	
    void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        if(Input.GetMouseButtonDown(0))
        {
            // Toggle the supply value on click, also change the color of text depending on the value the supply carries.
            lineValue = !lineValue;
            output.GetComponent<ConnectionControl>().lineValue = lineValue;
            supplyText.color = lineValue ? Color.green : Color.red;
        }
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = origColor;
    }
}
