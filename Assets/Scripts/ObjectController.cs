using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startRotation;

    protected void Start()
    {
        startPosition = transform.position;
    }

    public void ResetObjectPosition()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
