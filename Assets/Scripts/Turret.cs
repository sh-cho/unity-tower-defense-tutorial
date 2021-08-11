using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Constants
    private const string ENEMY_TAG = "Enemy";

    // Fields    
    private GameObject target;
    [SerializeField] private float fireRadius = 0.5f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireRadius);
    }


    // ------------------------------
    private void UpdateTarget()
    {
        // TODO: Optimization (with RayCast maybe?)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ENEMY_TAG);

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && nearestDistance <= fireRadius)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }
}
