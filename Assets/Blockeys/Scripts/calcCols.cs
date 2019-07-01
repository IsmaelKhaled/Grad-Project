using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class calcCols : MonoBehaviour {
    // this script is responsible for calculating the column sums and scoring so far
    public int[] columnSums = new int [6];
//    public delegate void MyMethod();
//   public List<MyMethod> myList = new List<MyMethod>();
    public GameObject thePlayer;
    public int[] rowSums = new int[6];
    public float timer;
    public Text[] columnValues;
    private AudioSource source;
    public AudioClip scoredten;
    List<List<GameObject>> columnCells = new List<List<GameObject>>();
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

        for (int i = 0; i < 6;i++ ) // retarded way because im lazy
            columnCells.Add(new List<GameObject>());
        foreach (Transform child1 in transform) //Add the cells of a column to a list, unefficient way but works
            {
                foreach (Transform child in child1.transform)
                {
                    if (child.GetComponent<cell>().id % 5 == 0)
                        columnCells[5].Add(child.gameObject);
                    else if (child.GetComponent<cell>().id % 5 == 1)
                        columnCells[1].Add(child.gameObject);
                    else if (child.GetComponent<cell>().id % 5 == 2)
                        columnCells[2].Add(child.gameObject);
                    else if (child.GetComponent<cell>().id % 5 == 3)
                        columnCells[3].Add(child.gameObject);
                    else if (child.GetComponent<cell>().id % 5 == 4)
                        columnCells[4].Add(child.gameObject);
                }
            }
	}


    List<Action> MyFunctions = new List<Action>();
    

/*    public void RunFns() //executes all the functions in actions list
    {
        foreach (var RunFn in MyFunctions)
        {
            Debug.Log("i work");
            RunFn();
        }
    }*/


    public void Execute() {
        Debug.Log("Execute");
                //Debug.Log(transform);
        foreach (Transform child1 in transform) //Add the cells of a column to a list, unefficient way but works
        {
          

            foreach (Transform child in child1.transform)
            {
                if (child.GetComponent<cell>().val != null)
                {
                    child.GetComponent<cell>().val();
                    
                   
                }
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if ((Time.time - timer) >= 0.1)
        {
            timer = Time.time;

           
            

        }
	}

  /*public void AddDelegates() // sums the values on cells in a column
    {
        

        int[] colSums = new int[6];
        int i=0;
        foreach (Transform child1 in transform)
         {
             rowSums[i + 1] = child1.GetComponent<calc>().rowSum;
            foreach (Transform child in child1.transform)
            {
                if (child.GetComponent<cell>().id % 5 == 0) {
                    // colSums[5] += child.GetComponent<cell>().value;

                    //myList.Add(child.GetComponent<cell>().val);

                }
                else if (child.GetComponent<cell>().id % 5 == 1) {
                    // colSums[1] += child.GetComponent<cell>().value;
                    Debug.Log(child.GetComponent<cell>().id);
                Debug.Log(child.GetComponent<cell>());
                //myList.Add(child.GetComponent<cell>().val);
            }
                else if (child.GetComponent<cell>().id % 5 == 2)
                    //colSums[2] += child.GetComponent<cell>().value;
                    //myList.Add(child.GetComponent<cell>().val);
                else if (child.GetComponent<cell>().id % 5 == 3)
                    //   colSums[3] += child.GetComponent<cell>().value;
                    //myList.Add(child.GetComponent<cell>().val);
                else if (child.GetComponent<cell>().id % 5 == 4)
                    //  colSums[4] += child.GetComponent<cell>().value;
                    //myList.Add(child.GetComponent<cell>().val);
            }
            i++;    
            }
        return myList;
    }*/

    /*void gotTen() // Detect if a 10 is scored on a row or column (currently bugged, only detects and destroys columns if row & column are both 10
    {
        
        //for (int i=1;i<=5;i++)
        //{
        //    if(rowSums[i]==10)
        //    {
        //        Debug.Log("Got ten at row " + i + "!");
        //    }
        //}
        List<GameObject> toDestroy = new List<GameObject>();
        foreach(Transform child in transform)
        {
            if(child.GetComponent<calc>().rowSum==10)
            {
                foreach (Transform child1 in child.transform)
                {
                    GameObject collidingObject = child1.GetComponent<cell>().collidingObject;
                    if (collidingObject != null)
                        if(!toDestroy.Contains(collidingObject))
                            toDestroy.Add(collidingObject);
                    source.PlayOneShot(scoredten, .5f);
                }
            }
        }
        for(int i =1;i<=5;i++)
        {
             if(columnSums[i]==10)
             {
                 for (int j=0;j<5;j++)
                 {
                     GameObject collidingObject = columnCells[i][j].GetComponent<cell>().collidingObject;
                     if (collidingObject != null)
                         if (!toDestroy.Contains(collidingObject))
                             toDestroy.Add(collidingObject);
                    source.PlayOneShot(scoredten, .5f);

                }
             }
        }


        foreach (GameObject ob in toDestroy)
        {
            Debug.Log(ob.name);
            Destroy(ob);
        }
    }*/
}
