using UnityEngine;

public class GravelController : MonoBehaviour
{
    public GameObject dropObjectPrefab;
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
        if (dropObjectPrefab != null)
        {
            Instantiate(dropObjectPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
