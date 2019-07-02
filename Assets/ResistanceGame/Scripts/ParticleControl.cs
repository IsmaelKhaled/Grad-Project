using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public GameObject[] Particles;
    public float Zpos = 5;
    Vector3 SpawnPosition = new Vector3(0, 0, 5f);
    bool playing = false;
    GameObject CurrentParticle;
    private void Start()
    {
        for (int i = 0; i < Particles.Length; i++)
        {
            Particles[i].SetActive(false);
        }
    }
    
    private void LateUpdate()
    {
        if (!playing)
        {
            CurrentParticle = chooseParticle();
        }
        else
        {
            CheckPlaying();
        }
    }
    GameObject chooseParticle()
    {
        int r = UnityEngine.Random.Range(0, Particles.Length);
        GameObject particle = Particles[r];
        SpawnPosition = SpawnPoint();
        particle.SetActive(true);
        particle.transform.position = SpawnPosition;
        particle.GetComponent<ParticleSystem>().Play();
        particle.GetComponent<AudioSource>().Play();
        playing = true;
        return particle;
        
    }
    void CheckPlaying()
    {
        
        if (CurrentParticle.GetComponent<ParticleSystem>().time >= CurrentParticle.GetComponent<ParticleSystem>().main.duration)
        {
            CurrentParticle.GetComponent<ParticleSystem>().Stop();
            CurrentParticle.GetComponent<AudioSource>().Stop();
            CurrentParticle.SetActive(false);
            playing = false;
        }
    }
    private Vector3 SpawnPoint()
    {
        float x = 0, y = 0, z = Zpos;
        Vector3 point = new Vector3(x, y, z);
        bool seen = false;
        while (!seen)
        {
            x = UnityEngine.Random.Range(0, 100);
            y = UnityEngine.Random.Range(0, 100);
            point = new Vector3(x, y, z);
            Vector3 screenpoint = Camera.main.WorldToViewportPoint(point);
            if(screenpoint.x >= 0 && screenpoint.x <=1 && screenpoint.y >=0 && screenpoint.y <=1 && screenpoint.z > 0)
            {
                seen = true;
            }
        }
        return point;
        
    }
}
