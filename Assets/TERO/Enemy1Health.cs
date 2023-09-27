using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    [Header("Health")]
    public float health = 100f;
    public int currentHealth;
    public int maxHealth = 100;
    public EnemyHealthSlider enemyHealthSlider;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "weapon1")
        {
            //player.TakeDamage(player.damage);

        }

    }
}
