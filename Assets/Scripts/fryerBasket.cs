using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fryerBasket : MonoBehaviour
{
    int indexOfFryerItem;

    public List<Transform> fryerObjectPos;

    public List<GameObject> fryerObjects;

    // Start is called before the first frame update
    void Start()
    {
        indexOfFryerItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.629f)
            transform.localPosition = new Vector3(transform.position.x, 0.629f, transform.position.z);

        if (transform.position.y > 0.76f)
            transform.position = new Vector3(transform.position.x, 0.76f, transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fryable"))
        {
            indexOfFryerItem++;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fryable"))
        {
            fryerObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Fryable"))
        {
            fryerObjects.Remove(collision.gameObject);
        }
    }

    public void pushedDown()
    {
        transform.position = new Vector3(transform.position.x, 0.629f, transform.position.z);
        foreach (GameObject go in fryerObjects)
        {
            go.GetComponent<GrilledFoodStopwatch>().stopwatchActive = true;
            go.gameObject.transform.position = new Vector3(transform.position.x, 0.6628f, transform.position.z);
        }
    }

    public void released()
    {
        transform.position = new Vector3(transform.position.x, 0.76f, transform.position.z);
        foreach (GameObject go in fryerObjects)
        {
            go.GetComponent<GrilledFoodStopwatch>().stopwatchActive = false;
            go.gameObject.transform.position = new Vector3(transform.position.x, 0.7847534f, transform.position.z);
        }
    }
}
