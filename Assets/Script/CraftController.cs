using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class CraftController : MonoBehaviour
{
    public CraftSettings CraftSettings;


    private List<ICraftable> _items = new List<ICraftable>();
    private List<GameObject> _selected = new List<GameObject>();
    private Button _craftButton;

    public Transform UIItems;

    public bool _isCraftModeActive { get; set; }

    private void Start()
    {
        _craftButton = GetComponentInChildren<Button>();

        
        _isCraftModeActive = false;
    }
    

   
    public void EnterCraftMode()
    {
        _isCraftModeActive = !_isCraftModeActive;

        CheckCraft();

        if (_items == null)
        {
            _items = new List<ICraftable>();
        }
        _selected.Clear();

        var craftableComponents = GetComponentsInChildren<ICraftable>();
        if (craftableComponents == null || craftableComponents.Length == 0)
        {
            Debug.LogWarning("Не найдены компоненты с интерфейсом ICraftable");
            return;
        }

        _items = craftableComponents.ToList();
        Debug.Log($"Найдено крафтабельных предметов: {_items.Count}");

        foreach (var item in craftableComponents)
        {
            if (item == null) continue;

            var gameObj = ((MonoBehaviour)item).gameObject;
            var button = gameObj.GetComponent<Button>();

            if (button != null)
            {
                button.onClick.RemoveAllListeners();

                if (_isCraftModeActive)
                {
                    button.onClick.AddListener(() => Select(gameObj));
                }
            }
        }

        Debug.Log($"Режим крафта {(_isCraftModeActive ? "включен" : "выключен")}");
    }

    private void Select(GameObject obj)
    {
        if (_selected.Contains(obj))
        {
            _selected.Remove(obj);
            obj.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else
        {
            _selected.Add(obj);
            obj.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f);
        }

        CheckCombo();

    }

    private void CheckCombo()
    {
        List<string> selectedNames = new List<string>();
        foreach (var item in _selected)
        {
            var n = item.GetComponent<ICraftable>().Name;
            selectedNames.Add(n);
        }

        foreach (var combination in CraftSettings.Combinations)
        {
            if (combination.Sources.SequenceEqual(selectedNames))
            {
                Debug.Log("Match");

                foreach (var victim in _selected)
                {
                    Destroy(victim);
                }

                var newItem = Instantiate(combination.Result, UIItems);
            }
        }
    }

    private void CheckCraft()
    {

        Image _buttonColor = _craftButton.GetComponent<Image>();
        _buttonColor.color = _isCraftModeActive ? new Color(0.8f, 0.8f, 0.5f) : new Color(1f, 1f, 1f);

    }
}
