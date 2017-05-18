using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    public GameObject playButton;
    public GameObject topScore;
    public GameObject MainframeBody;
    public Camera mainCamera;
    public GameObject gameManager;
    public GameObject gameOver;
    public GameObject inGameScoreText;
    public GameObject TopScoreHolder;
    public GameObject Ads;
    public GameObject MainMainframeBody;

    SplineFollower GUIMainframeBody;
    SplineFollower GUImainCamera;
    TopScore topScoreScript;
    PositionOperator positionOperator;
    TutorialScript tutorialScript;

    AdManager adManager;
    private bool GUIMainframeBodyMovement;
    private bool GUImainCameraMovement;
    private GUImainframeScript guiMainframeScript;
    private Score score;
    ArrayTest arrayTest;


    void Start () {
        topScoreScript = TopScoreHolder.GetComponent<TopScore>();
        GUIMainframeBody = MainframeBody.GetComponent<SplineFollower>();
        GUImainCamera = mainCamera.GetComponent<SplineFollower>();
        arrayTest = gameManager.GetComponent<ArrayTest>();
        guiMainframeScript = MainframeBody.GetComponent<GUImainframeScript>();
        score = gameManager.GetComponent<Score>();
        adManager = Ads.GetComponent<AdManager>();
        positionOperator = MainMainframeBody.GetComponent<PositionOperator>();
        tutorialScript = GetComponent<TutorialScript>();
    }
	
	void Update () {

        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            FromMenuToGame();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            FromGameToMenu();
        }
        */
        #endregion
    }

    #region MENU ANIMATION SETUP
    #region START OF THE GAME

    // NOTE: Called by menu button
    public void startButtonStart()
    {
        InMenuGUI(false);
        GUImainCamera.direction = Spline.Direction.Forward;
    }

    // NOTE: Called by 
    public void cameraTriggerStart()
    {
        GUIMainframeBody.direction = Spline.Direction.Backward;
    }

    public void mainframeTriggerStart()
    {
        GUIMainframeBody.direction = Spline.Direction.Backward;
    }

    public void mainframeReachedTrigger()
    {
        arrayTest.RunTheGame();
        positionOperator.RestartSpeed();
        InGameGUI(true);
        guiMainframeScript.DisableGUIMainframe();
    }

    #endregion

    #region END OF THE GAME

    public void gameOverCalledOver()
    {
        Invoke("InvokedMainframeMovement", 0.7f);
    }

    void InvokedMainframeMovement()
    {
        guiMainframeScript.EnableGUIMainframe();
        GUIMainframeBody.direction = Spline.Direction.Forward;
    }

    public void mainframeTriggerOver()
    {
        GUImainCamera.direction = Spline.Direction.Backward;
        InGameGUI(false);
        topScoreScript.GameOverScoreCheck();
        score.resetScore();
        adManager.UpdateCounter();
    }

    // NOTE: The final trigger of game over state
    public void cameraTriggerOver()
    {
        InMenuGUI(true);
        arrayTest.GameReset();
    }

    #endregion

    #endregion

    #region GUI SCREENS

    void InMenuGUI(bool state)
    {
        playButton.SetActive(state);
        topScore.SetActive(state);
    }

    void InGameGUI(bool state)
    {
        inGameScoreText.SetActive(state);
        if (!state)
        {
            gameOver.SetActive(state);
        }
    }
    #endregion

    #region TUTORIAL

    // TO DO: Do this part of tutorial as Switch, each switch explains specific thing (orb, spin etc.)
    // Dont just write everything here, only call it here

    #region ORB EXPLANATION
    public void OrbSpawned()
    {
        if (!tutorialScript.TutEnabled)
        {
            return;
        }
        else
        {
            Invoke("InvokePlayTutorial", 2.5f);
        }
    }

    void InvokePlayTutorial()
    {
        tutorialScript.PlayTutorial(1);
    }

    public void OrbPicked()
    {
        if (!tutorialScript.TutEnabled)
        {
            return;
        }
        else
        {
            tutorialScript.EndTutorial(1);
            tutorialScript.EndTutorial(3);
        }
    }
    #endregion

    #endregion
}
