using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static string selectedBall = "Splash";
    public static List<string> unlockedBalls = new List<string>() { "Jumpy" };

    public static void UnlockBall(string ballName)
    {
        if (unlockedBalls.Contains(ballName)) return;    // return if the ball is already unlocked
        unlockedBalls.Add(ballName);    // unlock the ball by adding it to the list
    }

    public static bool IsBallUnlocked(string ballName)
    {
        if (unlockedBalls.Contains(ballName))
        {
            return true;
        }

        return false;
    }
}
