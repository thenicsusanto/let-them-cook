using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;

    private XRPokeInteractor _xrPokeInteractor;
    [SerializeField] private Image watchImage;

    private void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeAttachPoint();
        GameManager.Instance.GetWatch(watchImage);
    }

    void SetPokeAttachPoint()
    {
        if (PokeAttachPoint == null) { Debug.Log("Poke Attach Point is null"); return; }

        if (_xrPokeInteractor == null) { Debug.Log("XR Poke Interactor is null"); return; }

        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
