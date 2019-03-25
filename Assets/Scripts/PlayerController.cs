﻿using System.Collections;
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

        if (col.gameObject.tag == "SuperPellet")
        {
            consumedPowerPellet = true;
            timeLeftPower = powerPelletTime;
        }

        if (col.gameObject.tag == "Pellet")
        {
            // no special behavior
        }

        if (col.gameObject.tag == "Fruit")
        {
            // no special behavior
        }

        if (col.gameObject.tag == "Ghost")
        {
            if (consumedPowerPellet)
            {
                // no special behavior
            }
            else
            {
                // game over
            }
        }
    }
}
