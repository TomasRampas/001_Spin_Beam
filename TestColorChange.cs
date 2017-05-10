using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorChange : MonoBehaviour {

    public List<Material> MaterialList = new List<Material>();

    public Material defaultMat;
    public Material add;
    public Material remove;

    private Renderer render;

	void Start () {
        render = GetComponent<Renderer>();
        MaterialList.Add(defaultMat);
        MaterialList.Add(add);
        MaterialList.Add(remove);
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            render.material = MaterialList[1];
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            render.material = remove;
        }
	}
}
