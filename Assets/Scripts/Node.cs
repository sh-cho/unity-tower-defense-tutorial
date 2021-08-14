using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughMoneyColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Color originalColor;
    private bool isSelected;

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
        isSelected = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild || !buildManager.HasMoney)
            return;

        // Build Turret
        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (isSelected)
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
        if (isSelected)
            return;

        rend.material.color = originalColor;
    }

    // -------------------------------------------------------------------------
    // Custom methods
    // -------------------------------------------------------------------------
    public void SelectToggle()
    {
        if (turret)
        {
            rend.material.color = (isSelected ? originalColor : selectedColor);
            isSelected = !isSelected;
        }
    }
}
