using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilledFoodStopwatch : MonoBehaviour
{
    public bool stopwatchActive;
    float currentTime;
    [SerializeField] private float timeToOvercooked;

    [SerializeField] private Material undercookedMat, grilledMat, overcookedMat;

    public CookedState state;
    public enum CookedState
    {
        frozen,
        undercooked,
        grilled,
        overcooked
    }

    // Start is called before the first frame update
    void Start()
    {
        state = CookedState.frozen;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true && GameManager.Instance.grillOn && currentTime < timeToOvercooked)
        {
            currentTime += Time.deltaTime;
            CheckFoodState();
        }
    }

    void CheckFoodState()
    {
        if (currentTime > timeToOvercooked * 0.30f && currentTime < timeToOvercooked * 0.5f)
        {
            //loop through children and change materials
            for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material = undercookedMat;
                    Debug.Log(transform.GetChild(i).name);
                }
            }
            state = CookedState.undercooked;            
        }
        else if (currentTime >= timeToOvercooked * 0.5f && currentTime < timeToOvercooked * 0.85)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material = grilledMat;
                }
            }
            state = CookedState.grilled;
        }
        else if (currentTime >= timeToOvercooked * 0.9f)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Renderer>() != null)
                {
                    transform.GetChild(i).GetComponent<Renderer>().material = overcookedMat;
                }
            }
            state = CookedState.overcooked;
        }
    }
}
