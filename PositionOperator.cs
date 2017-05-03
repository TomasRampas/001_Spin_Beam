using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PositionOperator : MonoBehaviour {

    public GameObject mainframe;

    SplineFollower follower;
    MainframeActionSelection mainframeActionSelection;
    
	void Start () {
        mainframeActionSelection = mainframe.GetComponent<MainframeActionSelection>();
        follower = GetComponent<SplineFollower>();
	}
	
	void Update () {

        #region TEST INPUT
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartMovement();
        }
        #endregion
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            mainframeActionSelection.starterPhase -= 1;
            mainframeActionSelection.numberOfLoops += 1;
            StopMovement();
        }
    }

    #region MAINFRAME BODY MOVEMENT

    public void StartMovement()
    {
        follower.autoFollow = true;
    }

    void StopMovement()
    {
        follower.autoFollow = false;
    }

    # endregion
}
