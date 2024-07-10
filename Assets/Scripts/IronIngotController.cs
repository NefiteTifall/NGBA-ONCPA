using UnityEngine;

public class IronIngotController : ObjectController
{
    public PortalController portalController;
    public ObjectController flintController;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Iron ingot collision");
        if (collision.gameObject == flintController.gameObject)
        {
            OnIngotHitFlint();
        }
    }

    private void OnIngotHitFlint()
    {
        Debug.Log("Iron ingot hit flint");
        if (portalController.IsPlayerClose)
        {
            Debug.Log("Player is close to the portal");
            portalController.ActivatePortal();
        }
    }
}
