using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertTile : MonoBehaviour
{
    public bool houseInstantiated = false;

    public void InstantiateHouse(GameObject housePrefab)
    {
        Vector3 centerPosition = GetComponent<Collider>().bounds.center;
        Instantiate(housePrefab, centerPosition, Quaternion.Euler(0, -90, 0));
        houseInstantiated = true;
    }
}
