using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedChickenTenders : MonoBehaviour
{
    public int tenderAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.name.Contains("ChickenTender"))
        {
            tenderAmount++;
        }
    }
}
