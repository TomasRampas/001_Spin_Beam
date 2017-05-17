﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float smooth = 1f;
    private Quaternion targetRotation;

    public SwipeCode swipeControls;

	void Start () {
        targetRotation = transform.rotation;
	}
	

	void Update () {
		if (Input.GetKeyDown("left"))
        {
            //targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
            turnLeft();
        }

        if (Input.GetKeyDown("right"))
        {
            //targetRotation *= Quaternion.AngleAxis(90, Vector3.back);
            turnRight();
        }

        if (swipeControls.SwipeLeft)
        {
            turnRight();
        }

        if (swipeControls.SwipeRight)
        {
            turnLeft();
        }

        if (swipeControls.SwipeUp)
        {
            turnRight();
        }

        if (swipeControls.SwipeDown)
        {
            turnLeft();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

    public void turnLeft()
    {
        targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
    }

    public void turnRight()
    {
        targetRotation *= Quaternion.AngleAxis(90, Vector3.back);
    }
}
