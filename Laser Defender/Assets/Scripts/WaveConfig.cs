using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [field: SerializeField] public GameObject EnemyPrefab { get; private set; }
    [field: SerializeField] public GameObject PathPrefab { get; private set; }
    [field: SerializeField] public float TimeBetweenSpawns { get; private set; }
    [field: SerializeField] public float SpawnRandomFactor { get; private set; }
    [field: SerializeField] public int NumberOfEnemies { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }


    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in PathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    } 
}
