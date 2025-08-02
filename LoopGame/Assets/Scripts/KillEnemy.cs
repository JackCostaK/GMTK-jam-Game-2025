using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillEnemy : MonoBehaviour
{


    public UnityEvent inSpot = null;
    public UnityEvent leftSpot = null;
    public UnityEvent explode = null;

    private bool canKill = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (canKill)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                explode.Invoke();
            }
            
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D killColider)
    {
        if (killColider.CompareTag("Player"))
        {
            print("hey");
            inSpot.Invoke();
            canKill = true;
        }
        else
        {
            print(killColider.tag);
        }
    }
    private void OnTriggerExit2D(Collider2D killColider)
    {
        if (killColider.CompareTag("Player"))
        {
            leftSpot.Invoke();
            canKill = false;
        }
    }
    
    
    
}
