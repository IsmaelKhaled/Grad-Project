using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR_Logic : MonoBehaviour {
    public bool topInput;
    public bool botInput;
    public bool output;


    void Start()
    {
    }

    void Update()
    {

        /*The following part is responsible for actually enforcing the AND gate logic on the object itself
         * by reading the 2 input nodes lineValues and ORing them together,
         * then outputting the result on the lineValue of the output node.
         */
        foreach (Transform child in transform) //loop over the children of the gate object (the nodes whether input or output) and find the input nodes
        {
            if (child.name == "Top Input Node")
                topInput = child.GetComponent<ConnectionControl>().lineValue;
            else if (child.name == "Bottom Input Node")
                botInput = child.GetComponent<ConnectionControl>().lineValue;
        }

        output = topInput | botInput;

        transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue = output;

    }
}
