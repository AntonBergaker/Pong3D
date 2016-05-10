using UnityEngine;
using System.Collections;

public class ConfettiColor : MonoBehaviour {

    ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;

    bool triggered = false;

	// Use this for initialization
	void LateUpdate () {
        if (triggered == false)
        {
            particleSystem = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particleSystem.maxParticles];

            int length = particleSystem.GetParticles(particles);

            for (int i = 0; i < length; i++)
            {
                particles[i].startColor = Color.HSVToRGB(Random.value, 1, 1);
            }

            particleSystem.SetParticles(particles, length);
            triggered = true;
        }
	}
}
