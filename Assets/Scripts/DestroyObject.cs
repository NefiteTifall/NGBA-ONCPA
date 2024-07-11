using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Game Object to destroy
    public GameObject objectToDestroy;

    // Destroy the object
    public void Destroy()
    {
        Destroy(objectToDestroy);
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
