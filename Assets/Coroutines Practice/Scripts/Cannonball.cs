using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    private Rigidbody ballRb;
    public float upForce;
    public float outForce;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddRelativeForce(Vector3.up * upForce, ForceMode.Impulse);
        ballRb.AddRelativeForce(Vector3.forward * outForce, ForceMode.Impulse);
        Invoke("BallIsLife", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BallIsLife()
    {
        Destroy(gameObject);
    }
}
