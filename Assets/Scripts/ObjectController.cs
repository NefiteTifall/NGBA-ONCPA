using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjectController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startRotation;
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    public bool IsGrabbed => isGrabbed;

    private void Awake() {
        grabInteractable = GetComponent<XRGrabInteractable>();

        Debug.Assert(grabInteractable != null, "XRGrabInteractable not found on object");

        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    protected void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation.eulerAngles;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    public void ResetObjectPosition()
    {
        transform.SetPositionAndRotation(startPosition, Quaternion.Euler(startRotation));
    }
}
