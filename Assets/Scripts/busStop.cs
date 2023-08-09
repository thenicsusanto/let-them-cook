using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class busStop : MonoBehaviour
{
    [SerializeField]
    private AudioSource busSound;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Untagged"))
        {
            busSound.Play();
            StartCoroutine(leaveToScreen());
        }
    }

    IEnumerator leaveToScreen()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Testing1 1");
    }
}
