using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bell : MonoBehaviour
{
    [SerializeField] private OrderPlatform orderPlatform;
    [SerializeField] private PickupPlatform pickupPlatform;
    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    GameObject presser;
    bool isPressed;

    private void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, -0.01f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            TheAudioManager.Instance.PlaySFX("Bell");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0, 0);
            onRelease.Invoke();
            //TheAudioManager.Instance.PlaySFX("Bell");

            isPressed = false;
        }
    }

    public void CheckTakeOrder()
    {
        if (orderPlatform.takeOrder)
        {
            Debug.Log("Takes Order from CheckTakeOrder in Bell Script");
            orderPlatform.currentCustomer.GetComponent<Customer>().TakeOrder();
        }
    }

    private void Update()
    {
        //Remove this code and use bell when checking collect order
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TheAudioManager.Instance.PlaySFX("Bell");
        //    Debug.Log("checking collect order with space bar");
        //    CheckCollectOrder();
        //}
    }

    public void CheckCollectOrder()
    {
        if (pickupPlatform && orderPlatform.listOfCurrentCustomers.Count == 0)
        {
            Debug.Log("Taking Order from CheckWaiting in Bell Script");
            orderPlatform.listOfCurrentCustomers[0].GetComponent<Customer>().CollectOrder();
        }
    }
}
