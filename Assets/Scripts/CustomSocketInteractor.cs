using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketInteractor : XRSocketInteractor
{
    public GameObject objectToPlace;

    private ObjectController objectController;
    private bool isPlaced = false;

    public bool IsPlaced => isPlaced;

    protected override void Start()
    {
        base.Start();

        objectController = objectToPlace.GetComponent<ObjectController>();
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        bool baseCanSelect = base.CanSelect(interactable);
        bool hasSpecificComponent = interactable.transform.gameObject == objectToPlace;

        return baseCanSelect && hasSpecificComponent && objectController.isCanBePlacedInSocket;
    }

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        bool baseCanHover = base.CanHover(interactable);
        bool hasSpecificComponent = interactable.transform.gameObject == objectToPlace;

        return baseCanHover && hasSpecificComponent && objectController.isCanBePlacedInSocket;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        isPlaced = false;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        isPlaced = false;
    }

    public void DestroyObject()
    {
        if (isPlaced)
        {
            Destroy(objectToPlace);
        }
    }
}
