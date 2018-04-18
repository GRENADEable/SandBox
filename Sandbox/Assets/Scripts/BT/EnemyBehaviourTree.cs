using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourTree : MonoBehaviour
{
    [HideInInspector] public Node root;
    public WayPointSystem path;
    public float enemySpeed;
    public PlayerController _Player;

    public Transform player;
    public Transform rock;

    public float chaseDistance;
    public float attackDistance;
    public float distanceToPlayer;
    //public float rockDistance;
    public float angle;
    [HideInInspector] public Vector3 tarDir;
    public float distanceToWaypoint;

    // Use this for initialization
    void Start ()
    {
        //Patrol p = new Patrol(); //Can be also written as the line below.
        Selecter selectNode = new Selecter();
        Sequence sequenceNode = new Sequence();

        root = selectNode;
        selectNode.children.Add(sequenceNode);
        selectNode.children.Add(new Patrol());

        sequenceNode.children.Add(new Chase());
        sequenceNode.children.Add(new Attack());

        _Player = GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        root.Execute(this);
	}
}
