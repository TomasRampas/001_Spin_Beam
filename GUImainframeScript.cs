using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUImainframeScript : MonoBehaviour {

    public Component[] meshRenderer;

	void Start ()
    {
        meshRenderer = GetComponentsInChildren<MeshRenderer>();
	}

    public void DisableGUIMainframe()
    {
        foreach (MeshRenderer mesh in meshRenderer)
        {
            mesh.enabled = false;
        }
    }

    public void EnableGUIMainframe()
    {
        foreach (MeshRenderer mesh in meshRenderer)
        {
            mesh.enabled = true;
        }
    }
}
