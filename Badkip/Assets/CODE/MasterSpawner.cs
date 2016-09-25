using UnityEngine;

public class MasterSpawner : MonoBehaviour {
    public SpawnerData[] spawndata;
}


[System.Serializable]
public class SpawnerData {
    public GameObject[] objectsToSpawn;
}
