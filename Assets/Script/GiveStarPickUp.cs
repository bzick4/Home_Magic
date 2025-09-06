using UnityEngine;

public class GiveStarPickUp : MonoBehaviour, IItem
{

    [SerializeField] private GameObject _UIItem;
    public GameObject UIItem => _UIItem; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterData>() != null)
            {
                CharacterData _data = other.GetComponent<CharacterData>();

                if (_data == null) return;

                var item = Object.Instantiate(UIItem, _data.InventoryUIRoot.transform, false);
            
                Destroy(this.gameObject);
            }

        }

    }
    
}
