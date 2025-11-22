using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using time = UnityEngine.Time;

public class SpawnTargets : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject ufoPrefab;
    public List<Vector3> coordinateList;
    public int spawnpointAmount;
    public int obstacleSpawnDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coordinateList = new List<Vector3>();

        // Add all objects called SpawnPoint to list spawnPoints
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("ObstacleSpawnPoint"))
        {
            coordinateList.Add(point.transform.position);
            spawnpointAmount++;
        }
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }

    System.Collections.IEnumerator SpawnTarget()
    {
        while (true)
        {
            if (GameManager.isPaused == false && GameManager.gameOver == false && GameManager.isGameStarted == true)
            {

                int spawnIndex = Random.Range(0, spawnpointAmount);
                Vector3 spawnPosition = coordinateList[spawnIndex];

                float target = Random.Range(0f, 1f);
                if (target < .5f)
                {
                    // Meteor prefab not ready yet.
                    // Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
                    Instantiate(ufoPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(ufoPrefab, spawnPosition, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(obstacleSpawnDelay);
        }
    }
}
