using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private float initialForce = 10.0f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bullet;


    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(Vector3.right * initialForce * Time.deltaTime, ForceMode2D.Impulse); 
    }
    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        if (FloorDetect.CheckLayerInMask(enemyMask, other.gameObject.layer))
        {
            Debug.Log("Hit enemy");
            Destroy(bullet);
            
            
        }
    }
}
