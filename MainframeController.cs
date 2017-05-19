using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeController : MonoBehaviour {

    public void RandomSelection()
    {
        int randomSelection = Random.Range(1, 4);
        RandomTurn(randomSelection);
    }

    void RandomTurn(int selectedRotation)
    {
        switch (selectedRotation)
        {
            case 1:
                transform.Rotate(0.0f, 0.0f, 90.0f);
                break;
            case 2:
                transform.Rotate(0.0f, 0.0f, 180.0f);
                break;
            case 3:
                transform.Rotate(0.0f, 0.0f, 270.0f);
                break;
            case 4:
                transform.Rotate(0.0f, 0.0f, 0.0f);
                break;
            default:
                break;
        }
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
