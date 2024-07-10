using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public string gravelTag = "Gravel";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gravelTag))
        {
            GravelController gravel = collision.gameObject.GetComponent<GravelController>();

            if (gravel != null)
            {
                gravel.OnShovelHit();
            }
        }
    }
}