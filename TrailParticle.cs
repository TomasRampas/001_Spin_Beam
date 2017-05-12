using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticle : MonoBehaviour {

    public Transform particle;

    void Start()
    {
        particle.GetComponent<ParticleSystem>();
    }

    void Update ()
    {
        
	}
}
