using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTP : MonoBehaviour
{
    // Nom de la scène vers laquelle vous souhaitez téléporter le joueur
    public string sceneToLoad;
    // Temps d'attente avant la téléportation en secondes
    public float teleportDelay = 1.0f;
    // L'élément qui aura le trigger
    public GameObject triggerElement;
    // Activation du portail
    public bool isPortalActive = false;

    private float timer;
    private bool startTimer = false;

    private void Start()
    {
        SetPortalActivation(isPortalActive);
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
        // Vérifie si le portail est activé et si le joueur est entré dans le trigger
        if (isPortalActive && other.CompareTag("Player"))
        {
            // Lance la téléportation avec un délai
            startTimer = true;
        }
    }

    // Méthode pour téléporter après un délai
    private void TeleportAfterDelay()
    {
        // Téléporte le joueur vers la nouvelle scène
        SceneManager.LoadScene(sceneToLoad);
    }

    // Méthode pour activer ou désactiver le portail via une action extérieure
    public void SetPortalActivation(bool activationStatus)
    {
        isPortalActive = activationStatus;
        if (triggerElement != null)
        {
            triggerElement.SetActive(isPortalActive); // Activer ou désactiver le triggerElement

            // Assurez-vous que le triggerElement a un collider et qu'il est marqué comme Trigger
            Collider collider = triggerElement.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
            else
            {
                Debug.LogError("Trigger element must have a Collider component.");
            }
        }
    }
}
