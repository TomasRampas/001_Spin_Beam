using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyScript
{
    public static float elapsedTime;

    // Time after which the maximum difficulty will be reached
    static float secondsToMaxDifficutly = 120;

    public static float GetDifficultyPercent()
    {
        //return 11f;
        return Mathf.Clamp01( elapsedTime / secondsToMaxDifficutly);

    }

}
