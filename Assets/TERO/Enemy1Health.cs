using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy1Health : MonoBehaviour
{
    [Header("Health")]
    public float health = 100f;
    public int damage = 20;
    public int currentHealth;
    public int maxHealth = 100;
    public EnemyHealthSlider enemyHealthSlider;
    public GameObject player;
    public GameObject enemyHitBox;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        enemyHealthSlider.SetMaxHealth(maxHealth);
        enemyHitBox = GameObject.Find("enemyHitBox").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemyHealthSlider.SetHealth(currentHealth);
        //healthbar.SetMaxHealth(currentHealth);
        //GetComponent<BossHealthScript>().SetMaxHealth(currentHealth);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "weapon1")
        {
           TakeDamage(damage);

        }

    }
}
