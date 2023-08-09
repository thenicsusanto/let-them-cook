using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject readyFoodObject;
    public int reputation = 3;

    public bool grillOn;
}
