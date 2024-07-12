using UnityEngine;

public class NetherWartsController : MonoBehaviour
{
    public ObjectController netherWartObjectController;
    public int health = 3;

    public void OnHoeHit()
    {
        health--;

        if (health <= 0)
        {
            DestroyElement();
        }
    }

    private void DestroyElement()
    {
        if (netherWartObjectController != null)
        {
            netherWartObjectController.transform.position = transform.position;
            netherWartObjectController.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}
