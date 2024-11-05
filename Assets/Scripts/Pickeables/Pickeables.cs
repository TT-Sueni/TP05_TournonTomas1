using UnityEngine;

public class Pickeables : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip SfxPick;

    GameManager gameManager;
    

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FloorDetect.CheckLayerInMask(playerMask, collision.gameObject.layer))
        {
            //gameManager.moneyCounter++;
            AudioSource.clip = SfxPick;
            AudioSource.Play();

            Destroy(gameObject);
            //Debug.Log(gameManager.moneyCounter);
        }
         
    }
    
}
