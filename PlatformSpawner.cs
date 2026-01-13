using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject bridge;
    public float bridgelength;
    public float spawnRate;

    public GameObject[] obstacles;
    public float obstaclePosition;


    public Transform lastBridge;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = lastBridge.transform.position;
        newPos = lastPosition;

        StartCoroutine(SpawnBridges());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBridges()
    {
        while (!stop)
        {
            newPos.z += bridgelength;
            GameObject b = Instantiate(bridge, newPos, bridge.transform.rotation);

            yield return new WaitForSeconds(spawnRate);

            if (Random.Range(0, 3) < 2) {

                GameObject o = SpawnObstacle();
                o.transform.SetParent(b.transform);

            }



            //lastPosition = newPos;
        }



    }

    GameObject SpawnObstacle() {

        GameObject obstacle = obstacles[Random.Range(0,obstacles.Length)];
        float obstacleXPos;
        int leftRight = Random.Range(0, 2);
        if(leftRight == 0)
        {
            obstacleXPos = -obstaclePosition;
        }
        else
        {
            obstacleXPos = obstaclePosition;
        }

        Vector3 spawnPos = obstacle.transform.position;
        spawnPos.z = newPos.z;
        spawnPos.x = obstacleXPos;

        GameObject o = Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        return o;
    }


}
