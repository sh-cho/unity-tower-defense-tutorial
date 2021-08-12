using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;
    
    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color originalColor;

    private BuildManager buildManager;


    // -------------------------------------------------------------------------
    // Properties
    // -------------------------------------------------------------------------
    public Vector3 BuildPosition { get { return transform.position + positionOffset; } }


    // -------------------------------------------------------------------------
    // Unity Events
    // -------------------------------------------------------------------------
    private void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret)
        {
            Debug.Log("We can't build here!");
            return;
        }

        // Build Turret
        // GameObject turrentToBuild = BuildManager.Instance.GetTurretToBuild();
        // turret = Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
