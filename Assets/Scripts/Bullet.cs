using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float speed = 70f;
    [SerializeField] private int damage = 50;
    [SerializeField] private float explosionRadius = 0f;    // To splash damage

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
        transform.LookAt(target.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    // ------------------------------
    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        // splash damage
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    public void Explode()
    {
        // TODO: Fix with OverlapSphere Layer mask (tag checking is slow maybe)
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                Damage(col.gameObject);
            }
        }
    }

    public void Damage(GameObject target)
    {
        Enemy e = target.GetComponent<Enemy>();
        e.TakeDamage(damage);
    }
}
