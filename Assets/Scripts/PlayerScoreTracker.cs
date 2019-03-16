using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreTracker : MonoBehaviour
{
    public int score;

    void Start()
    {
        score = 0;
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
        }
    }
}
