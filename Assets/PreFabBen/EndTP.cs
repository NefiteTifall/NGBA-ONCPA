using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class EndTP : MonoBehaviour
{
    // Nom de la sc�ne vers laquelle vous souhaitez t�l�porter le joueur
    public string sceneToLoad;
    // Temps d'attente avant la t�l�portation en secondes
    public float teleportDelay = 1.0f;
    // L'�l�ment qui aura le trigger
    public GameObject triggerElement;
    // Liste des XR Socket Interactors
    public List<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor> socketInteractors = new List<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    // Activation du portail
    public bool isPortalActive = false;

    private float timer;
    private bool startTimer = false;

    private void Start()
    {
        SetPortalActivation(isPortalActive);
        foreach (var socket in socketInteractors)
        {
            socket.selectEntered.AddListener(OnSocketElementPlaced);
            socket.selectExited.AddListener(OnSocketElementRemoved);
        }
    }

    private void Update()
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
        // V�rifie si le portail est activ� et si le joueur est entr� dans le trigger
        if (isPortalActive && other.CompareTag("Player"))
        {
            // Lance la t�l�portation avec un d�lai
            startTimer = true;
        }
    }

    // M�thode pour t�l�porter apr�s un d�lai
    private void TeleportAfterDelay()
    {
        // T�l�porte le joueur vers la nouvelle sc�ne
        SceneManager.LoadScene(sceneToLoad);
    }

    // M�thode pour activer ou d�sactiver le portail via une action ext�rieure
    public void SetPortalActivation(bool activationStatus)
    {
        isPortalActive = activationStatus;
        if (triggerElement != null)
        {
            triggerElement.SetActive(isPortalActive); // Activer ou d�sactiver le triggerElement

            // Assurez-vous que le triggerElement a un collider et qu'il est marqu� comme Trigger
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

    // M�thode appel�e lorsqu'un �l�ment est plac� dans un socket
    private void OnSocketElementPlaced(SelectEnterEventArgs args)
    {
        CheckAllSocketsFilled();
    }

    // M�thode appel�e lorsqu'un �l�ment est retir� d'un socket
    private void OnSocketElementRemoved(SelectExitEventArgs args)
    {
        CheckAllSocketsFilled();
    }

    // V�rifie si tous les sockets contiennent des �l�ments
    private void CheckAllSocketsFilled()
    {
        foreach (var socket in socketInteractors)
        {
            if (!socket.hasSelection)
            {
                SetPortalActivation(false);
                return;
            }
        }
        SetPortalActivation(true);
    }
}
