
using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab1;
    public GameObject columnPrefab2;
    private int columnPoolSize = 5;
    private float spawnRate = 1.75f;
    private float columnMin = 0.06f;
    private float columnMax = 3.35f;

    protected GameObject[] columns;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2(5f, 0f);
    private float spawnXPosition = 5f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;


        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
        {      
            columns[i] = (GameObject)Instantiate(columnPrefab1, objectPoolPosition, Quaternion.identity);     
        }
    }



    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            if (GameControl.instance.score % 5 == 0) spawnRate -= 0.1f;

            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            int randomNumber = Random.Range(0, 6);
            if(randomNumber > 4)
            {
                Destroy(columns[currentColumn]);
                columns[currentColumn] = (GameObject)Instantiate(columnPrefab2, new Vector2(spawnXPosition, spawnYPosition), Quaternion.identity);
            }
            else
            {
                Destroy(columns[currentColumn]);
                columns[currentColumn] = (GameObject)Instantiate(columnPrefab1, new Vector2(spawnXPosition, spawnYPosition), Quaternion.identity);
            }


            
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}