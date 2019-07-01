        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;


public class Block
{
    public GameObject myBlock;
    public Block Father;
    public Block[] CollidingChildren = new Block[10];
    public string type = "";
    public bool isConditioned = false;
    public Block() { }
    public int kidOrder = 0;

    
}

public class BlocksConnect : MonoBehaviour
{
    public Vector3 myCollider;
    public int extensions = 1;
    public GameObject tembo;
    public GameObject Nike;
    private Object thisLock = new Object();
    public Button mybotton;
    public   GameObject thePlayer;
    public static float speed = 100;
    public static Rigidbody2D rb;
    public GameObject MyMain;
    //public GameObject IncreaseBy1;
    public Vector3 tempVect;
    public static int BlockCounter;
    public int kid = 0; 
        
    bool collided = false;
    public GameObject collidingObject;

    // private BoxCollider MyCol;

    public GameObject MainBlock;
    public GameObject Bottom    ;
    public GameObject Neck, targetObj, target;


    public Button submit, cancel;
    public InputField input;
    float y = 0, y2 = 0;
   
    float yfor = 0, yfor2 = 0;
    int MainChilds = 0;
    
   // public Block DirectChild = new Block();
    public Block ParentBlock = new Block();
    public Block FatherInLaw = new Block();
    public GameObject temp;
    public int h = 1;
    bool AddedChild = false;
    string oldValue = "";
    public string[] instructions = new string[100];
    public int currentInstruction=0;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("CharaRef_13");
        rb = thePlayer.GetComponent<Rigidbody2D>();
        BlockCounter = 0;
        ParentBlock.myBlock = gameObject;
       // DirectChild.myBlock = gameObject;
        /*  Bottom = MainBlock.transform.GetChild(1).gameObject;

         y2 = Bottom.transform.position.y;
         yfor = Neck.transform.position.y;
         */
    }

    // Update is called once per frame
    void Update()
    {
        

        if (collidingObject == null)
            collided = false;
        submit.onClick.AddListener(submittask);
        cancel.onClick.AddListener(canceltask);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    target = hit.transform.gameObject;
                    {
                        if (target.tag == "value")
                        {
                            Debug.Log("This is a value");
                            submit.gameObject.SetActive(true);
                            input.gameObject.SetActive(true);
                            cancel.gameObject.SetActive(true);
                            oldValue = target.GetComponentInChildren<TextMeshPro>().text;
                            input.text = oldValue;
                            targetObj = target;
                            
                        }
                        if (target.tag == "variable")
                        {if (gameObject.tag == "myMain")
                            {
                                analyzeBlock(ParentBlock);
                            }
                            Debug.Log("This is a variable");
                            execute();
                        }
                    }
                }
            }
        }
    }
    void submittask()
    {
        submit.gameObject.SetActive(false);
        input.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
        Debug.Log("GOOD");
        targetObj.GetComponentInChildren<TextMeshPro>().text = input.text;
    }
    void canceltask()
    {
        submit.gameObject.SetActive(false);
        input.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
        Debug.Log("cancel");
        targetObj.GetComponentInChildren<TextMeshPro>().text = oldValue;
    }
/*    public void OnTriggerEnter(Collider col) //When a dice enters a cell (and the mouse is not held anymore)

    {
        for (int i = 0; i < ParentBlock.CollidingChildren.Length; i += 1)
        {
            if (ParentBlock.CollidingChildren[i].myBlock != null)
            {
                Debug.Log(ParentBlock.CollidingChildren[0].myBlock);
            }
;
        }
    }*/
    void execute()
    {
        for (int i = 0; i < instructions.Length; i += 1)
        {
            if(instructions[i]!="" && instructions[i]!=null)
            if (instructions[i] == "moveright")
            {
                Invoke("MoveRight",i/2f);
            }
            else if (instructions[i] == "moveleft")
            {
                Invoke("MoveLeft", i / 2f);
            }
            else if (instructions[i] == "moveup")
            {
                Invoke("MoveUp", i / 2f);
            }
            else if (instructions[i] == "movedown")
            {
                Invoke("MoveDown", i / 2f);
            }

        }

        

    }

    public void OnTriggerStay(Collider col) //When a dice enters a cell (and the mouse is not held anymore)
    {

       
        if (gameObject.tag == "myMain")
        {
            if (!collided && !Input.GetKey(KeyCode.Mouse0))
            {
                
        
                collidingObject = col.gameObject;
                Block DirectChild = new Block();
                DirectChild.myBlock = collidingObject;
                DirectChild.Father = ParentBlock;
                if (collidingObject.tag == "3Bar")
                {
                    collidingObject.GetComponent<BlocksConnect>().FatherInLaw = ParentBlock;
                    collidingObject.GetComponent<BlocksConnect>().ParentBlock.kidOrder = BlockCounter;
                }
                if (FatherInLaw != null)
                {

                    ParentBlock.Father = FatherInLaw;
                }
                
                DirectChild.type = collidingObject.name;
                DirectChild.kidOrder = BlockCounter;
                    ParentBlock.CollidingChildren[BlockCounter] = DirectChild;
                BlockCounter += 1;

               

                if (collidingObject.tag == "1Bar")
                {


                    
                   myCollider = new Vector3(gameObject.GetComponent<BoxCollider>().center.x, gameObject.GetComponent<BoxCollider>().center.y, gameObject.GetComponent<BoxCollider>().center.z - 0.005f);
                    Debug.Log(myCollider.y);
                    collidingObject.transform.position = new Vector3(1.550f, gameObject.transform.position.y - (myCollider.y * 160 *extensions), -1);
                    collidingObject.GetComponent<BoxCollider>().enabled = (false);
                    extensions = extensions + 1;

                    if (ParentBlock.myBlock.tag == "myMain")
                    {
                        traceChildren(ParentBlock, ParentBlock.kidOrder,  1);
                    }
                    else
                    {
                        traceChildren(ParentBlock.Father, ParentBlock.kidOrder, 1);
                    }


                }
                else if (collidingObject.tag == "3Bar")
                {



                    myCollider = new Vector3(gameObject.GetComponent<BoxCollider>().center.x, gameObject.GetComponent<BoxCollider>().center.y, gameObject.GetComponent<BoxCollider>().center.z - 0.015f);
                    collidingObject.transform.position = new Vector3(1.550f, gameObject.transform.position.y - (myCollider.y * 160 * extensions), -1);


                    collidingObject.GetComponents<BoxCollider>()[1].enabled = (false);


                    extensions = extensions + 3;

                    if (ParentBlock.myBlock.tag == "myMain")
                    {
                        traceChildren(ParentBlock, ParentBlock.kidOrder, 3);
                    }
                    else
                    {
                        traceChildren(ParentBlock.Father, ParentBlock.kidOrder, 3);
                    }


                }
                else if (collidingObject.tag == "5Bar")
                {

                    myCollider = new Vector3(gameObject.GetComponent<BoxCollider>().center.x, gameObject.GetComponent<BoxCollider>().center.y, gameObject.GetComponent<BoxCollider>().center.z - 0.025f);
                    collidingObject.transform.position = new Vector3(1.550f, gameObject.transform.position.y - (myCollider.y * 190 * extensions), -1);

             
                    extensions = extensions + 5;
                    if (ParentBlock.myBlock.tag == "myMain")
                    {
                        traceChildren(ParentBlock, ParentBlock.kidOrder, 1);
                    }
                    else
                    {
                        traceChildren(ParentBlock.Father, ParentBlock.kidOrder, 1);
                    }

                }
                /*if (ParentBlock.myBlock.tag =="myMain")
                {
                    traceChildren(ParentBlock,DirectChild.kidOrder, extensions-1);
                }
                else
                {
                    Debug.Log(extensions + " when im doing 3 bar");
                    traceChildren(ParentBlock.Father, DirectChild.kidOrder, extensions-1);
                }*/

               // analyzeBlock(ParentBlock);

            }
        }

        if (gameObject.tag == "3Bar")
        { 
            
            if (!collided && !Input.GetKey(KeyCode.Mouse0))
            {


                //  Bottom = MainBlock.transform.GetChild(1).gameObject;
                /*collidingObject = col.gameObject;
                Block DirectChild = new Block();
                DirectChild.myBlock = collidingObject;
                DirectChild.type = collidingObject.name;
                ParentBlock.CollidingChildren[BlockCounter] = DirectChild;
                BlockCounter += 1;
                */
                collidingObject = col.gameObject;
                Block DirectChild = new Block();
                DirectChild.myBlock = collidingObject;
                DirectChild.Father = ParentBlock;
                if (collidingObject.tag == "3Bar")
                {
                    collidingObject.GetComponent<BlocksConnect>().FatherInLaw = ParentBlock;
                    collidingObject.GetComponent<BlocksConnect>().ParentBlock.kidOrder = BlockCounter;

                }
                if (FatherInLaw != null)
                {

                    ParentBlock.Father = FatherInLaw;
                }

                DirectChild.type = collidingObject.name;
                DirectChild.kidOrder = BlockCounter;
                ParentBlock.CollidingChildren[BlockCounter] = DirectChild;
                BlockCounter += 1; 

           

                if (collidingObject.tag == "1Bar")
                {


                    myCollider = new Vector3(gameObject.GetComponents<BoxCollider>()[0].center.x, gameObject.GetComponents<BoxCollider>()[0].center.y, gameObject.GetComponents<BoxCollider>()[0].center.z - 0.005f);
                    collidingObject.transform.position = new Vector3(2.07f, gameObject.transform.position.y - (myCollider.y * 230 * extensions)    , -1);
                    collidingObject.GetComponent<BoxCollider>().enabled = (false);

                    extensions = extensions + 1;
                    ParentBlock.Father.myBlock.GetComponent<BlocksConnect>().extensions += 1;
                    traceChildren(ParentBlock, ParentBlock.kidOrder, 1);





                }
                else if (collidingObject.tag == "3Bar")
                {

                    myCollider = new Vector3(gameObject.GetComponents<BoxCollider>()[0].center.x, gameObject.GetComponents<BoxCollider>()[0].center.y, gameObject.GetComponents<BoxCollider>()[0].center.z - 0.015f);
                    collidingObject.transform.position = new Vector3(2.07f, gameObject.transform.position.y - (myCollider.y * 240 * extensions), -1);
                    extensions = extensions + 3;
                    ParentBlock.Father.myBlock.GetComponent<BlocksConnect>().extensions += 3;

                    collidingObject.GetComponents<BoxCollider>()[1].enabled = (false);


                    if (ParentBlock.myBlock.tag == "myMain")
                    {
                        traceChildren(ParentBlock, ParentBlock.kidOrder, 3);
                    }
                    else
                    {
                        traceChildren(ParentBlock.Father, ParentBlock.kidOrder, 3);
                    }


                }
                else if (collidingObject.tag == "5Bar")
                {

                    myCollider = new Vector3(gameObject.GetComponents<BoxCollider>()[0].center.x, gameObject.GetComponents<BoxCollider>()[0].center.y, gameObject.GetComponents<BoxCollider>()[0].center.z - 0.025f);
                    collidingObject.transform.position = new Vector3(2.07f, gameObject.transform.position.y - (myCollider.y * 240 * extensions), -1);
                    extensions = extensions + 5;

                }



            }
        }
    }

    void traceChildren(Block theparent,int kidOrder, int bar)
    {

        for (int k = 0; k < bar; k += 1)
        {
            theparent.myBlock.transform.GetChild(k+h + 2).gameObject.SetActive(true);
        }
            h += bar;
        


        if (theparent!= null)
        { 
            theparent.myBlock.GetComponent<BoxCollider>().center = new Vector3(theparent.myBlock.GetComponent<BoxCollider>().center.x, theparent.myBlock.GetComponent<BoxCollider>().center.y, theparent.myBlock.GetComponent<BoxCollider>().center.z - 0.00465f*bar);
            theparent.myBlock.transform.Find("MainBottom").gameObject.transform.position = new Vector3(theparent.myBlock.transform.Find("MainBottom").gameObject.transform.position.x, theparent.myBlock.transform.Find("MainBottom").gameObject.transform.position.y - 0.46f * (bar), -1);

          if (theparent.myBlock.tag != "myMain")
            {

                int h2 = theparent.Father.myBlock.GetComponent<BlocksConnect>().h;


                for (int k = 0; k < bar; k += 1)
                {
                    theparent.Father.myBlock.transform.GetChild(k + h2 + 2).gameObject.SetActive(true);
                }
                theparent.Father.myBlock.GetComponent<BlocksConnect>().h += bar;

                theparent.Father.myBlock.GetComponent<BoxCollider>().center = new Vector3(theparent.Father.myBlock.GetComponent<BoxCollider>().center.x, theparent.Father.myBlock.GetComponent<BoxCollider>().center.y, theparent.Father.myBlock.GetComponent<BoxCollider>().center.z - 0.00465f*bar);
               
                theparent.Father.myBlock.transform.Find("MainBottom").gameObject.transform.position = new Vector3(theparent.Father.myBlock.transform.Find("MainBottom").gameObject.transform.position.x, theparent.Father.myBlock.transform.Find("MainBottom").gameObject.transform.position.y - 0.46f * (bar), -1);
            }


          

            //theparent.myBlock.transform.Find("Neck").gameObject.transform.position = new Vector3(theparent.myBlock.transform.Find("Neck").gameObject.transform.position.x, theparent.myBlock.transform.Find("MainBottom").gameObject.transform.position.y - 0.48f * bar, -1);



            for (int i = kidOrder+1; i < theparent.Father.CollidingChildren.Length; i += 1)
            {
                //Debug.Log("hello");

                if (theparent.Father.CollidingChildren[i] != null)
                { 
                    Debug.Log("What happened");
                    if (theparent.Father.CollidingChildren[i].myBlock.tag == "3Bar")
                    { 
                        traceChildren(theparent.Father.CollidingChildren[i],0, bar);
                     }

                    theparent.Father.CollidingChildren[i].myBlock.transform.position = new Vector3(theparent.Father.CollidingChildren[i].myBlock.transform.position.x, theparent.Father.CollidingChildren[i].myBlock.transform.position.y - (0.48f*bar) , -1);
                    //Bottom.transform.position = new Vector3(Bottom.transform.position.x, -0.48f*bar, -1);

                }
            }
        }
    }


    delegate void analyze(Block Target);

    void ForLoop(int j, Block Target, analyze A)
    {
        for (int i = 0; i < j; i += 1)
        {
            A(Target);
        }
    }
    public  void MoveLeft()
    {

         tempVect = new Vector3(-1, 0, 0);
 

        tempVect = tempVect.normalized * speed * Time.deltaTime / 2;
        rb.MovePosition(rb.transform.position + tempVect);
        // Can add more complicated logic here
    }
    public void MoveRight()
    {
        // Can add more complicated logic here
        
            tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime / 2;
            rb.MovePosition(rb.transform.position + tempVect);
       
    }
    public  void MoveUp()
    {
       
 

         tempVect = new Vector3(0, 1, 0);

        tempVect = tempVect.normalized * speed * Time.deltaTime / 2;
        rb.MovePosition(rb.transform.position + tempVect);
    }
    public void MoveDown()
    {
       
        tempVect = new Vector3(0, -1, 0);

        tempVect = tempVect.normalized * speed * Time.deltaTime / 2;
        rb.MovePosition(rb.transform.position + tempVect);
        Debug.Log(tempVect);
        
    }
    void IncreaseBy(ref int Target, int Amount)
    {
        Target += Amount;
    }
    void DecreaseBy(ref int Target, int Amount)
    {
        Target -= Amount;
    }
    void SetTo(ref int Target, int Amount)
    {
        Target = Amount;
    }

    GameObject ChildWithTag(Transform parent, string _tag)
    {

        bool found = false;
        GameObject result = null;
        foreach (Transform child in parent)
        {
            if (child.tag == _tag)
            {
                result = child.gameObject;
                found = true;
                break;
            }
        }
        if (!found) { result = null; }
        return result;
    }
    void analyzeBlock(Block CurrentBlock)
    {
       
        for (int j = 0; j < CurrentBlock.CollidingChildren.Length; j += 1)
        {
            
             
                Block dummy = CurrentBlock.CollidingChildren[j];
                if (dummy != null)
                {
                    if (dummy.type == "for" /*&& dummy.isConditioned*/)
                    {
                        string value = ChildWithTag(dummy.myBlock.GetComponent<Transform>().GetChild(1), "value").GetComponentInChildren<TextMeshPro>().text;
                        ForLoop(int.Parse(value), dummy.myBlock.GetComponent<BlocksConnect>().ParentBlock, analyzeBlock);
                        
                   
                    }
                    else if (dummy.type == "increase")
                    {
                        string value = ChildWithTag(dummy.myBlock.GetComponent<Transform>(), "value").GetComponentInChildren<TextMeshPro>().text;
                        IncreaseBy(ref kid, int.Parse(value));
                        Debug.Log(kid);
                    }
                    else if (dummy.type == "decrease")
                    {
                        string value = ChildWithTag(dummy.myBlock.GetComponent<Transform>(), "value").GetComponentInChildren<TextMeshPro>().text;
                        DecreaseBy(ref kid, int.Parse(value));
                        Debug.Log(kid);
                    }
                    else if (dummy.type == "set")
                    {
                        string value = ChildWithTag(dummy.myBlock.GetComponent<Transform>(), "value").GetComponentInChildren<TextMeshPro>().text;
                        SetTo(ref kid, int.Parse(value));
                        Debug.Log(kid);
                    }
                    else if (dummy.type == "moveup")
                    {
                    //Invoke("MoveUp",( j / 2f) + k);
                    instructions[currentInstruction] = dummy.type;
                    currentInstruction += 1;
                    }
                    else if (dummy.type == "movedown")
                    {
                     
                        //Invoke("MoveDown", (j/2f )+k);
                        //MoveDown();
                    instructions[currentInstruction] = dummy.type;
                    currentInstruction += 1;
                }
                    else if (dummy.type == "moveright")
                    {
                    instructions[currentInstruction] = dummy.type;
                    currentInstruction += 1;

                    //Invoke("MoveRight", (j/2f)+k);
                    // MoveRight();
                    //Debug.Log(j + " " + k);

                    }
                    else if (dummy.type == "moveleft")
                    {
                    instructions[currentInstruction] = dummy.type;
                    currentInstruction += 1;
                    //Invoke("MoveLeft", (j / 2f) + k);


                    }

                }
            
        }

    }
}
