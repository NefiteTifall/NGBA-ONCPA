using UnityEngine;

public class IronIngotController : ObjectController
{
    public float distanceThreshold = 0.5f;

    public PortalController portalController;
    public ObjectController flintObjectController;

    void Update()
    {
        if (flintObjectController == null) return;

        if (this.IsGrabbed && flintObjectController.IsGrabbed)
        {
            float distance = Vector3.Distance(this.transform.position, flintObjectController.gameObject.transform.position);

            if (distance <= distanceThreshold)
            {
                OnIngotHitFlint();
            }
        }
    }

    private void OnIngotHitFlint()
    {
        if (portalController.IsPlayerClose)
        {
            portalController.ActivatePortal();
        }
    }
}
