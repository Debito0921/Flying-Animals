using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static int Score;
    public TextMeshProUGUI TMPscore;

    [SerializeField] private AudioSource points;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        PlayerPrefs.SetInt("score", Score);
    }

    
    void AddScore()
    {
        Score++;
        TMPscore.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Destroy(other.gameObject);
        AddScore();
        points.Play(); //vfx

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "explode")
        {
            Debug.Log("Collide with explode plat");
            GameObject.Destroy(collision.gameObject);
            AddScore();
            points.Play();
        }
    }

}
