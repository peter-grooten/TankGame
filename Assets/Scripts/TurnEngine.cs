using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEngine : MonoBehaviour
{
    private int spelerBeurt = 1;
    public GameObject Speler1;
    public GameObject Speler2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spelers = GameObject.FindGameObjectsWithTag("Speler");
        foreach (GameObject g in spelers)
        {
            if (g.GetComponent<TankController>().spelerNummer == 1)
            {
                Speler1 = g;
            }
            else if (g.GetComponent<TankController>().spelerNummer == 2)
            {
                Speler2 = g;
            }
        }
        // de speler die aan de beurt is actief maken.
        Invoke("Init", 0.1f);

    }
    void Init()
    {
        if (spelerBeurt == 1)
        {
            Debug.Log("Speler1actief");
            // Maak speler 1 actief
            Speler1.GetComponent<TankController>().ZetActief(true);
            Speler2.GetComponent<TankController>().ZetActief(false);
        }
        else if (spelerBeurt == 2)
        {
            Debug.Log("Speler2actief");
            // Maak speler 2 actief
            Speler1.GetComponent<TankController>().ZetActief(false);
            Speler2.GetComponent<TankController>().ZetActief(true);
        }
    }

    public void WisselBeurt()
    {
        if (spelerBeurt == 1)
        {
            Debug.Log("Speler2 is aan de beurt");
            spelerBeurt = 2;
            Speler1.GetComponent<TankController>().ZetActief(false);
            Speler2.GetComponent<TankController>().ZetActief(true);
        }
        else if (spelerBeurt == 2)
        {
            Debug.Log("Speler1 is aan de beurt");
            spelerBeurt = 1;
            Speler1.GetComponent<TankController>().ZetActief(true);
            Speler2.GetComponent<TankController>().ZetActief(false);
        }
    }

}