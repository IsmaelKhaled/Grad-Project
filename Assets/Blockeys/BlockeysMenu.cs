using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockeysMenu : MonoBehaviour
{
    public GameObject Player,HorseMan,King,ActiveGame,StartMenu;
    public Button ExitButton,StartButton,BackButton;
    public string kingDir="none",PlayerDir="none",HorseManDir="none";
    public bool Animate =true;
    float Factor=2.0f;

    public Texture2D cursor;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, hotSpot, CursorMode.ForceSoftware);
        Debug.Log(Screen.width/ 1000f);
        Factor = Screen.width / 1000f;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.onClick.AddListener(StartTask);
        ExitButton.onClick.AddListener(ExitTask);
        BackButton.onClick.AddListener(BackTask);
        if(Animate)
        {
        	MoveObject(Player,ref PlayerDir);
        	MoveObject(King,ref kingDir);
        	MoveObject(HorseMan,ref HorseManDir);
        	
        }
    }
    void MoveObject(GameObject Target,ref string Direction)
    {
    	if(Direction=="Right"){MoveRight(Target,ref Direction);}
    	else if(Direction=="Left"){MoveLeft(Target,ref Direction);}
    	else
    	{
	    	int x =UnityEngine.Random.Range(0,10)%2;
	    	switch(x)
	    	{
	    		case 0:
	    			if(Direction!="Left"){MoveRight(Target,ref Direction);Direction="Right";}
	    			return;
	    		case 1:
	    			if(Direction!="Right"){MoveLeft(Target,ref Direction);Direction="Left";}
	    			return;
	    	}
    	}
    }
    void MoveRight(GameObject Target, ref string Direction)
    {
    	if(Target.transform.position.x+Factor<Screen.width+500)
    	{
    		Target.transform.position=new Vector3(Target.transform.position.x+Factor,Target.transform.position.y,Target.transform.position.z);
    	}
    	else
    	{
    		Direction="none";
    		int x =UnityEngine.Random.Range(0,1000)%2;
	    	switch(x)
	    	{
	    		case 0:
	    			ShiftUp(Target);
	    			return;
	    		case 1:
	    			ShiftDown(Target);
	    			return;
    		}
    	}
    }
    void MoveLeft(GameObject Target,ref string Direction)
    {
    	if(Target.transform.position.x+Factor>-200)
    	{
    		Target.transform.position=new Vector3(Target.transform.position.x-Factor,Target.transform.position.y,Target.transform.position.z);
    	}
    	else
    	{
    		Direction="none";
    		int x =UnityEngine.Random.Range(0,1000)%2;
	    	switch(x)
	    	{
	    		case 0:
	    			ShiftUp(Target);
	    			return;
	    		case 1:
	    			ShiftDown(Target);
	    			return;
    		}
    	}
    }
    void ShiftUp(GameObject Target)
    {
    	int x=0,i=0;
    	while(i<10)
    	{
	    	x = UnityEngine.Random.Range(0,7);
	    	if(Target.transform.position.y+(20*x)<Screen.height+50)
	    	{
	    		Target.transform.position=new Vector3(Target.transform.position.x,Target.transform.position.y+(20*x),Target.transform.position.z);
	    		i=30;
	    	}
	    	i+=1;
    	}
    }
    void ShiftDown(GameObject Target)
    {
    	int x=0,i=0;
    	while(i<10)
    	{
	    	x = UnityEngine.Random.Range(0,7);
	    	if(Target.transform.position.y-(20*x)>50)
	    	{
	    		Target.transform.position=new Vector3(Target.transform.position.x,Target.transform.position.y-(20*x),Target.transform.position.z);
	    		i=30;
	    	}
	    	i+=1;
    	}
    }



    void ExitTask()
    {
    	//ExitScene
    }
    void StartTask()
    {
    	StartMenu.SetActive(false);
    	ExitButton.gameObject.SetActive(false);
    	BackButton.gameObject.SetActive(true);
    	ActiveGame.SetActive(true);
    	Animate=false;
    }
    void BackTask()
    {
    	StartMenu.SetActive(true);
    	ExitButton.gameObject.SetActive(true);
    	BackButton.gameObject.SetActive(false);
    	ActiveGame.SetActive(false);
    	Animate=true;
    }
}
