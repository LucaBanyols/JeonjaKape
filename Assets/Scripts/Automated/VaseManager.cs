using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseManager : MonoBehaviour 
{
    public List<GameObject> vases;
    public List<Transform> vaseWaypoints;
    private int randomWaypoint = 0;
    private int vaseWaypointLength = 0;

    void Start()
    {
        for (int i = 0; i < vases.Count; i++)
        {
            vaseWaypointLength = vaseWaypoints.Count;
            randomWaypoint = Random.Range(0, vaseWaypointLength);
            vases[i].transform.position = vaseWaypoints[randomWaypoint].position;
            vaseWaypoints.RemoveAt(randomWaypoint);
        }
    }
}
