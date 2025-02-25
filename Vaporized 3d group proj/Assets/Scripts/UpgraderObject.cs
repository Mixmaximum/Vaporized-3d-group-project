using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class UpgraderObject : MonoBehaviour
{
    [SerializeField] public float cost;
    [SerializeField] private float costMultiplier;
    private TextMeshProUGUI costText;
    private GameObject upgradeHUD;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = "Cost: " + cost;
        upgradeHUD = GameObject.FindGameObjectWithTag("UpgradeHUD");
        upgradeHUD.GetComponent<Canvas>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        upgradeHUD.GetComponent<Canvas>().enabled = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = true;
        cost = cost *= costMultiplier;
        costText.text = "Cost: " + cost;
    }
}
