using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectCosts : MonoBehaviour
{
    [SerializeField] float cost;
    private TextMeshProUGUI costText;
    // Start is called before the first frame update
    void Start()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = "Cost: " + cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
