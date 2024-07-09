using UnityEngine;
using UnityEngine.SceneManagement;

public class HitboxTrigger : MonoBehaviour
{
    public bool enableSceneChange = false;
    public int sceneIndex = 0;
    public bool enableSpawnPoint = false;
    public Transform spawnPoint;

    public bool enablePortalByDefault = true; // Par d�faut, le portail est activ�
    private bool playerActionActivatesPortal = false; // D�clencheur de l'action du joueur

    public bool IsPortalActive { get; private set; } // Propri�t� pour savoir si le portail est actif

    private bool isInTrigger = false;
    private float timeSpentInTrigger = 0f;
    public float triggerDuration = 2.5f; // Dur�e du d�lai avant changement de sc�ne, modifiable dans l'inspecteur

    private Renderer portalRenderer; // R�f�rence au composant Renderer de portalEffect

    public Material activeMaterial; // Mat�riau � appliquer lorsque le portail est actif

    void Start()
    {
        IsPortalActive = enablePortalByDefault;
        portalRenderer = GetComponent<Renderer>(); // R�cup�re le composant Renderer attach� � cet objet
        UpdatePortalMaterial();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            timeSpentInTrigger = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            timeSpentInTrigger = 0f;
        }
    }

    void Update()
    {
        if (!IsPortalActive && playerActionActivatesPortal)
        {
            ActivatePortal();
        }

        if (!IsPortalActive && !enableSpawnPoint) // Ne v�rifie le d�lai que si le SpawnPoint n'est pas activ�
        {
            if (isInTrigger)
            {
                timeSpentInTrigger += Time.deltaTime;
                if (timeSpentInTrigger >= triggerDuration)
                {
                    if (enableSceneChange)
                    {
                        SceneManager.LoadScene(sceneIndex);
                        enableSpawnPoint = false;
                    }
                    isInTrigger = false;
                    timeSpentInTrigger = 0f;
                }
            }
        }
    }

    public void TriggerPlayerAction()
    {
        playerActionActivatesPortal = true;
    }

    public void ActivatePortal()
    {
        IsPortalActive = true;
        UpdatePortalMaterial();
    }

    public void DeactivatePortal()
    {
        IsPortalActive = false;
        UpdatePortalMaterial();
    }

    public void SetSpawnPoint(Transform point)
    {
        spawnPoint = point;
        enableSpawnPoint = true;
        IsPortalActive = true; // Activer le portail lorsque le spawn point est s�lectionn�
        UpdatePortalMaterial();
    }

    private void UpdatePortalMaterial()
    {
        if (portalRenderer != null)
        {
            portalRenderer.material = IsPortalActive ? activeMaterial : null; // Utilise activeMaterial si le portail est actif, sinon aucun mat�riau
        }
    }
}
