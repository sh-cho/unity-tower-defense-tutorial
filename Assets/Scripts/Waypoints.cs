using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static List<Transform> points;

    private void Awake()
    {
        points = new List<Transform>();
        foreach (Transform child in transform)
        {
            points.Add(child);
        }
    }
}
