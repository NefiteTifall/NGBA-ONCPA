using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public string gravelTag = "Gravel";

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Shovel hit");

        if (collision.gameObject.CompareTag(gravelTag))
        {
            Debug.Log("Shovel hit gravel");

            GravelController gravel = collision.gameObject.GetComponent<GravelController>();

            if (gravel != null)
            {
                gravel.OnShovelHit();
            }
        }
    }
}
