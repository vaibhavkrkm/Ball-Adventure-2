using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Ball", menuName = "Player/Create new Ball")]
public class PlayerBall : ScriptableObject
{
    [Header("Ball Info")]
    public string ballName;

    [Header("Ball Sprites")]
    public Sprite happySprite;
    public Sprite veryHappySprite;
    public Sprite sadSprite;
    public Sprite verySadSprite;
    public Sprite surprisedSprite;
    public Sprite confidentSprite;
    public Sprite angrySprite;
    public Sprite deadSprite;

    [Header("Ball Stats")]
    public int ballJumpPower;
    public int ballMaxSpeed;
    public int ballAcceleration;

    [Header("Special Abilities")]
    public bool waterImmunity;
    public bool lavaImmunity;
    public bool metalImmunity;
}
