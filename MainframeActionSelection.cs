using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainframeActionSelection : MonoBehaviour
{

    // Number of practice loops
    public int starterPhase = 2;
    // Number of loops
    public int numberOfLoops = 0;

    delegate void ActionMethods();
    List<ActionMethods> actionMethods = new List<ActionMethods>();
    int randomAction = 0;
    ArrayTest arrayTest;

    void Awake()
    {
        GameObject gameController = GameObject.FindWithTag("GameController");
        arrayTest = gameController.GetComponent<ArrayTest>();
        CreateList();
    }

    void Update() {

        #region TEST INPUT
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P pressed");
            SetRandomAction();
        }
        #endregion

    }

    #region ASSIGNING ACTION METHODS TO LIST

    public void CreateList()
    {
        actionMethods.Add(RemoveBeamAction);
        actionMethods.Add(AddBeamAction);
        actionMethods.Add(RandomBeamAction);
    }

    #endregion

    #region SELECTION OF ACTION - MAIN FEATURE

    public void SetRandomAction()
    {
        if (starterPhase <= 0)
        {
            int currentListSize = 0;
            int selectedAction = 0;
            currentListSize = arrayTest.listActive.Count;
            Debug.Log("currentListSize" + currentListSize);
            selectedAction = ActionCombinations(currentListSize);
            Debug.Log("selectedAction" + selectedAction);
            actionMethods[selectedAction]();
        } else {
            // NOTE: First two rounds, player does not get any add or remove beams in mainframe
            actionMethods[2]();
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
                int[] actionNumber4 = new int[] { 0, 2 };
                randomAction = actionNumber4[Random.Range(0, actionNumber4.Length)];
                break;
            default:
                randomAction = 0;
                break;
        }

        return randomAction;
    }
    #endregion

    // ADD CODE-----------------------------------------------
    #region MAINFRAME ACTIONS
    // NOTE: 0 action
    void RemoveBeamAction()
    {
        // ADD CODE-----------------------------------------------
        Debug.Log("Called RemoveBeamAction");
    }

    // NOTE: 1 action
    void AddBeamAction()
    {
        // ADD CODE-----------------------------------------------
        Debug.Log("Called AddBeamAction");
    }

    // NOTE: 2 action
    void RandomBeamAction()
    {
        // ADD CODE-----------------------------------------------
        Debug.Log("Called RandomBeamAction");
    }
    #endregion
}
