using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;
    public bool consumedSuperPellet;
    public float timeLeftSuper;

    void Start()
    {
        score = 0;
        consumedSuperPellet = false;
        timeLeftSuper = 0;
    }

    void FixedUpdate()
    {
        if (consumedSuperPellet)
        {
            timeLeftSuper -= Time.deltaTime;
            if (timeLeftSuper < 0)
            {
                consumedSuperPellet = false;
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
            consumedSuperPellet = true;
            timeLeftSuper = 5;
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
            if (consumedSuperPellet)
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
