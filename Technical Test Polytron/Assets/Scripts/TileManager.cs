using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject housePrefab;
    // Hapus treeInstantiated dari sini

    void Update()
    {
        OnClick();
    }

    private void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Dirt"))
                {             
                    DirtTile dirtTile = hit.collider.GetComponent<DirtTile>();
                    if (dirtTile != null && !dirtTile.houseInstantiated && !dirtTile.hasTreeSpawned)
                    {
                        dirtTile.InstantiateHouse(housePrefab);
                        GameManager.Instance.score.AddScore(10);
                    }
                }
                if (hit.collider.CompareTag("Desert"))
                {           
                    DesertTile desertTIle = hit.collider.GetComponent<DesertTile>();
                    if (desertTIle != null && !desertTIle.houseInstantiated)
                    {
                        desertTIle.InstantiateHouse(housePrefab);
                        GameManager.Instance.score.AddScore(2);
                    }
                }
            }
        }
    }
}
