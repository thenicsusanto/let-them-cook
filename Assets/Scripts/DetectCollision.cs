using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
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
        if(collision.gameObject.CompareTag("Weapon"))
        {
            TheAudioManager.Instance.PlaySFX("MetalDrop");
        }

        if(collision.gameObject.CompareTag("Pan"))
        {
            TheAudioManager.Instance.PlaySFX("PanDrop");
        }
    }
}
