using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    public GameObject guiManagerObject;
    public GameObject orb;
    public GameObject orbPicked;
    public GameObject despawnColliderObject;
    public GameObject gameManager;
    private Light light;
    private ParticleSystem orbPickedParticle;
    private Collider collider;
    private Collider despawnCollider;
    private ArrayTest arrayTest;
    private Score score;
    GUIManager guiManager;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = orb.GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    public bool includeChildren = true;

    void Start()
    {
        light = GetComponent<Light>();
        orbPickedParticle = orbPicked.GetComponent<ParticleSystem>();
        collider = GetComponent<Collider>();
        despawnCollider = despawnColliderObject.GetComponent<Collider>();
        arrayTest = gameManager.GetComponent<ArrayTest>();
        score = gameManager.GetComponent<Score>();
        guiManager = guiManagerObject.GetComponent<GUIManager>();
    }

    void Update()
    {
        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnOrb();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            DespawnOrb();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            OrbPicked();
        }
        */
        #endregion
    }

    #region ORB STATES

    private void OnMouseDown()
    {
        OrbPicked();
    }

    public void SpawnOrb()
    {  
        Invoke ("PlayOrbParticle", 0.25f);
        collider.enabled = true;
        despawnCollider.enabled = true;
        // NOTE: PLaceholder tutorial
        guiManager.OrbSpawned();
    }

    public void DespawnOrb()
    {
        StopOrbParticle();
        Invoke("offLight", 0.4f);
        collider.enabled = false;
        despawnCollider.enabled = false;
        arrayTest.GameOver();
    }

    public void OrbPicked()
    {
        orbPickedParticle.Play();
        StopOrbParticle();
        Invoke("offLight", 0.4f);
        collider.enabled = false;
        despawnCollider.enabled = false;
        score.addPoint();
        // NOTE: Placeholder tutorial
        guiManager.OrbPicked();

    }

    #endregion

    #region ORB METHODS

    void PlayOrbParticle()
    {
        onLight();
        system.Play(includeChildren);
    }

    void StopOrbParticle()
    {
        system.Stop(includeChildren);
    }

    void onLight()
    {
        light.enabled = true;
    }

    void offLight()
    {
        light.enabled = false;
    }

    #endregion
}
