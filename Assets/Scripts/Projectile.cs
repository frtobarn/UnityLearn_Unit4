using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private GameObject player;
    private GameObject enemy;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;
        transform.position += enemyDirection * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(collision.gameObject);
        }
    }
}
