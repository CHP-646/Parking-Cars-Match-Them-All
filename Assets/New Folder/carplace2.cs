using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carplace2 : MonoBehaviour
{
    public List<GameObject> objectsToEnable;
    private int currentIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car3"))
        {
            Destroy(other.gameObject);


            if (currentIndex < objectsToEnable.Count)
            {
                GameObject objectToEnable = objectsToEnable[currentIndex];


                if (objectToEnable != null && !objectToEnable.activeSelf)
                {
                    objectToEnable.SetActive(true);
                }

                currentIndex++;
            }
        }
    }
}

