using UnityEngine;

public class FireResistancePotionController : ObjectController
{
    public GameObject potionOverlay;
    public Transform head;
    public float distanceThreshold = 0.5f;
    public BoxCollider lavaWallCollider;

    protected void Update()
    {
        if (IsGrabbed)
        {
            if (Vector3.Distance(transform.position, head.position) <= distanceThreshold)
            {
                DrinkPotion();

                lavaWallCollider.enabled = false;
            }
        }
    }

    public void DrinkPotion()
    {
        potionOverlay.SetActive(false);
    }
}
