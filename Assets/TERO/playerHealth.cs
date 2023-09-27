using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [Header("Health")]
    public float health = 100f;
    public int currentHealth;
    public int damage = 20;
    public int maxHealth = 100;
    public int bHealth;
    public HealthSlider healthSlider;
    public GameObject enemy;
    public GameObject player;
    public GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        hitBox = GameObject.Find("hitBox").gameObject;
        healthSlider = Slider.FindAnyObjectByType<HealthSlider>();
        enemy = GameObject.FindWithTag("Enemy1");
        player = GameObject.FindWithTag("Player");
        //hitBox.SetActive(false);
        currentHealth = maxHealth;
        healthSlider.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            //Instantiate(gM.explosion, gM.player.transform.position, transform.rotation);
            Destroy(player);

        }


    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthSlider.SetHealth(currentHealth);
        //healthbar.SetMaxHealth(currentHealth);
        //GetComponent<BossHealthScript>().SetMaxHealth(currentHealth);

    }

    void HealthPickup(int bHealth)
    {
        currentHealth += bHealth;

        healthSlider.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {



        if (hitBox.activeSelf)
        {
            if (other.tag == "Enemy1")
            {
               //TakeDamage(damage);

            }

            if (other.tag == "EnemyWeapon")
            {
                TakeDamage(damage);

            }

            if (other.tag == "Enemy2")
            {
                TakeDamage(damage);

            }

            if (other.tag == "Enemy3")
            {
                TakeDamage(damage);

            }
        }

    }
}

