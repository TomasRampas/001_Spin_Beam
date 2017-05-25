using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject Trigger1;
	public GameObject Trigger2;
	public GameObject GUIManagerObject;
    public Camera mainCamera;
	
    bool cameraPosition;
	Collider trig1;
	Collider trig2;
	GUIManager guiManager;

    ArrayTest arrayTest;

    #region CAMERA FOV

    public bool ZoomIn;
    public bool ZoomOut;

    float cameraFov = 50f;
    float fovIncrease;
    float fovDecrease;
    float minFov = 50f;
    float maxFov = 60f;
    float speed = 1f;

    #endregion

    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        arrayTest = gameControllerObject.GetComponent<ArrayTest>();
		trig1 = Trigger1.GetComponent<Collider>();
		trig2 = Trigger2.GetComponent<Collider>();
		guiManager = GUIManagerObject.GetComponent<GUIManager>();
	}

    void Update()
    {
        #region CAMERA FOV
        if (ZoomIn == true && fovIncrease < 2f)
        {
            FovZoomIn();
            Debug.Log("<color=red><b> ZOOM IN " + fovIncrease + "</b></color>");
        }

        if (ZoomOut == true && fovDecrease < 2f)
        {
            FovZoomOut();
            Debug.Log("<color=cyan><b> ZOOM OUT " + fovIncrease + "</b></color>");
        }
        #endregion
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

    #region FOV ADJUSTMENT

    public void SetFOVZoomIn()
    {
        ZoomIn = true;
        fovIncrease = 0;
    }

    public void SetFOVZoomOut()
    {
        ZoomOut = true;
        fovDecrease = 0;
    }

    void FovZoomOut()
    {
        ZoomIn = false;
        fovDecrease += Time.deltaTime * speed;
        cameraFov = Mathf.Lerp(minFov, maxFov, fovDecrease);
        mainCamera.fieldOfView = cameraFov;
    }

    void FovZoomIn()
    {
        ZoomOut = false;
        fovIncrease += Time.deltaTime * speed;
        cameraFov = Mathf.Lerp(maxFov, minFov, fovIncrease);
        mainCamera.fieldOfView = cameraFov;
    }

    #endregion
}
