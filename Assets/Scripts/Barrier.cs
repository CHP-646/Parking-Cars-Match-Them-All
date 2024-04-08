using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.tag=="BlockCar")
        //{
        //    other.gameObject.tag = "Player";
        //}
        if(other.gameObject.CompareTag("Player"))
        {
            Car car = other.GetComponent<Car>();
            
            car.navemsh();
            
        }
    }
}
