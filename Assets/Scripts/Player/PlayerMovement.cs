using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [Header("Parametros")]
    [SerializeField] float speed = 1.0f;
    public float jumpForce = 10;



    [Header("Movimiento")]

    [SerializeField] private KeyCode keyLeft = KeyCode.A;
    [SerializeField] private KeyCode keyRight = KeyCode.D;
    [SerializeField] private KeyCode shoot = KeyCode.R;
    [SerializeField] private KeyCode jump = KeyCode.W;
    [SerializeField] private Animator animator;
    [SerializeField] SpriteRenderer spriteRendererCY;
    //public bool flip = false;

    [Header("Objetos")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask playerMask;

    [SerializeField] FloorDetect floorDetect;
    [Header("Audio")]
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxJump;
    [SerializeField] AudioClip SfxShoot;




    private Rigidbody2D rb;
    private GameObject shot;
    //float maxspeed = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRendererCY = GetComponent<SpriteRenderer>();



    }

    void Update()
    {
        Movevement();
        Animations();
    }


    private void Movevement()
    {
        if (Input.GetKeyDown(jump) && floorDetect.isGrounded)
        {
            AudioSource.clip = SfxJump;
            AudioSource.Play();
            floorDetect.isGrounded = false;



            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
        if (Input.GetKey(keyLeft))
        {

            rb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode2D.Impulse);
           // spriteRendererCY.flipX = true;


        }
        else if (Input.GetKeyUp(keyLeft))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKey(keyRight))
        {
            //spriteRendererCY.flipX = false;


            rb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            //SpeedLimit();
        }
        else if (Input.GetKeyUp(keyRight))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(shoot))
        {
            AudioSource.clip = SfxShoot;
            AudioSource.Play();
            shot = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            //animator.SetTrigger("Shoot");
        }

    }

    private void Animations()
    {

        if (Input.GetKey(keyLeft) || Input.GetKey(keyRight))
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

    }

    private void OnTriggerEnter2D(Collider2D other) // cuando toca un enemigo, insertar danio
    {
        if (FloorDetect.CheckLayerInMask(enemyMask, other.gameObject.layer))
        {
            Debug.Log("Hit");

        }

    }


    /*private void SpeedLimit()
    {
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = Vector3.Normalize(rb.velocity)*maxspeed;
        }
        else if (rb.velocity.magnitude < maxspeed)
        {
            rb.velocity = Vector3.Normalize(rb.velocity) * -maxspeed;
        }
    }*/
}




