using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreNumber;
    public GameObject Mainframe;

    MainframeActionSelection mainframeActionSelection;
    int score;

    void Awake()
    {
        mainframeActionSelection = Mainframe.GetComponent<MainframeActionSelection>();
    }
	
	void Update () {
        //score = mainframeActionSelection.numberOfLoops;
        scoreNumber.text = "" + score;
    }

    public void addPoint()
    {
        score += 1;
    }

}
