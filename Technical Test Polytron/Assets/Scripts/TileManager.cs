// Script TileManager
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject housePrefab;
    // Hapus treeInstantiated dari sini

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Dirt"))
                {
                    // Anda dapat memanggil fungsi di skrip DirtTile untuk menangani logika tersebut
                    DirtTile dirtTile = hit.collider.GetComponent<DirtTile>();
                    if (dirtTile != null && !dirtTile.houseInstantiated && !dirtTile.hasTreeSpawned)
                    {
                        dirtTile.InstantiateHouse(housePrefab);
                    }
                }
            }
        }
    }
}
