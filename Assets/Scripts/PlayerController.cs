using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;
    public bool consumedPowerPellet;
    public float timeLeftPower;
    public float powerPelletTime;

    void Start()
    {
        score = 0;
        consumedPowerPellet = false;
        timeLeftPower = 0;
        powerPelletTime = 10;
    }

    void FixedUpdate()
    {
        if (consumedPowerPellet)
        {
            timeLeftPower -= Time.deltaTime;
            if (timeLeftPower < 0)
            {
                consumedPowerPellet = false;
            }
        }
    }

    void AddScore(int points)
    {
        score += points;
    }

    void OnTriggerEnter(Collider col)
    {
        ScoreObject scoreObject = col.GetComponent<ScoreObject>();
        if (scoreObject != null)
        {
            AddScore(scoreObject.points);
            Debug.Log("Score Added");
        }

        if (col.gameObject.tag == Constants.POWER_PELLET)
        {
            consumedPowerPellet = true;
            timeLeftPower = powerPelletTime;
        }

        if (col.gameObject.tag == Constants.PELLET)
        {
            // no special behavior
        }

        if (col.gameObject.tag == Constants.FRUIT)
        {
            // no special behavior
        }

        if (col.gameObject.tag == Constants.GHOST)
        {
            if (consumedPowerPellet)
            {
                // no special behavior
            }
            else
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
        Debug.Log(col.gameObject.tag);
    }
}
