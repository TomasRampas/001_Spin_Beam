using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class GUImainframeScript : MonoBehaviour {

    public List<GameObject> GUImainframe = new List<GameObject>();
    public GameObject GUIManagerObject;
	public GameObject trigger1;
	public GameObject trigger2;

    SplineFollower GUIMainframeBody;
    GUIManager guiManager;
	Collider trig1;
	Collider trig2;

    bool mainframePosition = false;

    ArrayTest arrayTest;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
        GUIMainframeBody = GetComponent<SplineFollower>();
        guiManager = GUIManagerObject.GetComponent<GUIManager>();
		trig1 = trigger1.GetComponent<Collider>();
		trig2 = trigger2.GetComponent<Collider>();
	}

    void Update()
    {
        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisableGUIMainframe();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            EnableGUIMainframe();
        }
        */
        #endregion
    }

    public void DisableGUIMainframe()
    {
        ChangeVisibilityMainframe(false);
    }

    public void EnableGUIMainframe()
    {
        ChangeVisibilityMainframe(true);
    }

    void ChangeVisibilityMainframe(bool state)
    {
        for (int i = 0; i < GUImainframe.Count; i++)
        {
            GameObject selected;
            MeshRenderer render;
            selected = GUImainframe[i];
            render = selected.GetComponent<MeshRenderer>();
            render.enabled = state;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // NOTE: Mainframe Trigger1
        if (other.gameObject.CompareTag("GUItrigger2") && mainframePosition)
        {
            trig1.enabled = false;
            trig2.enabled = true;
            mainframePosition = false;
            guiManager.mainframeTriggerOver();

        // NOTE: Mainframe Trigger2
        } else if (other.gameObject.CompareTag("GUItrigger2") && !mainframePosition)
        {
            trig1.enabled = true;
            trig2.enabled = false;
            mainframePosition = true;
            guiManager.mainframeReachedTrigger();
        }
    }
}
