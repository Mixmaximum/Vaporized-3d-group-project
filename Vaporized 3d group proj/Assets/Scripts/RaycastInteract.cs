using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class RaycastInteract : MonoBehaviour
{
    [SerializeField] float interactRange = 4;
    [SerializeField] LayerMask layers;
    [SerializeField] TextMeshProUGUI interactText;
    private GameObject hud;
    float cost;
    float score;
    HUDManager playerScore;
    // Start is called before the first frame update
    void Start()
    {
        interactText.enabled = false;
        hud = GameObject.FindGameObjectWithTag("HUD");
        playerScore = hud.GetComponent<HUDManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, interactRange, layers))
        {
            if (hit.collider.gameObject.tag == "Interactable")
            {
                interactText.enabled = true; // makes interact text pop up
                cost = hit.collider.gameObject.GetComponent<ObjectCosts>().cost;
                score = playerScore.score; // Get the score from the hud and make it a float, keep that updated
                score = playerScore.score; // Get the score from the hud and make it a float, keep that updated
                if (score >= cost && Input.GetKeyDown(KeyCode.E))
                {
                    playerScore.score -= cost; //subtract the cost from the score on the hud
                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Interact");
                    //we know we hit an interactable object so we trigger the interact trigger
                    hit.collider.gameObject.GetComponent<ObjectCosts>().purchased = true;
                    // sets it to bought
                    Debug.Log("Bought");
                }
            }
            if (hit.collider.gameObject.tag == "Core" && playerScore.holdingCore == false)
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                    playerScore.holdingCore = true;
                }
            }
            if (hit.collider.gameObject.tag == "Generator" && playerScore.holdingCore == true && hit.collider.GetComponent<Generator>().isCharging == false)
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Generator>().isCharging = true;
                    playerScore.holdingCore = false;
                }
            }
            if (hit.collider.gameObject.tag == "ChargedCore")
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    playerScore.cores++;
                }

            }
        }
        else
        {
            interactText.enabled = false;
        }
    }
   
}
