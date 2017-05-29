using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class CameraTest : MonoBehaviour {

    float cameraFov = 50f;
    float fovIncrease;
    float fovDecrease;
    float minFov = 50f;
    float maxFov = 60f;
    float speed = 1f;

    bool ZoomIn;
    bool ZoomOut;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ZoomIn = true;
            fovIncrease = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ZoomOut = true;
            fovDecrease = 0;
        }

        if (ZoomIn == true && fovIncrease < 2f)
        {
            ZoomOut = false;
            fovIncrease += Time.deltaTime * speed;
            cameraFov = Mathf.Lerp(maxFov, minFov, fovIncrease);
            Camera.main.fieldOfView = cameraFov;
        }

        if (ZoomOut == true)
        {
            ZoomIn = false;
            fovDecrease += Time.deltaTime * speed;
            cameraFov = Mathf.Lerp(minFov, maxFov, fovDecrease);
            Camera.main.fieldOfView = cameraFov;
        }
    }
}
