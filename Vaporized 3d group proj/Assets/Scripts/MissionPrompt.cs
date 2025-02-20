using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionPrompt : MonoBehaviour
{
    private GameObject hud;
    private GameObject pauseMenu;
    private TextMeshProUGUI hudMissionPrompt;
    private TextMeshProUGUI pauseMissionPrompt;
    private HUDManager hudManager;
    [SerializeField] float popUpTime;
    float popUpTime2;
    private float timer;
    private float timer2;
    [Space(5)]

    [Header("Pop Up Texts")]
    [SerializeField] string zeroCoresMissionPopUp;
    [SerializeField] string zeroCoresPausePopUp;
    [SerializeField] string allCoresMissionPopUp;
    [SerializeField] string allCoresPausePopUp;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        hudMissionPrompt = hud.GetComponentsInChildren<TextMeshProUGUI>()[0];
        pauseMissionPrompt = pauseMenu.GetComponentsInChildren<TextMeshProUGUI>()[0];
        hudManager = hud.GetComponent<HUDManager>();
        popUpTime2 = popUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        HudUpdater();
        PauseUpdater();
    }
    void HudUpdater()
    {
        if (hudManager.cores <= 0 && timer <= popUpTime)
        {
            hudMissionPrompt.text = (zeroCoresMissionPopUp);
            timer += Time.deltaTime;
        }
        else if (hudManager.cores == hudManager.maxCores && timer2 <= popUpTime2)
        {
            hudMissionPrompt.text = (allCoresMissionPopUp);
            timer2 += Time.deltaTime;
        }
        else
        {
            hudMissionPrompt.text = (" ");
        }
    }
    void PauseUpdater()
    {
        if (hudManager.cores <= 0)
        {
            pauseMissionPrompt.text = (zeroCoresPausePopUp);
        }
        else if (hudManager.cores == hudManager.maxCores)
        {
            pauseMissionPrompt.text = (allCoresPausePopUp);
        }
    }
}
