using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTesting : MonoBehaviour {

    public List<int> TestList = new List<int>();

	void Start () {
		
	}
	
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Q))
        {
            printAllThingsInTheList();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rewriteAllStuff();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            sortTheList();
        }
    }

    void printAllThingsInTheList()
    {
        for (int i = 0; i < TestList.Count; i++)
        {
            int value;
            value = TestList[i];
            Debug.Log("<color=cyan><b> Value of int " + value + "</b></color>" + i);
        }
    }

    void rewriteAllStuff()
    {
        for (int i = 0; i < TestList.Count; i++)
        {
            int valueAdd = 2;
            int value;
            value = TestList[i];
            value += valueAdd;
            TestList.RemoveAt(i);
            TestList.Insert(i, value);
            Debug.Log("<color=yellow><b> loop result " + value + "</b></color>" + i);
        }
    }

    void sortTheList()
    {
        TestList.Sort();
    }
}
