using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PositionOperator : MonoBehaviour {

    // NOTE: Difficulty lvl variables
    public Vector2 speedMinMax;
    float speed;
    float time;

    public GameObject mainframe;
    public GameObject gameManager;
    public GameObject orb;

    private ArrayTest arrayTest;
    private OrbScript orbScript;
    SplineFollower follower;
    MainframeActionSelection mainframeActionSelection;
    
	void Start () {
        mainframeActionSelection = mainframe.GetComponent<MainframeActionSelection>();
        follower = GetComponent<SplineFollower>();
        arrayTest = gameManager.GetComponent<ArrayTest>();
        orbScript = orb.GetComponent<OrbScript>();
        DifficultyScript.elapsedTime = Time.time;

    }
	
	void Update () {

        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartMovement();
        }*/

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RestartSpeed();
        }*/
        #endregion

        DifficultyScript.elapsedTime = Time.time - time;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, DifficultyScript.GetDifficultyPercent());
        follower.followSpeed = speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            /*if(mainframeActionSelection.starterPhase > 0)
            {
                mainframeActionSelection.starterPhase -= 1;
            }*/
            mainframeActionSelection.numberOfLoops += 1;
            StopMovement();
            arrayTest.EndOfRound();
        }

        if (other.gameObject.CompareTag("OrbDespawn"))
        {
            orbScript.DespawnOrb();
        }

        if (other.gameObject.CompareTag("LaserCollider") && !arrayTest.gameOver)
        {
                arrayTest.PlayLaserParticle();
                orbScript.SpawnOrb();
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

    #endregion

    #region SPEED DIFFICULTY LVL
    public void RestartSpeed()
    {
        time = Time.time;
    }
    #endregion
}
