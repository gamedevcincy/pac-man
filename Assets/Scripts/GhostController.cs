using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public bool inactive;
    public float timeLeftInactive;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftInactive = 0;
        //inactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.gameObject.activeSelf)
        {
            timeLeftInactive -= Time.deltaTime;
            if (timeLeftInactive < 0)
            {
                //inactive = false;
                this.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerController playerController = col.GetComponent<PlayerController>();
            if (playerController != null && playerController.consumedPowerPellet)
            {
                this.gameObject.SetActive(false);
                //inactive = true;
                timeLeftInactive = 25;
            }
        }
    }
}
