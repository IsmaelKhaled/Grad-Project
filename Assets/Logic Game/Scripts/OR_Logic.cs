using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR_Logic : MonoBehaviour
{

    public Transform topInput;
    public Transform botInput;
    public bool output;
    bool isActive = false;

    void Start()
    {
    }

    void Update()
    {

        /*The following part is responsible for actually enforcing the AND gate logic on the object itself
         * by reading the 2 input nodes lineValues and XORing them together,
         * then outputting the result on the lineValue of the output node.
         */
        foreach (Transform child in transform) //loop over the children of the gate object (the nodes whether input or output) and find the input nodes
        {
            if (child.name == "Top Input Node")
                topInput = child;
            else if (child.name == "Bottom Input Node")
                botInput = child;
        }

        if (topInput.GetComponent<LogicInteractable>().occupied && botInput.GetComponent<LogicInteractable>().occupied)
            isActive = true;

        if (isActive)
        {
            output = topInput.GetComponent<ConnectionControl>().lineValue | botInput.GetComponent<ConnectionControl>().lineValue;
            transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue = output;
        }

    }
}
