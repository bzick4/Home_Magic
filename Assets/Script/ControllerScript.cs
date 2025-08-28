using UnityEngine;
using System.Threading.Tasks;

public class ControllerScript : MonoBehaviour
{
    // [SerializeField] private GameObject _Player;
    // [SerializeField] private Load _LoadingScreen;

    // private void Start()
    // {
    //     StartGame();
    // }

    // private async void StartGame()
    // {
    //     if (_Player == null || _LoadingScreen == null)
    //     {
    //         Debug.LogError("Player or LoadingScreen not assigned!");
    //         return;
    //     }

    //     _Player.EnableAllScripts(false);

    //     await _LoadingScreen.StartLoadingAsync();

    //     while (_LoadingScreen._currentLoad < 112)
    //     {
    //         await Task.Delay(10);
    //     }

    //     _Player.EnableAllScripts(true);
    //     Debug.Log("Скрипты игрока активированы.");
    // // }

    [SerializeField] private MonoBehaviour[] _PlayerScripts;
    [SerializeField] private Load _LoadingScreen;

    private void Start()
    {
        // Отключаем все скрипты при старте
        foreach (var script in _PlayerScripts)
        {
            if (script != null)
                script.enabled = false;
        }

        _LoadingScreen.OnLoadMilestone += EnableScriptByIndex;
    }

    private void EnableScriptByIndex(int index)
    {
        if (index < 0 || index >= _PlayerScripts.Length) return;
        
        if (_PlayerScripts[index] != null)
        {
            _PlayerScripts[index].enabled = true;
            //Debug.Log($"Активирован скрипт {_PlayerScripts[index].GetType().Name}");
        }
    }

    private void OnDestroy()
    {
        if (_LoadingScreen != null)
            _LoadingScreen.OnLoadMilestone -= EnableScriptByIndex;
    }



}