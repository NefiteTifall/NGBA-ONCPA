using UnityEngine;

public class IronIngotController : ObjectController
{
    public float distanceThreshold = 0.5f;

    public PortalController portalController;
    public ObjectController flintController;

    private void OnIngotHitFlint()
    {
        Debug.Log("OnIngotHitFlint - IsPlayerClose :" + portalController.IsPlayerClose);

        if (portalController.IsPlayerClose)
        {
            portalController.ActivatePortal();
        }
    }

    void Update()
    {
        if (this.IsGrabbed && flintController.IsGrabbed)
        {
            float distance = Vector3.Distance(this.transform.position, flintController.gameObject.transform.position);

            if (distance <= distanceThreshold)
            {
                OnIngotHitFlint();
            }
        }
    }
}
