using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NextTruck : MonoBehaviour
{
    public Transform target;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);
            }
        }
        float distance = Vector3.Distance(transform.position, target.position);
        {
            if(distance<0.01f)
            {
                Truck truck= GetComponent<Truck>();
                if (truck != null)
                {
                    if(truck.nexttruck!= null)
                        truck.Nexttruck();


                }

            }
        }
    }
}
