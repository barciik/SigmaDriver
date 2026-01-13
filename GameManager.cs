using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("ScoreUp", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString(); 

    }
}
