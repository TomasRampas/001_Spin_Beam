using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour {



    #region BLUE LISTS
    public List<GameObject> listActive = new List<GameObject>();
    public List<GameObject> listDisabled = new List<GameObject>();
    public List<GameObject> mainframeListActive = new List<GameObject>();
    public List<GameObject> mainframeListDisabled = new List<GameObject>();
    #endregion

    #region YELLOW LISTS
    public List<GameObject> listActiveYellow = new List<GameObject>();
    public List<GameObject> listDisabledYellow = new List<GameObject>();
    public List<GameObject> mainframeListActiveYellow = new List<GameObject>();
    public List<GameObject> mainframeListDisabledYellow = new List<GameObject>();
    #endregion

    #region SHARED LISTS
    public List<GameObject> allPlayerPrefabs = new List<GameObject>();
    public List<GameObject> AllMainframePrefabs = new List<GameObject>();
    #endregion

    public float startWait;
    public float waveWait;

    public GameObject mainframeBody;
    public GameObject end;
    public GameObject gameOverText;
    public GameObject guiManagerObject;
    public GameObject mainframe;

    private MainframeController mainframeController;
    private MainframeActionSelection mainframeActionSelection;
    private PositionOperator positionOperator;
    private MaterialChanger materialChanger;
    private GameObject ExtraActionSelection;
    private GUIManager guiManager;
    private RotationSelection rotationSelection;

    private bool GameStarted;
    private bool gameRunning;
    public bool gameOver;

    void Start()
    {
        rotationSelection = mainframe.GetComponent<RotationSelection>();
        GameObject MainframeController = GameObject.FindWithTag("MainframeController");
        mainframeController = MainframeController.GetComponent<MainframeController>();
        mainframeActionSelection = MainframeController.GetComponent<MainframeActionSelection>();
        positionOperator = mainframeBody.GetComponent<PositionOperator>();
        materialChanger = GetComponent<MaterialChanger>();
        guiManager = guiManagerObject.GetComponent<GUIManager>();
        PreparationOfTheFirstGame();
    }

    void Update() {

		#region TEST INPUT

		/*
		     if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            RunTheGame();
        }
			if (Input.GetKeyDown(KeyCode.O))
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
		#endregion
	}

	#region MAIN METHODS 

	public void PreparationOfTheFirstGame()
    {

        // NOTE: First time player setup
        AssignInDisableList();
        AssignInDisableListYellow();

        PlayerPrefabRandomSelection();
        PlayerPrefabRandomSelectionYellow();

        listActiveEnable();
        listActiveEnableYellow();

        listDisabledDisable();
        listDisabledDisableYellow();

        // NOTE: Mainframe setup
        mainframeController.ResetRotation();
        MainframeListClean();
        ActivateSignalSendThroughPlayerPrefabs();

        MainframeListActiveActivation();
        MainframeListActiveActivationYellow();

        MainframeListDeactivation();
        MainframeListDeactivationYellow();

        mainframeActionSelection.CallRandomAction();
        AssignAllBeamsInActiveLists();

        rotationSelection.SetMainframeRotation();

    }

    public void RunTheGame()
    {
        GameStarted = true;
        gameRunning = true;

        // NOTE: Start mainframe movement
        positionOperator.StartMovement();
    }

    // NOTE: End of round is called on trigger enter in PositionOperator.cs 31
    public void EndOfRound()
    {
        if (!gameOver)
        {
            mainframeController.ResetRotation();
            MainframeListClean();
            ActivateSignalSendThroughPlayerPrefabs();

            MainframeListActiveActivation();
            MainframeListActiveActivationYellow();

            MainframeListDeactivation();
            MainframeListDeactivationYellow();

            mainframeActionSelection.CallRandomAction();
            AssignAllBeamsInActiveLists();

            rotationSelection.SetMainframeRotation();

            positionOperator.StartMovement();
        } else
        {
            return;
        }

    } 

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        guiManager.gameOverCalledOver();
    }

    #endregion

    #region GAME RESET

    public void GameReset()
    {
        gameOverText.SetActive(false);
        ResetOfPlayerLists();
        MainframeListClean();
        gameOver = false;

        // NOTE: for loops assigning game object to disable lists for blue and yellow
        for (int i = 0; i < 4; i++)
        {
            GameObject selected;
            selected = allPlayerPrefabs[i];
            listDisabled.Add(selected);
        }

        for (int i = 4; i < 8; i++)
        {
            GameObject selected;
            selected = allPlayerPrefabs[i];
            listDisabledYellow.Add(selected);
        }

        mainframeActionSelection.ResetMainframeActionSelection();

        PreparationOfTheFirstGame();
    }
    #endregion

    #region PLAYER PREFABS

    #region PLAYER BLUE
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
        // NOTE: IMPORTANT the numberOfSelections defines how many blue beam are active on the start
        int numberOfSelections = 1; 
        for (int i = 0; i < numberOfSelections; i++)
        {
            GameObject selected;
            CubeScript prefabScript;
            int randomSelection = Random.Range(0, listDisabled.Count);
            selected = listDisabled[randomSelection];
            prefabScript = selected.GetComponent<CubeScript>();
            prefabScript.SetAsActive();
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
    #endregion

    #region PLAYER YELLOW
    void AssignInDisableListYellow()
    {
        for (int i = 0; i < listDisabledYellow.Count; i++)
        {
            GameObject selected;
            CubeScriptYellow cubeScriptYellow;
            Component[] meshRenderer;
            selected = listDisabledYellow[i];
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = false;
            }
            cubeScriptYellow = selected.GetComponent<CubeScriptYellow>();
            cubeScriptYellow.SetAsDisabled();

        }
    }

    void PlayerPrefabRandomSelectionYellow()
    {
        int numberOfSelections = 1;
        for (int i = 0; i < numberOfSelections; i++)
        {
            GameObject selected;
            CubeScriptYellow prefabScriptYellow;
            int randomSelection = Random.Range(0, listDisabledYellow.Count);
            selected = listDisabledYellow[randomSelection];
            prefabScriptYellow = selected.GetComponent<CubeScriptYellow>();
            prefabScriptYellow.SetAsActive();
            listActiveYellow.Add(listDisabledYellow[randomSelection]);
            listDisabledYellow.Remove(listDisabledYellow[randomSelection]);
        }

    }

    void listActiveEnableYellow()
    {
        for (int i = 0; i < listActiveYellow.Count; i++)
        {
            GameObject selected;
            CubeScriptYellow cubeScriptYellow;
            selected = listActiveYellow[i];
            Component[] meshRenderer;
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = true;
            }
            cubeScriptYellow = selected.GetComponent<CubeScriptYellow>();
            cubeScriptYellow.SetAsActive();
            TagAssignment(selected, 5);
        }
    }

    void listDisabledDisableYellow()
    {
        for (int i = 0; i < listDisabledYellow.Count; i++)
        {
            GameObject selected;
            CubeScriptYellow cubeScriptYellow;
            Component[] meshRenderer;
            selected = listDisabledYellow[i];
            meshRenderer = selected.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshRenderer)
            {
                mesh.enabled = false;
            }
            cubeScriptYellow = selected.GetComponent<CubeScriptYellow>();
            cubeScriptYellow.SetAsDisabled();
            TagAssignment(selected, 6);
        }
    }
    #endregion

    #region PLAYER SHARED

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

        for (int i = 4; i < 8; i++)
        {
            GameObject selected;
            CubeScriptYellow cubeScriptYellow;
            selected = allPlayerPrefabs[i];
            cubeScriptYellow = selected.GetComponent<CubeScriptYellow>();
            cubeScriptYellow.SendSignalToMainframePrefabs();
        }
    }

    void ResetOfPlayerLists()
    {
        // NOTE: Reset of Player GameObjects to their default state (tag, material)
        for (int i = 0; i < 4; i++)
        {
            GameObject playerBeam;
            CubeScript cubeScript;
            playerBeam = allPlayerPrefabs[i];
            cubeScript = playerBeam.GetComponent<CubeScript>();
            cubeScript.resetThePlayerBeam();
            TagAssignment(playerBeam, 2);
        }

        for (int i = 4; i < 8; i++)
        {
            GameObject playerBeam;
            CubeScriptYellow cubeScriptYellow;
            playerBeam = allPlayerPrefabs[i];
            cubeScriptYellow = playerBeam.GetComponent<CubeScriptYellow>();
            cubeScriptYellow.resetThePlayerBeam();
            TagAssignment(playerBeam, 6);
        }

        // NOTE: Cleaning of Mainframe lists for new assignment
        listActive.Clear();
        listDisabled.Clear();
        listActiveYellow.Clear();
        listDisabledYellow.Clear();
    }
    #endregion
    #endregion

    #region SELECTION OF MAINFRAME ROTATION
    
    // NOTE: Assign all mainframe and player beams in active lists
    void AssignAllBeamsInActiveLists()
    {
        for (int i = 0; i < allPlayerPrefabs.Count; i++)
        {
            GameObject selected;
            PlayerRotationSelection playerRotationSelection;
            selected = allPlayerPrefabs[i];
            playerRotationSelection = selected.GetComponent<PlayerRotationSelection>();
            playerRotationSelection.AssignPlayerBeamToSelectionList();
        }

        for (int i = 0; i < AllMainframePrefabs.Count; i++)
        {
            GameObject selected;
            MainframeRotationSelection mainframeRotationSelection;
            selected = AllMainframePrefabs[i];
            mainframeRotationSelection = selected.GetComponent<MainframeRotationSelection>();
            mainframeRotationSelection.AssignMainframeBeamToSelectionList();
        }
    }


    #endregion

    #region OUTSIDE INPUT

    #region BLUE PREFABS INPUT
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
    #endregion

    #region YELLOW PREFABS INPUT
    public void PlayerBeamRemoveContactYellow(GameObject selected)
    {
        int cubeIndex;
        cubeIndex = listActiveYellow.IndexOf(selected);
        listDisabledYellow.Add(selected);
        listActiveYellow.RemoveAt(cubeIndex);
        listDisabledDisableYellow();
        listActiveEnableYellow();
    }

    public void PlayerBeamAddContactYellow(GameObject selected)
    {
        int cubeIndex;
        cubeIndex = listDisabledYellow.IndexOf(selected);
        listActiveYellow.Add(selected);
        listDisabledYellow.RemoveAt(cubeIndex);
        listDisabledDisableYellow();
        listActiveEnableYellow();
    }
    #endregion

    #region SHARED
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

        for (int i = 0; i < listActiveYellow.Count; i++)
        {
            GameObject playerBeam;
            CubeScriptYellow cubeParticleScript;
            playerBeam = listActiveYellow[i];
            cubeParticleScript = playerBeam.GetComponent<CubeScriptYellow>();
            cubeParticleScript.playLaserParticle();
        }

    }
    #endregion

    #endregion

    #region MAINFRAME PREFABS

    #region MAINFRAME BLUE
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
    #endregion

    #region MAINFRAME YELLOW
    public void AddToMainframeListActiveYellow(GameObject selected)
    {
        mainframeListActiveYellow.Add(selected);
    }

    public void AddToMainframeListDisabledYellow(GameObject selected)
    {
        mainframeListDisabledYellow.Add(selected);
    }

    public void MainframeListActiveActivationYellow()
    {
        for (int i = 0; i < mainframeListActiveYellow.Count; i++)
        {
            GameObject selected;
            MainframeScriptYellow mainframeScriptYellow;
            selected = mainframeListActiveYellow[i];
            mainframeScriptYellow = selected.GetComponent<MainframeScriptYellow>();
            mainframeScriptYellow.activeMainframePrefab();
            TagAssignment(selected, 5);
        }
    }

    public void MainframeListDeactivationYellow()
    {
        for (int i = 0; i < mainframeListDisabledYellow.Count; i++)
        {
            GameObject selected;
            MainframeScriptYellow mainframeScriptYellow;
            selected = mainframeListDisabledYellow[i];
            mainframeScriptYellow = selected.GetComponent<MainframeScriptYellow>();
            mainframeScriptYellow.deactivatedMainframePrefab();
            TagAssignment(selected, 6);
        }
    }
    #endregion

    #region SHARED METHODS
    public void MainframeListClean()
    {
        // NOTE: Reset of Mainframe GameObjects to their default state (tag, material)
        for (int i = 0; i < 4; i++)
        {
            GameObject mainframeBeam;
            MainframeScript mainframeScript;
            mainframeBeam = AllMainframePrefabs[i];
            mainframeScript = mainframeBeam.GetComponent<MainframeScript>();
            mainframeScript.resetMainframePrefab();
            TagAssignment(mainframeBeam, 2);
        }

        for (int i = 4; i < 8; i++)
        {
            GameObject mainframeBeam;
            MainframeScriptYellow mainframeScriptYellow;
            mainframeBeam = AllMainframePrefabs[i];
            mainframeScriptYellow = mainframeBeam.GetComponent<MainframeScriptYellow>();
            mainframeScriptYellow.resetMainframePrefab();
            TagAssignment(mainframeBeam, 6);
        }

        // NOTE: Cleaning of Mainframe lists for new assignment
        mainframeListDisabled.Clear();
        mainframeListActive.Clear();
        mainframeListDisabledYellow.Clear();
        mainframeListActiveYellow.Clear();
    }
    #endregion
    #endregion

    #region MAINFRAME RANDOM ACTIONS
    #region MAINFRAME BLUE
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

    #region MAINFRAME YELLOW
    public GameObject RandomMainframeBeamSelectionYellow()
    {
        int randomSelection;
        MainframeScriptYellow mainframeScriptYellow;
        randomSelection = Random.Range(0, mainframeListDisabledYellow.Count);
        ExtraActionSelection = mainframeListDisabledYellow[randomSelection];
        mainframeScriptYellow = ExtraActionSelection.GetComponent<MainframeScriptYellow>();
        // TO DO: Some extra work will be have to done here
        mainframeScriptYellow.activeMainframePrefab();
        TagAssignment(ExtraActionSelection, 5);
        return ExtraActionSelection;
    }

    public GameObject RemoveRandomSelectionFromMainframeActiveYellow()
    {
        int randomSelection;
        MainframeScriptYellow mainframeScriptYellow;
        randomSelection = Random.Range(0, mainframeListActiveYellow.Count);
        ExtraActionSelection = mainframeListActiveYellow[randomSelection];
        mainframeScriptYellow = ExtraActionSelection.GetComponent<MainframeScriptYellow>();
        // TO DO: Some extra work will be have to done here
        mainframeScriptYellow.removeMainframePrefab();
        TagAssignment(ExtraActionSelection, 8);
        return ExtraActionSelection;
    }

    public GameObject AddRandomSelectionFromManiframeDisabledYellow()
    {
        int randomSelection;
        MainframeScriptYellow mainframeScriptYellow;
        randomSelection = Random.Range(0, mainframeListDisabledYellow.Count);
        ExtraActionSelection = mainframeListDisabledYellow[randomSelection];
        mainframeScriptYellow = ExtraActionSelection.GetComponent<MainframeScriptYellow>();
        // TO DO: Some extra work will be have to done here
        mainframeScriptYellow.addMainframePrefab();
        TagAssignment(ExtraActionSelection, 7);
        return ExtraActionSelection;
    }
    #endregion

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
            case 5:
                AssignTag.tag = "ActiveYellow";
                break;
            case 6:
                AssignTag.tag = "NotActiveYellow";
                break;
            case 7:
                AssignTag.tag = "AddYellow";
                break;
            case 8:
                AssignTag.tag = "RemoveYellow";
                break;
            default:
                break;
        }
    }
# endregion
}
