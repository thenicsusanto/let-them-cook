using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedHotDog : MonoBehaviour
{
    public bool hasKetchup;
    public bool hasMustard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HotDogEntered()
    {
        Debug.Log("Entered");
    }

    public void HotDogExited()
    {
        Debug.Log("Exited");
    }
}
