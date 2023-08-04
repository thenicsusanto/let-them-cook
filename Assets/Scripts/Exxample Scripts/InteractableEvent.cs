using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class InteractableEvent : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private Renderer cubeRenderer;
    private Color originalColor;
    [SerializeField] private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }
    private void OnEnable() {
        
    }

    public void InteractableChangeColor(SelectEnterEventArgs args)
    {
        cubeRenderer.material.color = newColor;
    }
    public void InteractableResetColor(SelectExitEventArgs args)
    {
        cubeRenderer.material.color = originalColor;
    }
    public void InteractorVibrate(SelectEnterEventArgs arg)
    {
        arg.interactorObject.transform.GetComponent<ActionBasedController>().SendHapticImpulse(0.5f, 0.2f);
    }
}
