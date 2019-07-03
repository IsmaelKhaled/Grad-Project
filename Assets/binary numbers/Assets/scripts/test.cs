using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    public bool Lighted = false;
    [SerializeField] private Animator anim;
    [SerializeField] float  allowTime;
    bool allowed;

    public AudioSource src;
    public AudioClip TurnOn;
    public AudioClip TurnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!allowed) allowTime += Time.deltaTime;

        if (allowTime >= 0.6f)
        {
            allowed = true;
            allowTime = 0f;

        }

        if (allowed)
        {
            if (Input.GetMouseButton(0))
            {
                allowed = false;
                Vector3 clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D coll = GetComponent<Collider2D>();
                if (coll.OverlapPoint(clicked))
                {

                    if (!Lighted)
                    {
                        turn_on();

                    }
                    else
                    {
                        turn_of();

                    }



                }

            }
        }
        
    }

    public void turn_on()
    {
        anim.SetBool("hoba", true);
        anim.SetBool("TurnOn", true);
        Lighted = true;
        src.clip = TurnOn;
        src.Play();
    }
    public void turn_of()
    {
        anim.SetBool("hoba", false);
        anim.SetBool("TurnOn", false);
        Lighted = false;
        src.clip = TurnOff;
        src.Play();
    }
}
