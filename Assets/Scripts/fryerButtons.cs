using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
                other.gameObject.transform.position = new Vector3(-0.0776f, 1.0256f, 0.3464f);
                fryerBasket.GetComponent<fryerBasket>().pushedDown();
            }
            else
            {
                other.gameObject.transform.position = new Vector3(-9.91f, -0.2531458f, 0.1933f);
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
                other.gameObject.transform.position = new Vector3(-0.0776f, 1.027342f, 0.3431f);
            }
            else
                other.gameObject.transform.position = new Vector3(-9.91f, -0.2514038f, 0.19f);
        }
    }
}
