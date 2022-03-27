using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private bool levelCompleted = false;

    [SerializeField] private AudioSource finishSound;

    // Start is called before the first frame update
    void Start()
    {
        //finishSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("End_Screen");
    }
}
