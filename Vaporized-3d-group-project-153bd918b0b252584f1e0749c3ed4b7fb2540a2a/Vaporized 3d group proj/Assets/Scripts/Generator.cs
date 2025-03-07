using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] float maxCharge;
    [SerializeField] float enemyDamage = 0.1f;
    [SerializeField] GameObject fakeCore;
    [SerializeField] GameObject chargedCore;
    [SerializeField] Image chargebar;
    float currentCharge;
    public bool isCharging;
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
            chargedCore.SetActive(false);
            currentCharge += Time.deltaTime;
            chargebar.fillAmount = currentCharge / maxCharge;
            if (currentCharge >= maxCharge)
            {
                fakeCore.SetActive(false);
                chargedCore.SetActive(true); 
                isCharging = false;
                currentCharge = 0;
            }
       }
    }

    public void Charge()
    {
        isCharging = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && isCharging && currentCharge >= 0)
        {
            currentCharge -= enemyDamage;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && isCharging && currentCharge >= 0)
        {
            currentCharge -= enemyDamage;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isCharging && currentCharge >= 0)
        {
            currentCharge -= enemyDamage;
        }
    }
}
