using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Grab : MonoBehaviour
{
    // User
    public GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Récupération de la position de l'objet qui possède le script 
        Vector3 pos = transform.position;
        // Récupération de la position de l'utilisateur
        Vector3 controllerPos = controller.transform.position;
        // Calcul de la distance entre l'objet et l'utilisateur
        float distance = Vector3.Distance(pos, controllerPos);
        // Si la distance est inférieure à 1
        if (distance < 1)
        {
            // Active le XR Grab interactable
            GetComponent<XRGrabInteractable>().enabled = true;
        }
        else {
            // Sinon, désactive le XR Grab interactable
            GetComponent<XRGrabInteractable>().enabled = false;            
        }
    }
}
