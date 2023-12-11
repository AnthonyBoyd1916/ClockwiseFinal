using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScripts : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWPindex = 0;
    private Animator ratanim;
    //private Vector2 left, right;

    [SerializeField] private float ratspeed = 2f;        
    private void Awake()
    {
        ratanim = GetComponent<Animator>();
        //left = waypoints[0].transform.position;
        //right = waypoints[1].transform.position;
    }
    
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWPindex].transform.position, transform.position) < .1f)
        {
            currentWPindex++;
            if (currentWPindex >= waypoints.Length) { currentWPindex = 0; }
        }       
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWPindex].transform.position, Time.deltaTime * ratspeed);

        if (currentWPindex == 0) //(transform.position.x >= left.x && transform.position.x != right.x)
        {
            ratanim.SetFloat("X", 1);
        }
        else if (currentWPindex == 1) //(transform.position.x <= right.x && transform.position.x != left.x)
        {
            ratanim.SetFloat("X", -1);
        }
    }
}
