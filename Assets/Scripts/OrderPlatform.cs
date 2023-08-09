using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPlatform : MonoBehaviour
{
    public bool takeOrder;
    public GameObject currentCustomer;
    //public GameObject priorityCustomer;
    public List<GameObject> listOfCurrentCustomers = new List<GameObject>();

    bool forPCTesting;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //take away "&& !forPCTesting" when testing in VR
        if(other.CompareTag("Customer") /*&& !forPCTesting*/)
        {
            takeOrder = true;
            currentCustomer = other.gameObject;

            //delete below code when testing in vr because you are gonna press the bell
            //Debug.Log("Take order was called");
            //currentCustomer.GetComponent<Customer>().TakeOrder();
            //forPCTesting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer") /*&& priorityCustomer == null*/)
        {
            takeOrder = false;
            currentCustomer = null;
            //priorityCustomer = other.gameObject;
            listOfCurrentCustomers.Add(other.gameObject);
        }
    }
}
