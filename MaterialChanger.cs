using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material MaterialDefault;
    public Material MaterialAdd;
    public Material MaterialRemove;

    List<Material> MaterialList = new List<Material>();
    private Renderer RendererMaterial;

	void Start ()
    {
        MaterialList.Add(MaterialDefault);
        MaterialList.Add(MaterialAdd);
        MaterialList.Add(MaterialRemove);
    }

    public void SetToDefaultMaterial(GameObject beam)
    {
        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[0];
        }
    }

    public void SetToAddMaterial(GameObject beam)
    {
        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[1];
        }
    }

    public void SetToRemoveMaterial(GameObject beam)
    {
        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[2];
        }
    }

    /*
    #region NEW MATERIAL ASSIGNMENT
    public void emissiveMaterialStates(int selectedState)
    {
        GameObject objectMaterial = emissivePart;
        Renderer render;
        render = objectMaterial.GetComponent<Renderer>();
        switch (selectedState)
        {
            case 1:
                render.material = DefaultMaterial;
                break;
            case 2:
                render.material = RemoveMaterial;
                break;
            case 3:
                render.material = AddMaterial;
                break;
            default:
                Debug.Log("ERROR: No material assigned");
                break;
        }
    }

    public void dummyMaterialStates(int selectedState)
    {
        GameObject objectMaterial = dummyObject;
        Renderer render;
        render = dummyObject.GetComponent<Renderer>();
        switch (selectedState)
        {
            case 1:
                render.material = DummyRemoveMaterial;
                break;

            case 2:
                render.material = DummyAddMaterial;
                break;
            default:
                Debug.Log("ERROR: No material assigned");
                break;
        }

    }
    #endregion
    */

}
