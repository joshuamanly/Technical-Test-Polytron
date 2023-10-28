using System.Collections;
using UnityEngine;

public class RandomSpawnTree : MonoBehaviour
{
    public GameObject treePrefab; 
    [SerializeField] private float spawnInterval = 1f; 

    public void SpawnTreesPeriodically()
    {
        StartCoroutine(SpawnTrees());
    }

    private IEnumerator SpawnTrees()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Mengambil semua objek dengan tag "Dirt".
            GameObject[] dirtPrefabs = GameObject.FindGameObjectsWithTag("Dirt");

            if (dirtPrefabs.Length > 0)
            {
                // Pilih secara acak prefab "Dirt".
                GameObject randomDirtPrefab = dirtPrefabs[Random.Range(0, dirtPrefabs.Length)];

                DirtTile dirtTile = randomDirtPrefab.GetComponent<DirtTile>();

                if (dirtTile != null && !dirtTile.hasTreeSpawned && !dirtTile.houseInstantiated)
                {
                    // Hitung posisi tengah collider "Dirt" yang terpilih.
                    Collider dirtCollider = randomDirtPrefab.GetComponent<Collider>();
                    Vector3 centerPosition = dirtCollider.bounds.center;

                    // Instantiate prefab pohon di tengah collider "Dirt."
                    GameObject spawnedTree = Instantiate(treePrefab, centerPosition, Quaternion.identity);

                    // Set status "Dirt" telah memiliki pohon yang di-spawn.
                    dirtTile.hasTreeSpawned = true;
                }
            }
        }
    }
}

