using UnityEngine;

public class TruckTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject has the tag "Truck"
        if (other.CompareTag("Truck"))
        {
            Debug.Log("Truck detected!");
        }
        else
        {
            Debug.Log("Other object entered the trigger, but it's not a truck.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: You can add logic here if you want to do something when the truck exits the trigger
    }
}
