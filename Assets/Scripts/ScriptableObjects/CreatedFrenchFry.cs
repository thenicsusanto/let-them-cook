using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedFrenchFry : MonoBehaviour
{
    int totalFries;
    public int value = 2;

    private void Start()
    {
        value = 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name.Contains("FrenchFry"))
        {
            //if(totalFries > 0 && totalFries < )
        }
    }
}
