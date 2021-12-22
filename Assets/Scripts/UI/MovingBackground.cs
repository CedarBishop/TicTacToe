using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 dirSpeed;
    public Vector3 endPosition;

    private void FixedUpdate()
    {
        transform.Translate(dirSpeed * Time.fixedDeltaTime);
        if (transform.position.x > endPosition.x || transform.position.y > endPosition.y)
        {
            transform.position = startingPosition;
        }
    }
}
