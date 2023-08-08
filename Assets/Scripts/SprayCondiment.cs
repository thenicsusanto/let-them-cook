using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayCondiment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCondiment(ParticleSystem particleEffect)
    {
        particleEffect.Play();
        Debug.Log("Played");
    }

    public void StopCondiment(ParticleSystem particleEffect)
    {
        particleEffect.Stop();
        Debug.Log("Stopped");
    }
}
