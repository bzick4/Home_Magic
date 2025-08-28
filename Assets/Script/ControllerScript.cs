using UnityEngine;
using System.Threading.Tasks;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    [SerializeField] private Load _LoadingScreen;

    private void Start()
    {
        StartGame();
    }

    private async void StartGame()
    {
        if (_Player == null || _LoadingScreen == null)
        {
            Debug.LogError("Player or LoadingScreen not assigned!");
            return;
        }

        _Player.EnableAllScripts(false);

        await _LoadingScreen.StartLoadingAsync();

        while (_LoadingScreen._currentLoad < 112)
        {
            await Task.Delay(10);
        }

        _Player.EnableAllScripts(true);
        Debug.Log("Скрипты игрока активированы.");
    }
}