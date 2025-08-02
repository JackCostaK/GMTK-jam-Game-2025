using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{
    public UnityEvent levelComplete = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D killColider)
    {
        if (killColider.CompareTag("Player"))
        {
            levelComplete.Invoke();
        }
    }
}
