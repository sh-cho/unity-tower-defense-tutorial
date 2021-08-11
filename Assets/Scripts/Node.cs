using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Color originalColor;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret)
        {
            Debug.Log("We can't build here!");
            return;
        }

        // Build Turret
        GameObject turrentToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
