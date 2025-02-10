using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float health = 2;
    Image healthBar;
    float maxHealth;
    private GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = health / maxHealth;
        hud = GameObject.FindGameObjectWithTag("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            hud.GetComponent<PlayerScore>().score++;
            Destroy(gameObject);
        }
    }
}
