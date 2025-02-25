using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Exfil : MonoBehaviour
{
    [SerializeField] string teleportLocation = "Win";
    [SerializeField] private float exfilTime;
    [SerializeField] private TextMeshProUGUI countDownText;
    private GameObject hud;
    private HUDManager hudManager;
    private BoxCollider boxCollider;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        hudManager = hud.GetComponent<HUDManager>();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        countDownText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hudManager.coresDone && boxCollider.enabled == false)
        {
            boxCollider.enabled = true;
            countDownText.enabled = true;
            timer = exfilTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(timer / 60);
                int seconds = Mathf.FloorToInt(timer % 60);
                countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            if (timer <= 0)
            {
                SceneManager.LoadScene(teleportLocation);
            }
        }
    }
}
