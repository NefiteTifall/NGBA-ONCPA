using UnityEngine;

public class ResetZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ResetPlayerPosition();
        }
        else if (other.CompareTag("Object"))
        {
            other.GetComponent<ObjectController>().ResetObjectPosition();
        }
		else
        {
            Debug.Log("Tag non reconnu : " + other.tag);
        }
    }
}
