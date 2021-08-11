using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float speed = 70f;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.sqrMagnitude <= distanceThisFrame * distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    // ------------------------------
    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(target);
        Destroy(gameObject);
    }
}
