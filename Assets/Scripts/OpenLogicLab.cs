using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLogicLab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }


    void position_save()
    {
        PlayerPrefs.SetFloat("p_x", GameObject.Find("MProtagnist").transform.localPosition.x);
        PlayerPrefs.SetFloat("p_y", GameObject.Find("MProtagnist").transform.localPosition.y);
        PlayerPrefs.SetFloat("p_z", GameObject.Find("MProtagnist").transform.localPosition.z);

        PlayerPrefs.SetInt("Saved", 1);
        // You need to actually save the values!
        PlayerPrefs.Save();
        Debug.Log("Saved position at: " + PlayerPrefs.GetFloat("p_x"));
    }

    private void OnMouseDown()
    {
        position_save();
        if (gameObject.tag == "Logic Lab")
        {
            SceneManager.LoadScene("Logic Gates 0");
        }
    else if (gameObject.tag =="Resistance Lab")
        {
            SceneManager.LoadScene("ResistanceGame");
        }
        else if (gameObject.tag =="Blockeys Lab")
        {   
            SceneManager.LoadScene("Blockeys");
        }
    }
}
