using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastInteract : MonoBehaviour
{
    [SerializeField] float interactRange = 4;
    [SerializeField] LayerMask layers;
    [SerializeField] TextMeshProUGUI interactText;
    // Start is called before the first frame update
    void Start()
    {
        interactText.enabled = false;
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
                //we know we hit an interactable object so we trigger the interact trigger
                interactText.enabled = true;
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }
}
