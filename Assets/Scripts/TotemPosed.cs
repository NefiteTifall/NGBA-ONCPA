using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemPosed : MonoBehaviour
{
    public GameObject rayon;

    // Fonction que l'on peux appeler depuis un autre script
    public void OnTotemPosed()
    {
        Destroy(rayon);
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
