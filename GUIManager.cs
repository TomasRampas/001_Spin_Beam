using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    public GameObject playButton;
    public GameObject MainframeBody;
    public Camera mainCamera;
    public GameObject gameManager;

    SplineFollower GUIMainframeBody;
    SplineFollower GUImainCamera;

    private bool GUIMainframeBodyMovement;
    private bool GUImainCameraMovement;
    private MeshRenderer meshRenderMainframe;
    private GUImainframeScript guiMainframeScript;
    ArrayTest arrayTest;

	void Start () {
        GUIMainframeBody = MainframeBody.GetComponent<SplineFollower>();
        GUImainCamera = mainCamera.GetComponent<SplineFollower>();
        arrayTest = gameManager.GetComponent<ArrayTest>();
        meshRenderMainframe = MainframeBody.GetComponent<MeshRenderer>();
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

    public void FromMenuToGame()
    {
        HideMainPageGUI();
        GUImainCamera.direction = Spline.Direction.Forward;
    }

    public void FromGameToMenu()
    {
        guiMainframeScript.EnableGUIMainframe();
        GUIMainframeBody.direction = Spline.Direction.Forward;
    }

    #region CONNECTED WITH TRIGGERS

    public void TransitionFromGameToMenu()
    {
        if (!GUImainCameraMovement)
        {
            GUImainCamera.direction = Spline.Direction.Backward;
            GUImainCameraMovement = true;
            GUIMainframeBodyMovement = false;
        }
        
    }

    public void GUImainframeMoveOut()
    {
        if (!GUIMainframeBodyMovement)
        {
            GUIMainframeBody.direction = Spline.Direction.Backward;
            GUIMainframeBodyMovement = true;
            GUImainCameraMovement = false;
            Invoke("CallStartOfTheGame", 2f);
        }
        
    }

    void CallStartOfTheGame()
    {
        arrayTest.RunTheGame();
    }

    public void ShowMainPageGUI()
    {
        playButton.SetActive(true);
    }

    public void GUIMainframeInvisible()
    {
        guiMainframeScript.DisableGUIMainframe();
    }

    #endregion

    void HideMainPageGUI()
    {
        playButton.SetActive(false);
    }
}
