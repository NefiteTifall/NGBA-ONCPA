using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketInteractor : XRSocketInteractor
{
    public GameObject? objectToPlace;

    private bool isPlaced = false;

    public bool IsPlaced => isPlaced;

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        bool baseCanSelect = base.CanSelect(interactable);

        if (objectToPlace != null)
        {
            bool hasSpecificComponent = interactable.transform.gameObject == objectToPlace;

            return baseCanSelect && hasSpecificComponent;
        }

        return baseCanSelect;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        bool baseCanHover = base.CanHover(interactable);

        if (objectToPlace != null)
        {
            bool hasSpecificComponent = interactable.transform.gameObject == objectToPlace;

            return baseCanHover && hasSpecificComponent;
        }

        return baseCanHover;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        isPlaced = true;

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        isPlaced = false;

        base.OnSelectExited(args);
    }

    public void DestroyObject()
    {
        if (isPlaced)
        {
            Destroy(objectToPlace);
        }

        DisableSocket();
    }

    private void DisableSocket()
    {
        this.enabled = false;
    }
}
