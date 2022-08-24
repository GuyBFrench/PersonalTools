using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float jump = 400.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private SpawnManager spawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(JumpLogic());
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnManager.gameActive)
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(playerDirection * speed); 
        }
        

        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator JumpLogic()
    {
        float minWaitTime = 5;
        float maxWaitTime = 10;

        while (spawnManager.gameActive)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            if (spawnManager.gameActive == true)
            {
                enemyRb.AddForce(0,jump,0);
            }
            
        }
    }
}
