using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour
{
    // The target
    [SerializeField] private Transform target;
    // Enemy's spawn location
    private Vector3 targetSpawn;
    private Vector3 spawn;
    // Enemy's speed
    [SerializeField] private float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
        targetSpawn = target.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        //Respawn enemy when player is respawning
        if (target.position == targetSpawn)
        {
            transform.position = spawn;
        }
        else
        { // moves towards player
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


}
