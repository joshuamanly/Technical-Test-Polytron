using System.Collections;
using UnityEngine;

public class RandomSpawnTree : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab; 
    [SerializeField] private float spawnInterval = 1f;
    private int dirtCount;
    private int plantedTreeCount = 0;
    public void SpawnTreesPeriodically()
    {
        StartCoroutine(SpawnTrees());
    }

    private IEnumerator SpawnTrees()
    {
        dirtCount = GameObject.FindGameObjectsWithTag("Dirt").Length;
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); 
            GameObject[] dirtPrefabs = GameObject.FindGameObjectsWithTag("Dirt");

            if (dirtPrefabs.Length >= 0)
            {
                GameObject randomDirtPrefab = dirtPrefabs[Random.Range(0, dirtPrefabs.Length)];
                DirtTile dirtTile = randomDirtPrefab.GetComponent<DirtTile>();

                if (dirtTile != null && !dirtTile.hasTreeSpawned && !dirtTile.houseInstantiated)
                {         
                    Collider dirtCollider = randomDirtPrefab.GetComponent<Collider>();
                    Vector3 centerPosition = dirtCollider.bounds.center;

                    Instantiate(treePrefab, centerPosition, Quaternion.identity);

                    dirtTile.hasTreeSpawned = true;
                    plantedTreeCount++;

                    if (plantedTreeCount >= dirtCount)
                    {
                        Debug.Log("Tree is finished planting");
                    }
                }
            }
            
        }
    }
}

