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
        Debug.Log("Purchased Standard Turret");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Purchased Another turret");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
