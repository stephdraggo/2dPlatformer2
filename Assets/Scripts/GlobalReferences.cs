using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    //put static variables here
    public static int gameScore;
    public static int tempScore;
}

//put global enums here
public enum PlayerState
{
    Idle,
    Running,
    Jumping,
    Dead,
}
public enum EnemyState
{
    Passive,
    Aggro,
    Attack,
}