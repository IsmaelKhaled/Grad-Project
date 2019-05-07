    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCtrl : MonoBehaviour
{
    List<GameObject> inputs;
    List<GameObject> outputs;
    ConnectionControl A;
    ConnectionControl B;
    ConnectionControl Cin ;
    bool coroutineStarted = false;
    public GameObject completeLevelUI;
    public GameObject help;
    bool S ;
    bool Co;
    public Animator anim;
    GameObject[] gates;
    int currentScene;
    bool fullyConnected = true;
    void Start()
    {
        GameObject[] i = GameObject.FindGameObjectsWithTag("Input Supply");
        inputs = new List<GameObject>(i);
        GameObject[] o = GameObject.FindGameObjectsWithTag("Target");
        outputs = new List<GameObject>(o);
        List<ConnectionControl> inputVals = new List<ConnectionControl>();
        List<ConnectionControl> outputVals = new List<ConnectionControl>();

        gates = GameObject.FindGameObjectsWithTag("Logic Gate");

        foreach (GameObject input in inputs)
        {
            inputVals.Add(input.transform.Find("Output Node").GetComponent<ConnectionControl>());
        }

        foreach (GameObject output in outputs)
        {
            outputVals.Add(output.transform.Find("Input Node").GetComponent<ConnectionControl>());
        }
        currentScene = 1;
         A = inputVals[0];
         B = inputVals[1];
         Cin = inputVals[2];
         S = outputVals[0];
         Co = outputVals[1];

         if (currentScene == 6)
             StartCoroutine("Help");
    }
    void Update()
    {
        foreach(GameObject gate in gates)
            foreach(Transform child in gate.transform)
            {
                if (child.GetComponent<LogicInteractable>().occupied == false)
                    fullyConnected = false;
            }
        if (!coroutineStarted && fullyConnected)
            StartCoroutine(Level1Complete(currentScene));
        fullyConnected = true;
    }



    IEnumerator Level1Complete(int currentScene) // Checks if the level is completed
    {
        coroutineStarted = true;
        bool good = true;
        #region Test Cases 1
        if(currentScene == 6)
        { 
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
        }
        #endregion
        #region Test Cases 2
        else if(currentScene == 5)
        {
            {
                A.lineValue = false;
                B.lineValue = false;
                yield return new WaitForSeconds(0.1f);
                if (CheckCondition(true, true)) 
                {
                    good = false;
                    Debug.Log("Fail 1: " + A.lineValue + " " + B.lineValue +  " " + S + " " + Co + ", good = " + good + ".");
                }
                else
                {
                    Debug.Log("Succeed 1");
                }
            }
            {
                A.lineValue = false;
                B.lineValue = true;
                yield return new WaitForSeconds(0.1f);
                if (CheckCondition(false, true))
                {
                    good = false;
                    Debug.Log("Fail 2: " + A.lineValue + " " + B.lineValue + " " + S + " " + Co + ", good = " + good + ".");
                }
                else
                {
                    Debug.Log("Succeed 2");
                }
            }
            {
                A.lineValue = true;
                B.lineValue = false;
                yield return new WaitForSeconds(0.1f);
                if (CheckCondition(false, true))
                {
                    good = false;
                    Debug.Log("Fail 3: " + A.lineValue + " " + B.lineValue +" " + S + " " + Co + ", good = " + good + ".");
                }
                else
                {
                    Debug.Log("Succeed 3");
                }
            }
            {
                A.lineValue = true;
                B.lineValue = true;
                yield return new WaitForSeconds(0.1f);
                if (CheckCondition(true, false))
                {
                    good = false;
                    Debug.Log("Fail 4: " + A.lineValue + " " + B.lineValue + " " + S + " " + Co + ", good = " + good + ".");
                }
                else
                {
                    Debug.Log("Succeed 4");
                }
            }
        }
        #endregion
        if (good)
            GameOver();

        A.lineValue = false;
        B.lineValue = false;
        Cin.lineValue = false;
       // yield return new WaitForSeconds(4f);
        coroutineStarted = false;
    }
    IEnumerator Fading()
    {
        anim.Play("Fade out");
        yield return new WaitForSeconds(1f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
    IEnumerator Help()
    {
        yield return new WaitForSeconds(60f);
        help.SetActive(true);

    }
    public void StartGame()
    {
        Debug.Log("Loading next scene");
        StartCoroutine("Fading");
    }
    public void GameOver()
    {
        Debug.Log("You win!");
        completeLevelUI.SetActive(true);
        //SceneManager.LoadScene(currentScene + 1);
    }
    bool CheckCondition(bool sVal, bool coVal) //Check the Target nodes against the two given values
    {
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
