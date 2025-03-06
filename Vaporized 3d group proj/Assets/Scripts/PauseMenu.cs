using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject player;
    private GameObject upgradeHUD;
    private GameObject hud;
    private GameObject upgrader;
    private GameObject[] core;
    private GameObject[] interactable;
    // Use this for initialization
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        upgradeHUD = GameObject.FindGameObjectWithTag("UpgradeHUD");
        hud = GameObject.FindGameObjectWithTag("HUD");
        upgrader = GameObject.FindGameObjectWithTag("Upgrader");
        core = GameObject.FindGameObjectsWithTag("Core");
        interactable = GameObject.FindGameObjectsWithTag("Interactable");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            GetComponent<Canvas>().enabled = true;
            player.GetComponent<ThirdPersonController>().LockCameraPosition = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Resume();
            
        }

    }

    public void Resume()
    {
        if (upgradeHUD.GetComponent<Canvas>().enabled == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GetComponent<Canvas>().enabled = false;
            player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSave()
    {
        player.GetComponent<PLayerSaveData>().Load();
        hud.GetComponent<HUDSaveData>().Load();
        upgrader.GetComponent<UpgraderSaveData>().Load();
        for (int i = 0; i < core.Length; i++)
        {
            core[i].GetComponent<CoresSaveData>().Load();
        }
        for (int i = 0; i < interactable.Length; i++)
        {
            interactable[i].GetComponent<InteractableSaveData>().Load();
        }
    }
}
