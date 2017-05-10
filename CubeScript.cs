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
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
        mainframeScript = MainframeCube.GetComponent<MainframeScript>();

	}

    void Update()
    {
        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddContact();
        }
        */
        #endregion
    }

    #region SENDING SIGNAL TO MAINFRAME PREFABS

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
    # endregion

    #region STATE OF THE PREFAB
    public void SetAsActive()
    {
        ActivePlayerPrefab = true;
    }

    public void SetAsDisabled()
    {
        ActivePlayerPrefab = false;
    }
    # endregion

    #region CONNECTION WITH ARRAYTEST
    public void RemoveContact()
    {
        arrayTest.PlayerBeamRemoveContact(gameObject);
    }

    public void AddContact()
    {
        arrayTest.PlayerBeamAddContact(gameObject);
    }
# endregion

    #region COLLISION RULES
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == ("Active"))
        {
            if (other.gameObject.CompareTag("Active"))
            {
                // success, point added, new round coming
            }
            else if (other.gameObject.CompareTag("Remove"))
            {
                // success, change state of this prefab (deactivate), new round coming
                SetAsDisabled();
                RemoveContact();
            }
            else
            {
                // fail, stop the game
                arrayTest.GameOver();
            }
        } else if (gameObject.tag == ("NotActive"))
        {
            if (other.gameObject.CompareTag("Add"))
            {
                // success, change state of this prefab (activate), new round coming
                SetAsActive();
                AddContact();
            }
            else if (other.gameObject.CompareTag("NotActive"))
            {
                // success, point added, new round coming
            }
            else if (other.gameObject.CompareTag("Active"))
            {
                // success, point added, new round coming
                //happens when extra active mainframe beam hits invisible player beam
            }
            else
            {
                // fail, stop the game
                arrayTest.GameOver();
            }
        }
    }
    #endregion
}
