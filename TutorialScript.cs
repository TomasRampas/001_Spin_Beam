using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    // Placeholder stuff
    public GameObject picture;
    public GameObject swipeTut;
    public GameObject orbTut;
    public GameObject orbObj;

    public GameObject MainframeBody;
    public bool TutEnabled = true;
    public GameObject playerObject;

    OrbScript orbScript;
    SwipeCode swipeCode;
    int tutorialPlayed;
    int tutorialRun = 1;
    int dontPlay = 0;
    TutorialScript tutorialScript;
    PositionOperator positionOperator;

    #region ANIMATION PARTS
    public GameObject swipePart;
    #endregion

    void Start ()
    {
        orbScript = orbObj.GetComponent<OrbScript>();
        swipeCode = playerObject.GetComponent<SwipeCode>();
        CheckTutorialAvailable();
        positionOperator = MainframeBody.GetComponent<PositionOperator>();
    }

    void Update()
    {

        #region TEST INPUT
        /*
        if(Input.GetKeyDown(KeyCode.P))
        {
            RestartTutorial();
        }*/
        /*
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowSwipeTut();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            HideSwipeTut();
        }*/

        #endregion

        //NOTE: Check for swipe input to exit first tutorial window


    }

    #region TUTORIAL STATE
    /*
    // OLD STUFF REMOVE AFTER FINISHED
    public void PlayTutorial(int playPart)
    {
        if (!TutEnabled)
        {
            return;
        } else
        { 
            switch (playPart)
            {
                case 1:
                    // Placehodler stuff
                    picture.SetActive(true);
                    positionOperator.StopMovement();
                    break;
                case 2:
                    // Placeholder stuff
                    break;
            }
        }
    }*/

    /*
    // OLD STUFF REMOVE AFTER FINISHED
    public void EndTutorial(int endPart)
    {
        switch (endPart)
        {
            case 1:
                // Placehodler stuff
                picture.SetActive(false);
                positionOperator.StartMovement();
                positionOperator.RestartSpeed();

                break;
            case 2:
                // Placehodler stuff
                break;
            case 3:
                // END OF TUTORIAl
                PlayerPrefs.SetInt("PlayTutorial", tutorialRun);
                CheckTutorialAvailable();
                break;
        }
    }*/
    #endregion

    void CheckTutorialAvailable()
    {
        tutorialPlayed = PlayerPrefs.GetInt("PlayTutorial", 0);
        if (tutorialPlayed > dontPlay)
        {
            TutEnabled = false;
        }
    }

    // NOTE: Debug only
    public void RestartTutorial()
    {
        PlayerPrefs.DeleteKey("PlayTutorial");
    }

    #region TUTORIAL PARTS

    public void PlayEndTutorialPart(int tutorial)
    {
        if (!TutEnabled)
        {
            return;
        }else
        {
            switch (tutorial)
            {
                case 1:
                    // NOTE: Show Swipe tutorial
                    ShowSwipeTut();
                    swipeCode.tutCheck = true;
                    break;

                case 2:
                    // NOTE: Hide Swipe tutorial + LAST TUTORIAL
                    Invoke ("HideSwipeTut", 0.5f);
                    
                    break;

                case 3:
                    // NOTE: Show ORB tutorial
                    Invoke("ShowOrbTut", 1f);
                    break;

                case 4:
                    // NOTE: Hide ORB tutorial
                    HideOrbTut();
                    PlayerPrefs.SetInt("PlayTutorial", tutorialRun);
                    CheckTutorialAvailable();
                    break;
            }
        }
    }

    #region MAINFRAME MOVEMENT

    void stopMainframeMovement()
    {
        positionOperator.StopMovement();
    }

    void startMainframeMovement()
    {
        positionOperator.StartMovement();
        positionOperator.RestartSpeed();
    }

    #endregion

    #region SWIPE

    void ShowSwipeTut()
    {
        swipeTut.SetActive(true);
        Invoke("stopMainframeMovement", 0.4f);
        StartCoroutine("SpinAnimation");

    }

    void HideSwipeTut()
    {
        startMainframeMovement();
        swipeTut.SetActive(false);
        StopCoroutine("SpinAnimation");
        swipePart.transform.rotation = Quaternion.identity;
    }

    IEnumerator SpinAnimation()
    {
        Quaternion from = swipePart.transform.rotation;
        Quaternion to = swipePart.transform.rotation;
        to *= Quaternion.Euler(Vector3.forward * 90);

        float elapsed = 0.0f;
        while (elapsed < 0.5f)
        {
            swipePart.transform.rotation = Quaternion.Slerp(from, to, elapsed / 0.5f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        swipePart.transform.rotation = to;
        yield return new WaitForSeconds(1f);
        swipePart.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(1f);
        StartCoroutine("SpinAnimation");
    }

    #endregion

    #region ORB

    public void ShowOrbTut()
    {
        // NOTE: BUG WORKAROUND this is to prevent game stuck in tutrial screne, do not know what causes it
        if (!orbScript.OrbState)
        {
            HideOrbTut();
            orbScript.StopOrbParticle();
        } else
        {
            orbTut.SetActive(true);
            Invoke("stopMainframeMovement", 0.7f);
        }
    }

    public void HideOrbTut()
    {
        startMainframeMovement();
        orbTut.SetActive(false);
    }

    #endregion

    #region ADD
    //TO DO
    #endregion

    #region REMOVE
    // TO DO
    #endregion



    #endregion

}
