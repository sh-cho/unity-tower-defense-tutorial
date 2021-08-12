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


    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    private TurretBlueprint turretToBuild;

    // ------------------------------
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        node.turret = Instantiate(turretToBuild.prefab, node.BuildPosition, Quaternion.identity);
    }
    public void SelectTurretToBuild(TurretBlueprint newTurret) { turretToBuild = newTurret; }

}
