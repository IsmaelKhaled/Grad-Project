
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCtrl : MonoBehaviour
{
    List<GameObject> inputs;
    List<GameObject> outputs;
    ConnectionControl A;
    ConnectionControl B;
    ConnectionControl Cin ;
    bool coroutineStarted = false;
    public GameObject completeLevelUI;
    public bool S ;
    public bool Co;
    void Start()
    {
        GameObject[] i = GameObject.FindGameObjectsWithTag("Input Supply");
        inputs = new List<GameObject>(i);
        GameObject[] o = GameObject.FindGameObjectsWithTag("Target");
        outputs = new List<GameObject>(o);
         List<ConnectionControl> inputVals = new List<ConnectionControl>();
        List<ConnectionControl> outputVals = new List<ConnectionControl>();

        foreach (GameObject input in inputs)
        {
            inputVals.Add(input.transform.Find("Output Node").GetComponent<ConnectionControl>());
        }

        foreach (GameObject output in outputs)
        {
            outputVals.Add(output.transform.Find("Input Node").GetComponent<ConnectionControl>());
        }

         A = inputVals[0];
         B = inputVals[1];
         Cin = inputVals[2];
         S = outputVals[0];
         Co = outputVals[1];
    }
    void Update()
    {
        if (!coroutineStarted)
            StartCoroutine("LevelComplete");
    }



    IEnumerator LevelComplete() // Checks if the level is completed
    {
        coroutineStarted = true;
        bool good = true;

        //Case 1
        {

            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(true, true)) 
            {
                good = false;
                Debug.Log("Fail 1: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 1");
            }
        }

        //Case 2
        {
            Cin.lineValue = true;

            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(false,true))
            {
                good = false;
                Debug.Log("Fail 2: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 2");
            }
        }

        //Case 3
        {
            A.lineValue = false;
            B.lineValue = true;
            Cin.lineValue = false;
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(false, true))
            {
                good = false;
                Debug.Log("Fail 3: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 3");
            }
        }
        //Case 4
        {
            A.lineValue = false;
            B.lineValue = true;
            Cin.lineValue = true;
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(true, false))
            {
                good = false;
                Debug.Log("Fail 4: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 4");
            }
        }

        //Case 5
        {
            A.lineValue = true;
            B.lineValue = false;
            Cin.lineValue = false;
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(false, true))
            {
                good = false;
                Debug.Log("Fail 5: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 5");
            }
        }
        //Case 6
        {
            A.lineValue = true;
            B.lineValue = false;
            Cin.lineValue = true;
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(true, false))
            {
                good = false;
                Debug.Log("Fail 6: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 6");
            }
        }
        //Case 7
        {
            A.lineValue = true;
            B.lineValue = true;
            Cin.lineValue = false;
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(true, false))
            {
                good = false;
                Debug.Log("Fail 7: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 7");
            }
        }
        //Case 8
        {
            A.lineValue = true;
            B.lineValue = true;
            Cin.lineValue = true; 
            yield return new WaitForSeconds(0.1f);
            if (CheckCondition(false, false))
            {
                good = false;
                Debug.Log("Fail 8: " + A.lineValue + " " + B.lineValue + " " + Cin.lineValue + " " + S + " " + Co + ", good = " + good + ".");
            }
            else
            {
                Debug.Log("Succeed 8");
            }
        }

        if(good)
            GameOver();

        A.lineValue = false;
        B.lineValue = false;
        Cin.lineValue = false;
        yield return new WaitForSeconds(4f);
        coroutineStarted = false;
    }
    public void GameOver()
    {

        Debug.Log("You win!");
        completeLevelUI.SetActive(true);
       // SceneManager.LoadScene(1);
    }
    void UpdateAllLines()
    {
        GameObject[] allLines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in allLines)
        {
            line.GetComponent<ConnectionControl>().UpdateLines();
        }
    }
    bool CheckCondition(bool sVal, bool coVal) //Check the Target nodes against the two given values
    {
        for (int i = 0; i < 10;i++)
            UpdateAllLines();
        FetchTargets(ref S, ref Co);
        if (S == sVal || Co == coVal)
            return true;
        else
            return false;
    }
    void FetchTargets(ref bool S,ref bool Co) //Fetches the current values of the target nodes.
    {
        List<ConnectionControl> outputVals = new List<ConnectionControl>();
        foreach (GameObject output in outputs)
        {
            outputVals.Add(output.transform.Find("Input Node").GetComponent<ConnectionControl>());
        }

        S = outputVals[0].lineValue;
        Co = outputVals[1].lineValue;
    }
}
