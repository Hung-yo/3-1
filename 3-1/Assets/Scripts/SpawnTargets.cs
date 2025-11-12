using UnityEngine;
using time = UnityEngine.Time;

public class SpawnTargets : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject ufoPrefab;
    public float screenDimensionX;
    public float screenDimensionY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenDimensionX = Camera.main.orthographicSize * Camera.main.aspect;
        screenDimensionY = Camera.main.orthographicSize;
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
                float spawnPosX;
                float spawnPosY;

                float spawnArea = Random.Range(1, 4);
                if (spawnArea == 1)
                {
                    // Spawn in the top area
                    spawnPosX = Random.Range(-screenDimensionX, screenDimensionX);
                    spawnPosY = screenDimensionY + 1f;
                }
                else if (spawnArea == 2)
                {
                    // Spawn in the bottom area
                    spawnPosX = Random.Range(-screenDimensionX, screenDimensionX);
                    spawnPosY = -screenDimensionY - 1f;
                }
                else if (spawnArea == 3)
                {
                    // Spawn in the left area
                    spawnPosX = -screenDimensionX - 1f;
                    spawnPosY = Random.Range(-screenDimensionY, screenDimensionY);
                }
                else
                {
                    // Spawn in the right area
                    spawnPosX = screenDimensionX + 1f;
                    spawnPosY = Random.Range(-screenDimensionY, screenDimensionY);
                }

                Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0f);

                float target = Random.Range(0f, 1f);
                if (target < .5f)
                {
                    Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(ufoPrefab, spawnPosition, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
