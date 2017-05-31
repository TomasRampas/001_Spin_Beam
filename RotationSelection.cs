using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSelection : MonoBehaviour {

    private int rotation = 1;
    private int lastRotation = 1;
    private int compareRotation = 1;
    public GameObject mainframe;

    public List<int> playerBeams = new List<int>();
    public List<int> mainframeBeams = new List<int>();
    public List<int> NotMatchingRot = new List<int>();

    private MainframeController mainframeController;

    private void Awake()
    {
        mainframeController = mainframe.GetComponent<MainframeController>();
    }

    void Start()
    {
        
    }

    void Update () {

        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindNotMatchingCombinations();
        }*/
        #endregion

    }

    #region INPUT AREA

    #region ROTATION VALUE UPDATE
    public void updatePlayerRotationValue(int value)
    {
        rotation += value;
        

    }

    public void InputRotationCheck()
    {
        if (rotation > 4)
        {
            rotation = 1;
        } else if (rotation <= 0)
        {
            rotation = 4;
        }


        #region TEST DEBUG LOG OF LIST CONTENT
        /*
        // INFO ----------------------------------------------------------------------------------------------------
        for (int i = 0; i < mainframeBeams.Count; i++)
        {
            int value;
            value = mainframeBeams[i];
            Debug.Log("<color=yellow><b> -------- MAINFRAME TEST LOOP ----------- </b></color>");
            Debug.Log("<color=yellow><b> List index " + i + " - Value " + value + "////-------------------</b></color>");
        }

        for (int i = 0; i < playerBeams.Count; i++)
        {
            int value;
            value = playerBeams[i];
            Debug.Log("<color=cyan><b> -------- PLAYER TEST LOOP ----------- </b></color>");
            Debug.Log("<color=cyan><b> List index " + i + " - Value " + value + "////-------------------</b></color>");
        }
        */
        #endregion

        //Debug.Log("<color=cyan><b> --------BEFORE UPDATE " + lastRotation + " ----------- </b></color>");
        //Debug.Log("<color=yellow><b> --------ROTATION UPDATE " + rotation + " ----------- </b></color>");
        //Debug.Log("<color=cyan><b> --------AFTER UPDATE " + lastRotation + " ----------- </b></color>");
    }
    #endregion



    public void addPlayerValuesToList(int beamValue)
    {
        playerBeams.Add(beamValue);
        //Debug.Log("<color=white><b>Player Beam value " + beamValue + "//////////////////////</b></color>");
    }

    public void addMainframeValuesToList(int mainValue)
    {
        mainframeBeams.Add(mainValue);
        //Debug.Log("<color=yellow><b>Mainframe Beam value " + mainValue + "//////////////////////</b></color>");
    }

    // NOTE: Call to trigger mainframe counter rotation
    public void SetMainframeRotation()
    {
        FindNotMatchingCombinations();
        //Debug.Log("<color=red><b>*/*/*/*/*/*/*/*/*/*/*/ NEW ROUND /*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/ </b></color>");
    }
    #endregion

    #region OUTPUT AREA

    void SendSelectedRotation(int selectedRotation)
    {
        mainframeController.RandomTurn(selectedRotation);
    }
    #endregion

    #region SYSTEM

    // NOTE: Find false rotations of the Player
    void FindNotMatchingCombinations()
    {
        lastRotation = rotation;
        compareRotation = lastRotation;
        int playerCombinationSize;
        playerCombinationSize = playerBeams.Count;

        // NOTE: 4 rounds to cover all possible rotations
        for (int i = 0; i < 4; i++)
        {
            // Log Message:
            //Debug.Log("<color=cyan><b>--------//////////////---------</b></color>");
            //Debug.Log("<color=cyan><b>Round " + i + " started //////////////</b></color>");
            //Debug.Log("<color=cyan><b>Player rotation " + lastRotation + " //////////////</b></color>");

            //Debug.Log("<color=cyan><b> Player last rotation " + lastRotation + "</b></color>");


            #region TEST DEBUG LOG OF LIST CONTENT
            /*
            // INFO ----------------------------------------------------------------------------------------------------
            for (int x = 0; x < mainframeBeams.Count; x++)
            {
                int value;
                value = mainframeBeams[x];
                Debug.Log("<color=yellow><b> -------- 1 MAINFRAME TEST LOOP ----------- </b></color>");
                Debug.Log("<color=yellow><b> List index " + x + " - Value " + value + "////-------------------</b></color>");
            }

            for (int z = 0; z < playerBeams.Count; z++)
            {
                int value;
                value = playerBeams[z];
                Debug.Log("<color=cyan><b> -------- 1 PLAYER TEST LOOP ----------- </b></color>");
                Debug.Log("<color=cyan><b> List index " + z + " - Value " + value + "////-------------------</b></color>");
            }*/
            #endregion

            int equalValuesFound = 0;
            int validCombinations;

            // NOTE: Check of player beams
            for (int g = 0; g < playerBeams.Count; g++)
            {
                #region TEST DEBUG LOG OF LIST CONTENT
                /*
                // INFO ----------------------------------------------------------------------------------------------------
                for (int x = 0; x < mainframeBeams.Count; x++)
                {
                    int value;
                    value = mainframeBeams[x];
                    Debug.Log("<color=yellow><b> -------- 2 MAINFRAME TEST LOOP ----------- </b></color>");
                    Debug.Log("<color=yellow><b> List index " + x + " - Value " + value + "////-------------------</b></color>");
                }

                for (int z = 0; z < playerBeams.Count; z++)
                {
                    int value;
                    value = playerBeams[z];
                    Debug.Log("<color=cyan><b> -------- 2 PLAYER TEST LOOP ----------- </b></color>");
                    Debug.Log("<color=cyan><b> List index " + z + " - Value " + value + "////-------------------</b></color>");
                }*/
                #endregion

                int playerBeamValue;
                playerBeamValue = playerBeams[g];

                //Debug.Log("<color=yellow><b>Player beam value tested " + playerBeamValue + " //////////////</b></color>");

                // NOTE: Checking slected player beam against all active mainframe beams
                for (int a = 0; a < mainframeBeams.Count; a++)
                {

                   
                   #region TEST DEBUG LOG OF LIST CONTENT
                   /*
                    // INFO ----------------------------------------------------------------------------------------------------
                    for (int x = 0; x < mainframeBeams.Count; x++)
                    {
                        int value;
                        value = mainframeBeams[x];
                        Debug.Log("<color=yellow><b> -------- 3 MAINFRAME TEST LOOP ----------- </b></color>");
                        Debug.Log("<color=yellow><b> List index " + x + " - Value " + value + "////-------------------</b></color>");
                    }

                    for (int z = 0; z < playerBeams.Count; z++)
                    {
                        int value;
                        value = playerBeams[z];
                        Debug.Log("<color=cyan><b> -------- 3 PLAYER TEST LOOP ----------- </b></color>");
                        Debug.Log("<color=cyan><b> List index " + z + " - Value " + value + "////-------------------</b></color>");
                    }*/
                    #endregion
                    
                    int mainframeBeamValue;
                    int playerBeamValueStorage;
                    mainframeBeamValue = mainframeBeams[a];
                    playerBeamValueStorage = playerBeamValue;
                    playerBeamValueStorage -= mainframeBeamValue;
                    //Debug.Log("<color=green><b>Mainframe beam vs Player beam " + mainframeBeamValue + " player beam " + playerBeamValueStorage + " //////////////</b></color>");

                    if (playerBeamValueStorage == 0)
                    {
                        equalValuesFound++;
                        //Debug.Log("<color=red><b>EqualValuesFound //////////////</b></color>");
                    }
                    //Debug.Log("<color=white><b>EqualValues NOT Found //////////////</b></color>");

                }
            }

            validCombinations = playerCombinationSize - equalValuesFound;

            if (validCombinations != 0)
            {
                NotMatchingRot.Add(lastRotation);
                //Debug.Log("<color=red><b> not matching /////////////</b></color>");
            } else
            {
                //Debug.Log("<color=green><b> matching ////////////////</b></color>");
            }

            // NOTE: Reset of values
            equalValuesFound = 0;
            validCombinations = 0;

            // NOTE: Addition is at the end
            lastRotation++;
            
            if (lastRotation > 4)
            {
                lastRotation = 1;
            }
            
            increasePlayerBeamListValues();
        }

        RandomSelectFromAvailable();
    }

    // NOTE: Increases value of all player beams to do next round of check
    void increasePlayerBeamListValues()
    {
        for (int i = 0; i < playerBeams.Count; i++)
        {
            int value;
            value = playerBeams[i];
            value += 2;
            if (value > 7 && value%2 == 0)
            {
                value = 0;
            } else if (value > 7) 
            {
                value = 1;
            }
            playerBeams.RemoveAt(i);
            playerBeams.Insert(i, value);
            //Debug.Log("<color=yellow><b> Updated value " + value + "</b></color> " + i);
        }
    }

    // NOTE: Select a false rotation of the Player
    void RandomSelectFromAvailable()
    {
        int selectedRotation;

        #region TEST DEBUG LOG OF LIST CONTENT
        /*
        // INFO ----------------------------------------------------------------------------------------------------
        for (int x = 0; x < NotMatchingRot.Count; x++)
        {
            int value;
            value = NotMatchingRot[x];
            Debug.Log("<color=yellow><b> -------- 1 FINAL SELECTION TEST LOOP ----------- </b></color>");
            Debug.Log("<color=yellow><b> List index " + x + " - Value " + value + "////-------------------</b></color>");
        }*/
        #endregion

        if (NotMatchingRot.Count == 0)
        {
            //Debug.Log("<color=yellow><b> None notMatching </b></color>");

            // WARNING: Make sure that the range is between 1 / 4
            selectedRotation = Random.Range(1, 5);
            AdjustingMainframeRotation(selectedRotation);
            //Debug.Log("<color=yellow><b> None notMatching - selected </b></color> " + selectedRotation);
        } else
        {
            int selected;
            //Debug.Log("<color=yellow><b> Some notMatching </b></color>");
            selected = Random.Range(0, NotMatchingRot.Count);
            selectedRotation = NotMatchingRot[selected];
            //Debug.Log("<color=yellow><b> Some notMatching - selected </b></color>" + selectedRotation);
            AdjustingMainframeRotation(selectedRotation);

        }
    }

    // NOTE: Take the false rotations of player and use it to adjust rotation of mainframe
    void AdjustingMainframeRotation(int selectedAngle)
    {
        int MainframeRotation = 1;

        /*
        int PlayerRotation = 0;

        PlayerRotation = compareRotation;
        MainframeRotation = selectedAngle;

        MainframeRotation -= PlayerRotation;
        MainframeRotation = Mathf.Abs(MainframeRotation);
        if (MainframeRotation == 0)
        {
            MainframeRotation = 4;
        }*/

        /*
        PlayerRotation = Mathf.Abs(PlayerRotation);
        Debug.Log("<color=cyan><b> rotation " + PlayerRotation + "</b></color>");
        MainframeRotation += PlayerRotation;
        Debug.Log("<color=cyan><b> Mainframe rotation " + MainframeRotation + "</b></color>");
        */

        MainframeRotation = selectedAngle;

        SelectedOrientation(MainframeRotation);
    }

    // NOTE: Set the final rotation of mainframe
    void SelectedOrientation (int finalRotation)
    {
        switch (finalRotation)
        {
            case 1:
                // NOTE: spin mainframe 0 degrees
                SendSelectedRotation(1);
                //Debug.Log("<color=red><b> 1 Final Selection </b></color>");
                break;

            case 2:
                // NOTE: spin mainframe 90 degrees
                SendSelectedRotation(2);
                //Debug.Log("<color=red><b> 2 Final Selection </b></color>");
                break;

            case 3:
                // NOTE: spin mainframe 180 degrees
                SendSelectedRotation(3);
                //Debug.Log("<color=red><b> 3 Final Selection </b></color>");
                break;

            case 4:
                // NOTE: spin mainframe 270 degrees
                SendSelectedRotation(4);
                //Debug.Log("<color=red><b> 4 Final Selection </b></color>");
                break;
        }

        CleaningOfSearch();
    }

    // NOTE: Restart of all used values and lists
    void CleaningOfSearch()
    {
        playerBeams.Clear();
        mainframeBeams.Clear();
        NotMatchingRot.Clear();
    }

    #endregion
}
