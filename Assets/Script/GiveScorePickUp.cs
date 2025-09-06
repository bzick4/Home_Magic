using UnityEngine;

public class GiveScorePickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int _randomBonus= Random.Range(15,35);

        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<CharacterData>() != null)
            {
                CharacterData _data = other.GetComponent<CharacterData>();


                _data.Score(_randomBonus);
                Destroy(gameObject);
            }

        }

    }
    
}
