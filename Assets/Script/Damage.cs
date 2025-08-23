using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Health>() != null)
        {
            Health health = other.GetComponent<Health>();

            if (other.CompareTag("Player"))
            {
                Debug.Log("Damage =" + damage);
                health.TakeDamage(damage);
            }
        }
    }
}