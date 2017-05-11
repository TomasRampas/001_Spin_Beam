using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour {

    #region ALL SCRIPTS
    public List<GameObject> MainframePrefabs = new List<GameObject>();
    public GameObject mainframe;

    private MainframeScript mainframeScript;
    private MainframeActionSelection mainframeActionSelection;
    #endregion


    void Start () {
		
	}
	
	void Update () {
        #region KEYBOARD 1
           /* #region MAINFRAME
                // Setting visibility
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.physicalEmissivePartVisible();
                        Debug.Log("<color=green><b>MAINFRAME BODY PREFAB SET AS VISIBLE</b></color>");
                    }
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.physicalEmissivePartInvisible();
                        Debug.Log("<color=red><b>MAINFRAME BODY PREFAB SET AS INVISIBLE</b></color>");
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.dummyObjectVisible();
                        Debug.Log("<color=green><b>MAINFRAME BODY PREFAB DUMMY SET AS VISIBLE</b></color>");
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.dummyObjectInvisible();
                        Debug.Log("<color=red><b>MAINFRAME BODY PREFAB DUMMY SET AS INVISIBLE</b></color>");
                    }
                }

                // Setting material
                if (Input.GetKeyDown(KeyCode.T))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.emissiveMaterialStates(1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.emissiveMaterialStates(2);
                    }
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.emissiveMaterialStates(3);
                    }
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.dummyMaterialStates(1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    for (int i = 0; i < MainframePrefabs.Count; i++)
                    {
                        GameObject objectInList;
                        objectInList = MainframePrefabs[i];
                        mainframeScript = objectInList.GetComponent<MainframeScript>();
                        mainframeScript.dummyMaterialStates(2);
                    }
                }

                // Random Action call
                // TO DO: setting the random actions is more complex due to connection with lists
                if (Input.GetKeyDown(KeyCode.P))
                {
                    mainframeActionSelection = mainframe.GetComponent<MainframeActionSelection>();
                    // NOTE: done to skip the first two rounds set actions
                    mainframeActionSelection.numberOfLoops = 3;
                    mainframeActionSelection.SetRandomAction();
                }*/

        #endregion

    }
}
