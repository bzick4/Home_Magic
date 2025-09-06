using UnityEngine;
using System;
using TMPro;

public class Health : MonoBehaviour
{
    private VeiwModel _veiwModel;
    [SerializeField] private float _Health =float.MaxValue;
    public float currentHealth
    {
        get => _Health;
        set
        {
            if (_Health == value) return;
            _Health = value;
            if (_veiwModel != null) _veiwModel.Health = _Health.ToString();
            if (_Health <= 0)
            {
                Death();
            }
        }
    } //{ get; set; }

    public static Action OnDamage;

    private void Start()
    {
        ApplySettings(SettingsManager.Instance.CurrentSettings);
    }
    private void Awake()
    {
        _veiwModel = FindObjectOfType<VeiwModel>();
        
        SettingsManager.Instance.OnSettingsChanged += ApplySettings;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        //Death();
    }

    private void ApplySettings(Settings settings)
    {
        currentHealth = settings._HeroHealth;

        Debug.Log($"Применены настройки игрока: HP={currentHealth}");
    }

    private void OnDestroy()
    {
        if (SettingsManager.Instance != null)
            SettingsManager.Instance.OnSettingsChanged -= ApplySettings;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(currentHealth);
    }

    private void Death()
    {
        if (currentHealth <= 0)
            OnDamage?.Invoke();
    }
}