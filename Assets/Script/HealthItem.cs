using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, ICraftable
{

    
    private Health health;
    [SerializeField] private string _Name = "";

    public string Name => _Name;


    public void Heal()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
            health.TakeDamage(-40);
            // health.currentHealth = +40;


            Destroy(this.gameObject);
        }

    }

    public void ExtraHeal()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
            health.TakeDamage(-80);
            // health.currentHealth = +40;


            Destroy(this.gameObject);
        }

    }
}
