using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Exfil : MonoBehaviour
{
    [SerializeField] private float exfilTime;
    [SerializeField] private TextMeshProUGUI countDownText;
    private GameObject hud;
    private HUDManager hudManager;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD");
        hudManager = hud.GetComponent<HUDManager>();
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
        countDownText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hudManager.coresDone)
        {
            boxCollider.enabled = true;
            meshRenderer.enabled = true;
            countDownText.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (timer < exfilTime)
        {
            timer += Time.deltaTime;
        }
    }
}
