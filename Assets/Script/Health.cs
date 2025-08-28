using UnityEngine;
using System;

public class Health : MonoBehaviour
{
   
    public float currentHealth { get; set; }

    public static Action OnDamage;

    private void Awake()
    {
         ApplySettings(SettingsManager.Instance.CurrentSettings);
        SettingsManager.Instance.OnSettingsChanged += ApplySettings;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
            OnDamage?.Invoke();
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
}