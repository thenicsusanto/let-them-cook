using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.VisualScripting;

public class MealBag : MonoBehaviour
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
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            IterateThroughChildren(collision.gameObject.transform);
            collision.gameObject.transform.SetParent(transform);
            for(int i=0; i<collision.gameObject.GetComponent<BurgerBoxBehavior>().renderers.Count; i++)
            {
                if (collision.gameObject.GetComponent<BurgerBoxBehavior>().renderers[i].GetComponent<Renderer>() != null)
                {
                    collision.gameObject.GetComponent<BurgerBoxBehavior>().renderers[i].GetComponent<Renderer>().enabled = false;
                }
            }

            Chicken[] disabledList = FindObjectsOfType<Chicken>();
            for(int i=0;i<disabledList.Length;i++)
            {
                disabledList[i].gameObject.GetComponent<Renderer>().enabled = false;
            }
            collision.gameObject.transform.localPosition = Vector3.zero;
            collision.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            foodInBag.Add(collision.gameObject);
            foodInBag = foodInBag.OrderBy(go => go.name).ToList();
        }  
    }

    private void IterateThroughChildren(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // Do something with the child GameObject or its components here
            Debug.Log("Child name: " + child.name);
            if(child.GetComponent<Renderer>() != null)
            {
                child.GetComponent<Renderer>().enabled = false;
            }

            if(child.GetComponent<Collider>() != null)
            {
                child.GetComponent<Collider>().enabled = false;
            }

            // Recursive call to iterate through nested children
            IterateThroughChildren(child);
        }
    }
}