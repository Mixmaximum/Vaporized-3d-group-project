using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health = 10;
    [SerializeField]
    string levelToLoad;
    public float maxHealth;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    TextMeshProUGUI healthText;
    public bool healthUpgraded;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health + "/" + maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthUpgraded)
        {
            health = maxHealth;
            healthBar.fillAmount = health / maxHealth;
            healthText.text = health + "/" + maxHealth;
            healthUpgraded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //we want to take damage IF the player hits the enemy capsule
        //bool key = true;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            //health = health - 1;
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            healthText.text = health + "/" + maxHealth;
            //health--;
            //consequences for taking damage
            //If we take damage so health is below 0, reload the level
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            healthText.text = health + "/" + maxHealth;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            healthText.text = health + "/" + maxHealth;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            healthText.text = health + "/" + maxHealth;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
