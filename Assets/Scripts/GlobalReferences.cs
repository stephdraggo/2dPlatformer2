using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    //put static variables here
    public static int gameScore;
    public static int tempScore;
}

//PlayerState affects behaviour towards enemy collision and animations
public enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Falling,
    Dead,
}
public enum EnemyState
{
    Passive,
    Aggro,
    Attack,
}