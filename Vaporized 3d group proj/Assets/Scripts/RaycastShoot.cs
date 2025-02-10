using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    [SerializeField] LayerMask layers;
    [SerializeField] private float shootDist = 10;
    [SerializeField] private float shootDelay = 0.5f;
    private bool buttonDown;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (buttonDown && shootTimer >= shootDelay)
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, shootDist, layers))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                }
                shootTimer = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            buttonDown = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            buttonDown = false;
        }
    }
}
