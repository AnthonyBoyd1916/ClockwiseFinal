using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWPindex = 0;

    [SerializeField] private float platspeed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWPindex].transform.position, transform.position) < .1f)
        {
            currentWPindex++;
            if (currentWPindex >= waypoints.Length) { currentWPindex = 0; }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWPindex].transform.position, Time.deltaTime * platspeed);
        //if (Input.GetButtonDown("Q"))
        //{
        // rb.velocity = new Vector2(rb.velocity.x, jppower);
        //}

        if (Input.GetButtonDown("Timestop"))
        {
            platspeed = 0f;
        }
        if (Input.GetButtonUp("Timestop"))
        {
            platspeed = 2f;
        }
    }


}
