using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MoveCursor : MonoBehaviour
{
    
    public Transform pos1, pos2, startPos;
    public float speed = 2.0f;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = startPos.position;
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            if (transform.position == pos1.position)
            {
                nextPos = pos2.position;
            }
            if (transform.position == pos2.position)
            {
                nextPos = pos1.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            GameObject.Destroy(GameObject.Find("cursor"));
        }
        
    }

}
