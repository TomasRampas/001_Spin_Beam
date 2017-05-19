using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class TestAnythingScript : MonoBehaviour {

    public Vector2 speedMinMax;
    float speed;
    float time;

    float value = 1f;

    // NEW STUFF
    int range = 2;

    int testValue1 = 1;

    List<int> testValues = new List<int>();

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
            ArrayTest2();

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ArrayTest();
        }
    }

    void restartSpeed()
    {
        time = Time.time;
    }

    void AssignObjectTolist()
    {
        testValues.Add(testValue1);
        Debug.Log("testValue1 " + testValue1);
    }


    void ArrayTest2()
    {
        range += 1;
        Debug.Log("range " + range);
    }

    void ArrayTest()
    {
        int randomAction;
        int[] actionNumber2 = new int[] { 1, 2, 3, 4, 5, 6 };
        randomAction = actionNumber2[Random.Range(0, range)];
        Debug.Log("random selection " + randomAction);

    }

}
