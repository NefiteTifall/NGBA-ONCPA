using UnityEngine;

public class ShovelController : ObjectController
{
    public string gravelTag = "Gravel";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gravelTag))
        {
            if (collision.gameObject.TryGetComponent<GravelController>(out var gravel))
            {
                gravel.OnShovelHit();
            }
        }
    }
}
