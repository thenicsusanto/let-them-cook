using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBag : MonoBehaviour
{
    public List<GameObject> foodInBag = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Dish>() != null)
        //{
        //    foodInBag.Add(other.gameObject);
        //    other.gameObject.transform.SetParent(gameObject.transform);
        //    other.gameObject.transform.localPosition = Vector3.zero;
        //    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //    Debug.Log(other.name);
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FoodBag"))
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.localPosition = Vector3.zero;
            collision.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            foodInBag.Add(collision.gameObject);
        }
    }
}