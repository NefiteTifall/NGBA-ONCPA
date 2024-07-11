using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeleportToScene : MonoBehaviour
{
    public string sceneName;  // Nom de la scène vers laquelle vous voulez téléporter

    // Cette méthode est appelée lorsque quelque chose entre dans le trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet entrant est le joueur (ou l'objet que vous voulez téléporter)
        if (other.CompareTag("Object"))
        {
            // Chargez la nouvelle scène
            StartCoroutine(LoadSceneAfterDelay());
        }
    }
	
}
