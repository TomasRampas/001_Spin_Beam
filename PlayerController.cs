using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float smooth = 1f;
    private Quaternion targetRotation;

	void Start () {
        targetRotation = transform.rotation;
	}
	

	void Update () {
		if (Input.GetKeyDown("left"))
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
        }

        if (Input.GetKeyDown("right"))
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.back);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}
}
