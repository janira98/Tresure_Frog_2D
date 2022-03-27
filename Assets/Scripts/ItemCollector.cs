using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] private Text CoinCount;
    [SerializeField] private AudioSource collectSound;
    private int coins = 0;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            CoinCount.text = "Coins : "+coins;
            collectSound.Play();
        }
    }
}
