using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    GameObject presser;
    bool isPressed;

    public ParticleSystem grillSmoke;

    private void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            if(transform.name != "StartGrillButton" && transform.name != "StopGrillButton")
            {
                button.transform.localPosition = new Vector3(0, 0.003f, 0);
            }
            
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            if (transform.name != "StartGrillButton" && transform.name != "StopGrillButton")
            {
                button.transform.localPosition = new Vector3(0, 0.015f, 0);
            }
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGrill()
    {
        TheAudioManager.Instance.PlayLoopedSFX("Grill");
        grillSmoke.Play();
    }

    public void StopGrill()
    {
        TheAudioManager.Instance.sfxLoopedSource.Stop();
        grillSmoke.Stop();
    }
}
