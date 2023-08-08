using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreatedHotDog : MonoBehaviour
{
    public bool hasKetchup;
    public bool hasMustard;

    public string state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HotDogEntered(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.name);
        Debug.Log("Entered");
        state = args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>().state.ToString();
        if(args.interactableObject.transform.GetComponentInChildren<Condiments>().hasKetchup)
        {
            hasKetchup = true;
        }
        if(args.interactableObject.transform.GetComponentInChildren<Condiments>().hasMustard)
        {
            hasMustard = true;
        }
    }

    public void HotDogExited()
    {
        Debug.Log("Exited");
        state = "";
    }
}
