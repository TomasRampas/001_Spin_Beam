using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    // Placeholder stuff
    public GameObject picture;

    public GameObject MainframeBody;
    public bool TutEnabled = true;

    int tutorialPlayed;
    int tutorialRun = 1;
    int dontPlay = 0;
    TutorialScript tutorialScript;
    PositionOperator positionOperator;

	void Start ()
    {
        CheckTutorialAvailable();
        positionOperator = MainframeBody.GetComponent<PositionOperator>();
    }
	

	void Update ()
    {
        #region TEST INPUT
        /*
        if(Input.GetKeyDown(KeyCode.P))
        {
            RestartTutorial();
        }*/
        #endregion

    }

    #region TUTORIAL STATE
    public void PlayTutorial(int playPart)
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
    }
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

    public void TestingStuff()
    {
        int blue;
        int yellow;

        blue = 1;
        yellow = 0;

        if (blue * yellow == 1)
        {

        }

        if (blue + yellow < 2)
        {

        }
    }

}
