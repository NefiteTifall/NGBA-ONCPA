using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Ajouter cette ligne pour r�soudre l'erreur CS0246

public class Teleportation : MonoBehaviour
{
    // Nom de la sc�ne vers laquelle vous souhaitez t�l�porter le joueur
    public string sceneToLoad;
    // Temps d'attente avant la t�l�portation en secondes
    public float teleportDelay = 1.0f;
    // L'�l�ment qui aura le trigger
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

    // Cette fonction est appel�e lorsqu'un autre collider entre dans le trigger collider attach� � l'�l�ment de d�clenchement
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur est entr� dans le trigger
        if (other.CompareTag("Player"))
        {
            // Lance la coroutine de t�l�portation avec un d�lai
            startTimer = true;
        }
    }

    // Coroutine pour g�rer le d�lai avant la t�l�portation
    private void TeleportAfterDelay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
