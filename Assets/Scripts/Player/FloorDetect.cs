using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetect : MonoBehaviour 
{
    [SerializeField] public LayerMask playerLayerMask;
    public bool isGrounded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckLayerInMask(playerLayerMask, other.gameObject.layer))
        {
            
            isGrounded = true;
        }
    }
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
