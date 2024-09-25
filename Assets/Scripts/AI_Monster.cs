using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Monster : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointsIndex;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointsIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointsIndex++;

        if (waypointsIndex == waypoints.Length)
        {
            waypointsIndex = 0;
        }
    }
}
