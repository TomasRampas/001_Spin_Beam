using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    public GameObject guiManagerObject;
    public GameObject orb;
    public GameObject orbPicked;
    public GameObject despawnColliderObject;
    public GameObject gameManager;
    public bool orbLive;

    #region GUI ORB
    public GameObject guiOrbLight;
    public GameObject guiOrb;
    public GameObject guiOrbPickedObject;
    private Light guiLight;
    #endregion

    #region TUTORIAL
    public TutorialScript tutScript;
    #endregion

    private Light light;
    private ParticleSystem orbPickedParticle;
    private ParticleSystem guiOrbPicked;
    private ParticleSystem guiOrbSystem;
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

    ParticleSystem systemGuiOrb
    {
        get
        {
            if (_GuiCachedSystem == null)
                _GuiCachedSystem = guiOrb.GetComponent<ParticleSystem>();
            return _GuiCachedSystem;
        }
    }
    private ParticleSystem _GuiCachedSystem;


    public bool includeChildren = true;

    void Start()
    {
        tutScript = guiManagerObject.GetComponent<TutorialScript>();
        guiLight = guiOrbLight.GetComponent<Light>();
        light = GetComponent<Light>();
        guiOrbPicked = guiOrbPickedObject.GetComponent<ParticleSystem>();
        orbPickedParticle = orbPicked.GetComponent<ParticleSystem>();
        guiOrbSystem = guiOrb.GetComponent<ParticleSystem>();
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

    public bool OrbState
    {
        get
        {
            return orbLive;
        }
    }

    private void OnMouseDown()
    {
        OrbPicked();
    }


    public void SpawnOrb()
    {
        orbLive = true;
        Debug.Log("<color=red><b>SpawnOrb</b></color>");
        Invoke ("PlayOrbParticle", 0.25f);
        collider.enabled = true;
        despawnCollider.enabled = true;
        // NOTE: PLaceholder tutorial
        guiManager.OrbSpawned();
        if (tutScript.TutEnabled == true)
        {
            tutScript.PlayEndTutorialPart(3);
        }
    }

    public void DespawnOrb()
    {
        orbLive = false;
        Debug.Log("<color=red><b>DespawnOrb</b></color>");
        StopOrbParticle();
        Invoke("offLight", 0.4f);
        collider.enabled = false;
        despawnCollider.enabled = false;
        arrayTest.GameOver();
    }

    public void OrbPicked()
    {
        orbLive = false;
        Debug.Log("<color=red><b>OrbPicked</b></color>");
        orbPickedParticle.Play();
        StopOrbParticle();
        Invoke("offLight", 0.4f);
        collider.enabled = false;
        despawnCollider.enabled = false;
        score.addPoint();
        // NOTE: Placeholder tutorial
        guiManager.OrbPicked();
        if (tutScript.TutEnabled == true)
        {
            tutScript.PlayEndTutorialPart(4);
        }
    }

    #endregion

    #region ORB METHODS

    void PlayOrbParticle()
    {
        onLight();
        system.Play(includeChildren);
    }

    public void StopOrbParticle()
    {
        Debug.Log("<color=red><b>OrbParticleStopped</b></color>");
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

    #region GUI ORB METHODS

    public void PlayGuiOrb()
    {
        systemGuiOrb.Play(includeChildren);
        guiLight.enabled = true;
    }

    public void StopGuiOrb()
    {
        systemGuiOrb.Stop(includeChildren);
        guiLight.enabled = false;
    }

    public void GuiOrbPciked()
    {
        guiOrbPicked.Play();
    }

    #endregion
}
