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


    // Start is called before the first frame update
    void Start()
    {

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
            
            Rigidbody2D rbToMove = objectToMove.GetComponent<Rigidbody2D>();
            if (rbToMove != null)
            {
                rbToMove.simulated = false; 
            }
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
        Instantiate(DestroyEffect, item.transform.position, Quaternion.identity);
        Destroy(item);
    }
}
