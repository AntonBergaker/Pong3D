using UnityEngine;
using System.Collections;

public class ConfettiColor : MonoBehaviour {

    ParticleSystem particleSys;
    ParticleSystem.Particle[] particles;

    bool triggered = false;

	// Use this for initialization
	void LateUpdate () {
        if (triggered == false)
        {
            particleSys = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particleSys.maxParticles];

            int length = particleSys.GetParticles(particles);

            for (int i = 0; i < length; i++)
            {
                particles[i].startColor = Color.HSVToRGB(Random.value, 1, 1);
            }

            particleSys.SetParticles(particles, length);
            triggered = true;
        }
	}
}
