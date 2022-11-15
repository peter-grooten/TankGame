using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class JetSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject jetPrefab;
    private float generatedSpawnTimer = 0f;

    public void JetSpawnTimer()
    {
       // generatedSpawnTimer = Random.Range(2, 5);
        Invoke("JetSpawner", generatedSpawnTimer);
    }
    private void JetSpawner()
    {
        Instantiate(jetPrefab);
    }
}
