using UnityEngine;
using UnityEngine.SceneManagement;

public class HitboxPortalTrigger : MonoBehaviour
{
    [Header("Portal Settings")]
    public bool portalActivatedByDefault = true;
    public float activationTime = 2.5f;
    public string sceneToLoad = "Scenes/";  // Nom de la scène à charger

    [Header("Block Settings")]
    public GameObject block;  // Référence au bloc à activer/désactiver

    [Header("Teleportation Settings")]
    public bool teleportationEnabled = true;  // Option pour activer/désactiver la téléportation

    private bool isPortalActive;
    private float timer;
    private bool startTimer = false;

    void Start()
    {
        isPortalActive = portalActivatedByDefault;
        UpdatePortalState();
    }

    void Update()
    {
        if (startTimer)
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
        if (isPortalActive && other.CompareTag("Player"))
        {
            startTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = 0;
            startTimer = false;
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
