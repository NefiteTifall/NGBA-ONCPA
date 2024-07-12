using UnityEngine;

public class HoeController : ObjectController
{
    public string netherWartsTag = "NetherWarts";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(netherWartsTag))
        {
            if (collision.gameObject.TryGetComponent<NetherWartsController>(out var netherWarts))
            {
                netherWarts.OnHoeHit();
            }
        }
    }
}
