using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Mainframe;
    public float smooth = 1f;
    private Quaternion targetRotation;

    private RotationSelection rotationSelection;
    public SwipeCode swipeControls;

	void Start () {
        targetRotation = transform.rotation;
        rotationSelection = Mainframe.GetComponent<RotationSelection>();
	}
	

	void Update () {
		if (Input.GetKeyDown("left"))
        {
            //targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
            turnRight();
        }

        if (Input.GetKeyDown("right"))
        {
            //targetRotation *= Quaternion.AngleAxis(90, Vector3.back);
            turnLeft();
        }

        if (swipeControls.SwipeLeft)
        {
            turnRight();
        }

        if (swipeControls.SwipeRight)
        {
            turnLeft();
        }

        if (swipeControls.SwipeUp)
        {
            turnRight();
        }

        if (swipeControls.SwipeDown)
        {
            turnLeft();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
	}

    public void turnLeft()
    {
        IncreaseRotationValue();
        targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
    }

    public void turnRight()
    {
        DecreaseRotationValue();
        targetRotation *= Quaternion.AngleAxis(90, Vector3.back);
    }

    void IncreaseRotationValue()
    {
        rotationSelection.updatePlayerRotationValue(1);
        rotationSelection.InputRotationCheck();
    }

    void DecreaseRotationValue()
    {
        rotationSelection.updatePlayerRotationValue(-1);
        rotationSelection.InputRotationCheck();
    }
}
