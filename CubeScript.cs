using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public GameObject MainframeCube;


    private ArrayTest arrayTest;
    private GameObject cube;

    private bool ActivePlayerPrefab;
    private MainframeScript mainframeScript;

	void Start () {

        cube = gameObject;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        mainframeScript = MainframeCube.GetComponent<MainframeScript>();

	}

    public void SendSignalToMainframePrefabs()
    {
        if (ActivePlayerPrefab == false)
        {
            mainframeScript.AddToDisabledArray();
        }
        else
        {
            mainframeScript.AddToEnabledArray();
        }
    }

    public void RemoveContact()
    {
        arrayTest.PlayerBeamRemoveContact(gameObject);
    }

    public void AddContact()
    {
        arrayTest.PlayerBeamAddContact(gameObject);
    }

    public void SetAsActive()
    {
        ActivePlayerPrefab = true;
    }

    public void SetAsDisabled()
    {
        ActivePlayerPrefab = false;
    }

    // TO DO: set rules for each type of collision + send acording impulses to lists
    void OnTriggerEnter(Collider other)
    {

    }
}
