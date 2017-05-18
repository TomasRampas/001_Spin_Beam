using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainframeScript : MonoBehaviour {

    public GameObject physicalPart;
    public GameObject emissivePart;
    public GameObject dummyObject;
    public GameObject playerPart;
    public GameObject playerEmissivepart;

    public Material RemoveMaterial;
    public Material AddMaterial;
    // NOTE: selecte the default material based on blue or yellow prefab
    public Material DefaultMaterial;
    public Material DummyRemoveMaterial;
    public Material DummyAddMaterial;

    private GameObject gameManager;
    private ArrayTest arrayTest;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameController");
        arrayTest = gameManager.GetComponent<ArrayTest>();
    }

    void Start() {

    }

    public void AddToEnabledArray()
    {
        arrayTest.AddToMainframeListActive(gameObject);
    }

    public void AddToDisabledArray()
    {
        arrayTest.AddToMainframeListDisabled(gameObject);
    }

    #region CONTACT
    public void removeContact()
    {
        //Debug.Log("Remove collision noted");
        gameObject.tag = "NotActive";
        dummyObjectInvisible();
        playerObjectVisible();
        playerPrefabEmissivePart(1);
    }

    public void addContact()
    {
        //Debug.Log("Add collision noted");
        gameObject.tag = "NotActive";
        dummyObjectVisible();
        dummyMaterialStates(2);
        playerObjectInvisible();
    }
    #endregion

    #region GENERAL METHODS
    public void resetMainframePrefab()
    {
        physicalEmissivePartInvisible();
        dummyObjectInvisible();
        emissiveMaterialStates(1);
        dummyMaterialStates(2);
        playerObjectInvisible();
    }

    public void activeMainframePrefab()
    {
        physicalEmissivePartVisible();
        dummyObjectInvisible();
        emissiveMaterialStates(1);
    }

    public void deactivatedMainframePrefab()
    {
        physicalEmissivePartInvisible();
        dummyObjectInvisible();
    }

    public void removeMainframePrefab()
    {
        physicalEmissivePartVisible();
        dummyObjectVisible();
        emissiveMaterialStates(2);
        dummyMaterialStates(1);
    }

    public void addMainframePrefab()
    {
        physicalEmissivePartVisible();
        emissiveMaterialStates(3);
        playerObjectVisible();
        playerPrefabEmissivePart(2);
    }

    public void RemovePlayerPrefabActive()
    {
        playerObjectVisible();
        playerPrefabEmissivePart(1);
    }

    public void playerPrefabNotActive()
    {
        playerObjectInvisible();
    }
    # endregion

    #region VISIBILITY CHANGE
    void physicalEmissivePartVisible()
    {
        MeshRenderer meshRenderer;
        GameObject[] parts = new GameObject[] { physicalPart, emissivePart };
        foreach (GameObject item in parts)
        {
            meshRenderer = item.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
        }
    }

    void physicalEmissivePartInvisible()
    {
        MeshRenderer meshRenderer;
        GameObject[] parts = new GameObject[] { physicalPart, emissivePart };
        foreach (GameObject item in parts)
        {
            meshRenderer = item.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }

    public void dummyObjectVisible()
    {
        MeshRenderer meshRender;
        meshRender = dummyObject.GetComponent<MeshRenderer>();
        meshRender.enabled = true;
    }

    public void dummyObjectInvisible()
    {
        MeshRenderer meshRender;
        meshRender = dummyObject.GetComponent<MeshRenderer>();
        meshRender.enabled = false;
    }

    void playerObjectVisible()
    {
        GameObject[] objects = new GameObject[] { playerPart, playerEmissivepart };
        foreach (GameObject item in objects)
        {
            MeshRenderer meshRenderer;
            meshRenderer = item.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
        }
        
    }

    void playerObjectInvisible()
    {
        GameObject[] objects = new GameObject[] { playerPart, playerEmissivepart };
        foreach (GameObject item in objects)
        {
            MeshRenderer meshRenderer;
            meshRenderer = item.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        }
    }

    #endregion

    #region MATERIAL CHANGE
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

    public void dummyMaterialStates (int selectedState)
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

    void playerPrefabEmissivePart (int selectedState)
    {
        GameObject objectMaterial = playerEmissivepart;
        Renderer render;
        render = objectMaterial.GetComponent<Renderer>();
        switch (selectedState)
        {
            case 1:
                render.material = RemoveMaterial;
                break;
            case 2:
                render.material = AddMaterial;
                break;
        }
    }

    #endregion
}