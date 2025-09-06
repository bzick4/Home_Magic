using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterData : MonoBehaviour
{

    public GameObject InventoryUIRoot;

    public List<MonoBehaviour> LevelUpAction;
    private int _currentLevel = 1;
    private int _score = 0;
    private int _scoreToNextLevel = 20;

    private List<IItem> _item;

    

    public void Score(int scoreAmount)
    {
        _score += scoreAmount;
        if (_score >= _scoreToNextLevel)
            LevelUp();
    }

    public void LevelUp()
    {
        _currentLevel++;
        _scoreToNextLevel *= 2;
        foreach (var action in LevelUpAction)
        {
            if (!(action is ILevelUp levelUp)) return;
            levelUp.LevelUp(this, _currentLevel);
        }
    }
}
