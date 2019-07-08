using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float force;
    public float rotationValue;
    private Rigidbody rg;

    public delegate void SendEvents();
    public static event SendEvents onNormalEnemyMovement;
    public static event SendEvents onReverseEnemyMovement;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rg.AddForce(transform.forward * force * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationValue * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rg.AddForce(-transform.forward * force * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationValue * Time.deltaTime, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NormalMovement" && onNormalEnemyMovement != null)
            onNormalEnemyMovement();

        if (other.tag == "ReverseMovement" && onReverseEnemyMovement != null)
            onReverseEnemyMovement();
    }
}
