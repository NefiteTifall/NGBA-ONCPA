using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckHeldItems : MonoBehaviour
{
    public ObjectController ironIngot;
    public ObjectController flint;

    private bool hasIronIngot = false;
    private bool hasFlint = false;

    void Update()
    {
        hasIronIngot = ironIngot.IsGrabbed;
        hasFlint = flint.IsGrabbed;

        if (hasIronIngot && hasFlint)
        {
            // Activer le déclencheur pour allumer le portail
            // Debug.Log("Le joueur a les deux objets nécessaires.");
        }
    }
}
