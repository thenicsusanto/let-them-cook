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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fryable"))
        {
            
            fryerObjects.Add(other.gameObject);
            Rigidbody RBother = other.gameObject.GetComponent<Rigidbody>();
            RBother.isKinematic = true;
            RBother.useGravity = false;

            indexOfFryerItem++;
            
        }
        /*else
            other.transform.position = new Vector3(0.749f, 0.826f, -1.212f);*/
    }

    public void pushedDown()
    {
        transform.position = new Vector3(transform.position.x, 0.629f, transform.position.z);
    }

    public void released()
    {
        transform.position = new Vector3(transform.position.x, 0.76f, transform.position.z);
    }
}
