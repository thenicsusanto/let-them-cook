using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deepFryerBehavior : MonoBehaviour
{

    bool cookingFin;

    GameObject fryerBasket;

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

    public void startCooking()
    {

            foreach (GameObject go in fryerBasket.gameObject.GetComponent<fryerBasket>().fryerObjects)
            {
                go.GetComponent<GrilledFoodStopwatch>().stopwatchActive = true;
            }

            StartCoroutine(cookingFinished());
        
    }

    private IEnumerator cookingFinished()
    {
        yield return new WaitForSeconds(8.5f);
        cookingFin = true;

    }
}
