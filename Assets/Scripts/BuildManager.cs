using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Singleton
    private static BuildManager _instance = null;
    public static BuildManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("BuildManager already exsits");
            return;
        }
        _instance = this;
    }


    [SerializeField] private GameObject standardTurretPrefab;
    private GameObject turretToBuild;
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // ------------------------------
    public GameObject GetTurretToBuild() { return turretToBuild; }
}
