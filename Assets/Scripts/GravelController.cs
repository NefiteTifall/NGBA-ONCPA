using UnityEngine;

public class GravelController : MonoBehaviour
{
    public ObjectController flintObjectController;
    public int health = 3;

    public void OnShovelHit()
    {
        health--;

        if (health <= 0)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        if (flintObjectController != null)
        {
            flintObjectController.transform.position = transform.position;
            flintObjectController.gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }
}
