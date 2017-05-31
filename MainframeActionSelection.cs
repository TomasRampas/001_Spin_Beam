using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainframeActionSelection : MonoBehaviour
{

    #region NEW SYSTEM

    #region DEBUG GUI

    public int BlueCount = 0;

    public Text DebugNumberOfLoops;
    public Text DebugProgressionLoopcount;
    public Text DebugRange1;
    public Text DebugRange2;
    public Text DebugPotentialSelectionCase2;
    public Text DebugPotentialSelectionCase1;
    public Text DebugFinalRandomBlue;
    public Text DebugFinalRandomYellow;

    int potentialSelectionCaseYellow;
    int potentialSelectionCaseBlue;

    #endregion

    int testRange = 0;

    // NOTE: Action selection progression
    int IncreaseEvery = 3; // NOTE: sets what round triggers next progression
    int ProgressionLoopCount; // NOTE: is raised each time progrssion loops is called by int IncreaseEvery + IMPORTANT: decides which check switch is called in ActionRulesCheck

    // NOTE: RangeLists setup
    int Range1 = 1;
    int Range2 = 1;

    #endregion

    // NOTE: Number of practice loops
    public int starterPhase;
    // NOTE: Number of loops player survived
    public int numberOfLoops = 1;

    // NOTE: Number of loops with random beam added (by forcing remove or add, gameplay is more interesting)
    public int numberOfRandomBeam;
    private int forceAnActionCall = 2;

    delegate void ActionMethods();
    int randomAction = 0;
    int randomActionYellow = 0;
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

        #region DEBUG GUI TEXTS

        DebugNumberOfLoops.text = "" + numberOfLoops;
        DebugProgressionLoopcount.text = "" + ProgressionLoopCount;
        DebugRange1.text = "" + Range1;
        DebugRange2.text = "" + Range2;
        DebugPotentialSelectionCase2.text = "" + potentialSelectionCaseBlue;
        DebugPotentialSelectionCase1.text = "" + potentialSelectionCaseYellow;
        DebugFinalRandomBlue.text = "" + randomAction;
        DebugFinalRandomYellow.text = "" + randomActionYellow;

        #endregion

    }

    #region ACTION SELECTION
    /*
    public void SetRandomAction()
    {
        if (starterPhase <= numberOfLoops)
        {
            int currentListSize = 0;
            int selectedAction = 0;
            currentListSize = arrayTest.listActive.Count;
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
                //Debug.Log("<color=red><b>Remove Action</b></color>");
                arrayTest.RemoveRandomSelectionFromMainframeActive(); 
                break;
            case 1:
                //Debug.Log("<color=green><b>Add Action</b></color>");
                arrayTest.AddRandomSelectionFromManiframeDisabled();
                break;
            case 2:
                numberOfRandomBeam += 1;
                if (numberOfRandomBeam >= forceAnActionCall)
                {
                    //Debug.Log("<color=yellow><b>Forced Action Call</b></color>");
                    ForceActionCall();
                } else
                {
                    //Debug.Log("<color=white><b>Random Beam</b></color>");
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
    }*/
    #endregion
    
    #region NEW ACTION SELECTION SYSTEM

    #region COLOR SELECTION

    public void CallRandomAction()
    {
        // INFO: Check action selection progression
        UpdateListsLoopNumber(numberOfLoops);
        //Debug.Log("<color=red><b>Number of loops</b></color>" + numberOfLoops);
        //Debug.Log("<color=cyan><b>Progression Loop count </b></color>" + ProgressionLoopCount);
        //Debug.Log("<color=yellow><b>Range1 </b></color>" + Range1);
        //Debug.Log("<color=white><b>Range2 </b></color>" + Range2);
        
        // INFO: Random selection from available actions
        ActionCombinationsBlue(arrayTest.listActive.Count);
        ActionCombinationsYellow(arrayTest.listActiveYellow.Count);

        // INFO: Check of combination rules
        ActionRulesCheck(randomAction, randomActionYellow);
        //Debug.Log("<color=red><b> ------------------- </b></color>");
    }
    #endregion

    #region COLOR ACTION LISTS

    #region LISTS UPDATE
    void UpdateListsLoopNumber(int loopNumber)
    {
        if (loopNumber % IncreaseEvery == 0)
        {
            ProgressionLoopCount += 1;
            if (ProgressionLoopCount == 1)
            {
                Range1 += 1;
                Range2 += 1;
            }else if (ProgressionLoopCount == 2)
            {
                Range2 += 1;
            }
            else
            {
                return;
            }
        }        
    }

    #endregion

    #region BLUE LISTS
    int ActionCombinationsBlue(int listSize)
    {
        BlueCount = listSize;
        Debug.Log("<color=red><b> BlueCount " + listSize + " </b></color>");

        //Debug.Log("<color=cyan><b>Blue action combination</b></color>");
        switch (listSize)
        {
            case 1:
                int[] actionNumber2 = new int[] { 2, 1 };
                randomAction = actionNumber2[Random.Range(0, Range1)];
                //Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                Debug.Log("<color=white><b> BLUE SIZE 1 " + randomAction + " </b></color>");
                break;

            case 2:
                int[] actionNumber3 = new int[] { 2, 0, 1, };
                randomAction = actionNumber3[Random.Range(0, Range2)];
                //Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                //Debug.Log("<color=white><b> case 3 </b></color>" + randomAction);
                Debug.Log("<color=white><b> BLUE SIZE 2 " + randomAction + " </b></color>");
                break;
            case 3:
                int[] actionNumber4 = new int[] { 0, 2 };
                randomAction = actionNumber4[Random.Range(0, Range1)];
                //Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                //Debug.Log("<color=white><b> case 4 </b></color>" + randomAction);
                Debug.Log("<color=white><b> BLUE SIZE 3 " + randomAction + " </b></color>");
                break;
            default:
                randomAction = 0;
                break;
        }
        return randomAction;

        #region OLD VERSION OF BLUE
        /*
        switch (listSize)
        {
            case 2:
                int[] actionNumber2 = new int[] { 2, 1 };
                randomAction = actionNumber2[Random.Range(0, Range1)];
                Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                //Debug.Log("<color=white><b> case 2 </b></color>" + randomAction);
                break;

            case 3:
                int[] actionNumber3 = new int[] { 2, 0, 1, };
                randomAction = actionNumber3[Random.Range(0, Range2)];
                Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                //Debug.Log("<color=white><b> case 3 </b></color>" + randomAction);
                break;
            case 4:
                int[] actionNumber4 = new int[] { 0 };
                randomAction = actionNumber4[Random.Range(0, actionNumber4.Length)];
                Debug.Log("<color=cyan><b> Potential selection case 2 - </b></color>" + randomAction);
                potentialSelectionCaseBlue = randomAction;
                //Debug.Log("<color=white><b> case 4 </b></color>" + randomAction);
                break;
            default:
                randomAction = 0;
                break;
        }
        return randomAction;*/
        #endregion
    }
    #endregion

    #region YELLOW LISTS
    int ActionCombinationsYellow(int listSize)
    {
        //Debug.Log("<color=yellow><b>Yellow action combination</b></color>");
        switch (listSize)
        {
            case 1:
                int[] actionNumber2 = new int[] { 2, 1 };
                randomActionYellow = actionNumber2[Random.Range(0, Range1)];
                //Debug.Log("<color=yellow><b> Potential selection case 1 - </b></color>" + randomActionYellow);
                potentialSelectionCaseYellow = randomActionYellow;
                //Debug.Log("<color=white><b> Range1 </b></color>" + Range1);
                break;
            case 2:
                int[] actionNumber3 = new int[] { 2, 0, 1 };
                randomActionYellow = actionNumber3[Random.Range(0, Range2)];
                //Debug.Log("<color=yellow><b> Potential selection case 2 - </b></color>" + randomActionYellow);
                potentialSelectionCaseYellow = randomActionYellow;
                //Debug.Log("<color=white><b> Range2 </b></color>" + Range2);
                break;
            case 3:
                int[] actionNumber4 = new int[] { 0, 2 };
                randomActionYellow = actionNumber4[Random.Range(0, Range1)];
                //Debug.Log("<color=yellow><b> Potential selection case 3 - </b></color>" + randomActionYellow);
                potentialSelectionCaseYellow = randomActionYellow;
                //Debug.Log("<color=white><b> case 3 </b></color>" + randomAction);
                break;
            default:
                randomActionYellow = 0;
                break;
        }
        return randomActionYellow;
    }
    #endregion
    #endregion

    #region FINAL ACTION SELECTION
    void SpecificPrefabActionCall(int selectedAction, bool color)
    {
        //Debug.Log("<color=red><b>Final action selection</b></color>");
        switch (selectedAction)
        {
            case 0: // Remove
                if (!color)
                {
                    arrayTest.RemoveRandomSelectionFromMainframeActiveYellow();
                    //Debug.Log("<color=yellow><b> Final Remove Yellow </b></color>");
                }
                else
                {
                    arrayTest.RemoveRandomSelectionFromMainframeActive();
                    //Debug.Log("<color=cyan><b> Final Remove Blue </b></color>");
                    Debug.Log("<color=red><b> ------- REMOVING FROM BLUE ACTION ------" + BlueCount + "</b></color>");
                }
                break;

            case 1: // Add
                if (!color)
                {
                    arrayTest.AddRandomSelectionFromManiframeDisabledYellow();
                    //Debug.Log("<color=yellow><b> Final Add Yellow </b></color>");
                }
                else
                {
                    arrayTest.AddRandomSelectionFromManiframeDisabled();
                    //Debug.Log("<color=cyan><b> Final Add Blue </b></color>");
                }
                break;

            case 2: // Random
                if (!color)
                {
                    arrayTest.RandomMainframeBeamSelectionYellow();
                    //Debug.Log("<color=yellow><b> Final Random Yellow </b></color>" + randomAction);
                }
                else
                {
                    arrayTest.RandomMainframeBeamSelection();
                    //Debug.Log("<color=cyan><b> Final Random Blue </b></color>" + randomAction);
                }
                break;

            default:
                break;
        }
    }

    #region SUPPORT METHODS

    // NOTE: Sets number of rules that disable specific combination of blue and yellow actions until certain loop count reached
    void ActionRulesCheck(int BlueAction, int YellowAction)
    {
        //Debug.Log("<color=white><b> Action rules check</b></color>");
        //Debug.Log("<color=red><b>ProgressionLoopCount </b></color>" + ProgressionLoopCount);
        switch (ProgressionLoopCount)
        {
            case 1:
                // NOTE: This rule disables combinations of 2x add and 2x remove, and combinations of add and remove (0 + 1, 1 + 0)
                if (BlueAction + YellowAction < 2 || BlueAction * YellowAction == 1)
                {
                    //Debug.Log("<color=red><b> Case 1 Reset of Action 1 </b></color>");
                    ActionCombinationsBlue(arrayTest.listActive.Count);
                    ActionCombinationsYellow(arrayTest.listActiveYellow.Count);
                    //Debug.Log("<color=red><b> Case 1 call new check </b></color>");
                    ActionRulesCheck(randomAction, randomActionYellow);

                }
                else
                {
                    //Debug.Log("<color=green><b> Actions checked all OK </b></color>");
                    SpecificPrefabActionCall(randomAction, true);
                    SpecificPrefabActionCall(randomActionYellow, false);
                }
                break;
            
            case 2:
                // NOTE: This rule disables combinations of add and remove (0 + 1, 1 + 0)
                if (BlueAction * YellowAction == 1 || (BlueAction + YellowAction)*BlueAction == 1)
                {
                    //Debug.Log("<color=red><b> Case 2 Reset of Action 1 </b></color>");
                    ActionCombinationsBlue(arrayTest.listActive.Count);
                    ActionCombinationsYellow(arrayTest.listActiveYellow.Count);
                    //Debug.Log("<color=red><b> Case 2 call new check </b></color>");
                    ActionRulesCheck(randomAction, randomActionYellow);
                }
                else
                {
                    //Debug.Log("<color=green><b> Actions checked all OK </b></color>");
                    SpecificPrefabActionCall(randomAction, true);
                    SpecificPrefabActionCall(randomActionYellow, false);
                }
                break;
            


            default:
                // NOTE: This rule disables combinations of add and remove (0 + 1, 1 + 0)
                if (BlueAction * YellowAction == 1)
                {
                    //Debug.Log("<color=red><b> Case 2 Reset of Action 1 </b></color>");
                    ActionCombinationsBlue(arrayTest.listActive.Count);
                    ActionCombinationsYellow(arrayTest.listActiveYellow.Count);
                    //Debug.Log("<color=red><b> Case 2 call new check </b></color>");
                    ActionRulesCheck(randomAction, randomActionYellow);
                }
                else
                {
                    //Debug.Log("<color=green><b> Actions checked all OK </b></color>");
                    SpecificPrefabActionCall(randomAction, true);
                    SpecificPrefabActionCall(randomActionYellow, false);
                }
                break;
        }
    }

    public void ResetMainframeActionSelection()
    {
        Range1 = 1;
        Range2 = 1;
        ProgressionLoopCount = 0;
        numberOfRandomBeam = 0;
        numberOfLoops = 1;
    }
    #endregion

    #endregion
    #endregion
}
