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
    public void BurgerEntered(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.name);
        if(args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>() != null )
        {
            state = args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>().state.ToString();
        }
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
        args.interactableObject.transform.GetComponentInChildren<Rigidbody>().isKinematic = true;
        args.interactableObject.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        args.interactableObject.transform.GetComponent<BoxCollider>().enabled = false;
    }
    public void BurgerExited()
    {
        Debug.Log("Exited");
        state = "";
        hasLettuce = false;
        hasCheese = false;
    }
}
