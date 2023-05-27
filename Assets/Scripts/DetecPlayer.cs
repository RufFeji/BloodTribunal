using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecPlayer : MonoBehaviour
{
    public GameObject EnemyMesh;
    public GameObject player;
    public float distanceToStopFollowing = 10f;
    public bool startFollowing;
    private void Update()
    {
        if (startFollowing) 
        {
            EnemyMesh.GetComponent<MovingPlatform>().followPlayer = true;
        }
        if (!startFollowing)
        {
            EnemyMesh.GetComponent<MovingPlatform>().followPlayer = false;
        }

        if(Vector3.Distance(transform.position, player.transform.position) > distanceToStopFollowing)
        {
            startFollowing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startFollowing = true;
        }
    }

}
