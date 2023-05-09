using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public PlayerController playerController;
    int previousHeadBumpCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PassiveScore", 0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.headBumpCount != previousHeadBumpCount)
        {
            score++;
            previousHeadBumpCount = playerController.headBumpCount;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    void PassiveScore()
    {
        score += 10;
    }
}
