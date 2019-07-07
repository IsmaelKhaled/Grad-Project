using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

    public Text nametxt;
    public Text dialoguetxt;

    public int numofpanels;

    private Queue<string> sentences;
    private int buttonsCount; //num of buttons in certain panel
    private int panelnum; //panel child index
    private string panelTag;   //panel Tag

    AudioSource typing;

	// Use this for initialization
	void Start () {

        sentences=new Queue<string>();
        typing = GetComponent<AudioSource>();
		
	}

    public void StartDialogue(Dialogue dialogue)
    {
        
        nametxt.text = dialogue.name;
        panelnum = dialogue.panelindex;
        panelTag = dialogue.panelTagname;
        buttonsCount = dialogue.buttonsCount;

        //show text back
        GameObject textbackPanel = GameObject.FindGameObjectWithTag("txtback");
        textbackPanel.transform.GetChild(0).gameObject.SetActive(true);

        // hide all panels 
        GameObject mainPanel = GameObject.FindGameObjectWithTag("mainTag");

        for (int i = 0; i < numofpanels;i++ )
        {   
            mainPanel.transform.GetChild(i).gameObject.SetActive(false);
        }


        // show exit button 
        GameObject exitPanel = GameObject.FindGameObjectWithTag("exit");
        exitPanel.transform.GetChild(0).gameObject.SetActive(true);

        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();

        if (sentences.Count != 0)
        {// show next button 
            GameObject nxtPanel = GameObject.FindGameObjectWithTag("nxt");
            nxtPanel.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            dialoguetxt.text = "No dialogue";
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        
    }

    IEnumerator TypeSentence (string sentence)
    {
        typing.Play();

        dialoguetxt.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialoguetxt.text += letter;
           
            yield return null;
        }

        typing.Stop();
        
    }

    void EndDialogue()
    {

        // show certain panel
        GameObject mainPanel = GameObject.FindGameObjectWithTag("mainTag");

        mainPanel.transform.GetChild(panelnum).gameObject.SetActive(true);

        GameObject wantedPanel = GameObject.FindGameObjectWithTag(panelTag);

        for (int i = 0; i < buttonsCount; i++)
        {
            wantedPanel.transform.GetChild(i).gameObject.SetActive(true);
        }

        // hide next button 
        GameObject nxtPanel = GameObject.FindGameObjectWithTag("nxt");
        nxtPanel.transform.GetChild(0).gameObject.SetActive(false);

    }

    public void exitConv()
    {
        //stop typing and sound
        StopAllCoroutines();
        typing.Stop();
        
        // hide exit button 
        GameObject exitPanel = GameObject.FindGameObjectWithTag("exit");
        exitPanel.transform.GetChild(0).gameObject.SetActive(false);

        // hide next button 
        GameObject nxtPanel = GameObject.FindGameObjectWithTag("nxt");
        nxtPanel.transform.GetChild(0).gameObject.SetActive(false); 

        // hide all panels 
        GameObject mainPanel = GameObject.FindGameObjectWithTag("mainTag");

        for (int i = 0; i < numofpanels; i++)
        {
            mainPanel.transform.GetChild(i).gameObject.SetActive(false);
        }

        dialoguetxt.text = "";
        nametxt.text = "";

        //hide text back
        GameObject textbackPanel = GameObject.FindGameObjectWithTag("txtback");
        textbackPanel.transform.GetChild(0).gameObject.SetActive(false);
    }
}
