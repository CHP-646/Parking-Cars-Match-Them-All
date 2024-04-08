using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastTruck : MonoBehaviour
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
        if(canMove)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);
            }
        }
        
    }
}
