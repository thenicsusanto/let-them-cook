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
        
        //Check if I can just use events in VR (select entered selectenntereventargs)
        if (grabbableObject.name == "Lettuce")
        {
            TheAudioManager.Instance.PlaySFX("Lettuce");
        }
        else if(grabbableObject.name == "Cheese")
        {
            TheAudioManager.Instance.PlaySFX("Cheese");
        }
        else if(grabbableObject.name == "Burger" || grabbableObject.name == "TopBun")
        {
            TheAudioManager.Instance.PlaySFX("GrabWeapon");
        }
        else if(grabbableObject.name == "Patty")
        {
            TheAudioManager.Instance.PlaySFX("MeatSlap");
        }
        else
        {
            TheAudioManager.Instance.PlaySFX("GrabWeapon");
        }
    }

    public void ChangeGrabbedObject(GameObject box)
    {
        grabbableObject = box;
    }
}