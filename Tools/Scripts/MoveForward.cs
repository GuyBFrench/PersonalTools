using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private Rigidbody arrowRb;
    private GameObject player;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        arrowRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        // Vector3 awayDirection = (transform.position - player.transform.position).normalized;
        // arrowRb.AddForce(awayDirection * speed);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy1"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawnManager.KilledScore(1);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawnManager.KilledScore(2);
        }
    }
}
