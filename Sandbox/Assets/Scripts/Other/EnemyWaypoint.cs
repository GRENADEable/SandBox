using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownerBTWaypoint : MonoBehaviour
{
    public WayPointSystem path;

    private int currentPositionIndex;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        currentPositionIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.Positions[currentPositionIndex], speed);
        if (transform.position == path.Positions[currentPositionIndex])
        {
            currentPositionIndex++;
        }
        if (currentPositionIndex == path.Positions.Length)
        {
            currentPositionIndex = 0;
        }
	}
}
