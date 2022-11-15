using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;
    void Start()
    {
        Invoke("JetDestroyer", 7);
    }
    void Update()
    {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void JetDestroyer()
    {
        Destroy(gameObject);
    }
}