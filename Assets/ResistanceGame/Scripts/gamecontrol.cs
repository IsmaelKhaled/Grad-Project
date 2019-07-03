using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class gamecontrol : MonoBehaviour
{
    public TextMeshProUGUI value;
    public TextMeshProUGUI goal;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI timer;
    public Resistance resistance;
    public GameObject Particles;
    private float randGoal;
    private int score_num=0;
    float[] factors = new float[] { 1f, 10f, 100f, 1000f, 10000f, 100000f, 1000000f,10000000f,100000000f,1000000000f, 0.1f, 0.01f};

    bool help=false;

    //timer -> reset_timer to initialize
    private float timer_val;
    private float savetimerval;
    private bool canCount;
    private bool doOnce;

    //Audio
    AudioSource match;
    private AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        match=GetComponent<AudioSource>();
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        Particles.SetActive(true);
        updategoal();
        InvokeRepeating("checkScore",1f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(score_num<10){
            value.text= resistance.value.ToString("N");
        }
        else{
            value.enabled=false;
        }
        
        countDown(); 
    }

    void updategoal()
    {

        int r = UnityEngine.Random.Range(0, factors.Length);
        randGoal = UnityEngine.Random.Range(1,100) * factors[r];
        goal.text= randGoal.ToString("N");
        reset_timer();
        resistance.Restart();
        value.text="0";
        
    }
    

    public void checkScore()
    {
        if (resistance.value == randGoal)
        {
            if(timer_val>40) score_num+=3; // add 3 points in first 20 seconds
            else if(timer_val>20) score_num+=2; // add 2 points in second 20 seconds
            else score_num++; // add 1 point in the remaining seconds

            // edit score
            match.Play();
            score.text= score_num.ToString();
            updategoal();
            
        }
    }

    void countDown()
    {
        if(timer_val > 0.0f && canCount)
        {
            timer_val -= Time.deltaTime;
            int seconds = (int) (timer_val % 60);
            int minutes = (int) (timer_val / 60 ) % 60;

            string timeformat = string.Format("{0:00}:{1:00}", minutes,seconds);
            timer.text=timeformat;
        }

        else if(timer_val<= 0.0f && ! doOnce && ! help)
        {
            canCount=false;
            doOnce=true;
            timer.text="00:00";
            timer_val=0;
            exitgame ();
        }
    }


    void reset_timer()
    {
        timer_val= 60; //1 minute
        canCount=true;
        doOnce=false;
    }

    public void showhelp ()
    {
        GameObject instPanel = GameObject.FindGameObjectWithTag("help");

        if (! help)
        {
           help=true;
           instPanel.transform.GetChild(0).gameObject.SetActive(true);
           savetimerval = timer_val;
        }
        else if (help)
        {
            help=false;
            timer_val = savetimerval;
            instPanel.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void gameover()
    {
        controlAudio(false);
        GameObject overPanel = GameObject.FindGameObjectWithTag("gameover");
        overPanel.transform.GetChild(0).gameObject.SetActive(true);
        GameObject helpbutton = GameObject.FindGameObjectWithTag("helpbuttom");
        helpbutton.transform.GetChild(0).gameObject.SetActive(false);
        finalScore.text=score_num.ToString();
        Particles.GetComponent<ParticleControl>().GameOver();
    }

    void controlAudio(bool play) 
    {
        if (play){
            foreach( AudioSource audioS in allAudioSources) {
                audioS.Play();
            }
        }
        else if (!play){
            foreach( AudioSource audioS in allAudioSources) {
                audioS.Stop();
            }
        }
    }

    public void playagain ()
    {
        controlAudio(true);
        GameObject overPanel = GameObject.FindGameObjectWithTag("gameover");
        overPanel.transform.GetChild(0).gameObject.SetActive(false);
        GameObject helpbutton = GameObject.FindGameObjectWithTag("helpbuttom");
        helpbutton.transform.GetChild(0).gameObject.SetActive(true);
        GameObject extPanel = GameObject.FindGameObjectWithTag("exitbutton");
        extPanel.transform.GetChild(0).gameObject.SetActive(true);
        updategoal();
        score_num=0;
        score.text= score_num.ToString();

    }

     public void exitgame ()
    {
        gameover();
        GameObject extPanel = GameObject.FindGameObjectWithTag("exitbutton");
        extPanel.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
