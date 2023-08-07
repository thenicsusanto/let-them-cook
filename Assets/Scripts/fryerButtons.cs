using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fryerButtons : MonoBehaviour
{

    public GameObject fryerBasket;

    public bool greenButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
        {
            if (!greenButton)
            {
                //transform.position = new Vector3(-0.0776f, 1.0256f, 0.3464f);
                fryerBasket.GetComponent<fryerBasket>().pushedDown();
            }
            else
            {
                //transform.position = new Vector3(-9.91f, -0.2531458f, 0.1933f);
                fryerBasket.GetComponent<fryerBasket>().released();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.CompareTag("rightHand"))
        {
            if (!greenButton)
            {
                transform.position = new Vector3(-0.0776f, 1.027342f, 0.3431f);
            }
            else
                transform.position = new Vector3(-9.91f, -0.2514038f, 0.19f);
        }*/
    }
}
