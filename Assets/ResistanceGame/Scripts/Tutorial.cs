using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public int part = 0;
    public GameObject[] Parts;
    bool playpart = false;
    public GameObject GameControl;
    bool IsTutorial = false;
    private void Update()
    {
        if (IsTutorial)
        {

            Time.timeScale = 0;
            Parts[part].SetActive(true);
            GameControl.GetComponent<gamecontrol>().checkScore();
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    public void SetTutorial(bool status)
    {
        IsTutorial = status;
    }
    public void IncreasePart()
    {
        Parts[part].SetActive(false);
        part++;
    }
    public void DecreasePart()
    {
        Parts[part].SetActive(false);
        part--;
    }
    public void EndTutorial()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
