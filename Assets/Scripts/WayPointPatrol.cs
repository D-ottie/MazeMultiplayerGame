using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;

    void Start()
    {
       navMeshgent.SetDestination(waypoints[0].position); 
    }

    
    void Update()
    {
        if(navMeshgent.remainingDistance< navMeshgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex+1) % waypoints.Length;
            navMeshgent. SetDestination(waypoints[m_CurrentWaypointIndex].position);

        }
    }
}
