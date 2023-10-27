using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneratedMap : MonoBehaviour
{
    [SerializeField] private int mapWidth = 8;
    [SerializeField] private int mapHeight = 8;
    [SerializeField] private GameObject[] tilePrefabs; 
    

    private void Start()
    {
        MakeMapGrid();
    }

    void MakeMapGrid()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                Vector3 position = new Vector3(x + 1, 0, z + 1);

                int randomTileIndex = Random.Range(0, tilePrefabs.Length);
                GameObject randomTilePrefab = tilePrefabs[randomTileIndex];

                
                Instantiate(randomTilePrefab, position, Quaternion.identity);
                
            }
        }
    }
}
