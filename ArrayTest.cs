using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour {

    public List<GameObject> listActive = new List<GameObject>();
    public List<GameObject> listDisabled = new List<GameObject>();
    public List<GameObject> mainframeListActive = new List<GameObject>();
    public List<GameObject> mainframeListDisabled = new List<GameObject>();
    public List<GameObject> allPlayerPrefabs = new List<GameObject>();
    public int activeNumber;
    public int disabledNumber;

    private MainframeController mainframeController;
    private GameObject randomSelectionFromLists;
    private bool GameStarted;
    private bool gameEnded;

    void Start() {

        GameObject MainframeController = GameObject.FindWithTag("MainframeController");
        mainframeController = MainframeController.GetComponent<MainframeController>();

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.R))
        {
            RunTheGame();
        }

        if (!gameEnded)
        {
            StopCoroutine(RunningGame());
        }

        #region TEST INPUT

        /*if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            MainframeListActiveActivation();
            MainframeListDeactivation();
        }*/

        /*if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            MainframeListClean();
        }*/


        /*if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            randomSelectionFromLists = RandomSelection(mainframeListActive);
            Debug.Log(randomSelectionFromLists);
            DisableMeshRenderer(randomSelectionFromLists);
        }*/

        /*if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            mainframeController.RandomSelection();
        }*/

        /*if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            mainframeController.ResetRotation();
        }*/
#endregion
    }

    #region COROUTINE

                                                                        /// CONTINUE ///
    IEnumerator RunningGame()
    {
        // Runtime of the game
        // Mainframe movement in PositionOperator.cs
        yield return null;
    }

    #endregion

    #region MAIN METHODS 

    void RunTheGame()
    {
        GameStarted = true;
        StartCoroutine(RunningGame());
    }

    void FirstTimePlayerSetup()
    {
        AssignInDisableList();
        PlayerPrefabRandomSelection();
        listActiveEnable();
        listDisabledDisable();
    }

    void UpdateOfMainframe()
    {
        mainframeController.ResetRotation();
        MainframeListClean();
        ActivateSignalSendThroughPlayerPrefabs();
        // Random spawn of beams / remove / add
        mainframeController.RandomSelection();
    } 

    #endregion

    # region PLAYER PREFABS
    // PLAYER prefabs

    void AssignInDisableList()
    {
        disabledNumber = 4;
        for (int i = 0; i < disabledNumber; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            selected = listDisabled[i];
            MeshRenderer m = selected.GetComponent<MeshRenderer>();
            m.enabled = false;
            cubeScript = selected.GetComponent<CubeScript>();
            cubeScript.SetAsDisabled();

        }
    }

    void PlayerPrefabRandomSelection()
    {
        int numberOfSelections = 2;
        for (int i = 0; i < numberOfSelections; i++)
        {
            int randomSelection = Random.Range(0, listDisabled.Count);
            listActive.Add(listDisabled[randomSelection]);
            activeNumber += 1;
            disabledNumber -= 1;
            listDisabled.Remove(listDisabled[randomSelection]);
            listActiveEnable();
        }

    }

    void listActiveEnable()
    {
        for (int i = 0; i < activeNumber; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            selected = listActive[i];
            MeshRenderer m = selected.GetComponent<MeshRenderer>();
            m.enabled = true;
            cubeScript = selected.GetComponent<CubeScript>();
            cubeScript.SetAsActive();
            TagAssignment(selected, 1);
        }
    }

    void listDisabledDisable()
    {
        for (int i = 0; i < disabledNumber; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            selected = listDisabled[i];
            MeshRenderer m = selected.GetComponent<MeshRenderer>();
            m.enabled = false;
            cubeScript = selected.GetComponent<CubeScript>();
            cubeScript.SetAsDisabled();
            TagAssignment(selected, 2);
        }
    }

    void ActivateSignalSendThroughPlayerPrefabs()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            selected = allPlayerPrefabs[i];
            cubeScript = selected.GetComponent<CubeScript>();
            cubeScript.SendSignalToMainframePrefabs();
        }
    }

    #endregion

    #region OUTSIDE INPUT
    // OUTSIDE Input

    public void PlayerBeamRemoveContact(GameObject selected)
    {
        Debug.Log("Player beam has been hit by remove action");
        int cubeIndex;
        cubeIndex = listActive.IndexOf(selected);
        listDisabled.Add(selected);
        disabledNumber += 1;
        activeNumber -= 1;
        listActive.RemoveAt(cubeIndex);
        listDisabledDisable();
        TagAssignment(selected, 2);
    }

    public void PlayerBeamAddContact(GameObject selected)
    {
        Debug.Log("Player beam was added by add action");
        int cubeIndex;
        cubeIndex = listDisabled.IndexOf(selected);
        listActive.Add(selected);
        disabledNumber -= 1;
        activeNumber += 1;
        listDisabled.RemoveAt(cubeIndex);
        listDisabledDisable();
        TagAssignment(selected, 2);
    }
    #endregion

    # region MAINFRAME PREFABS
    // MAINFRAME prefabs

    public void AddToMainframeListActive(GameObject selected)
    {
        Debug.Log("Mainframe block added to active list");
        mainframeListActive.Add(selected);
    }

    public void AddToMainframeListDisabled(GameObject selected)
    {
        Debug.Log("Mainframe block added to disabled list");
        mainframeListDisabled.Add(selected);
    }

    public void MainframeListActiveActivation()
    {
        Debug.Log("Activation of mainframe prefabs");
        for (int i = 0; i < mainframeListActive.Count; i++)
        {
            GameObject selected;
            selected = mainframeListActive[i];
            MeshRenderer mesh;
            mesh = selected.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            TagAssignment(selected, 1);
        }
    }

    public void MainframeListDeactivation()
    {
        Debug.Log("Deactivatio of mainrame prefabs");
        for (int i = 0; i < mainframeListDisabled.Count; i++)
        {
            GameObject selected;
            selected = mainframeListDisabled[i];
            TagAssignment(selected, 2);
        }
    }

    public void MainframeListClean()
    {
        Debug.Log("Cleaning of mainframe lists");
        for (int i = 0; i < mainframeListActive.Count; i++)
        {
            GameObject mainframeBeam;
            mainframeBeam = mainframeListActive[i];
            MeshRenderer mesh;
            mesh = mainframeBeam.GetComponent<MeshRenderer>();
            mesh.enabled = false;
            TagAssignment(mainframeBeam, 2);
        }
        mainframeListDisabled.Clear();
        mainframeListActive.Clear();
    }

    #endregion

    # region REUSABLE METHODS
    /// REUSABLE METHODS

    // Random selection from a list - returns selected object
    GameObject RandomSelection(List<GameObject> listToUse)
    {
        GameObject selected;
        int randomNumber;
        randomNumber = Random.Range(0, listToUse.Count);
        selected = listToUse[randomNumber];

        return selected;
    }

    // Switching the MeshRenderer
    public void DisableMeshRenderer(GameObject mainframePrefab)
    {
        MeshRenderer meshR;
        meshR = mainframePrefab.GetComponent<MeshRenderer>();
        meshR.enabled = !meshR.enabled;
    }

    // Tag assigner
    public void TagAssignment(GameObject AssignTag, int beamTag)
    {
        switch (beamTag)
        {
            case 1:
                print("object tag active");
                AssignTag.tag = "Active";
                break;
            case 2:
                print("object tag NotActive");
                AssignTag.tag = "NotActive";
                break;
            case 3:
                print("object tag Add");
                AssignTag.tag = "Add";
                break;
            case 4:
                print("object tag Remove");
                AssignTag.tag = "Remove";
                break;
            default:
                print("object tag No tag");
                break;
        }
    }
# endregion
}
