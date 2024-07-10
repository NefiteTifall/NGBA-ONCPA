using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Nécessaire pour utiliser l'Image
using System.Collections;  // Nécessaire pour utiliser IEnumerator

public class Teleportation : MonoBehaviour
{
    [Header("Portal Settings")]
    public float activationTime = 1f;  // Temps avant la téléportation
    public string sceneToLoad = "YourSceneName";  // Nom de la scène à charger

    [Header("Trigger Settings")]
    public GameObject triggerObject;  // Référence à l'objet avec lequel le joueur doit interagir

    [Header("Fade Settings")]
    public Image fadeImage;  // Référence à l'image utilisée pour le fondu

    private bool startTimer = false;
    private float timer;

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= activationTime)
            {
                StartCoroutine(FadeAndTeleport());
                startTimer = false;  // Désactive le timer après le déclenchement de la téléportation
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            startTimer = true;
            timer = 0;  // Réinitialiser le timer chaque fois que le joueur entre dans le trigger
        }
    }

    private IEnumerator FadeAndTeleport()
    {
        // Commence le fondu au noir
        float fadeDuration = 1f;
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(currentTime / fadeDuration);
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        // Change la scène après le fondu
        SceneManager.LoadScene(sceneToLoad);
    }
}
