using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Selected Standard Turret");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Selected Missile Turret");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }
}
