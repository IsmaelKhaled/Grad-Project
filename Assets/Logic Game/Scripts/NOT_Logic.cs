using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT_Logic : MonoBehaviour {

    public Transform input;
    public bool output;
    bool isActive = false;

    void Update()
    {

        /*The following part is responsible for actually enforcing the AND gate logic on the object itself
         * outputting the result on the lineValue of the output node.
         */
        input = transform.Find("Input Node");
        if (input.GetComponent<LogicInteractable>().occupied)
            isActive = true;

        if (isActive)
        {
            output = !input.GetComponent<ConnectionControl>().lineValue;
            transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue = output;
        }

    }
}
