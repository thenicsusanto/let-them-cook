using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condiments : MonoBehaviour
{
    public bool hasKetchup;
    public bool hasMustard;
    public GameObject ketchupLine;
    public GameObject mustardLine;

    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "Ketchup" && !hasKetchup)
        {
            Debug.Log("Ketchup");
            hasKetchup = true;
            GameObject newKetchupLine = Instantiate(ketchupLine, transform.position, Quaternion.identity);
            newKetchupLine.transform.SetParent(gameObject.transform);
            newKetchupLine.transform.localPosition += new Vector3(0, 0.5f, 0);
        }
        else if(other.name == "Mustard" && !hasMustard)
        {
            Debug.Log("Mustard");
            hasMustard = true;
            GameObject newKetchupLine = Instantiate(mustardLine, transform.position, Quaternion.identity);
            newKetchupLine.transform.SetParent(gameObject.transform);
            newKetchupLine.transform.localPosition += new Vector3(0, 0.5f, 0);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (!hasKetchup)
        {
            Debug.Log("Hit");
            hasKetchup = true;
            GameObject newKetchupLine = Instantiate(ketchupLine, transform.position, Quaternion.identity);
            newKetchupLine.transform.SetParent(gameObject.transform);
            newKetchupLine.transform.position += new Vector3(0, 0.5f, 0);
        }
        
        //if (collision.gameObject.tag == "Ketchup")
        //{
        //    hasKetchup = true;
        //    Debug.Log("hit by ketchup");
        //}
        //if (collision.gameObject.name == "Mustard")
        //{
        //    hasMustard = true;
        //    Debug.Log("hit by mustard");
        //}
    }*/
}
