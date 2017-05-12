using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour {

    public float startWait;
    public float waveWait;
    public List<GameObject> listActive = new List<GameObject>();
    public List<GameObject> listDisabled = new List<GameObject>();
    public List<GameObject> mainframeListActive = new List<GameObject>();
    public List<GameObject> mainframeListDisabled = new List<GameObject>();
    public List<GameObject> allPlayerPrefabs = new List<GameObject>();
    public List<GameObject> AllMainframePrefabs = new List<GameObject>();
    public GameObject mainframeBody;
    public GameObject end;
    public GameObject gameOverText;
    public GameObject guiManagerObject;

    private MainframeController mainframeController;
    private MainframeActionSelection mainframeActionSelection;
    private PositionOperator positionOperator;
    private MaterialChanger materialChanger;
    private GameObject ExtraActionSelection;
    private GUIManager guiManager;

    private bool GameStarted;
    private bool gameRunning;
    public bool gameEnded;

    void Start() {

        GameObject MainframeController = GameObject.FindWithTag("MainframeController");
        mainframeController = MainframeController.GetComponent<MainframeController>();
        mainframeActionSelection = MainframeController.GetComponent<MainframeActionSelection>();
        positionOperator = mainframeBody.GetComponent<PositionOperator>();
        materialChanger = GetComponent<MaterialChanger>();
        guiManager = guiManagerObject.GetComponent<GUIManager>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            RunTheGame();
        }

        #region TEST INPUT

        /*if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefabRandomSelection();
            Debug.Log("O pressed");
        }*/

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

        #region TEST INPUT2
        /*
        if (Input.GetKeyDown(KeyCode.Q)) // Checked
        {
            AssignInDisableList();
            Debug.Log("<color=green><b> Action 1 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.W)) // Checked
        {
            PlayerPrefabRandomSelection();
            Debug.Log("<color=red><b> Action 2 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.E)) // Checked
        {
            listActiveEnable();
            Debug.Log("<color=green><b> Action 3 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.R)) // Checked
        {
            listDisabledDisable();
            Debug.Log("<color=red><b> Action 4 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.T)) // Checked
        {
            mainframeController.ResetRotation();
            Debug.Log("<color=green><b> Action 5 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.Y)) // Checked
        {
            MainframeListClean();
            Debug.Log("<color=red><b> Action 6 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.U)) // Checked 
        {
            ActivateSignalSendThroughPlayerPrefabs();
            Debug.Log("<color=green><b> Action 7 </b></color>");
        }

        if (Input.GetKeyDown(KeyCode.A)) // Checked 
        {
            MainframeListActiveActivation();
            Debug.Log("<color=red><b> Action 8_1 </b></color>");
        }

        if (Input.GetKeyDown(KeyCode.S)) // Checked 
        {
            MainframeListDeactivation();
            Debug.Log("<color=red><b> Action 8_2 </b></color>");
        }

        if (Input.GetKeyDown(KeyCode.I)) // PROBLEM: Remove action called!!!
        {
           mainframeActionSelection.SetRandomAction();
            Debug.Log("<color=red><b> Action 8_3 </b></color>");
        }

        if (Input.GetKeyDown(KeyCode.O)) // Checked
        {
            mainframeController.RandomSelection();
            Debug.Log("<color=green><b> Action 9 </b></color>");
        }
        if (Input.GetKeyDown(KeyCode.P)) // Checked
        {
            positionOperator.StartMovement();
            Debug.Log("<color=red><b> Action 10 </b></color>");
        }
        */
        # endregion
    }

    #region MAIN METHODS 

    public void RunTheGame()
    {
        GameStarted = true;
        gameRunning = true;

        // NOTE: First time player setup
        AssignInDisableList();
        PlayerPrefabRandomSelection();
        listActiveEnable();
        listDisabledDisable();

        // NOTE: Mainframe setup
        mainframeController.ResetRotation();
        MainframeListClean();
        ActivateSignalSendThroughPlayerPrefabs();
        MainframeListActiveActivation();
        MainframeListDeactivation();
        mainframeActionSelection.SetRandomAction();
        mainframeController.RandomSelection();

        // NOTE: Start mainframe movement
        positionOperator.StartMovement();
    }

    // NOTE: End of round is called on trigger enter in PositionOperator.cs 31
    public void EndOfRound()
    {
        mainframeController.ResetRotation();
        MainframeListClean();
        ActivateSignalSendThroughPlayerPrefabs();
        MainframeListActiveActivation();
        MainframeListDeactivation();
        mainframeActionSelection.SetRandomAction();
        mainframeController.RandomSelection();
        if (!gameEnded)
        {
            positionOperator.StartMovement();
        }
    } 

    public void GameOver()
    {
        gameEnded = true;
        gameOverText.SetActive(true);
        Invoke("CallGUIEndAnimation", 1f);
    }

    // NOTE: Inovke on game over GUI animation
    void CallGUIEndAnimation()
    {
        guiManager.FromGameToMenu();
    }

    #endregion

    #region PLAYER PREFABS
    void AssignInDisableList()
    {
        for (int i = 0; i < listDisabled.Count; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            Component[] meshRenderer;
            selected = listDisabled[i];
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = false;
            }
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
            listDisabled.Remove(listDisabled[randomSelection]);
        }

    }

    void listActiveEnable()
    {
        for (int i = 0; i < listActive.Count; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            selected = listActive[i];
            Component[] meshRenderer;
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = true;
            }
            cubeScript = selected.GetComponent<CubeScript>();
            cubeScript.SetAsActive();
            TagAssignment(selected, 1);
        }
    }

    void listDisabledDisable()
    {
        for (int i = 0; i < listDisabled.Count; i++)
        {
            GameObject selected;
            CubeScript cubeScript;
            Component[] meshRenderer;
            selected = listDisabled[i];
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = false;
            }
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
    public void PlayerBeamRemoveContact(GameObject selected)
    {
        int cubeIndex;
        cubeIndex = listActive.IndexOf(selected);
        listDisabled.Add(selected);
        listActive.RemoveAt(cubeIndex);
        listDisabledDisable();
        listActiveEnable();
    }

    public void PlayerBeamAddContact(GameObject selected)
    {
        int cubeIndex;
        cubeIndex = listDisabled.IndexOf(selected);
        listActive.Add(selected);
        listDisabled.RemoveAt(cubeIndex);
        listDisabledDisable();
        listActiveEnable();
    }

    public void PlayLaserParticle()
    {
        for (int i = 0; i < listActive.Count; i++)
        {
            GameObject playerBeam;
            CubeScript cubeParticleScript;
            playerBeam = listActive[i];
            cubeParticleScript = playerBeam.GetComponent<CubeScript>();
            cubeParticleScript.playLaserParticle();
        }
    }

    #endregion

    # region MAINFRAME PREFABS

    public void AddToMainframeListActive(GameObject selected)
    {
        mainframeListActive.Add(selected);
    }

    public void AddToMainframeListDisabled(GameObject selected)
    {
        mainframeListDisabled.Add(selected);
    }

    public void MainframeListActiveActivation()
    {
        for (int i = 0; i < mainframeListActive.Count; i++)
        {
            GameObject selected;
            MainframeScript mainframeScript;
            selected = mainframeListActive[i];
            mainframeScript = selected.GetComponent<MainframeScript>();
            mainframeScript.activeMainframePrefab();
            TagAssignment(selected, 1);
        }
    }

    public void MainframeListDeactivation()
    {
        for (int i = 0; i < mainframeListDisabled.Count; i++)
        {
            GameObject selected;
            MainframeScript mainframeScript;
            selected = mainframeListDisabled[i];
            mainframeScript = selected.GetComponent<MainframeScript>();
            mainframeScript.deactivatedMainframePrefab();
            TagAssignment(selected, 2);
        }
    }

    public void MainframeListClean()
    {
        // NOTE: Reset of Mainframe GameObjects to their default state (tag, material)
        for (int i = 0; i < AllMainframePrefabs.Count; i++)
        {
            GameObject mainframeBeam;
            MainframeScript mainframeScript;
            mainframeBeam = AllMainframePrefabs[i];
            mainframeScript = mainframeBeam.GetComponent<MainframeScript>();
            mainframeScript.resetMainframePrefab();
            TagAssignment(mainframeBeam, 2);
        }

        // NOTE: Cleaning of Mainframe lists for new assignment
        mainframeListDisabled.Clear();
        mainframeListActive.Clear();
    }
    #endregion

    #region MAINFRAME RANDOM ACTIONS
    public GameObject RandomMainframeBeamSelection()
    {
        int randomSelection;
        MainframeScript mainframeScript;
        randomSelection = Random.Range(0, mainframeListDisabled.Count);
        ExtraActionSelection = mainframeListDisabled[randomSelection];
        mainframeScript = ExtraActionSelection.GetComponent<MainframeScript>();
        mainframeScript.activeMainframePrefab();
        TagAssignment(ExtraActionSelection, 1);
        return ExtraActionSelection;
    }

    public GameObject RemoveRandomSelectionFromMainframeActive()
    {
        int randomSelection;
        MainframeScript mainframeScript;
        randomSelection = Random.Range (0, mainframeListActive.Count);
        ExtraActionSelection = mainframeListActive[randomSelection];
        mainframeScript = ExtraActionSelection.GetComponent<MainframeScript>();
        mainframeScript.removeMainframePrefab();
        TagAssignment(ExtraActionSelection, 4);
        return ExtraActionSelection;
    }

    public GameObject AddRandomSelectionFromManiframeDisabled()
    {
        int randomSelection;
        MainframeScript mainframeScript;
        randomSelection = Random.Range(0, mainframeListDisabled.Count);
        ExtraActionSelection = mainframeListDisabled[randomSelection];
        mainframeScript = ExtraActionSelection.GetComponent<MainframeScript>();
        mainframeScript.addMainframePrefab();
        TagAssignment(ExtraActionSelection, 3);
        return ExtraActionSelection;
    }
    #endregion

    #region REUSABLE METHODS

    // NOTE: Random selection from a list - returns selected object
    GameObject RandomSelection(List<GameObject> listToUse)
    {
        GameObject selected;
        int randomNumber;
        randomNumber = Random.Range(0, listToUse.Count);
        selected = listToUse[randomNumber];

        return selected;
    }

    // NOTE: Switching the MeshRenderer
    public void DisableMeshRenderer(GameObject mainframePrefab)
    {
        Component[] meshRenderer;
        meshRenderer = ExtraActionSelection.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshRenderer)
        {
            mesh.enabled = !mesh.enabled;
        }
    }

    // NOTE: Tag assigner
    public void TagAssignment(GameObject AssignTag, int beamTag)
    {
        switch (beamTag)
        {
            case 1:
                AssignTag.tag = "Active";
                break;
            case 2:
                AssignTag.tag = "NotActive";
                break;
            case 3:
                AssignTag.tag = "Add";
                break;
            case 4:
                AssignTag.tag = "Remove";
                break;
            default:
                break;
        }
    }
# endregion
}
