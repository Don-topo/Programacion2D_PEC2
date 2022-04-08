using UnityEngine;

public class CoinController : MonoBehaviour
{

    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameManager.PickUpCoin(coinValue);
            Destroy(gameObject);           
        }
    }
}
