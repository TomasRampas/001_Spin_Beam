using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public GameObject MainframeCube;
    public GameObject LaserParticle;
    public GameObject PlayerBeamBodyEmissive;
    public GameObject PlayerBeamBody;

    private ArrayTest arrayTest;
    private GameObject cube;
    private OrbScript orbScript;

    private bool ActivePlayerPrefab;
    private MainframeScript mainframeScript;

    void Awake()
    {
        cube = gameObject;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
        mainframeScript = MainframeCube.GetComponent<MainframeScript>();
    }

    void Start () {

        /*
        cube = gameObject;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
        mainframeScript = MainframeCube.GetComponent<MainframeScript>();
        */

        // INFO: Make connection with orb script
        GameObject orb = GameObject.FindWithTag("Orb");
        orbScript = orb.GetComponent<OrbScript>();
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

    #region RESET
    public void resetThePlayerBeam()
    {
        SetAsDisabled();
        MeshRenderer mesh;

        GameObject[] parts = new GameObject[] { PlayerBeamBodyEmissive, PlayerBeamBody };
        foreach (GameObject item in parts)
        {
            mesh = item.GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }
    }
    #endregion

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
                MainframeScript mainScript;
                mainScript = other.GetComponent<MainframeScript>();
                mainScript.removeContact();
                
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
                MainframeScript mainScript;
                mainScript = other.GetComponent<MainframeScript>();
                mainScript.addContact();
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

    #region PARTICLE

    public void playLaserParticle()
    {
        LaserScript laserScript;
        laserScript = LaserParticle.GetComponent<LaserScript>();
        laserScript.PlayLaserParticle();
    }

    # endregion
}
