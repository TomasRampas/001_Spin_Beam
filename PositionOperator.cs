using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PositionOperator : MonoBehaviour {

    SplineFollower follower;
    
	void Start () {
        follower = GetComponent<SplineFollower>();
		
	}
	
	void Update () {
        // Testing feature
		if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartMovement();
        }
	}

    public void StartMovement()
    {
        follower.autoFollow = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            Debug.Log("Round Finished");
            Invoke ("WaitForPause", 0.25f);
            
        }
    }

    void WaitForPause()
    {
        follower.autoFollow = false;
    }
}
