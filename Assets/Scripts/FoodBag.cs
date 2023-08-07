using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBag : MonoBehaviour
{
    public List<OrderItem> foodInBag = new List<OrderItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.GetComponent<Dish>() != null)
    //    {
    //        foodInBag.Add(other.gameObject);
    //        other.gameObject.transform.SetParent(gameObject.transform);
    //        other.gameObject.transform.localPosition = Vector3.zero;
    //        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //        Debug.Log(other.name);
    //    }
    //}
}