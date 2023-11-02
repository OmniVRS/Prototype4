using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{

    public GameObject cannonball;
    public GameObject ballSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           StartCoroutine(Shoot(10));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Shoot(Random.Range(10, 100)));
        }
    }

    IEnumerator Shoot(int numberOfBalls)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(cannonball, ballSpawn.transform.position, ballSpawn.transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
