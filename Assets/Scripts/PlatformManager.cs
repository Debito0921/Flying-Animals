using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformManager : MonoBehaviour
{
    private const float PLAYER_DIST_SPAWN_PLAT = 15f;
    [SerializeField] private Transform platform_start;
    [SerializeField] private List <Transform> platformList;
    public List<GameObject> initialPlatform;
    private Queue<GameObject> platformQueue = new Queue<GameObject>();
   
    [SerializeField] private Ball ball;
    public Transform lastPlatformTransform;
    public bool isLeft = true;

    public GameObject GameOverBlock;

    private Vector3 lastEndPosition;
    private void Start()
    {
        lastEndPosition = platform_start.Find("TouchPosition").position;

        foreach (GameObject g in initialPlatform)
        {
            platformQueue.Enqueue(g);
        }

        int startingSpawn = 15;
        for (int i = 0; i < startingSpawn; i++)
        {
            SpawnPlatform();

        }


        
    }

    private void Update()
    {
        

        if (Vector3.Distance(ball.GetPosition(), lastEndPosition) < PLAYER_DIST_SPAWN_PLAT)
        {
            SpawnPlatform();
        }

        
    }

    private void SpawnPlatform()
    {
        float xLast = lastPlatformTransform.position.x;
        int random = (int)Random.Range(0f, 10f);
        float randomY = Random.Range(6.0f, 8.5f);
        lastEndPosition = new Vector3 (lastEndPosition.x, lastEndPosition.y + 3.5f, lastEndPosition.z);
        Transform chosenPlatform = platformList[Random.Range(0, platformList.Count)];

        if (isLeft)
        {
            
            xLast -= Random.Range(6.0f, 20.0f);
            
            isLeft = false;
        }
        else
        {
            
            xLast += Random.Range(6.0f, 20.0f);
            
            isLeft = true;
        }
        
 
        xLast = Mathf.Clamp(xLast, -11f, -1.2f);
        lastPlatformTransform = SpawnPlatform(chosenPlatform, new Vector3(xLast, lastPlatformTransform.position.y + randomY, 0 ));
        lastEndPosition = lastPlatformTransform.Find("TouchPosition").position;
    }

    private Transform SpawnPlatform(Transform platformList, Vector3 spawnPosition)
    {
        Transform platformTransform = Instantiate(platformList, spawnPosition, Quaternion.identity, GameObject.Find("Game Environment").transform);
        platformQueue.Enqueue(platformTransform.gameObject);
        return platformTransform;
    }

    public void DestroyPlatform()
    {
        if (platformQueue.Count > 10)
        {
            GameObject.Destroy(platformQueue.Dequeue());
        }
    }
    

    public Vector3 GetPosition() { return transform.position; }
}
