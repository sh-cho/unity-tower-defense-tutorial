using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int health = 100;
    [SerializeField] private int moneyDrop = 1;

    [SerializeField] private GameObject deathEffect;
    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            if (waypointIndex >= Waypoints.points.Count - 1)
            {
                EndPath();
                return;
            }

            target = Waypoints.points[++waypointIndex];
        }
    }

    // ----------------------------------------------------------------------------
    private void EndPath()
    {
        --PlayerStats.lives;
        Destroy(gameObject);
    }

    public void TakeDamage(int amonut)
    {
        health -= amonut;

        if (health <= 0)
        {
            PlayerStats.money += moneyDrop;

            // Die
            GameObject e = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(e, 5f);
            Destroy(gameObject);
        }
    }
}
