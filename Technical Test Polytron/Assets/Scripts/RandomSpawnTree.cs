using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnTree : MonoBehaviour
{
    public GameObject treePrefab; // Prefab pohon yang akan di-spawn.
    public float spawnInterval = 1f; // Interval waktu antara spawn pohon.

    private List<GameObject> spawnedTrees = new List<GameObject>();

    private void Start()
    {
        // Memulai coroutine untuk spawn pohon secara berkala.
        StartCoroutine(SpawnTreesPeriodically());
    }

    private IEnumerator SpawnTreesPeriodically()
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


    private bool HasTreeSpawned(GameObject dirtPrefab)
    {
        return spawnedTrees.Exists(tree => tree.transform.position == dirtPrefab.transform.position);
    }
}

