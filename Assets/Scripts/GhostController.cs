using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float timeLeftInactive;
    public bool active = true;
    private Renderer objRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftInactive = 0;
        objRenderer = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        objRenderer.enabled = active;
        if (!active)
        {
            timeLeftInactive -= Time.deltaTime;
            if (timeLeftInactive < 0)
            {
                active = true;
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
                //this.gameObject.SetActive(false);
                active = false;
                timeLeftInactive = 25;
            }
        }
    }
}
