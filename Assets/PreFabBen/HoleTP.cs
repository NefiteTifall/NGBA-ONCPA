using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public float darkenDuration = 1.0f; // Durée de l'assombrissement en secondes
    public string sceneToLoad; // Nom de la scène vers laquelle téléporter le joueur

    private bool isPlayerInside = false;
    private float timeEntered;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            timeEntered = Time.time;
        }
    }

    void Update()
    {
        if (isPlayerInside && Time.time - timeEntered >= darkenDuration)
        {
            // Assombrir la vue du joueur
            // Par exemple, changer la couleur de l'écran ou utiliser un effet de post-processing

            // Charger la nouvelle scène après le délai
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
