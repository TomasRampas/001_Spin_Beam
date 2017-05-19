using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloTest : MonoBehaviour {

    int testNumber = 0;
    int resultNumber;

	void Update () {
		
        // NOTE: Increase value
        if (Input.GetKeyDown(KeyCode.Q))
        {
            testNumber += 1;
            //Debug.Log(testNumber);
            DoCalculation();
        }

        // NOTE: Reset
        if (Input.GetKeyDown(KeyCode.W))
        {
            testNumber = 0;
        }
	}

    void DoCalculation()
    {
        if (testNumber%3==0)
        {
            Debug.Log("<color=green><b>Even number " + testNumber + "</b></color>");
        } /*else if (testNumber%3==1)
        {
            Debug.Log("<color=red><b>Odd number " + testNumber + " </b></color>");
        }*/
    }
}
