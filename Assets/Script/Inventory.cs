using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _Inventory;
    private CraftController _craftController => GetComponentInChildren<CraftController>();

    private bool _isInventory;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_isInventory)
            {
                _isInventory = true;
                _Inventory.SetActive(true);
            }
            else
            {
                _isInventory = false;
                _craftController._isCraftModeActive = false;
                _Inventory.SetActive(false);
            }
        }
    }
}
