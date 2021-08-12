using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughMoneyColor;
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

        if (!buildManager.CanBuild || !buildManager.HasMoney)
            return;

        if (turret)
        {
            Debug.Log("We can't build here!");
            return;
        }

        // Build Turret
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
