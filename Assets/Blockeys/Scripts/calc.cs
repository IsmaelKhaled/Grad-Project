using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calc : MonoBehaviour {
    //this script calculates the sum of a row
    public int rowSum = 0;
    public GameObject[] cells;
    public Text sumValue;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
      //  rowSum = sumRowVals();
     //   sumValue.text = rowSum.ToString(); //update row sum in UI
	}

   /* int sumRowVals()
    {
       int sum = 0;
       foreach (GameObject c in cells)
       {
           sum += c.GetComponent<cell>().value;
       }
       return sum;
    }*/

    

}
