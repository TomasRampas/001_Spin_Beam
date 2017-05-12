using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeActionSelection : MonoBehaviour
{

    // NOTE: Number of practice loops
    public int starterPhase = 1;
    // NOTE: Number of loops player survived
    public int numberOfLoops = 0;

    // NOTE: Number of loops with random beam added (by forcing remove or add, gameplay is more interesting)
    private int numberOfRandomBeam = 0;
    private int forceAnActionCall = 2;

    delegate void ActionMethods();
    int randomAction = 0;
    ArrayTest arrayTest;

    void Awake()
    {
        GameObject gameController = GameObject.FindWithTag("GameController");
        arrayTest = gameController.GetComponent<ArrayTest>();
    }

    void Update() {

        #region TEST INPUT
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P pressed");
            SetRandomAction();
        }*/
        #endregion

    }

    #region SELECTION OF ACTION - MAIN FEATURE
    public void SetRandomAction()
    {
        if (starterPhase <= 0)
        {
            int currentListSize = 0;
            int selectedAction = 0;
            currentListSize = arrayTest.listActive.Count;
            Debug.Log("List active count" + currentListSize);
            selectedAction = ActionCombinations(currentListSize);
            SpecificActionCall(selectedAction);
        } else {
            // NOTE: First two rounds, player does not get any add or remove beams in mainframe
            SpecificActionCall(2);
        }
    }

    int ActionCombinations(int listSize)
    {
        switch (listSize)
        {
            case 2:
                int[] actionNumber2 = new int[] { 1, 2 };
                randomAction = actionNumber2[Random.Range(0, actionNumber2.Length)];
                break;
            case 3:
                int[] actionNumber3 = new int[] { 0, 1, 2 };
                randomAction = actionNumber3[Random.Range(0, actionNumber3.Length)];
                break;
            case 4:
                int[] actionNumber4 = new int[] { 0 };
                randomAction = actionNumber4[Random.Range(0, actionNumber4.Length)];
                break;
            default:
                randomAction = 0;
                break;
        }
        return randomAction;
    }

    void SpecificActionCall(int selectedAction)
    {
        switch (selectedAction)
        {
            case 0:
                Debug.Log("<color=red><b>Remove Action</b></color>");
                arrayTest.RemoveRandomSelectionFromMainframeActive(); 
                break;
            case 1:
                Debug.Log("<color=green><b>Add Action</b></color>");
                arrayTest.AddRandomSelectionFromManiframeDisabled();
                break;
            case 2:
                numberOfRandomBeam += 1;
                if (numberOfRandomBeam >= forceAnActionCall)
                {
                    Debug.Log("<color=yellow><b>Forced Action Call</b></color>");
                    ForceActionCall();
                } else
                {
                    Debug.Log("<color=white><b>Random Beam</b></color>");
                    arrayTest.RandomMainframeBeamSelection();
                }
                break;
            default:
                break;
        }
    }

    // NOTE: Forced action when random selection appears too often
    void ForceActionCall()
    {
        numberOfRandomBeam = 0;
        SpecificActionCall(1);
    }
    #endregion
}
