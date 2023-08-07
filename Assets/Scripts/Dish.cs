using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public OrderItem compareDishItem;
    public int dishValue;
    
    void Start()
    {
        if(dishValue == 0)
        {
            compareDishItem = ScriptableObject.CreateInstance<Tenders>();
        }
        else if (dishValue == 1)
        {
            compareDishItem = ScriptableObject.CreateInstance<HotDog>();
        }
        else if (dishValue == 2)
        {
            compareDishItem = ScriptableObject.CreateInstance<FrenchFry>();
        }
        else if (dishValue == 3)
        {
            compareDishItem = ScriptableObject.CreateInstance<Burger>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FoodBag"))
        {
            collision.gameObject.GetComponent<FoodBag>().foodInBag.Add(compareDishItem);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            gameObject.transform.SetParent(collision.gameObject.transform);
            gameObject.transform.localPosition = Vector3.zero;
            
        }

        if(collision.gameObject.GetComponent<GrilledFoodStopwatch>() != null)
        {
            
        }
    }
}
