using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BurgerBoxBehavior : MonoBehaviour
{
    [SerializeField] private InputActionReference rightTriggerAction;
    [SerializeField] private InputActionReference leftTriggerAction;
    private Coroutine hoverCoroutine;

    [SerializeField] private Animator anim;
    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool TriggerActionDetect()
    {
        if(rightTriggerAction.action.WasPressedThisFrame() || leftTriggerAction.action.WasPressedThisFrame())
            return true;
        return false;
    }

    public void EnterHover(HoverEnterEventArgs args)
    {
        hoverCoroutine = StartCoroutine(StartHover());
    }
    public void ExitHover(HoverExitEventArgs args)
    {
        StopCoroutine(hoverCoroutine);
    }

    public void TestGrab(SelectEnterEventArgs args)
    {
        Debug.Log("grab");
    }
    IEnumerator StartHover()
    {
        while(true) 
        {
            if (TriggerActionDetect() && !isOpen)
            {
                Debug.Log("Opening...");
                anim.SetBool("isOpen", true);
                isOpen = true;
            }
            else if(TriggerActionDetect() && isOpen)
            {
                Debug.Log("Closing...");
                anim.SetBool("isOpen", false);
                isOpen = false;
            }
                
            yield return null;
        }
    }
}
