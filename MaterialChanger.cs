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
        // IF ALL WORKS DELETE //  RendererMaterial = beam.GetComponent<Renderer>();
        // IF ALL WORKS DELETE //  RendererMaterial.material = MaterialList[0];

        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[0];
        }
    }

    public void SetToAddMaterial(GameObject beam)
    {
        // IF ALL WORKS DELETE //  RendererMaterial = beam.GetComponent<Renderer>();
        // IF ALL WORKS DELETE //  RendererMaterial.material = MaterialList[1];

        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[1];
        }
    }

    public void SetToRemoveMaterial(GameObject beam)
    {
        // IF ALL WORKS DELETE //  RendererMaterial = beam.GetComponent<Renderer>();
        // IF ALL WORKS DELETE //  RendererMaterial.material = MaterialList[2];

        Component[] renderMaterial;
        renderMaterial = beam.GetComponentsInChildren<Renderer>();
        foreach (Renderer material in renderMaterial)
        {
            material.material = MaterialList[2];
        }
    }
}
