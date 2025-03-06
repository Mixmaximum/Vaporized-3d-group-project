using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class UpgradeHUD : MonoBehaviour
{
    [SerializeField] float healthUpgradeAmount;
    [SerializeField] float speedUpgradeAmount;
    [SerializeField] float damageUpgradeAmount;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {
        player.GetComponent<PlayerHealth>().health += healthUpgradeAmount;
        player.GetComponent<PlayerHealth>().maxHealth += healthUpgradeAmount;
        player.GetComponent<PlayerHealth>().healthUpgraded = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
    }

    public void Speed()
    {
        player.GetComponent<ThirdPersonController>().MoveSpeed += speedUpgradeAmount;
        player.GetComponent<ThirdPersonController>().SprintSpeed += speedUpgradeAmount;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
    }

    public void Damage()
    {
        player.GetComponent<RaycastShoot>().UpdateDamage(damageUpgradeAmount);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
    }
}
