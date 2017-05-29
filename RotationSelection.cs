using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSelection : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindNotMatchingCombinations();
        }

	}

    /*
    // NOTE: This method checks all possible combinations
    void CombinationTest()
    {
        int playerCombinationSize;
        playerCombinationSize = playerBeams.Count;

        // NOTE: Round
        for (int x = 0; x < 4; x++)
        {
            int equalValuesFound = 0;
            int validCombinations;

            // NOTE: Check of player beams
            for (int i = 0; i < playerBeams.Count; i++)
            {
                
                int playerBeamValue;
                playerBeamValue = playerBeams[i];

                // NOTE: Checking slected player beam against all active mainframe beams
                for (int a = 0; a < mainframeBeams.Count; a++)
                {
                    int mainframeBeamValue;
                    mainframeBeamValue = mainframeBeams[a];
                    playerBeamValue -= mainframeBeamValue;
                    if (playerBeamValue == 0)
                    {
                        equalValuesFound++;
                    }
                }
            }

            validCombinations = playerCombinationSize - equalValuesFound;

            if (validCombinations != 0)
            {
                // TO DO: Round marked as "no solution"
                // TO DO: Add this round to list for final rotation selection
            }

        }
    }*/

    #region NEW SYSTEM

    // TO DO: Assign here the final selection of both player and mainframe beams
    [Header ("Player Test input")]
    public List<int> playerBeams = new List<int>(); // TO DO: set to private once done with correct value assignment
    [Header("Mainframe Test input")]
    public List<int> mainframeBeams = new List<int>(); // TO DO: set to private once done with correct value assignment

    public List<int> NotMatchingRot = new List<int>();
    [Header("Player Test rotation")]
    public int rotation; // TO DO: set to private once done with correct value assignment

    // NOTE: Call to trigger mainframe counter rotation
    public void SetMainframeRotation(int playerRotation)
    {
        rotation = playerRotation;
        FindNotMatchingCombinations();
    }

    // NOTE: Find false rotations of the Player
    void FindNotMatchingCombinations()
    {
        int playerCombinationSize;
        playerCombinationSize = playerBeams.Count;

        // NOTE: 4 rounds to cover all possible rotations
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("<color=cyan><b> rotation " + rotation + "</b></color>");

            int equalValuesFound = 0;
            int validCombinations;

            // NOTE: Check of player beams
            for (int g = 0; g < playerBeams.Count; g++)
            {
                int playerBeamValue;
                playerBeamValue = playerBeams[g];

                // NOTE: Checking slected player beam against all active mainframe beams
                for (int a = 0; a < mainframeBeams.Count; a++)
                {
                    int mainframeBeamValue;
                    int playerBeamValueStorage;
                    mainframeBeamValue = mainframeBeams[a];
                    playerBeamValueStorage = playerBeamValue;
                    playerBeamValueStorage -= mainframeBeamValue;
                    if (playerBeamValueStorage == 0)
                    {
                        equalValuesFound++;
                    }
                }
            }

            validCombinations = playerCombinationSize - equalValuesFound;

            if (validCombinations != 0)
            {
                NotMatchingRot.Add(rotation);
                Debug.Log("<color=red><b> found not matching </b></color>");
            }

            // NOTE: Reset of values
            equalValuesFound = 0;
            validCombinations = 0;

            // NOTE: Addition is at the end
            rotation++;
            
            if (rotation > 4)
            {
                rotation = 1;
            }
            
            increasePlayerBeamListValues();
        }

        RandomSelectFromAvailable();
    }

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
                value = 6;
            }
            playerBeams.RemoveAt(i);
            playerBeams.Insert(i, value);
            Debug.Log("<color=yellow><b> Updated value " + value + "</b></color> " + i);
        }
    }

    // NOTE: Select a false rotation of the Player
    void RandomSelectFromAvailable()
    {
        int selectedRotation;

        if (NotMatchingRot.Count == 0)
        {
            Debug.Log("<color=yellow><b> None notMatching </b></color>");
            selectedRotation = Random.Range(1, 3);
            AdjustingMainframeRotation(selectedRotation);
            Debug.Log("<color=yellow><b> None notMatching - selected </b></color> " + selectedRotation);
        } else
        {
            int selected;
            Debug.Log("<color=yellow><b> Some notMatching </b></color>");
            selected = Random.Range(0, NotMatchingRot.Count);
            selectedRotation = NotMatchingRot[selected];
            Debug.Log("<color=yellow><b> Some notMatching - selected </b></color>" + selectedRotation);
            AdjustingMainframeRotation(selectedRotation);

        }
    }

    // NOTE: Take the false rotations of player and use it to adjust rotation of mainframe
    void AdjustingMainframeRotation(int selectedAngle)
    {
        int PlayerRotation = 0;
        int MainframeRotation = 1;

        PlayerRotation = rotation;
        rotation -= selectedAngle;
        rotation = Mathf.Abs(rotation);
        Debug.Log("<color=cyan><b> rotation " + rotation + "</b></color>");

        MainframeRotation += rotation;
        Debug.Log("<color=cyan><b> Mainframe rotation " + MainframeRotation + "</b></color>");

        SelectedOrientation(MainframeRotation);
    }

    // NOTE: Set the final rotation of mainframe
    void SelectedOrientation (int finalRotation)
    {
        switch (finalRotation)
        {
            case 1:
                // TO DO: spin mainframe 0 degrees
                CleaningOfSearch();
                Debug.Log("<color=red><b> 1 Final Selection </b></color>");
                break;

            case 2:
                // TO DO: spin mainframe 90 degrees
                CleaningOfSearch();
                Debug.Log("<color=red><b> 2 Final Selection </b></color>");
                break;

            case 3:
                // TO DO: spin mainframe 180 degrees
                CleaningOfSearch();
                Debug.Log("<color=red><b> 3 Final Selection </b></color>");
                break;

            case 4:
                // TO DO: spin mainframe 270 degrees
                CleaningOfSearch();
                Debug.Log("<color=red><b> 4 Final Selection </b></color>");
                break;
        }
    }

    void CleaningOfSearch()
    {
        // TO DO: Reset and celan all values and lists
    }

    #endregion
}
