using UnityEngine;

public class ControllerNearHeadDetector : MonoBehaviour
{
    public Transform rightController;
    public Transform leftController;
    public Transform head;
    public float distanceThreshold = 0.5f;

    protected void Update()
    {
        if (IsControllerNearHead())
        {
            Debug.Log("Controller is near head");
        }
    }

    public bool IsControllerNearHead()
    {
        float distanceRight = Vector3.Distance(rightController.position, head.position);
        float distanceLeft = Vector3.Distance(leftController.position, head.position);

        return distanceRight <= distanceThreshold || distanceLeft <= distanceThreshold;
    }
}