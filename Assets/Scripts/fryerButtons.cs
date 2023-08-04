using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fryerButtons : MonoBehaviour
{

    public GameObject fryerBasket;

    public bool greenButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
        {
            if (!greenButton)
            {
                transform.localPosition = new Vector3(-0.0776f, 1.0251f, 0.3448f);
                fryerBasket.GetComponent<fryerBasket>().pushedDown();
            }
            else
            {
                transform.localPosition = new Vector3(-9.91f, -0.62f, 0.52f);
                fryerBasket.GetComponent<fryerBasket>().released();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
        {
            if (!greenButton)
            {
                transform.localPosition = new Vector3(-0.0776f, 1.027342f, 0.3431f);
            }
            else
                transform.localPosition = new Vector3(-9.91f, -0.2514038f, 0.19f);
        }
    }
}
