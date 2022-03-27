using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helth : MonoBehaviour
{

    [SerializeField] private Image H0;
    [SerializeField] private Image H1;
    [SerializeField] private Image H2;


    private static int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = PlayerDie.count1;
        if(count == 1)
        {
            Destroy(H2);
        }
        else if(count == 2)
        {
            Destroy(H1);
            Destroy(H2);

        }
        else if(count == 3)
        {
            Destroy(H1);
            Destroy(H2);
            Destroy(H0);
        }
    }
}
