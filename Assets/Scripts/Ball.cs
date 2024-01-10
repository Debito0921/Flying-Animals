using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Collider2D col;
    public static float speed;


    [HideInInspector] public Vector3 pos { get { return transform.position;  } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        speed = rb.velocity.magnitude;
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
