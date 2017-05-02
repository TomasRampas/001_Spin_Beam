using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeScript : MonoBehaviour {

    private GameObject gameManager;
    private ArrayTest arrayTest;

    void Start() {
        gameManager = GameObject.FindWithTag("GameController");
        arrayTest = gameManager.GetComponent<ArrayTest>();

    }

    public void AddToEnabledArray()
    {
        arrayTest.AddToMainframeListActive(gameObject);
    }

    public void AddToDisabledArray()
    {
        arrayTest.AddToMainframeListDisabled(gameObject);
    }
}