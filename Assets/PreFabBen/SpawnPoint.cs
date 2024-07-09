using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform spawnPoint;

    void Awake()
    {
        // Trouver le point de spawn dans le prefab
        spawnPoint = transform.Find("SpawnPoint");

        if (spawnPoint != null)
        {
            // Déplacer le joueur ou tout autre objet à ce point de spawn
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
                player.transform.rotation = spawnPoint.rotation;
            }
        }
        else
        {
            Debug.LogWarning("SpawnPoint non trouvé dans le prefab.");
        }
    }
}
