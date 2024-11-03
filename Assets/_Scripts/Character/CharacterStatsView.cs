using TMPro;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour
{
    private const string HealthText = "Health:";
    private const string SpeedText = "Speed:";

    [field: SerializeField] private Character _character;

    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _speedText;

    private void Start()
    {
        _healthText.text = HealthText + _character.CharacterData.Health;
        _speedText.text = SpeedText + _character.CharacterData.Speed;

        _character.CharacterData.HealthChanged += OnHealthChanged;
        _character.CharacterData.SpeedChanged += OnSpeedChanged;
    }


    private void OnDisable()
    {
        _character.CharacterData.HealthChanged -= OnHealthChanged;
        _character.CharacterData.SpeedChanged -= OnSpeedChanged;
    }

    private void OnHealthChanged(int healthAmount)
        => _healthText.text = HealthText + healthAmount;

    private void OnSpeedChanged(float speedAmount)
        => _speedText.text = SpeedText + speedAmount;
}
