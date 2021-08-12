using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    private void Update()
    {
        moneyText.text = $"$ {PlayerStats.money}";
    }
}
