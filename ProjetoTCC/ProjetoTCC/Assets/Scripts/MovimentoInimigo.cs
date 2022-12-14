using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    bool isAlive = true;
    public float distance;
    public GameObject municao;
    public Transform SpawnMunicao;

    public Transform playerTransform;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    
        
        Ataque();
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("municao"))
        {
            isAlive = false;
            Destroy(gameObject);
        }
        
    }

    public void Ataque()
    {
        distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < 1f)
        {
            speed = 0.2f;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else
        {
            speed = 0;
        }
  

    }

    void Shoot()
    {
        Instantiate(municao, SpawnMunicao.position, transform.rotation);
    }

    



}
