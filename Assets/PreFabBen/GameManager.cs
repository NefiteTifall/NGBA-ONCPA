using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // Référence au prefab du joueur

    private void Start()
    {
        SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
        if (spawnPoint != null)
        {
            // Instancier le joueur à la position du SpawnPoint
            GameObject player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else
        {
            Debug.LogWarning("No SpawnPoint found in the scene. Player will not be spawned.");
        }
    }
}
