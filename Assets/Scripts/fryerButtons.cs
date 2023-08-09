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
                transform.position = new Vector3(-9.91f, -0.251f, 0.19f);
                fryerBasket.GetComponent<fryerBasket>().pushedDown();
                TheAudioManager.Instance.PlaySFX("ButtonPressed");
            }
            else if(greenButton)
            {
                transform.position = new Vector3(-9.91f, -0.61f, 0.46f);
                fryerBasket.GetComponent<fryerBasket>().released();
                TheAudioManager.Instance.PlaySFX("ButtonPressed");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rightHand"))
        {
            if (!greenButton)
            {
                transform.position = new Vector3(-0.0776000023f, 1.0273422f, 0.343100011f);
                TheAudioManager.Instance.PlaySFX("ButtonReleased");
            }
            else
                transform.position = new Vector3(-9.84000015f, -0.251403809f, 0.189999998f);
                TheAudioManager.Instance.PlaySFX("ButtonReleased");
        }
    }
}
