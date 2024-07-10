using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;

    protected void Start()
    {
        startPosition = transform.position;
    }

    public void ResetPlayerPosition()
    {
        transform.position = startPosition;
    }
}
