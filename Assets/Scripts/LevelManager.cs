using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    Camera cam;

    public Ball[] ball;
    private Ball defaultball;
    public Trajectory trajectory;
    private float threshold = 0.3f;

    [SerializeField] float PushForce = 10f;

    [SerializeField] private AudioSource poof;
    bool isDragging;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Ball.speed <= threshold)
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                defaultball = null;
                for (int i = 0; i < ball.Length; i++)
                {
                    Time.timeScale = 1f;
                    isDragging = true;
                    defaultball = ball[i];
                    OnDragStart();

                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                poof.Play();
                if (defaultball != null)
                {
                    Time.timeScale = 1f;
                    isDragging = false;
                    OnDragEnd();
                }
            }

            if (isDragging)
            {
                OnDrag();
            }
        }
    }




    ///Dragging
    private void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();

    }
    private void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = distance * direction * PushForce;

        trajectory.UpdateDots(defaultball.pos, force);
    }
    private void OnDragEnd()
    {
        defaultball.Push(force);
        trajectory.Hide();
    }

}
