using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreatedChickenTenders : MonoBehaviour
{
    public int tenderAmount;
    public int value = 0;
    //public string state;
    //public bool badlyGrilled;
    //[SerializeField] private List<GameObject> chickenTenders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChickenEntered(SelectEnterEventArgs args)
    {
        tenderAmount++;
        //chickenTenders.Add(args.interactableObject.transform.gameObject);
        //if(state != "grilled" && !badlyGrilled)
        //{
        //    badlyGrilled = true;
        //}
        //else if(state == "grilled" && !badlyGrilled)
        //{
        //    state = args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>().state.ToString();
        //}
        args.interactableObject.transform.GetComponentInChildren<Rigidbody>().isKinematic = true;
        args.interactableObject.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        args.interactableObject.transform.GetComponent<BoxCollider>().enabled = false;
    }

    public void ChickenExited(SelectExitEventArgs args)
    {
        tenderAmount--;
        //chickenTenders.Remove(args.interactableObject.transform.gameObject);
        //for(int i=0; i<chickenTenders.Count; i++)
        //{
        //    if(args.interactableObject.transform.GetComponentInChildren<GrilledFoodStopwatch>().state.ToString() != "grilled")
        //    {

        //    }
        //}
        //state = "";
        args.interactableObject.transform.GetComponentInChildren<Rigidbody>().isKinematic = true;
        args.interactableObject.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        args.interactableObject.transform.GetComponent<BoxCollider>().enabled = false;
    }

}
