using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    public bool includeChildren = true;
	
	void Update ()
    {
        #region TEST INPUT
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            system.Play(includeChildren);
        }
        */
        
        #endregion
    }

    public void PlayLaserParticle()
    {
        system.Play(includeChildren);
    }
}
