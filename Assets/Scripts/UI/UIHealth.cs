using UnityEngine;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _healthText;

    private void OnEnable()
    {
        Player.OnHealthInit += UpdateHealthText;
        Player.OnDamageTaken += UpdateHealthText;
    }

    private void OnDisable()
    {
        Player.OnHealthInit -= UpdateHealthText;
        Player.OnDamageTaken -= UpdateHealthText;
    }

    private void UpdateHealthText(int health)
    {
        _healthText.text = health.ToString();
    }
}
