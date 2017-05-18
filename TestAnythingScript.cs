using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TestAnythingScript : MonoBehaviour {

    public Vector2 speedMinMax;
    float speed;
    float time;

    SplineFollower follower;

    void Start() {
        follower = GetComponent<SplineFollower>();
        DifficultyScript.elapsedTime = Time.time;
    }

    void Update()
    {
        DifficultyScript.elapsedTime = Time.time - time;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, DifficultyScript.GetDifficultyPercent());
        follower.followSpeed = speed * 5f;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            restartSpeed();
        }
    }

    void restartSpeed()
    {
        time = Time.time;
    }
}
