using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    [SerializeField]
    GameObject lights;

    bool isOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOff)
        {
            float randNum = Random.Range(3, 8);
            StartCoroutine(LightSwitch(randNum));
        }
    }

    IEnumerator LightSwitch(float num)
    {
        isOff = true;
        yield return new WaitForSeconds(num);
        lights.SetActive(false);
        StartCoroutine(turnOnLights());
    }

    IEnumerator turnOnLights()
    {
        yield return new WaitForSeconds(0.5f);
        lights.SetActive(true);
    }
}
