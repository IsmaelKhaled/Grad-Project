using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

    private List<GameObject> inputs;
    private List<GameObject> outputs;

    void Start()
    {
        GameObject[] i = GameObject.FindGameObjectsWithTag("Input Supply");
        inputs = new List<GameObject>(i);
        GameObject[] o = GameObject.FindGameObjectsWithTag("Target");
        outputs = new List<GameObject>(o);
    }
    void Update()
    {
        if (LevelComplete())
            SceneManager.LoadScene(1);
    }



    bool LevelComplete() // This should check if the level is completed, currently not working
    {
        bool good = true;
        List<bool> inputVals = new List<bool>();
        List<bool> outputVals = new List<bool>();

        foreach (GameObject input in inputs)
        {
            inputVals.Add(input.transform.Find("Output Node").GetComponent<ConnectionControl>().lineValue);
        }

        foreach (GameObject output in outputs)
        {
            outputVals.Add(output.transform.Find("Input Node").GetComponent<ConnectionControl>().lineValue);
        }

        bool A = inputVals[0];
        bool B = inputVals[1];
        bool Cin = inputVals[2];
        bool S = outputVals[0];
        bool Co = outputVals[1];



        if (((A ^ B) ^ Cin != S) ||
            (((A & B) | (Cin & (A ^ B)))!= Co))
            good = false;
        


        return good;
    }
}
