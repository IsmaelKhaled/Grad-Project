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
        PlayerPrefs.SetFloat("p_x", GameObject.Find("Mprotagnist").transform.position.x);
        PlayerPrefs.SetFloat("p_y", GameObject.Find("Mprotagnist").transform.position.y);
        PlayerPrefs.SetFloat("p_z", GameObject.Find("Mprotagnist").transform.position.z);

        PlayerPrefs.SetInt("Saved", 1);
        // You need to actually save the values!
        PlayerPrefs.Save();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Logic Gates 0");
    }
}
