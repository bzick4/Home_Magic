using UnityEngine;
using System;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Settings _EasySettings;
    [SerializeField] private Settings _HardSettings;

    [Header("Settings Configuration")]
    [SerializeField] private GameDifficulty _selectedDifficulty;
    private GameDifficulty _currentDifficulty;

    public static SettingsManager Instance { get; private set; }
   public Settings CurrentSettings { get; private set; }
    
   

    public enum GameDifficulty
    {
        Easy,
        Hard
    }

    public event Action<Settings> OnSettingsChanged;

   private void Awake()
    {
        Instance = this;
        _currentDifficulty = _selectedDifficulty;
        CurrentSettings = _selectedDifficulty == GameDifficulty.Easy ? _EasySettings : _HardSettings;
        ApplySettings(_selectedDifficulty);
    }

    private void ApplySettings(GameDifficulty difficulty)
    {
        CurrentSettings = difficulty == GameDifficulty.Easy ? _EasySettings : _HardSettings;
        OnSettingsChanged?.Invoke(CurrentSettings);
        Debug.Log($"Применена конфигурация: {CurrentSettings.ConfigurationName}");
    }
    
   private void OnValidate()
    {
        if (Application.isPlaying && _selectedDifficulty != _currentDifficulty)
        {
            _currentDifficulty = _selectedDifficulty;
            ApplySettings(_selectedDifficulty);
        }
    }
}