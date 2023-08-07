using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //delete below code when testing in vr because you are gonna press the bell
            //Debug.Log("Take order was called");
            //currentCustomer.GetComponent<Customer>().TakeOrder();
            //forPCTesting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FoodBag"))
        {
            foodReady = false;
            GameManager.Instance.readyFoodObject = null;
            //currentCustomer = null;
            //priorityCustomer = other.gameObject;
        }
    }
}
