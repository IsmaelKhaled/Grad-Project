using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] lambs;
    public Text number;
    float DecideTime = 0f;
    bool Decided = false;
    public GameObject panel;

    public GameObject[] electricity;
    public GameObject illumination;
    [SerializeField]
    bool illuminate = false;
    float alpha = 0f;

    [SerializeField]
    int CurrentNumber;
    [SerializeField]
    int RandomNumber;
    // Start is called before the first frame update
    void Start()
    {
        electricity[0].SetActive(false); electricity[1].SetActive(false);
        panel.SetActive(false);
       // RandomNumber = Random.Range(0, 1024);
        //number.text = "" + RandomNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Decided)
        {
            DecideTime += Time.deltaTime;
            RandomNumber = Random.Range(0, 1024);
            number.text = "" + RandomNumber;
            if (DecideTime >= 1.5f) Decided = true;
        }

        if (illuminate) illuminating();

    }

    private void LateUpdate()
    {
        if (Decided)
        {
            CurrentNumber = 0;
            for (int i = 0; i < lambs.Length; i++)
            {
                if (lambs[i].GetComponent<test>().Lighted)
                {
                    CurrentNumber += (int)Mathf.Pow(2f, (float)i);
                }

            }
            if (CurrentNumber == RandomNumber)
            {
                number.text = "YaaaaY!";
                Invoke("EndGame", 2f);
                electricity[0].SetActive(true); electricity[1].SetActive(true);
                illuminate = true;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EndGame ()
    {
        panel.SetActive(true);
    }

    void illuminating()
    {
        alpha += 0.008f;
        if (alpha <= 0.4353f)
        {
            illumination.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
        }
        else
        {
            illuminate = false;
        }
        

    }
}
