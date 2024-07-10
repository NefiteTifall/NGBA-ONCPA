using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Ajouter cette ligne pour résoudre l'erreur CS0246

public class Teleportation : MonoBehaviour
{
    // Nom de la scène vers laquelle vous souhaitez téléporter le joueur
    public string sceneToLoad;
    // Temps d'attente avant la téléportation en secondes
    public float teleportDelay = 1.0f;
    // L'élément qui aura le trigger
    public GameObject triggerElement;

    private float timer;
    private bool startTimer = false;

    private void Start()
    {
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= teleportDelay)
            {
                TeleportAfterDelay();
            }
        }
    }

    // Cette fonction est appelée lorsqu'un autre collider entre dans le trigger collider attaché à l'élément de déclenchement
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur est entré dans le trigger
        if (other.CompareTag("Player"))
        {
            // Lance la coroutine de téléportation avec un délai
            startTimer = true;
        }
    }

    // Coroutine pour gérer le délai avant la téléportation
    private void TeleportAfterDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
