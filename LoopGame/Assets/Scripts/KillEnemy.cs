using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillEnemy : MonoBehaviour
{


    public UnityEvent inSpot = null;
    public UnityEvent leftSpot = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D killColider)
    {
        if (killColider.CompareTag("KillSpot"))
        {
            inSpot.Invoke();
            print("killspot");
        }
    }
    private void OnTriggerExit2D(Collider2D killColider)
    {
        if (killColider.CompareTag("KillSpot"))
        {
            leftSpot.Invoke();
            print("nvm");
        }
    }
    
    
    
}
