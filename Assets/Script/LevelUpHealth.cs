using UnityEngine;

public class LevelUpHealth : MonoBehaviour, ILevelUp
{

    private Health _health=>GetComponent<Health>();

    public void LevelUp(CharacterData data, int level)
    {
        if(_health == null)
        {
            if(_health == null) return;
        }

        _health.currentHealth +=50;
    }
}
