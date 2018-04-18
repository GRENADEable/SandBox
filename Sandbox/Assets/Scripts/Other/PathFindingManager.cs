using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{
    public static PathFindingManager _instance;

    public PathFindingManager GetInstance()
    {
        return _instance;
    }

    Vector3 [] NodesPosition;
    float [][] Distances;

    void Awake()
    {
        _instance = this;
    }

    void Intialize()
    {
        NodesPosition = new Vector3[transform.childCount];

        Distances = new float[transform.childCount][];

        for (int i = 0; i < transform.childCount; i++)
        {
            NodesPosition[i] = transform.GetChild(i).position;
            Distances[i] = new float[transform.childCount];
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.childCount; j++)
            {
                if (i == j)
                    Distances[i][j] = -1;
                else
                {
                    Vector3 dir = NodesPosition[j] - NodesPosition[i];

                    if (!Physics.Raycast(NodesPosition[i], dir, dir.magnitude))
                    {
                        Distances[i][j] = Vector3.Distance(NodesPosition[i], NodesPosition[j]);
                    }
                    else
                    {
                        Distances[i][j] = -1;
                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        Intialize();
	}


    void OnDrawGizmos()
    {
        Intialize();
        Gizmos.color = Color.yellow;
        for (int i = 0; i < Distances.Length; i++)
        {
            for (int j = 0; j < Distances[i].Length; j++)
            {
                if (Distances[i][j] != -1)
                    Gizmos.DrawLine(NodesPosition[i], NodesPosition[j]);
            }
        }
    }
}
