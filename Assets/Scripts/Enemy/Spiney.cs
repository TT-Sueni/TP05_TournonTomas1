//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.U2D;

//public class Spiney : MonoBehaviour
//{
//    public Rigidbody2D rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        looptime += Time.deltaTime;
//        if (looptime < 6)
//        {
//            spiney.rb.AddForce(Vector2.left * loopSpeed * Time.deltaTime, ForceMode2D.Impulse);
//        }
//        else if (looptime <= 7)
//        {
//            spiney.rb.AddForce(Vector2.right * loopSpeed * Time.deltaTime, ForceMode2D.Impulse);

//            if (looptime == 13)
//            {
//                looptime = 0;
//            }
//        }
//    }
//}
