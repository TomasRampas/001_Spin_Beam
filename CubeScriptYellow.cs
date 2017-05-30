using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScriptYellow : MonoBehaviour {

    public GameObject MainframeCube;
    public GameObject LaserParticle;
    public GameObject PlayerBeamBodyEmissive;
    public GameObject PlayerBeamBody;

    private ArrayTest arrayTest;
    private GameObject cube;
    private OrbScript orbScript;

    private bool ActivePlayerPrefab;
    private MainframeScriptYellow mainframeScript;
    private PlayerRotationSelection playerRotationSelection;

    void Awake()
    {
        cube = gameObject;
        playerRotationSelection = gameObject.GetComponent<PlayerRotationSelection>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
        mainframeScript = MainframeCube.GetComponent<MainframeScriptYellow>();
    }

    void Start () {

       

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
            playerRotationSelection.objectActive = false;
            mainframeScript.AddToDisabledArray();
        }
        else
        {
            playerRotationSelection.objectActive = true;
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
        arrayTest.PlayerBeamRemoveContactYellow(gameObject);
    }

    public void AddContact()
    {
        arrayTest.PlayerBeamAddContactYellow(gameObject);
    }
# endregion

    #region COLLISION RULES
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == ("ActiveYellow"))
        {
            if (other.gameObject.CompareTag("ActiveYellow"))
            {
                // success, point added, new round coming
            }
            else if (other.gameObject.CompareTag("RemoveYellow"))
            {
                // success, change state of this prefab (deactivate), new round coming
                SetAsDisabled();
                RemoveContact();
                MainframeScriptYellow mainScript;
                mainScript = other.GetComponent<MainframeScriptYellow>();
                mainScript.removeContact();
                
            }
            else
            {
                // fail, stop the game
                arrayTest.GameOver();
            }
        } else if (gameObject.tag == ("NotActiveYellow"))
        {
            if (other.gameObject.CompareTag("AddYellow"))
            {
                // success, change state of this prefab (activate), new round coming
                SetAsActive();
                AddContact();
                MainframeScriptYellow mainScript;
                mainScript = other.GetComponent<MainframeScriptYellow>();
                mainScript.addContact();
            }
            else if (other.gameObject.CompareTag("NotActiveYellow"))
            {
                // success, point added, new round coming
            }
            else if (other.gameObject.CompareTag("ActiveYellow"))
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

    #endregion
}
