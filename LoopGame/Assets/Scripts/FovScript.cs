using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FovScript : MonoBehaviour
{
    public float fovAngle = 90f;
    public Transform fovPoint;
    public float range = 8;

    public UnityEvent caught = null;

    public Transform target;

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
        RaycastHit2D r = Physics2D.Raycast(fovPoint.position, dir, range);



        if (angle < (fovAngle / 2))
        {
            if (r)
            {
                Debug.DrawRay(fovPoint.position, dir * range, Color.red);

                //if (r.collider.CompareTag("Player"))
                //{
                    caught.Invoke();
                 //   print("seen");
                //}
                //else
                //{
                 //   print("Not the player, tag is: " + r.collider.name);
                //}
            }
                
            

            else
            {
                print("Not seen");
            }
        }
    }
}
