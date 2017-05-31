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
    public GameObject mainCameraObject;
    public GameObject gameManager;
    public GameObject gameOver;
    public GameObject inGameScoreText;
    public GameObject TopScoreHolder;
    public GameObject Ads;
    public GameObject MainMainframeBody;
    public GameObject playIcon;
    public GameObject particles;
    public Light circleLightl;
    public SpriteRenderer guiSprite;

    CameraMovement cameraMovement;
    SplineFollower GUIMainframeBody;
    SplineFollower GUImainCamera;
    TopScore topScoreScript;
    PositionOperator positionOperator;
    TutorialScript tutorialScript;
    MeshRenderer playMesh;
    OrbScript orbScript;

    AdManager adManager;
    private bool GUIMainframeBodyMovement;
    private bool GUImainCameraMovement;
    private GUImainframeScript guiMainframeScript;
    private Score score;
    ArrayTest arrayTest;


    void Start () {
        orbScript = particles.GetComponent<OrbScript>();
        cameraMovement = mainCameraObject.GetComponent<CameraMovement>();
        topScoreScript = TopScoreHolder.GetComponent<TopScore>();
        GUIMainframeBody = MainframeBody.GetComponent<SplineFollower>();
        GUImainCamera = mainCamera.GetComponent<SplineFollower>();
        playMesh = playIcon.GetComponent<MeshRenderer>();
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
        orbScript.StopGuiOrb();
        orbScript.GuiOrbPciked();
        Invoke("startMovementInvoke", 0.5f);
    }

    void startMovementInvoke()
    {
        score.resetScore();
        guiSprite.enabled = false;
        circleLightl.enabled = false;
        InMenuGUI(false);
        GUImainCamera.direction = Spline.Direction.Forward;
        cameraMovement.SetFOVZoomOut();
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
        playMesh.enabled = false;
        Invoke("toInvokeTutorial", 1f);
    }

    void toInvokeTutorial()
    {
        tutorialScript.PlayEndTutorialPart(1);
    }

    #endregion

    #region END OF THE GAME

    public void gameOverCalledOver()
    {
        Invoke("InvokedMainframeMovement", 0.9f);
    }

    void InvokedMainframeMovement()
    {
        guiMainframeScript.EnableGUIMainframe();
        playMesh.enabled = true;
        GUIMainframeBody.direction = Spline.Direction.Forward;
    }

    public void mainframeTriggerOver()
    {
        GUImainCamera.direction = Spline.Direction.Backward;
        cameraMovement.SetFOVZoomIn();
        InGameGUI(false);
        topScoreScript.GameOverScoreCheck();
        adManager.UpdateCounter();
        Invoke("Invoked guiSprite", 1.4f);
    }

    void InvokedguiSprite()
    {
        guiSprite.enabled = true;
        Debug.Log("WTF");
    }

    // NOTE: The final trigger of game over state
    public void cameraTriggerOver()
    {
        InMenuGUI(true);
        orbScript.PlayGuiOrb();
        circleLightl.enabled = true;
        playMesh.enabled = true;
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
        //tutorialScript.PlayTutorial(1);
    }

    public void OrbPicked()
    {
        if (!tutorialScript.TutEnabled)
        {
            return;
        }
        else
        {
            //tutorialScript.EndTutorial(1);
            //tutorialScript.EndTutorial(3);
        }
    }
    #endregion

    #endregion
}
