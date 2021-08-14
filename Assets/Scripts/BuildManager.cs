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
    public GameObject NodeMenuButtons;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

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

    public void SelectNode(Node node)
    {
        if (selectedNode != null)
        {
            if (selectedNode == node)
            {
                DeselectNode();
                return;
            }
            else
            {
                DeselectNode();
            }
        }

        turretToBuild = null;
        selectedNode = node;
        selectedNode.SelectToggle();
        NodeMenuButtons.SetActive(true);
    }

    public void DeselectNode()
    {
        selectedNode.SelectToggle();
        NodeMenuButtons.SetActive(false);

        turretToBuild = null;
        selectedNode = null;
    }

    public void SelectTurretToBuild(TurretBlueprint newTurret)
    {
        turretToBuild = newTurret;
        if (selectedNode != null)
        {
            selectedNode.SelectToggle();
            selectedNode = null;
        }
        NodeMenuButtons.SetActive(false);
    }
}
