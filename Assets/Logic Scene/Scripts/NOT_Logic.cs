using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT_Logic : MonoBehaviour {

    public bool input;
    public bool output;

    void Update()
    {

        /*The following part is responsible for actually enforcing the AND gate logic on the object itself
         * outputting the result on the lineValue of the output node.
         */
        foreach (Transform child in transform) //loop over the children of the gate object (the nodes whether input or output) and find the input nodes
        {
            if (child.name == "Input Node")
                input = child.GetComponent<ConnectionControl>().lineValue;
        }

        output = !input;

        transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue = output;

    }
}
