using UnityEngine;

public class DirtTile : MonoBehaviour
{
    public bool hasTreeSpawned = false;
    public bool houseInstantiated = false; 

    public void InstantiateHouse(GameObject housePrefab)
    {
       
        Vector3 centerPosition = GetComponent<Collider>().bounds.center;

         
        Instantiate(housePrefab, centerPosition, Quaternion.Euler(0,-90,0));
        
     
        houseInstantiated = true;
    }
}
