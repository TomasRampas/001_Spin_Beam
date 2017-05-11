using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

    public Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.Play("BeamProjectile");
        }
	}
}
