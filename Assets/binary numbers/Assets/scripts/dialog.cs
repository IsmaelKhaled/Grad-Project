using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    public Text txt1;
    public Text txt2;
    public Text labels;
    public GameManager GM;
    public GameObject next;

    public AudioSource src;
    public AudioClip aud1;
    public AudioClip BtnSound;

    [SerializeField]
    int index = 0;
    int PreIndex = -1;
    [SerializeField]
    int FrmRate;
    float fading_co = 1f;
    bool fade_out = false;
    bool fade_in = false;
    float fading_time = 2f;

    string[] sentences = {"welcome to ..",
                          "the dark\n         circuit",
                          "now you want to fix some hardware in this circuit ",
                          "the problem is that the circuit is so dark and you have to light it up so you can see" ,
                          "and yes there is 10 leds there but if you light them all up it will be too over shiny",
                          "so you have to light them up in a certain way that the computer dictates",
                          "and because computers are always complicated",
                          "it will give you a decimal number!",
                          "then you will have to light up the leds that represent that decimal in binary code",
                          "as every led represent a power of  2  according to its position" ,
                          "and now there is too many ways to convert decimal to binary",
                          "one of them is to see what is the powers of  2  this decimal consists of ",
                          "for example: the number  80",
                          "is in fact 64 + 4 +2" ,
                          "so if we activate the second, the third and the seventh leds",
                          "now we can see clearly!" };
    // Start is called before the first frame update
    void Start()
    {
        FrmRate = 30;
        src.PlayOneShot(aud1);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_in || fade_out) fading();
        if (index != PreIndex)
        {
            instructions();
            PreIndex = index;
        }
        
    }

    public void increment()
    {
        next.SetActive(false);
        src.PlayOneShot(BtnSound);
        fade_out = true;
    }

    void fading()
    {
        if (fade_out)
        {
            if (fading_co >= fading_time / FrmRate)
            {
                fading_co -= fading_time / FrmRate;
                txt1.color = new Color((180f / 255f), 190f / 255f, 117f / 255f, fading_co);
                txt2.color = new Color((180f / 255f), 190f / 255f, 117f / 255f, fading_co);
            }
            else
            {
                fade_out = false;
                fade_in = true;
                index += 2;
                next.SetActive(true);
            }

        }

        else if (fade_in)
        {
            if (fading_co <= 1-(fading_time / FrmRate))
            {
                fading_co += fading_time / FrmRate;
                txt1.color = new Color((180f / 255f), 190f / 255f, 117f / 255f, fading_co);
                txt2.color = new Color((180f / 255f), 190f / 255f, 117f / 255f, fading_co);
            }
            else
            {
                fade_in = false;
            }
        }

    }

    void instructions()
    {
        if (index == 0)
        {
            txt1.transform.localScale = new Vector3(1.745325f, 3.6f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.796679f, 3.6f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
        }

        if (index == 2)
        {

            txt1.rectTransform.sizeDelta = new Vector2(160f, 40.6f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 55.4f);
            //    txt1.transform.localScale = new Vector3(1.745325f, 3.6f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.6f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
        }
        if (index == 4)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 61.69f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 46.06f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.68f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.4f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
        }
        if (index == 6)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 40.5f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 46.06f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.23f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.4f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
        }
        if (index == 8)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 63.3f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 53.82f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.5f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.4f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
            labels.gameObject.SetActive(true);
        }
        if (index == 10)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 63.3f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 55.7f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.23f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.4f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
        }
        if (index == 12)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 63.3f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 55.7f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.23f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 3.4f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
            GM.number.text = 80 + "";
        }
        if (index == 14)
        {
            txt1.rectTransform.sizeDelta = new Vector2(160f, 63.3f);
            txt2.rectTransform.sizeDelta = new Vector2(160f, 55.7f);
            txt1.transform.localScale = new Vector3(1.745325f, 2.23f, 2.0533f);
            txt2.transform.localScale = new Vector3(1.6f, 2.1f, 2.0533f);
            txt1.text = sentences[index];
            txt2.text = sentences[index + 1];
            GM.lambs[1].GetComponent<test>().turn_on();
            GM.lambs[2].GetComponent<test>().turn_on();
            GM.lambs[6].GetComponent<test>().turn_on();
            GM.illumination.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4353f);
        }
        if (index == 16)
        {

            GM.lambs[1].GetComponent<test>().turn_of();
            GM.lambs[2].GetComponent<test>().turn_of();
            GM.lambs[6].GetComponent<test>().turn_of();
            GM.illumination.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            labels.gameObject.SetActive(false);
            txt1.gameObject.SetActive(false);
            txt2.gameObject.SetActive(false);
            next.SetActive(false);
            src.Stop();
            GM.StartGame = true;
        }
    }
}
