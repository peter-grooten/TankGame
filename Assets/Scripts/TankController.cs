using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bulletToFire;
    float bulletPower = 15f;
    public int spelerNummer;
    bool isAanDeBeurt = false;
    float dirX = 0f;
    float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isAanDeBeurt)
        {
            dirX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
                Invoke("WisselBeurt", 0.1f);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject.Find("JetSpawn").GetComponent<JetSpawn>().JetSpawnTimer();
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (bulletPower > 9)
                {
                    bulletPower = bulletPower - 0.5f;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (bulletPower < 20)
                {

                    bulletPower = bulletPower + 0.5f;
                }
            }
        }
    }
    void WisselBeurt()
    {
        GameObject.Find("GameManager").GetComponent<TurnEngine>().WisselBeurt();
    }

    public void ZetActief(bool b)
    {
        if (b == true)
        {
            isAanDeBeurt = true;
        }
        else
        {
            isAanDeBeurt = false;
        }
    }
}
