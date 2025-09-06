using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftSettings", menuName = "Game/Craft Settings")]
public class CraftSettings : ScriptableObject
{
    public List<CraftCombination> Combinations;
}

[Serializable]
public class CraftCombination
{
    public List<string> Sources;
    public GameObject Result;
}
