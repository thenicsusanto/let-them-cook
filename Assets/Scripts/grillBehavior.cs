using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class grillBehavior : MonoBehaviour
{
    public Slider slider;
    float timer;

    [SerializeField] private Material frozenMat;
    [SerializeField] private Material pregrilled;
    [SerializeField] private Material grilledMat;
    [SerializeField] private Material overcooked;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grillable") )
        {
            timer = Time.time;
            //grillItem = other.gameObject;

            //SelectGrillPoint(other.gameObject);

            Debug.Log("Collided");
            //StartCoroutine(StartTimer(10f));
            collision.gameObject.GetComponent<GrilledFoodStopwatch>().stopwatchActive = true;
            TheAudioManager.Instance.PlaySFX("MeatSlap");
            //grillNoise.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Grillable"))
        {
            collision.gameObject.GetComponent<GrilledFoodStopwatch>().stopwatchActive = false;
        }
    }

    //IEnumerator StartTimer(float sec)
    //{
    //    float timer = 0;
    //    while (timer < sec && canInteract) 
    //    {
    //        if (slider.value > 0.2f && slider.value < 0.5)
    //        {
    //            hotDog.GetComponentInChildren<Renderer>().material = pregrilled;
    //        }
    //        else if (slider.value >= 0.5 && slider.value < 0.9f)
    //        {
    //            hotDog.GetComponentInChildren<Renderer>().material = grilledMat;
    //        }
    //        //else if(slider.value >= 0.9f)
    //        //{
    //        //    hotDog.GetComponentInChildren<Renderer>().material = overcooked;
    //        //    //Debug.Log(hotDog.GetComponentInChildren<Renderer>().material);
    //        //}

    //        slider.value = timer / sec;
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }


    //}
}
