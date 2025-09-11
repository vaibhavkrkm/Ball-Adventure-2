using System.Collections.Generic;
using UnityEngine;

public class BallDatabase : MonoBehaviour
{
    // list of all player balls (add from inspector)
    public List<PlayerBall> playerBallList = new List<PlayerBall>();

    // method to retrieve a ball from its name
    public PlayerBall GetBall(string ballName)
    {
        foreach (PlayerBall ball in playerBallList)    // looping over all balls
        {
            if (ball.ballName == ballName)    // if the name matches with the given name
            {
                return ball;    // return the ball data
            }
        }

        Debug.LogWarning($"Can't find the given ball name {ballName}");
        return null;
    }
}
