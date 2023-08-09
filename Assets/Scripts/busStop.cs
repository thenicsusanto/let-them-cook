using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class busStop : MonoBehaviour
{
    [SerializeField]
    private AudioSource busSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DOG"))
        {
            Debug.Log("anthony sucks");
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
