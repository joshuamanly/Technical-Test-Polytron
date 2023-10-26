using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratedMap : MonoBehaviour
{
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;
    [SerializeField] private GameObject[] tilePrefabs;
    private void Start()
    {
        MakeMapGrid();
    }

    void MakeMapGrid()
    {
        for(int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                Vector3 position = new Vector3(x, 0, z);

                int randomTileIndex = Random.Range(0, tilePrefabs.Length);
                GameObject randomTilePrefab = tilePrefabs[randomTileIndex];

                // Instantiate the random tile prefab at the current position
                Instantiate(randomTilePrefab, position, Quaternion.identity);
            }
        }
        
    }
}

