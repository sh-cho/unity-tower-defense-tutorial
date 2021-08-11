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
    [SerializeField] private GameObject partToRotate;
    [SerializeField] private float fireRadius = 0.5f;
    [SerializeField] private float turnSpeed = 10f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Transform tr = target.transform;
        // partToRotate.transform.LookAt(
        //     new Vector3(
        //         Mathf.Lerp(partToRotate.transform.position.x, tr.position.x, Time.deltaTime * turnSpeed),
        //         partToRotate.transform.position.y,
        //         Mathf.Lerp(partToRotate.transform.position.z, tr.position.z, Time.deltaTime * turnSpeed)
        //     )
        // );
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
