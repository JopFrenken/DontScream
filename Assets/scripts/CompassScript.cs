using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    // direction of player
    public Transform playerTransform;
    // direction of compass
    Vector3 direction;

    private void Update() // makes the compass always face the right direction
    {
        direction.z = playerTransform.eulerAngles.y;
        transform.localEulerAngles = direction; 
    }
}
