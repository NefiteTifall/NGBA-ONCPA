using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    // Point d'apparition initial de l'objet
    private Vector3 spawnPoint;

    // Limites de la carte (configurables via l'inspecteur)
    [Header("Map Boundaries")]
    public float xMin = -10.0f;
    public float xMax = 10.0f;
    public float yMin = -10.0f;
    public float yMax = 10.0f;
    public float zMin = -10.0f;
    public float zMax = 10.0f;

    void Start()
    {
        // Enregistrer la position initiale comme point d'apparition
        spawnPoint = transform.position;
    }

    void Update()
    {
        // Vérifier si l'objet est hors des limites de la carte
        if (transform.position.x < xMin || transform.position.x > xMax ||
            transform.position.y < yMin || transform.position.y > yMax ||
            transform.position.z < zMin || transform.position.z > zMax)
        {
            Respawn();
        }
    }

    // Méthode pour réapparaître l'objet à son point d'apparition initial
    void Respawn()
    {
        transform.position = spawnPoint;
    }
}
