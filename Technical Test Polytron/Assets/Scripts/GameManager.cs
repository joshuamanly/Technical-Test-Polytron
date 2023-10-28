using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Score score;
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        GetComponent<RandomSpawnTree>().SpawnTreesPeriodically();
    }
}
