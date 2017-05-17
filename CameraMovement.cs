using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject Trigger1;
	public GameObject Trigger2;
	public GameObject GUIManagerObject;
	
    bool cameraPosition;
	Collider trig1;
	Collider trig2;
	GUIManager guiManager;

    ArrayTest arrayTest;

    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
		trig1 = Trigger1.GetComponent<Collider>();
		trig2 = Trigger2.GetComponent<Collider>();
		guiManager = GUIManagerObject.GetComponent<GUIManager>();
	}

    void OnTriggerEnter(Collider other)
    {
        // NOTE: Camera Trigger 1
        if (other.gameObject.CompareTag("GUItrigger") && cameraPosition)
        {
            cameraPosition = false;
            trig2.enabled = true;
            trig1.enabled = false;
            guiManager.cameraTriggerOver();

        // NOTE: Camera Trigger 2
        } else if (other.gameObject.CompareTag("GUItrigger") && !cameraPosition)
        {
            cameraPosition = true;
            trig1.enabled = true;
            trig2.enabled = false;
			guiManager.mainframeTriggerStart();
        }
    }
}
