using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpParticles : MonoBehaviour
{
    private void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        //particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        // get
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //iterate
        for (int i = 0; i<numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 255, 255, 255);
            enter[i] = p;
        }
        //set
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}
