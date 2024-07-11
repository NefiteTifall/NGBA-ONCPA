using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [Header("Portal Settings")]
    public bool portalActivatedByDefault = true;
    public float activationTime = 2.5f;
    public string sceneToLoad = "Scenes/";  // Nom de la sc�ne � charger

    [Header("Block Settings")]
    public GameObject block;  // R�f�rence au bloc � activer/d�sactiver

    [Header("Teleportation Settings")]
    public bool teleportationEnabled = true;  // Option pour activer/d�sactiver la t�l�portation

    private bool isPortalActive;
    private float timer;

    private bool isPlayerClose = false;

    public bool IsPlayerClose => isPlayerClose;

    void Start()
    {
        isPortalActive = portalActivatedByDefault;
        UpdatePortalState();
    }

    void Update()
    {
        if (isPortalActive && isPlayerClose && teleportationEnabled)
        {
            timer += Time.deltaTime;
            if (timer >= activationTime)
            {
                ChangeScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0;
            isPlayerClose = false;
        }
    }

    public void ActivatePortal()
    {
        isPortalActive = true;
        UpdatePortalState();
    }

    public void DeactivatePortal()
    {
        isPortalActive = false;
        UpdatePortalState();
    }

    public void ToggleTeleportation(bool enable)
    {
        teleportationEnabled = enable;
    }

    private void UpdatePortalState()
    {
        block.SetActive(isPortalActive);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
