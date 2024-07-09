using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public float darkenDuration = 1.0f; // Dur�e de l'assombrissement en secondes
    public string sceneToLoad; // Nom de la sc�ne vers laquelle t�l�porter le joueur

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
            // Par exemple, changer la couleur de l'�cran ou utiliser un effet de post-processing

            // Charger la nouvelle sc�ne apr�s le d�lai
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
