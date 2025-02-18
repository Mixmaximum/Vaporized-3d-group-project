using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    public float score = 0;
    [SerializeField] private TextMeshProUGUI scorePopUp;
    [SerializeField] public int cores;
    [SerializeField] private TextMeshProUGUI corePopUp;
    [SerializeField] private TextMeshProUGUI coreHoldingPopUp;
    int maxCores;
    public bool holdingCore;
    // Start is called before the first frame update
    void Start()
    {
        maxCores = cores;
        cores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        corePopUp.text = "Cores: " + cores + "/" + maxCores;
        scorePopUp.text = "Score: " + score;
        if (holdingCore)
        {
            coreHoldingPopUp.text = "Holding Core";
        }
        else
        {
            coreHoldingPopUp.text = " ";
        }
    }
}
