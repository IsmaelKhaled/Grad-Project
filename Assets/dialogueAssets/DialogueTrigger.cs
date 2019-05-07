using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

   public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnMouseDown()
    {
        // return if text is already displayed
        GameObject textbackPanel = GameObject.FindGameObjectWithTag("txtback");
        if (textbackPanel.transform.GetChild(0).gameObject.activeSelf) return;

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
