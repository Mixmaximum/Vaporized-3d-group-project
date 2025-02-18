using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] float maxCharge;
    [SerializeField] GameObject fakeCore;
    [SerializeField] GameObject chargedCore;
    [SerializeField] Image chargebar;
    float currentCharge;
    public bool isCharging;
    bool charged;
    // Start is called before the first frame update
    void Start()
    {
        fakeCore.SetActive(false);
        chargedCore.SetActive(false);
        currentCharge = 0;
        chargebar = GetComponentsInChildren<Image>()[1];
        chargebar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if (isCharging)
       {
            fakeCore.SetActive(true);
            currentCharge += Time.deltaTime;
            chargebar.fillAmount = currentCharge / maxCharge;
            if (currentCharge >= maxCharge)
            {
                isCharging = false;
            }
       }
       if (charged)
       {

       }
    }

    public void Charge()
    {
        fakeCore.SetActive(true);
        isCharging = true;
    }
}
