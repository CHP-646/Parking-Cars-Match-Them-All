using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform[] frontWheels;
    public Transform[] rearWheels;
    public WheelCollider[] wheelColliders;
    public float speed = 5f;
    public string obstacleTag = "Obstacle";
    public bool isMoving = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private int currentWaypointIndex = 0;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 360f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            for (int i = 0; i < wheelColliders.Length; i++)
            {
                WheelHit hit;
                Vector3 wheelPosition;
                Quaternion wheelRotation;

                if (wheelColliders[i].GetGroundHit(out hit))
                {
                    wheelPosition = hit.point + (wheelColliders[i].transform.up * wheelColliders[i].radius);
                    wheelRotation = wheelColliders[i].transform.rotation; // Use the rotation of the wheel collider
                }
                else
                {
                    wheelPosition = wheelColliders[i].transform.position;
                    wheelRotation = wheelColliders[i].transform.rotation;
                }

                if (i < frontWheels.Length)
                {
                    frontWheels[i].position = wheelPosition;
                    frontWheels[i].rotation = wheelRotation;
                }
                else
                {
                    rearWheels[i - frontWheels.Length].position = wheelPosition;
                    rearWheels[i - frontWheels.Length].rotation = wheelRotation;
                }
            }

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                if (currentWaypointIndex < waypoints.Length - 1)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    isMoving = false;
                }
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            ResetCarPosition();
        }
    }

    void ResetCarPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset velocity
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset angular velocity
        isMoving = false;
        currentWaypointIndex = 0;
    }
}
