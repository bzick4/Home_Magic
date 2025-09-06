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

    public Transform UIItems;

    public void EnterCraftMode()
    {
        _selected.Clear();
        _items = GetComponentsInChildren<ICraftable>().ToList();
        Debug.Log(_items.Count);

        foreach (var item in _items)
        {
            var button = ((MonoBehaviour)item)?.gameObject.AddComponent<Button>();
            button.onClick.AddListener( () => { Select(button.gameObject); });
        }
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
}
