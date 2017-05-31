using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeRotationSelection : MonoBehaviour {

    public bool objectActive;
    public int objectValue;

    public GameObject Mainframe;
    private RotationSelection rotationSelection;

    void Awake()
    {
        rotationSelection = Mainframe.GetComponent<RotationSelection>();
    }

    void Start()
    {
        
    }

    public void AssignMainframeBeamToSelectionList()
    {
        if (objectActive)
        {
            rotationSelection.addMainframeValuesToList(objectValue);
        }
    }

}
