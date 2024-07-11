using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Door to open
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(false);
    }

    // On trigger Exit
    private void OnTriggerExit(Collider other)
    {
        door.SetActive(true);
    }
    
}
