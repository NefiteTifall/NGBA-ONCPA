using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLever : MonoBehaviour
{
    public bool leverActivated = false;
    // Fonction pour bouger le levier
    public void Move()
    {
        // R�cup�rer la rotation actuelle du levier
        Vector3 currentRotation = transform.localEulerAngles;
        
        // Si le levier est en position basse
        if (currentRotation.x == 315)
        {
            // Rotation sur l'axe X défini a -45
            transform.localEulerAngles = new Vector3(45, 0, 0);
            leverActivated = false;
        }
        // Sinon
        else
        {
            // Rotation sur l'axe X défini a 0
            transform.localEulerAngles = new Vector3(315, 0, 0);
            leverActivated = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
