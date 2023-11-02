using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    public bool hasPowerUp = false;
    private float powerupStrength = 15.0f;
    //public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 attackDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(attackDirection * speed);
        //powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            //hasPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log($"Enemy stole powerup!");
            //powerupIndicator.gameObject.SetActive(true);
            //StartCoroutine(PowerupTimer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasPowerUp)
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = (collision.gameObject.transform.position - transform.position);
            playerRb.AddForce(awayFromEnemy * powerupStrength, ForceMode.Impulse);
            Debug.Log("Enemy Super Hit!");
        }
    }

    IEnumerator PowerupTimer()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        Debug.Log("Powerup has ended");
    }
}
