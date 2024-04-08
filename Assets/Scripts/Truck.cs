using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class Truck : MonoBehaviour
{
    public GameObject[] cars;
    [SerializeField] int currentIndex = 0;
    public GameObject nexttruck;
    public GameObject[] targets;
    public int targetCountrer;
    public ParticleSystem[] particle;
    public GameObject WinPanel;
    public string truckTagToChabge;


   // public Car car;
    // Start is called before the first frame update
    void Start()
    {
        if(WinPanel!=null)
        {
            WinPanel.SetActive(false);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if(targetCountrer == targets.Length)
        {
            
            StartCoroutine(moveTruck());
            if(nexttruck != null)
            {
                StartCoroutine(ChanegTag());
               
            }
            
            Destroy(gameObject, 2f);
        }
        
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        //if (currentIndex < cars.Length)
        //{
        //    GameObject objectToEnable = cars[currentIndex];

        //    if (objectToEnable != null && !objectToEnable.activeSelf)
        //    {
        //        objectToEnable.SetActive(true);
        //    }

        //    currentIndex++;
        //}
        if (other.gameObject.CompareTag("PlacedinEmpty"))
        {
            other.gameObject.tag = "Player";
           

        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CArCame");
           //gameObject.tag = "BlueTruck";
            NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
            nav.enabled = false;
             StartCoroutine(MoveVehicleUp(other.transform));


        }
    }
    public void Nexttruck()
    {
        NextTruck nextTruck = nexttruck.GetComponent<NextTruck>();
        if(nextTruck != null)
        {
            nextTruck.canMove = true;
        }
        
    }
   IEnumerator ChanegTag()
    {
       

        yield return new WaitForSeconds(1.0f);
        NextTruck nextTruck = nexttruck.GetComponent<NextTruck>();
        if(nextTruck != null )
        {
            nextTruck.canMove = true;
        }
        LastTruck last = nexttruck.GetComponent<LastTruck>();
        if(last != null)
        {
            NextTruck nExtTruck = nexttruck.GetComponent<NextTruck>();
            if(nExtTruck!=null)
            {
                nExtTruck.enabled= false;
                last.canMove= true;
            }
        }
            
        
        Debug.Log("changed");
        if(truckTagToChabge!= null)
        {
            nexttruck.tag = truckTagToChabge;
        }
        
    }
    IEnumerator MoveVehicleUp(Transform car)
    {
        Transform target = targets[targetCountrer++].transform;
        car.SetParent(transform);
        while (Vector3.Distance(car.position, target.transform.position)>0.1f)
            {
                Vector3 dir = target.transform.position - car.position;
                Quaternion rotation = Quaternion.LookRotation(dir);
                car.rotation = rotation;
                car.Translate(Vector3.forward  *5* Time.deltaTime);
                yield return null;
            }
    }
    IEnumerator moveTruck()
    {
        yield return new WaitForSeconds(1.0f);
        foreach(ParticleSystem ps in particle)
        {
            if(!ps.isPlaying)
            {
                ps.Play();
            }
        }
        transform.Translate(Vector3.forward * 12* Time.deltaTime);
      // yield return new WaitForSeconds(1.0f);
        if(WinPanel!=null)
        {
            WinPanel.SetActive(true);
        }
         
    }
    
}

