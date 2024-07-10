using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // N�cessaire pour utiliser l'Image
using System.Collections;  // N�cessaire pour utiliser IEnumerator

public class Teleportation : MonoBehaviour
{
    [Header("Portal Settings")]
    public float activationTime = 1f;  // Temps avant la t�l�portation
    public string sceneToLoad = "YourSceneName";  // Nom de la sc�ne � charger

    [Header("Trigger Settings")]
    public GameObject triggerObject;  // R�f�rence � l'objet avec lequel le joueur doit interagir

    [Header("Fade Settings")]
    public Image fadeImage;  // R�f�rence � l'image utilis�e pour le fondu

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
                startTimer = false;  // D�sactive le timer apr�s le d�clenchement de la t�l�portation
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            startTimer = true;
            timer = 0;  // R�initialiser le timer chaque fois que le joueur entre dans le trigger
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

        // Change la sc�ne apr�s le fondu
        SceneManager.LoadScene(sceneToLoad);
    }
}
