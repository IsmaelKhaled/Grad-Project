using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour
{
    public BandColor[] Bands;

    public float value = 0f;
    
    private void Update()
    {
        int multi = Bands[2].CurrentColor > 9 ? 9-Bands[2].CurrentColor : Bands[2].CurrentColor;
        value = ((Bands[0].CurrentColor * 10) + Bands[1].CurrentColor) * (Mathf.Pow(10,multi));
    }
    public void Restart()
    {
        for (int i = 0; i < Bands.Length; i++)
        {
            Bands[i].Restart();
        }
    }
}
