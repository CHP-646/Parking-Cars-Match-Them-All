using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmptySlots : MonoBehaviour
{
    private NavMeshObstacle novobl;
    // Start is called before the first frame update
    void Start()
    {
        novobl= GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exited");
            other.gameObject.tag = "PlacedinEmpty";
           //novobl.enabled= false;
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("PlacedinEmpty"))
    //    {
    //        Debug.Log("Exited");
    //       //gameObject.tag = "EmptySlots";
    //        //novobl.enabled = true;
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlacedinEmpty"))
        {
            Debug.Log("Exited");
           // gameObject.tag = "EmptySlots";
          //novobl.enabled = true;
        }
    }
}
