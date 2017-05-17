using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreNumber;
    public GameObject Mainframe;

    MainframeActionSelection mainframeActionSelection;
    public int score = 0;

    void Awake()
    {
        mainframeActionSelection = Mainframe.GetComponent<MainframeActionSelection>();
    }
	
	void Update () {
        scoreNumber.text = "" + score;
    }

    public void addPoint()
    {
        score += 1;
    }

    public void resetScore()
    {
        score = 0;
    }
}
