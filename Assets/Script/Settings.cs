using UnityEngine;

[CreateAssetMenu(fileName = "HeroSettings", menuName = "Game/Hero Settings")]
public class Settings : ScriptableObject
{
    [Header("Hero Stats")]
    public float _HeroHealth;
    public float _HeroSpeedWalk;
    public float _HeroSpeedRun;

    [Header("Configuration Info")]
    public string ConfigurationName;
}
