using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform HoldSpot;
    public LayerMask PickUpMask;
    public Vector3 Direction {get; set;}
    public GameObject DestroyEffect;
    private GameObject itemHolding;
    public FollowThePath pathfollow;
    public Vector3 targetPosition;
    public GameObject objectToMove; 

    public float timerDuration = 7f; 
    private float timeRemaining;
    private bool timerIsActive = false;
    private Vector3 originalPositionOfObjectToMove;

    void Start()
    {
    if (objectToMove != null)
    {
        originalPositionOfObjectToMove = objectToMove.transform.position;
    }
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if(itemHolding. GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }
            else
            {
                Collider2D PickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, PickUpMask);
                if(PickUpItem)
                {
                    itemHolding = PickUpItem.gameObject;
                    itemHolding.transform.position = HoldSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }

        if (timerIsActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // Timer has expired, move the object back
                if (objectToMove != null)
                {
                    objectToMove.transform.position = originalPositionOfObjectToMove;
                    Debug.Log("Object has returned to its original position.");
                }
                timerIsActive = false;
            }
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 StartPoint = item.transform.position;
        Vector3 EndPoint = transform.position + Direction * 8;
        item.transform.parent = null;
        for (int i =0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(StartPoint, EndPoint, i * .04f);
            yield return null;
        }
        if (objectToMove != null)
        {
            objectToMove.transform.position = EndPoint;
            
            // Start the timer to move it back after a duration
            timerIsActive = true;
            timeRemaining = timerDuration;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
        Instantiate(DestroyEffect, item.transform.position, Quaternion.identity);
        Destroy(item);
    }
}
