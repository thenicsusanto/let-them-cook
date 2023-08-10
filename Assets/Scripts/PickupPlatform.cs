using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupPlatform : MonoBehaviour
{
    public bool foodReady;
    //public GameObject currentCustomer;
    //public GameObject priorityCustomer;

    bool forPCTesting;

    private void OnTriggerStay(Collider other)
    {
        //take away "&& !forPCTesting" when testing in VR
        if (other.CompareTag("FoodBag") /*&& !forPCTesting*/)
        {
            foodReady = true;
            GameManager.Instance.readyFoodObject = other.gameObject;
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            //delete below code when testing in vr because you are gonna press the bell
            //Debug.Log("Take order was called");
            //currentCustomer.GetComponent<Customer>().TakeOrder();
            //forPCTesting = true;
        }
    }

    public void MealBoxEntered(SelectEnterEventArgs args)
    {
        foodReady = true;
        GameManager.Instance.readyFoodObject = args.interactableObject.transform.gameObject;
        args.interactableObject.transform.GetComponentInChildren<Rigidbody>().isKinematic = true;
        //args.interactableObject.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        //args.interactableObject.transform.GetComponent<BoxCollider>().enabled = false;
    }

    public void MealBoxExited(SelectExitEventArgs args)
    {
        foodReady = false;
        GameManager.Instance.readyFoodObject = null;
        args.interactableObject.transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
        //args.interactableObject.transform.GetComponentInChildren<BoxCollider>().enabled = false;
        //args.interactableObject.transform.GetComponent<BoxCollider>().enabled = false;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("FoodBag"))
    //    {
    //        foodReady = false;
    //        GameManager.Instance.readyFoodObject = null;
    //        //currentCustomer = null;
    //        //priorityCustomer = other.gameObject;
    //    }
    //}
}
