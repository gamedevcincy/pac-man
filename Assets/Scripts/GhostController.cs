using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController playerController = col.GetComponent<PlayerController>();
            if (playerController != null && playerController.consumedPowerPellet)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
