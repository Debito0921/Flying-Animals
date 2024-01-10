using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExplodePlat: MonoBehaviour
{
    public float timeLimit = 5.0f;
    public GameObject platform;
    public TextMeshProUGUI timerText;
    private bool timerStarted = false;

    private float timeRemaining;

    [SerializeField] private AudioSource countdown;
    [SerializeField] private AudioSource explode; 

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted == true)
        {
            timeRemaining -= Time.deltaTime;
            int timeText = (int)timeRemaining;
            timerText.text = timeText.ToString();
        }

        if (timeRemaining <= 0)
        {
            Debug.Log("Destroy plat");
            countdown.Stop();
            explode.Play();
            Destroy(platform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !timerStarted)
        {
            timerStarted = true;
            countdown.Play();
            //ScoreManager.();
        }
    }

}
