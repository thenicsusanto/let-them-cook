using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepFryerBehavior : MonoBehaviour
{

    bool cookingFin;

    // Start is called before the first frame update
    void Start()
    {
        cookingFin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cookingFin)
        {
            //TheAudioManager.Instance.PlaySFX("Ding");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("fryerBasket"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            foreach (GameObject go in other.gameObject.GetComponent<fryerBasket>().fryerObjects)
            {
                go.GetComponent<GrilledFoodStopwatch>().stopwatchActive = true;
            }

            StartCoroutine(cookingFinished());
        }
    }

    private IEnumerator cookingFinished()
    {
        yield return new WaitForSeconds(8.5f);
        cookingFin = true;

    }
}
