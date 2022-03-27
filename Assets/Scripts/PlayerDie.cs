using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator mator;

    public static int count1 = 0;

    [SerializeField] private AudioSource DieSound;

    void Start()
    {
        mator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.CompareTag("fire") || collision.gameObject.CompareTag("Hidden"))
        {
           Die(); 
        }

        
    }

    private void Die()
    {
        count1++;
        mator.SetTrigger("die");
        rbody.bodyType = RigidbodyType2D.Static;
        DieSound.Play();
        DieCount();
        Debug.Log("..................................................................qqqqqqqqqqqqqqqqqqqqq"+count1);
    }
    public int DieCount()
    {
        if(count1>2)
        {
            count1 = 0; 
            SceneManager.LoadScene("Quit_Retry"); 
            Debug.Log(".................................................................."+count1); 
        }
        return count1;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }

    
}
