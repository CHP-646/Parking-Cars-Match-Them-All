using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
public class Car : MonoBehaviour
{
    public NavMeshAgent navmesh;
    private Transform targetlocation;
    public int speed;
    public bool canMove=false;
    public string trucktags;
    public float distance;
    public Rigidbody rb;
    public bool isPressed = false;
    public float rayCastDistance =0.3f;
    public bool canMoveWhenNoObstcle;//  private NavMeshObstacle navOb;
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
       // navOb= GetComponent<NavMeshObstacle>();
       // navOb.enabled= false;
        navmesh.enabled = false;
        rb= GetComponent<Rigidbody>();
        canMoveWhenNoObstcle = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
   //   Debug.DrawLine(transform.position + new Vector3(0, 0.25f, 0), Vector3.forward * 0.8f, Color.green);
        if (Physics.Raycast(transform.position+new Vector3(0,0.25f,0), transform.forward, out hit, 0.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
               
               canMoveWhenNoObstcle = false;

                NavMeshObstacle navob = targetlocation.GetComponent<NavMeshObstacle>();
                if (navob != null)
                {
                    //if (targetlocation.tag == "Untagged")
                    //{
                    //    targetlocation.tag = "EmptySlots";
                    //}
                }
                isPressed = false;
                canMove = false;
            }
            else
            {
                gameObject.tag = "Player";
            }
        }

        if (canMove)
        {
            
           transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        

        if (navmesh.enabled)
        {
            if (targetlocation != null)
            {
                navmesh.SetDestination(targetlocation.position);
               // targetlocation.tag = "Untagged";
            }
            
                distance = Vector3.Distance(transform.position, targetlocation.position);
            

            if (distance<0.1f)
            {
                Debug.Log("targeted");
                rb.isKinematic= true;
                navmesh.enabled = false;
                transform.localEulerAngles = new Vector3(0,0,0);
                targetlocation.tag = "Untagged";
                NavMeshObstacle navob=targetlocation.GetComponent<NavMeshObstacle>();
                navob.enabled = true;
            }
            
        }
        if (gameObject.tag == "PlacedinEmpty")
        {
            
            GameObject truck = GameObject.FindGameObjectWithTag(trucktags);
            if (truck != null)
            {
                navemsh();

                NavMeshObstacle navob = targetlocation.GetComponent<NavMeshObstacle>();
                navob.enabled = false;
                targetlocation = truck.transform;
               
            }
           
           
        }
      

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position+new Vector3(0, 0.25f, 0), transform.forward*0.5f);
    }
    public void OnMouseDown()
    {
        if(!isPressed)
        {
            canMove = true;
            isPressed = true;
            if (canMoveWhenNoObstcle)
                {

                   
                    GameObject[] emptySlots = GameObject.FindGameObjectsWithTag("EmptySlots");

                    if (emptySlots != null && emptySlots.Length > 0)
                    {
                        targetlocation = emptySlots[0].transform;
                        GameObject truck = GameObject.FindGameObjectWithTag(trucktags);
                        if (truck == null)
                        {
                            emptySlots[0].tag = "Untagged";
                        NavMeshObstacle navob = emptySlots[0].GetComponent<NavMeshObstacle>(); navob.enabled = false;
                        }


                        //NavMeshObstacle navob = targetlocation.GetComponent<NavMeshObstacle>();

                        //navob.enabled = false;


                    }

                } 

        }
    }
    public void navemsh()
    {
        if (navmesh != null)
        {
            Debug.Log(gameObject.name);
            canMove= false;
            navmesh.enabled = true;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("BlockCar"))
    //    {
    //        Debug.Log("ak");
    //        isPressed = false;
    //        canMoveWhenNoObstcle = false;
    //        canMove = false;
    //    }
    //}


}
