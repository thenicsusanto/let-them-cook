using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class busStop : MonoBehaviour
{
    [SerializeField]
    private AudioSource busSound;
    [SerializeField]
    private AudioSource menuTheme;


    private void Start()
    {
        menuTheme.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.CompareTag("MainCamera"))
        //{
        //    menuTheme.Stop();
        //    busSound.Play();
        //    StartCoroutine(leaveToScreen());
        //}
    }

    public void StartGame()
    {
        menuTheme.Stop();
        busSound.Play();
        StartCoroutine(leaveToScreen());
    }

    IEnumerator leaveToScreen()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Testing1 1");
    }
}
