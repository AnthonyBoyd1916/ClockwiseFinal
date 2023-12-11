using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject door;
    private int currentWPindex = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {                
        if (other.gameObject.CompareTag("Player"))
        {
            door.transform.position = waypoints[currentWPindex].transform.position;
        }
    }
}
