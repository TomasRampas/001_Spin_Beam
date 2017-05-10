using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PositionOperator : MonoBehaviour {

    public GameObject mainframe;
    public GameObject gameManager;

    private ArrayTest arrayTest;
    SplineFollower follower;
    MainframeActionSelection mainframeActionSelection;
    
	void Start () {
        mainframeActionSelection = mainframe.GetComponent<MainframeActionSelection>();
        follower = GetComponent<SplineFollower>();
        arrayTest = gameManager.GetComponent<ArrayTest>();
	}
	
	void Update () {

        /*#region TEST INPUT
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartMovement();
        }
        #endregion*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            mainframeActionSelection.starterPhase -= 1;
            mainframeActionSelection.numberOfLoops += 1;
            StopMovement();
            arrayTest.EndOfRound();
        }
    }

    #region MAINFRAME BODY MOVEMENT

    public void StartMovement()
    {
        follower.autoFollow = true;
    }

    public void StopMovement()
    {
        follower.autoFollow = false;
    }

    # endregion
}
