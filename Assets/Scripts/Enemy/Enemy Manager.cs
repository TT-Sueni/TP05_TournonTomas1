using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private Image enemyLife;
    [SerializeField] private ParticleSystem enemyParticle;
    [SerializeField] private LayerMask bulletMask;
    Rigidbody2D rb;
    Vector2 loopRight = new Vector2(1,0);
    Vector2 loopLeft = new Vector2(-1, 0);
    float looptime;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxEnemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        looptime = 0;
    }

    void Update()
    {
        looptime += Time.deltaTime;
        if (looptime < 2)
        {
            rb.velocity = loopRight;
        }
        else if (looptime >= 3)
        {
            
            rb.velocity = loopLeft;
            //rb.AddForce(Vector3.right * loopSpeed * Time.deltaTime, ForceMode2D.Force);

            if (looptime >= 6)
            {
                
                looptime = 0;
            }
        }
        if (enemyLife.fillAmount <= 0)
        {
            Destroy(enemy);
            Instantiate(enemyParticle, transform.position, quaternion.identity);
            enemyParticle.Play();
            AudioSource.clip = SfxEnemy;
            AudioSource.Play();

        }

    }
    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        if (FloorDetect.CheckLayerInMask(bulletMask, other.gameObject.layer))
        {
            

            enemyLife.fillAmount -= 0.25f;

        }
    }
}
