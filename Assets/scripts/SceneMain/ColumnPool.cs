using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public float spawnRate = 4f;
    public int columnPoolSize = 5;
    public float columnYmin = 0f;
    public float columnYmax = 3.6f;

    private float timeSinceLastSpawn;
    private float spawnXPos = 18f;
    private int currentColumn = 0;

    public GameObject columnsPrefab;
    private GameObject[] columns;
    private Vector2 objectPoolPostion = new Vector2(-15, -25f);
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i=0; i<columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnsPrefab, objectPoolPostion, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (!Player.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;

            float spamYPos = Random.Range(columnYmin, columnYmax);
            columns[currentColumn].transform.position = new Vector2(spawnXPos, spamYPos);

            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
