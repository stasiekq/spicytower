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
    int previousTouchingPlayer = 0;
    int prevE = 0;
    int prevZ = 0;
    int prevR = 0;


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
        if(EnemyController.touchingPlayer != previousTouchingPlayer)
        {
            previousTouchingPlayer = EnemyController.touchingPlayer;
            score /= 2;
        }
        if(playerController.zFound != prevZ)
        {
            prevZ = playerController.zFound;
            score += 10;
        }
        if(playerController.eFound != prevE)
        {
            prevE = playerController.eFound;
            score += 50;
        }
        if(playerController.rFound != prevR)
        {
            prevR = playerController.rFound;
            score *= 2;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    void PassiveScore()
    {
        score += 10;
    }
}
