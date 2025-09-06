using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _Inventory;
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
                _Inventory.SetActive(false);
            }
        }
    }
}
