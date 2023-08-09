using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreatedBurger : MonoBehaviour
{
    public bool hasCheese;
    public bool hasLettuce;
    public string state;

    public int value = 3;

    // Start is called before the first frame update
    void Start()
    {
        value = 3;
    }
    public void HotDogEntered(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.name);
        state = args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>().state.ToString();
        for(int i=0; i<args.interactableObject.transform.childCount; i++)
        {
            if(args.interactableObject.transform.name.Contains("Lettuce"))
            {
                hasLettuce = true;
            }
            else if (args.interactableObject.transform.name.Contains("Cheese"))
            {
                hasCheese = true;
            }
        }
    }
}
