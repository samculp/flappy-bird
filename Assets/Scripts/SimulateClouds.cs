using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateClouds : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public int preSimulationTime = 20;

    void Start()
    {
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        particleSystem.Simulate(preSimulationTime, true, true);
        particleSystem.Play();
    }
}
