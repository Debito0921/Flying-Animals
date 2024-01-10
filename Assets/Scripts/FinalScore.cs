using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        finalScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
