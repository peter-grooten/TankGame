using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletTtl = 5;
    [SerializeField]
    GameObject particleToSpawn;
    [SerializeField]
    Transform particleSpawnPoint;
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Speler1")
        {
            Debug.Log("hit");
            GameObject.Find("Canvas").GetComponent<ScoreManager>().AddP2Score();
        }
        if (collision.gameObject.name == "Speler2")
        {
            Debug.Log("hit");
            GameObject.Find("Canvas").GetComponent<ScoreManager>().AddP1Score();
        }
        ParticleSpawner();
        Destroy(gameObject);
    }
    public void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}
