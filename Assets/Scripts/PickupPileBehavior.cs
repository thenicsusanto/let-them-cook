using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class PickupPileBehavior : XRBaseInteractable
{
    [SerializeField]
    private GameObject grabbableObject;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Instantiate object
        GameObject newObject = Instantiate(grabbableObject, args.interactorObject.transform.position, Quaternion.identity);
        Debug.Log("instantiated" + grabbableObject.name);
        // Get grab interactable from prefab
        XRGrabInteractable objectInteractable = newObject.GetComponent<XRGrabInteractable>();

        // Select object into same interactor
        interactionManager.SelectEnter(args.interactorObject, objectInteractable);

        base.OnSelectEntered(args);
    }
}